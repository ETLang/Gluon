using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gluon.AST
{
    public interface ICallSignature
    {
        string Name { get; set; }
        Parameter Return { get; set; }
        List<Parameter> Parameters { get; }
        bool IsConst { get; }
        int OverloadOrdinal { get; set; }
    }
}
