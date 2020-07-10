using Gluon.PascalTreeNodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gluon
{
    public static class PascalTreeQueries
    {
        public static IEnumerable<T> GetAllNodes<T>(this PascalTree tree) where T : INode
        {
            foreach (var child in tree.ForwardTraversal)
                if (child is T)
                    yield return (T)child;
        }

        public static IEnumerable<AST.Type> GetAllReferencedTypes(this PascalTree tree)
        {
            return GetAllNodes<TypeRefNode>(tree).Select(n => n.Type).Distinct();
        }

        public static IEnumerable<AST.Namespace> GetAllReferencedNamespaces(this PascalTree tree)
        {
            return GetAllNodes<TypeRefNode>(tree).Select(n => n.Type.Namespace).Distinct();
        }

        public static IEnumerable<AST.Namespace> GetAllExternalReferencedNamespaces(this PascalTree tree)
        {
            List<AST.Namespace> refs = new List<AST.Namespace>();
            Action<INode,AST.Namespace> recurse = null;
            recurse = (node, currentNS) =>
            {
                var tn = node as TypeRefNode;
                var nsn = node as NamespaceNode;
                var bn = node as PascalTree;

                if(tn != null && !tn.Type.Namespace.IsWithin(currentNS))
                    refs.Add(tn.Type.Namespace);

                if (nsn != null)
                    currentNS = nsn.Namespace;

                if (bn != null)
                {
                    foreach (var child in bn.Children)
                        recurse(child, currentNS);
                }
            };

            recurse(tree, null);
            return refs.Distinct();
        }
    }
}
