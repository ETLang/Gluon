using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gluon.AST
{
    public enum Access
    {
        Public,
        Internal,
        Protected,
        Private,
    }

    public enum MemberNature
    {
        Instance,
        Static,
        Abstract,
        Virtual
    }

    public enum VariableContext
    {
        In,
        Out,
        Ref,
        Return,
        Make,
        Member
    }

    [Flags]
    public enum Construct
    {
        Unknown         = 0,
        Definition      = 1,
        Type            = 2,
        Member          = 3,
        Signature       = 4,
        Scope           = 5,
        Void            = (1 << 3) | Type,
        Primitive       = (2 << 3) | Type,
        Enum            = (3 << 3) | Type,
        String          = (4 << 3) | Type,
        Struct          = (5 << 3) | Type,
        Object          = (6 << 3) | Type,
        Delegate        = (7 << 3) | Type,
        Interface       = (8 << 3) | Type,
        Task            = (9 << 3) | Type,
        Constructor     = (1 << 3) | Member,
        Event           = (2 << 3) | Member,
        Property        = (3 << 3) | Member,
        Method          = (4 << 3) | Member,
        Field           = (5 << 3) | Member,
        Parameter       = (1 << 3) | Signature,
        Attribute       = (2 << 3) | Signature,
        Namespace       = (1 << 3) | Scope,
        Assembly        = (2 << 3) | Scope
    }
}
