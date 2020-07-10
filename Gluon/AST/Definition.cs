using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Gluon.AST
{
    public class Definition : Node
    {
        public Assembly Assembly { get; private set; } = new Assembly() { IsBuildSource = true };
        public List<Assembly> DependentAssemblies { get; private set; } = new List<Assembly>();
        public List<Namespace> DependentNamespaces { get; private set; } = new List<Namespace>();
        public List<Type> AllTypes { get; private set; } = new List<Type>();

        public List<NativeMappedType> NativeMappedTypes { get; private set; } = new List<NativeMappedType>();
        public List<SubstituteType> SubstituteTypes { get; private set; } = new List<SubstituteType>();
        public List<SubstituteNamespace> SubstituteNamespaces { get; private set; } = new List<SubstituteNamespace>();

        public Definition() : base(Construct.Definition)
        {
            DependentAssemblies.Add(BasicTypes.SystemAssembly);
            DependentNamespaces.Add(BasicTypes.SystemNamespace);
        }

        public Namespace LookupNamespace(string name)
        {
            return LookupNamespace(name.Split(new char[] { '.', ':' }, StringSplitOptions.RemoveEmptyEntries));
        }

        public Namespace LookupNamespace(string[] sequence)
        {
            if (sequence == null || sequence.Length == 0 || string.IsNullOrEmpty(sequence[0]))
                return BasicTypes.GlobalNamespace;

            string search = sequence.Last();

            foreach (var ns in DependentNamespaces)
            {
                if(ns.Name == search)
                {
                    bool match = true;
                    Namespace parent = ns.Parent;
                    for(int i = sequence.Length - 2; i >= 0;i--)
                    {
                        if (parent == null || parent.Name != sequence[i])
                        {
                            match = false;
                            break;
                        }
                        parent = parent.Parent;
                    }

                    if (match) return ns;
                }
            }

            return null;
        }
        public void Prepare()
        {
            Analyze();
        }

        public override void Analyze()
        {
            base.Analyze();

            if (!Assembly.IsGluonDefinition)
                Errors.Generic("Input assembly does not have the [GluonLibraryDefinition] attribute");

            Assembly.Analyze();

            foreach (var a in DependentAssemblies)
                a.Analyze();

            foreach (var n in DependentNamespaces)
                n.Analyze();

            foreach (var t in AllTypes)
                t.Analyze();
        }

        public override IEnumerable<Node> Declarations
        {
            get
            {
                return Many(
                    base.Declarations,
                    Assembly.Declarations,
                    DependentAssemblies.SelectMany(a => a.Declarations),
                    DependentNamespaces.SelectMany(n => n.Declarations),
                    AllTypes.SelectMany(t => t.Declarations));
            }
        }

        /// <summary>
        /// Find an existing AST type equivalent to the given system type.
        /// If AST type names are modified, only basic types will continue to successfully resolve.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public Type LookupType(System.Type type)
        {
            type = U.Deref(type);

            var ret = BasicTypes.Of(type);

            if (ret != null)
                return ret;

            var ns = LookupNamespace(type.Namespace);
            if (ns != null)
                ret = AllTypes.FirstOrDefault(t => t.Namespace == ns && t.Name == type.Name);

            return null;
        }

        public Type LookupType(string fullName)
        {
            var split = fullName.Split(new char[] { '.', ':' }, StringSplitOptions.RemoveEmptyEntries);

            if (split.Length == 0)
                return null;
            else if (split.Length == 1)
                return AllTypes.FirstOrDefault(t => t.Namespace == BasicTypes.GlobalNamespace && t.Name == fullName);
            else
            {
                var typeName = split.Last();
                var ns = LookupNamespace(split.Take(split.Length - 1).ToArray());

                if (ns == null)
                    return null;
                else
                    return AllTypes.FirstOrDefault(t => t.Namespace == ns && t.Name == typeName);
            }
        }
    }
}
