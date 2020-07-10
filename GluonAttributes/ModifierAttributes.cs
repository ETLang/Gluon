using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gluon
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class ModPropertyAttribute : Attribute
    {
        public bool? AutoField { get; set; }
        public bool? ConstGetter { get; set; }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public sealed class ModMethodAttribute : Attribute
    {
        public bool? Const { get; set; }
    }
}
