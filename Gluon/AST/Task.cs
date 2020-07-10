using ABI.Gluon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gluon.AST
{
    public class Task : Type
    {
        public Field Result { get; set; }
        public string WrapperName { get; }
        
        public Task() : base(Construct.Task)
        {
            WrapperName = "T_" + _TaskTypeIndex.ToString();
            _TaskTypeIndex++;
        }

        public Object GetWrapperType(Definition def)
        {
            var builder = new Builder(def);

            var ns = builder.Resolve(builder.Product.Assembly.Name);
            var baseType = (Object)builder.Resolve(typeof(Gluon.TaskBase));

            if (Result.Type.IsVoid)
                return baseType;

            var current = def.AllTypes.OfType<Object>().FirstOrDefault(o => o.Name == WrapperName && o.Namespace == ns);

            if (current != null)
                return current;

            var t = new Object()
            {
                Name = WrapperName,
                //BaseType = baseType,
                Access = Access.Internal,
                Namespace = builder.Resolve(builder.Product.Assembly.Name),
                Origin = TypeOrigin.MappedIntermediary,
            };

            t.Constructors.Add(new Constructor());
        
            foreach(var m in baseType.Methods)
                t.Methods.Add(m);

            t.Properties.Add(new Property()
            {
                Name = "Result",
                Access = Access.Public,
                Nature = MemberNature.Instance,
                Type = Result.Type,
                IsArray = Result.IsArray,
            });

            return t;
        }

        public override IEnumerable<Node> Declarations
        {
            get
            {
                yield return this;

                if (Result != null && !Result.IsVoid)
                    yield return Result;
            }
        }

        public override string ToString()
        {
            if (Result == null || Result.IsVoid)
                return "Task";

            return "Task<" + Result.ToString() + ">";
        }

        private static int _TaskTypeIndex = 1;
    }
}
