using Gluon.PascalTreeNodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gluon.PascalTreeCppExtensions
{
    public static class CppTreeQueries
    {
        public static IEnumerable<IncludeNode> GetAllDependentHeaders(this PascalTree tree, params AST.Type[] localTypes)
        {
            List<IncludeNode> includes = new List<IncludeNode>();

            AST.Assembly localAssembly = null;

            if (localTypes.Length != 0)
                localAssembly = localTypes[0].Assembly;

            foreach(var t in tree.GetAllReferencedTypes())
            {
                if (localTypes.Contains(t)) continue;

                if (t.CppHeader != null)
                    includes.Add(new IncludeNode(t.CppHeader));
                else if (t.Assembly == localAssembly)
                    includes.Add(new IncludeNode(t.Name + ".h", true));
            }

            return includes.Distinct(new IncludeNodeComparer());
        }

        private class IncludeNodeComparer : IEqualityComparer<IncludeNode>
        {
            public bool Equals(IncludeNode x, IncludeNode y)
            {
                return x.IsLocal == y.IsLocal && x.Path.ToLower() == y.Path.ToLower();
            }

            public int GetHashCode(IncludeNode obj)
            {
                var hash = obj.Path.ToLower().GetHashCode();

                if (obj.IsLocal)
                    hash = ~hash;

                return hash;
            }
        }
    }

    public class IncludeBlock : PascalTree { }

    public class IncludeNode : INode
    {
        public string Path { get; set; }
        public bool IsLocal { get; set; }

        public IncludeNode(string path, bool isLocal = false) { Path = path; IsLocal = isLocal; }

        public void Resolve(PascalRender writer)
        {
            if(IsLocal)
                writer.Line("#include \"{0}\"", Path.Replace('\\', '/'));
            else
                writer.Line("#include <{0}>", Path.Replace('\\', '/'));
        }
    }

    public class LocalTranslationsBlock : PascalTree
    {
        public Dictionary<AST.Type, string> Translations { get; private set; }

        public LocalTranslationsBlock(Dictionary<AST.Type, string> translations)
        {
            Translations = translations;
        }

        public override void Resolve(PascalRender writer)
        {
            var cpp = (CppRender)writer;

            if (Translations != null)
                foreach (var kvp in Translations)
                    cpp.LocalTranslations[kvp.Key] = kvp.Value;

            base.Resolve(writer);

            cpp.LocalTranslations.Clear();
        }
    }

    public class LocalTranslationStateNode : INode
    {
        public bool UseLocalTranslations { get; private set; }

        public LocalTranslationStateNode(bool use) { UseLocalTranslations = use; }

        public void Resolve(PascalRender writer)
        {
            var cpp = (CppRender)writer;
            cpp.UseLocalTranslations = UseLocalTranslations;
        }
    }
}
