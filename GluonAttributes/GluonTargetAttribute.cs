using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gluon
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public abstract class GluonTargetAttribute : Attribute
    {
        public string TargetID { get; private set; }
        public string ProjectName { get; set; }
        public string OutputFolder { get; set; }
        public string Mode { get; private set; }
        public bool ConsolidateFiles { get; set; }

        protected GluonTargetAttribute(string targetID, string mode = null)
        {
            TargetID = targetID;
            Mode = mode;
        }
    }

    public enum CppMode
    {
        Implementation,
        PimplWrapper
    }

    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public class GluonTargetCppAttribute : GluonTargetAttribute
    {
        public string PrecompiledHeader { get; set; }
        public string ProjectFile { get; set; }
        public bool FullIntellisense { get; set; }

        public GluonTargetCppAttribute(string targetID = "Cpp", CppMode mode = CppMode.Implementation)
            : base(targetID, mode.ToString()) { }
    }

    public enum CSharpMode
    {
        Default,
        Mono
    }

    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public class GluonTargetCSharpAttribute : GluonTargetAttribute
    {
        public string ProjectFile { get; set; }
        public string ImportedDll { get; set; }

        public GluonTargetCSharpAttribute(string targetID = "CSharp", CSharpMode mode = CSharpMode.Default) : base(targetID, mode.ToString()) { }
    }
}
