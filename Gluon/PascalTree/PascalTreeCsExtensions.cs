using Gluon.AST;
using Gluon.PascalTreeNodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gluon.PascalTreeCsExtensions
{
    public static class PascalTreeCsQueries
    {
    }

    public class AttributeNode : INode, ITypedNode
    {
        public AST.Attribute Attribute { get; private set; }

        public AttributeNode(AST.Attribute attr)
        {
            Attribute = attr;
        }

        public IEnumerable<AST.Type> ReferencedTypes
        {
            get
            {
                foreach (var sub in Attribute.Type.SelectReferencedTypes())
                    yield return sub;

                // TODO Could the type of named/unnamed parameters cause problems?
            }
        }

        public void Resolve(PascalRender writer)
        {
            var cs = (CsRender)writer;

            cs.WriteAttribute(Attribute);
        }
    }
}
