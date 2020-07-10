using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gluon.AST
{
    public class Object : Type
    {
        public bool IsAbstract { get; set; }
        public bool IsAlreadyGluonGenerated { get; set; }
        public Object BaseType { get; set; }
        public List<Object> Interfaces { get; private set; } = new List<Object>();
        public List<Property> Properties { get; private set; } = new List<Property>();
        public List<Event> Events { get; private set; } = new List<Event>();
        public List<Constructor> Constructors { get; private set; } = new List<Constructor>();
        public List<Method> Methods { get; private set; } = new List<Method>();

        //public bool HasDefaultConstructor { get { return Constructors.Count == 0 || Constructors.Any(c => c.Parameters.Count == 0); } }

        public Object() : base(Construct.Object) { }

        public bool DerivesFrom(Object baseType)
        {
            if (BaseType == baseType)
                return true;
            if (BaseType == null)
                return false;
            return BaseType.DerivesFrom(baseType);
        }

        public IEnumerable<Member> Members
        {
            get
            {
                return Many<Member>(Constructors, Events, Properties, Methods);
            }
        }

        public IEnumerable<Method> SyntaxExpandedMethods
        {
            get
            {
                return Many(
                    Methods,
                    Properties.Select(p => p.CreateGetter()),
                    Properties.Select(p => p.IsReadOnly ? null : p.CreateSetter()),
                    Events.Select(e => e.CreateAdder()),
                    Events.Select(e => e.CreateRemover()));
            }
        }

        public override IEnumerable<Node> Declarations
        {
            get
            {
                return Many(
                    base.Declarations,
                    With(BaseType),
                    Interfaces.SelectMany(i => i.Declarations),
                    Properties.SelectMany(p => p.Declarations),
                    Events.SelectMany(e => e.Declarations),
                    Constructors.SelectMany(c => c.Declarations),
                    Methods.SelectMany(m => m.Declarations));
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendFormat("[@{0}] ", Assembly == null ? "<null-assembly>" : Assembly.ToString());
            if (Attributes.Count != 0)
                sb.AppendFormat("[Attrs({0})] ", Attributes.Count);
            sb.Append("class ");
            sb.Append(this.FullName("."));

            if (BaseType != null || Interfaces.Count != 0)
                sb.Append(" : ");

            bool first = true;
            
            if(BaseType != null)
            {
                sb.Append(BaseType.FullName("."));
                first = false;
            }

            foreach(var i in Interfaces)
            {
                if (!first)
                    sb.Append(", ");
                first = false;
                sb.Append(i.FullName("."));
            }

            sb.Append(" { }");
            return sb.ToString();
        }
    }
}
