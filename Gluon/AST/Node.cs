using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Gluon.AST
{
    public abstract class Node
    {
        public Construct ConstructType { get; private set; }

        #region Name

        public string Name
        {
            get { return _Name; }
            set
            {
                if (_Name == value) return;
                var old = _Name;
                _Name = value;

                OnNameChanged(old, _Name);
            }
        }
        private string _Name;

        #endregion

        public virtual string UniqueName
        {
            get
            {
                return Name;
            }
        }

        public Node(Construct construct)
        {
            ConstructType = construct;
        }

        public virtual void Analyze() { }

        public virtual IEnumerable<Node> Declarations { get { yield return this; } }

        public XmlElement XmlDoc { get; set; }

        protected static IEnumerable<T> Many<T>(params IEnumerable<T>[] args) where T : Node
        {
            foreach(var arg in args)
            {
                if (arg == null) continue;

                foreach(var node in arg)
                {
                    if (node == null) continue;
                    yield return node;
                }
            }
        }
        
        protected static IEnumerable<T> With<T>(params T[] args) where T : Node { return args; }

        public override string ToString()
        {
            return Name;
        }

        protected virtual void OnNameChanged(string oldName, string newName) { }
    }
}
