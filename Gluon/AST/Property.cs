using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gluon.AST
{
    public class Property : Member, IVariable
    {
        public Type Type { get; set; }
        public bool IsArray { get; set; }
        public bool IsReadOnly { get; set; }
        public bool IsFactory { get; set; }
        public bool ConstGetter { get; set; } = true;
        public bool IsBacked { get; set; }
        public bool IsVoid { get { return false; } }
        public bool IsIn { get { return false; } }
        public bool IsRef { get { return false; } }
        public bool IsOut { get { return false; } }

        public Property() : base(Construct.Property) { }

        public Method CreateGetter()
        {
            var m = new Method
            {
                IsConst = true,
                Access = Access,
                Nature = Nature,
                Name = "Get" + Name,
                Return = new Parameter
                {
                    Context = (!IsFactory && Type.IsObject) ? VariableContext.In : VariableContext.Return,
                    Type = Type,
                    IsArray = IsArray,
                    Name = "___ret"
                }
            };

            return m;
        }

        public Method CreateSetter()
        {
            var m = new Method
            {
                Access = IsReadOnly ? Access.Private : Access,
                Nature = Nature,
                Name = "Set" + Name,
                Return = Parameter.Void,
            };

            m.Parameters.Add(new Parameter
            {
                Type = Type,
                IsArray = IsArray,
                Name = "value"
            });

            return m;
        }

        VariableContext IVariable.Context
        {
            get { return VariableContext.Member; }
            set { throw new NotImplementedException(); }
        }

        public override IEnumerable<Node> Declarations
        {
            get
            {
                return Many(base.Declarations, With(Type));
            }
        }

        public override string ToString()
        {
            return base.ToString() + Type.FullName(".") + (IsArray ? "[]" : "") + " " + Name + " { get; " + (IsReadOnly ? "" : "set; ") + "}";
        }
    }
}
