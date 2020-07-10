using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Gluon.AST
{
    public class Enum : Type
    {
        public Type UnderlyingType { get; set; }
        public List<Entry> Entries { get; private set; } = new List<Entry>();

        public Enum() : base(Construct.Enum) { }

        public class Entry
        {
            public string Name;
            public long Value;
            public XmlElement XmlDoc;

            public Entry(string name, long value, XmlElement doc)
            {
                Name = name; Value = value; XmlDoc = doc;
            }
        }

        public override string ToString()
        {
            return "enum " + Name + " : " + UnderlyingType.ToString();
        }
    }
}
