using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gluon.AST
{
    public interface IHasAttributes
    {
        List<Attribute> Attributes { get; }
    }
}
