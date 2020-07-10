using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gluon
{
    public static class ASTMutations
    {
        public static void SubstituteType(this AST.Definition def, AST.Type oldType, AST.Type newType)
        {
            foreach (var variable in def.Declarations.OfType<AST.IVariable>().Where(v => v.Type == oldType))
                variable.Type = newType;
        }

        public static void StripAllAttributes(this AST.Definition def)
        {
            foreach (var thing in def.Declarations.OfType<AST.IHasAttributes>())
                thing.Attributes.Clear();

            var attrTypes = def.AllTypes.Where(t => t.IsAttribute).ToArray();

            foreach (var attr in attrTypes)
                def.AllTypes.Remove(attr);
        }

        public static void StripAllGluonAttributes(this AST.Definition def)
        {
            var gluonNS = def.DependentNamespaces.FirstOrDefault(ns => ns.Name == "Gluon");

            if (gluonNS == null)
                return;

            foreach (var thing in def.Declarations.OfType<AST.IHasAttributes>())
            {
                var toRemove = thing.Attributes.Where(a => a.Type.Namespace == gluonNS).ToArray();

                foreach (var attr in toRemove)
                    thing.Attributes.Remove(attr);
            }
        }

        public static void StripUnreferencedTypes(this AST.Definition def, TypeOrigin includeOrigin)
        {
            var unref = new HashSet<AST.Type>();

            foreach (var type in def.AllTypes.Where(t => t.ConstructType == AST.Construct.Object ||
                                                         t.ConstructType == AST.Construct.Struct ||
                                                         t.ConstructType == AST.Construct.Enum))
                unref.Add(type);

            foreach (var rootType in def.AllTypes.SelectGeneratedTypes(includeOrigin))
            {
                if(unref.Contains(rootType))
                    unref.Remove(rootType);

                foreach(var refType in rootType.SelectReferencedTypes())
                {
                    if (unref.Contains(refType))
                        unref.Remove(refType);
                }
            }

            foreach (var t in unref)
                def.AllTypes.Remove(t);
        }

        public static void StripEmptyNamespaces(this AST.Definition def)
        {
            HashSet<AST.Namespace> used = new HashSet<AST.Namespace>();

            foreach (var t in def.AllTypes)
                for (var ns = t.Namespace; ns != null; ns = ns.Parent)
                    if (!used.Contains(ns))
                        used.Add(ns);

            def.DependentNamespaces.Clear();
            foreach (var ns in used)
                def.DependentNamespaces.Add(ns);
        }

        public static void ApplyNativeMappedTypes(this AST.Definition def, string targetID)
        {
            foreach(var map in def.NativeMappedTypes)
            {
                if (!string.IsNullOrEmpty(map.TargetID) && map.TargetID != targetID)
                    continue;

                var targetType = def.LookupType(map.NativeType);

                //if(targetType != null)
                //{
                //    // TODO error if header/lib conflict
                //    targetType.CppHeader = map.NativeHeader;
                //    targetType.CppLib = map.NativeLibrary;
                //}
                //else
                {
                    string ns, typeName;
                    int delim = map.NativeType.LastIndexOfAny(new char[] { '.', ':' });
                    if(delim == -1)
                    {
                        ns = null;
                        typeName = map.NativeType;
                    }
                    else
                    {
                        typeName = map.NativeType.Substring(delim + 1);
                        if (map.NativeType[delim] == '.')
                            ns = map.NativeType.Substring(0, delim);
                        else
                            ns = map.NativeType.Substring(0, delim - 1);
                    }

                    if (ns == null)
                        map.ManagedType.Namespace = BasicTypes.GlobalNamespace;
                    else
                        map.ManagedType.Namespace = def.LookupNamespace(ns);

                    map.ManagedType.Name = typeName;
                    map.ManagedType.Origin = TypeOrigin.Native;
                    map.ManagedType.CppHeader = map.NativeHeader;
                    map.ManagedType.CppLib = map.NativeLibrary;

                }
            }

            def.NativeMappedTypes.Clear();
        }

        public static void ApplyTypeSubstitutions(this AST.Definition def, string targetID)
        {
            Dictionary<AST.Type, AST.Type> map = new Dictionary<AST.Type, AST.Type>();

            foreach (var sub in def.SubstituteTypes)
                if (sub.TargetType != null && (string.IsNullOrEmpty(sub.TargetID) || sub.TargetID == targetID))
                    map[sub.OriginalType] = sub.TargetType;

            foreach(var sub in map)
            {
                var target = sub.Value;

                while (map.ContainsKey(target))
                    target = map[target];

                foreach(var variable in def.Declarations.OfType<AST.IVariable>().Where(v => v.Type == sub.Key))
                    variable.Type = target;
            }
        }

        public static void ApplyNamespaceSubsitutions(this AST.Definition def, string targetID)
        {
            Dictionary<AST.Namespace, AST.Namespace> map = new Dictionary<AST.Namespace, AST.Namespace>();

            foreach (var sub in def.SubstituteNamespaces)
                if (sub.ToNamespace != null && (string.IsNullOrEmpty(sub.TargetID) || sub.TargetID == targetID))
                    map[sub.FromNamespace] = sub.ToNamespace;

            foreach (var sub in map)
            {
                var target = sub.Value;

                while (map.ContainsKey(target))
                    target = map[target];

                foreach (var type in def.AllTypes.Where(t => t.Namespace == sub.Key))
                    type.Namespace = target;
            }
        }

        public static void RenameParametersToClarifyContext(this AST.Definition def, TypeOrigin includeOrigin = TypeOrigin.Gluon)
        {
            foreach(var t in def.AllTypes.SelectGeneratedTypes(includeOrigin).OfType<AST.Object>())
            {
                foreach(var c in t.Constructors)
                    foreach(var p in c.Parameters)
                    {
                        if (p.IsOut)
                            p.Name = "out" + p.Name.Capitalize();
                        else if (p.IsRef)
                            p.Name = "inout" + p.Name.Capitalize();
                    }

                foreach (var m in t.Methods)
                    foreach (var p in m.Parameters)
                    {
                        if (p.IsOut)
                            p.Name = "out" + p.Name.Capitalize();
                        else if (p.IsRef)
                            p.Name = "inout" + p.Name.Capitalize();
                    }
            }
        }

        public static void PutDefaultConstructorsFirst(this AST.Definition def, TypeOrigin includedOrigin = TypeOrigin.Gluon)
        {
            foreach(var t in def.AllTypes.SelectGeneratedTypes(includedOrigin).OfType<AST.Object>())
            {
                var dc = t.Constructors.FirstOrDefault(c => c.Parameters.Count == 0);

                if (dc == null || t.Constructors[0] == dc)
                    continue;

                t.Constructors.Remove(dc);
                t.Constructors.Insert(0, dc);
            }
        }

        public static void InsertDefaultConstructorsWhereNoneAreDefined(this AST.Definition def, TypeOrigin includedOrigin = TypeOrigin.Gluon)
        {
            foreach(var t in def.AllTypes.SelectGeneratedTypes(includedOrigin).OfType<AST.Object>().Where(t => !t.IsAbstract && t.Constructors.Count == 0))
                t.Constructors.Add(new AST.Constructor
                {
                    Access = AST.Access.Public,
                    Name = t.Name,
                    Nature = AST.MemberNature.Instance,
                });
        }
    }
}
