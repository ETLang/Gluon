using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gluon
{
    public abstract class GeneratorSettings
    {
        public string TargetId { get; private set; }
        public string GeneratorType { get; private set; }
        public string ProjectName { get; set; }
        public string OutputFolder { get; set; }
        public string Mode { get; set; }
        public bool ConsolidateFiles { get; set; }

        public GeneratorSettings(string type, string id)
        {
            GeneratorType = type;
            TargetId = id;
        }

        public virtual bool CleanAndValidate(string assemblyName)
        {
            if (string.IsNullOrEmpty(ProjectName))
                ProjectName = assemblyName;
            if (string.IsNullOrEmpty(OutputFolder))
                OutputFolder = ".\\" + TargetId;


            if (!Path.IsPathRooted(OutputFolder))
                OutputFolder = U.GetAbsolutePath(OutputFolder);

            return true;
        }
    }

    public class GeneratorSettingsCpp : GeneratorSettings
    {
        public string PrecompiledHeader { get; set; }
        public string ProjectFile { get; set; }
        public bool FullIntellisense { get; set; }

        new public CppMode Mode
        {
            get { return (CppMode)Enum.Parse(typeof(CppMode), base.Mode); }
            set { base.Mode = value.ToString(); }
        }

        public GeneratorSettingsCpp(string id) : base("Cpp", id) { Mode = CppMode.Implementation; }

        public override bool CleanAndValidate(string assemblyName)
        {
            if (!base.CleanAndValidate(assemblyName))
                return false; 

            CppMode m;
            if (!Enum.TryParse(base.Mode, out m))
            {
                Errors.Generic("Invalid mode specified for C++ target " + TargetId + ": " + base.Mode);
                return false;
            }

            if (string.IsNullOrEmpty(ProjectFile))
                ProjectFile = Path.Combine(OutputFolder, ProjectName + ".vcxproj");

            return true;
        }
    }

    public class GeneratorSettingsCSharp : GeneratorSettings
    {
        public string ImportedDll { get; set; }
        public string ProjectFile { get; set; }
        new public CSharpMode Mode
        {
            get { return (CSharpMode)Enum.Parse(typeof(CSharpMode), base.Mode); }
            set { base.Mode = value.ToString(); }
        }

        public GeneratorSettingsCSharp(string id) : base("CSharp", id) { Mode = CSharpMode.Default; }

        public override bool CleanAndValidate(string assemblyName)
        {
            if (!base.CleanAndValidate(assemblyName))
                return false;

            CSharpMode m;
            if (!Enum.TryParse(base.Mode, out m))
            {
                Errors.Generic("Invalid mode specified for C# target " + TargetId + ": " + base.Mode);
                return false;
            }

            if (string.IsNullOrEmpty(ProjectFile))
                ProjectFile = Path.Combine(OutputFolder, ProjectName + ".csproj");
            if (string.IsNullOrEmpty(ImportedDll))
                ImportedDll = ProjectName + ".Cpp.dll";

            return true;
        }
    }
}
