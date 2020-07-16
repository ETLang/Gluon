using ABI.Gluon;
using Gluon.ABI;
using Gluon.AST;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Gluon
{
    public class CsGenerator : Generator
    {
        #region Constants

        public static readonly string NativeDeclFile = "Native.abi.cs";
        public static readonly string ValueTypesFile = "ValueTypes.cs";
        public static readonly string ValueTypesABIFile = "ValueTypes.abi.cs";
        public static readonly string ConvertersFile = "Converters.abi.cs";
        
        #endregion

        new public GeneratorSettingsCSharp Settings { get { return (GeneratorSettingsCSharp)base.Settings; } }
        
        public string ABIFolder { get; private set; }
        public string BaseFolder { get; private set; }

        public List<AST.Object> AllGeneratedClasses { get; private set; } = new List<AST.Object>();
        public List<AST.Struct> AllGeneratedStructs { get; private set; } = new List<AST.Struct>();
        public List<AST.Enum> AllGeneratedEnums { get; private set; } = new List<AST.Enum>();
        public List<AST.Delegate> AllGeneratedDelegates { get; private set; } = new List<AST.Delegate>();
        public List<string> AllDependentAssemblies { get; private set; } = new List<string>();
        public List<AST.Struct> AllTranslatedStructs { get; private set; } = new List<AST.Struct>();
        public List<AST.Delegate> AllTranslatedDelegates { get; private set; } = new List<AST.Delegate>();

        public CsGenerator(AST.Definition def, GeneratorSettings settings) : base(def, settings)
        {
            ABIFolder = Path.Combine(Settings.OutputFolder, "ABI");
            BaseFolder = Path.Combine(Settings.OutputFolder, "GluonInternal");

            PreprocessDefinition();

            if (!Directory.Exists(ABIFolder))
                Directory.CreateDirectory(ABIFolder);
        }

        public override void GenerateAll()
        {
            if (!Directory.Exists(Settings.OutputFolder))
                Directory.CreateDirectory(Settings.OutputFolder);

            CopyBaseFiles();

            Definition.SubstituteType(BasicTypes.IUnknown, BasicTypes.IntPtr);

            if (Settings.ConsolidateFiles)
            {
                WriteFile(Path.Combine(Settings.OutputFolder, Definition.Name + ".cs"), true, file =>
                {
                    // Generate ABI Layer
                    GenerateNativeDecl(file);
                    GenerateValueTypesABI(file);
                    GenerateConverters(file);

                    foreach (var classType in AllGeneratedClasses)
                        GenerateClass(file, classType);


                    // Generate Wrapper Layer
                    file.Strata = ApiStrata.Normal;
                    GenerateValueTypes(file);

                    foreach (var classType in AllGeneratedClasses)
                        GenerateClass(file, classType);
                });
            }
            else
            {
                // Generate ABI Layer
                WriteFile(Path.Combine(ABIFolder, NativeDeclFile), true, GenerateNativeDecl);
                WriteFile(Path.Combine(ABIFolder, ValueTypesABIFile), true, GenerateValueTypesABI);
                WriteFile(Path.Combine(ABIFolder, ConvertersFile), true, GenerateConverters);

                foreach (var classType in AllGeneratedClasses)
                    WriteFile(Path.Combine(ABIFolder, classType.Name + ".abi.cs"), true, file => GenerateClass(file, classType));

                // Generate Wrapper Layer
                WriteFile(Path.Combine(Settings.OutputFolder, ValueTypesFile), false, GenerateValueTypes);

                foreach (var classType in AllGeneratedClasses)
                    WriteFile(Path.Combine(Settings.OutputFolder, classType.Name + ".cs"), false, file => GenerateClass(file, classType));
            }

            // Add new stuff to the project file
            ModifyProjectFile(Settings.ProjectFile);
        }

        public void ModifyProjectFile(string path)
        {
            if(!File.Exists(path))
            {
                Errors.Warn("Project file " + path + " not found!");
                return;
            }

            XmlDocument proj = new XmlDocument();
            proj.Load(path);
            var projectDir = Path.GetDirectoryName(path);
            bool modified = false;

            var csns = "http://schemas.microsoft.com/developer/msbuild/2003";
            XmlNamespaceManager nsm = new XmlNamespaceManager(proj.NameTable);
            nsm.AddNamespace("x", csns);

            var projectRoot = proj.SelectSingleNode("x:Project", nsm);
            var generatedGroup = proj.SelectSingleNode("x:Project/x:ItemGroup[@Label='Gluon Generated']", nsm) as XmlElement;

            if (generatedGroup == null)
            {
                generatedGroup = (XmlElement)projectRoot.AppendChild(proj.CreateElement("ItemGroup", csns));
                generatedGroup.SetAttribute("Label", "Gluon Generated");
                modified = true;
            }

            Action<string> ensureSource = source =>
            {
                var relsource = U.GetRelativePath(source, projectDir);
                var el = (XmlElement)proj.SelectSingleNode("x:Project/x:ItemGroup/x:Compile[translate(@Include, 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz') = '" + relsource.ToLower() + "']", nsm);

                if (el == null)
                {
                    el = proj.CreateElement("Compile", csns);
                    el.SetAttribute("Include", relsource);
                    generatedGroup.AppendChild(el);

                    if(relsource.StartsWith(".."))
                    {
                        var linkel = proj.CreateElement("Link", csns);

                        var linkPath = U.GetRelativePath(source, Settings.OutputFolder);
                        linkel.InnerText = linkPath;
                        el.AppendChild(linkel);
                    }
                    modified = true;
                }
            };

            foreach (var file in OutputFiles)
            {
                if (file.EndsWith(".cs", StringComparison.InvariantCultureIgnoreCase))
                    ensureSource(file);
            }

            OutputFiles.Add(path);
            if (modified)
                proj.Save(path);
        }

        public void GenerateNativeDecl(CsTreeWriter file)
        {
            file.Namespace(_assemblyNS, true, () =>
            {
                file.Line("public static class Native");
                file.Block(() =>
                {
                    file.Line(@"static Native()");
                    file.Block(() =>
                    {
                        foreach (var type in AllGeneratedClasses.Where(t => t.Origin != TypeOrigin.Managed && t.Origin != TypeOrigin.Native && !t.IsAbstract))
                            file.Line("GluonObject.RegisterType<global::{0}>(new Guid(\"{1}\"), native => new global::{0}(new AbiPtr(native)));",
                                type.FullName("."), type.PrivateId);
                    });
                    file.Line(
@"public const string DllPath = ""{0}"";

[DllImport(DllPath, EntryPoint = ""$_GetGluonExceptionDetails"")]
private static extern int GetGluonExceptionDetails(out int outHR, out ExceptionType outType, out IntPtr outText);

internal static void RegisterTypes() {{ }}

public static void Throw(int hr)
{{
    if (hr == (int)HResult.S_OK) return;

    int checkhr;
    ExceptionType type;
    IntPtr msgPtr;
    string msg;
    var chk = GetGluonExceptionDetails(out checkhr, out type, out msgPtr);
    if (chk != 0 || hr != checkhr) throw new GluonExceptionAssertionFail();
    msg = Marshal.PtrToStringAnsi(msgPtr);
    throw Translate.Exception(type, msg);
}}", Settings.ImportedDll, Definition.Assembly.Name.Replace('.', '_'));
                });
            });
        }

        public void GenerateValueTypesABI(CsTreeWriter file)
        {
            foreach (var type in AllGeneratedStructs.Where(t => CsRender.RequiresABITranslation(t.ToVariable())))
                file.DefineStruct(type);
        }

        public void GenerateValueTypes(CsTreeWriter file)
        {
            foreach (var type in AllGeneratedEnums)
                file.DefineEnum(type);

            foreach (var type in AllGeneratedDelegates)
                file.DefineDelegate(type);

            foreach (var type in AllGeneratedStructs.Where(t => t.Origin != TypeOrigin.Managed))
                file.DefineStruct(type);
        }

        public void GenerateConverters(CsTreeWriter file)
        {
            file.Namespace(_assemblyNS, true, () =>
            {
                foreach (var d in AllTranslatedDelegates)
                    file.DefineDelegateWrapper(d);

                file.Line("internal static partial class MConv");
                file.Block(() =>
                {
                    foreach (var t in Definition.SelectArrayedTypes().Where(t => t.IsStruct || t.IsDelegate || t.IsObject))
                        file.WriteArrayMemberConverter(t);
                });
            });
        }

        public void GenerateClass(CsTreeWriter file, AST.Object type)
        {
            file.DefineClass(type);
        }

        #region Internal
        
        private CsTreeWriter CreateSourceFile()
        {
            var tok = new CsTreeWriter(Settings.Mode == CSharpMode.Mono);
            tok.BlockComment(() => tok.Line(Disclaimer));
            tok.Line();

            tok.Use(Definition.LookupNamespace("Gluon"));
            tok.Use(Definition.LookupNamespace("System"));
            tok.Use(Definition.LookupNamespace(typeof(Marshal).Namespace));
            tok.Use(_assemblyNS, true);
            tok.Use(_gluonNS, true);
            tok.DeferredUsings();

            return tok;
        }

        private void WriteFile(string path, bool abi, Action<CsTreeWriter> dostuff)
        {
            var file = CreateSourceFile();
            file.Strata = abi ? ApiStrata.ABI : ApiStrata.Normal;
            dostuff(file);
            Render(file, path);
        }

        private void Render(PascalTreeWriter treeWriter, string path)
        {
            var writer = new CsRender();

            treeWriter.InsertUsings();
            treeWriter.Tree.Resolve(writer);
            writer.Write(path);
            OutputFiles.Add(path);
        }
        
        private void PreprocessDefinition()
        {
            Definition.ApplyTypeSubstitutions(Settings.TargetId);
            Definition.ApplyNamespaceSubsitutions(Settings.TargetId);

            foreach (var type in Definition.AllTypes)
            {
                if (type.Origin != TypeOrigin.Mapped)
                {
                    if (type.IsObject && type.Origin != TypeOrigin.Managed && type.Assembly == Definition.Assembly)
                        AllGeneratedClasses.Add((AST.Object)type);
                    else if (type.IsStruct)
                        AllGeneratedStructs.Add((AST.Struct)type);
                    else if (type.IsEnum && type.Origin != TypeOrigin.Managed && type.Assembly == Definition.Assembly)
                        AllGeneratedEnums.Add((AST.Enum)type);
                    else if (type.IsDelegate && !((AST.Delegate)type).IsGeneric)
                        AllGeneratedDelegates.Add((AST.Delegate)type);
                }
            }

            foreach (var type in Definition.AllTypes)
            {
                if (type.IsDelegate)
                    AllTranslatedDelegates.Add((AST.Delegate)type);
                else if (type.IsStruct && CppRender.RequiresABITranslation(type.ToVariable()))
                    AllTranslatedStructs.Add((AST.Struct)type);
            }

            Definition.StripAllGluonAttributes();
            Definition.PutDefaultConstructorsFirst();
            Definition.InsertDefaultConstructorsWhereNoneAreDefined();

            var builder = new AST.Builder(Definition);
            _assemblyNS = builder.Resolve(Definition.Assembly.Name);
            _gluonNS = builder.Resolve("Gluon");
            builder.Resolve(typeof(DllImportAttribute));
            builder.Resolve(typeof(MarshalAsAttribute));
            builder.Resolve(typeof(GluonObject));
            builder.Resolve(typeof(DelegateBlob));
        }

        private AST.Namespace _assemblyNS;
        private AST.Namespace _gluonNS;

        #endregion
    }
}
