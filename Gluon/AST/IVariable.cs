using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gluon.AST
{
    public interface IVariable
    {
        string Name { get; set; }
        Type Type { get; set; }
        VariableContext Context { get; set; }
        bool IsArray { get; set; }
        bool IsVoid { get; }
        bool IsIn { get; }
        bool IsRef { get; }
        bool IsOut { get; }
    }
}
