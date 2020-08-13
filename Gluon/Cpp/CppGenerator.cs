using Gluon.PascalTreeCppExtensions;
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
    public class CppGenerator : Generator
    {
        #region Settings

        // ABI
        public static readonly string PrototypesHeader = "Prototypes.h";
        public static readonly string PrototypesHeaderABI = "Prototypes.abi.h";
        public static readonly string ValueTypesHeader = "ValueTypes.h";
        public static readonly string ValueTypesHeaderABI = "ValueTypes.abi.h";
        public static readonly string ValueTypesConverters = "ValueTypes.abi.cpp";
        public static readonly string DelegateConvertersHeader = "Delegates.abi.h";
        public static readonly string DelegateConverters = "Delegates.abi.cpp";
        public static readonly string TaskWrappersHeaderABI = "TaskWrappers.abi.h";
        public static readonly string TaskWrappersHeader = "TaskWrappers.h";
        public static readonly string TaskWrappers = "Tasks.abi.cpp";

        // PIMPL
        public static readonly string PimplDelegatesHeader = "PimplDelegates.h";
        public static readonly string PimplDelegates = "PimplDelegates.cpp";

        #endregion

        new public GeneratorSettingsCpp Settings { get { return (GeneratorSettingsCpp)base.Settings; } }

        public string PublicFolder { get; private set; }
        public string CommonLibraryHeader { get; private set; }
        public string CommonLibraryImplementation { get; private set; }
        public string PublicLibraryHeader { get; private set; }
        public string PublicLibraryImplementation { get; private set; }

        public List<AST.Type> AllGeneratedTypes { get; private set; } = new List<AST.Type>();
        public List<AST.Object> AllGeneratedClasses { get; private set; } = new List<AST.Object>();
        public List<AST.Struct> AllGeneratedStructs { get; private set; } = new List<AST.Struct>();
        public List<AST.Enum> AllGeneratedEnums { get; private set; } = new List<AST.Enum>();
        public List<AST.Delegate> AllGeneratedDelegates { get; private set; } = new List<AST.Delegate>();
        public List<AST.Task> AllGeneratedTasks { get; private set; } = new List<AST.Task>();
        public List<AST.Struct> AllTranslatedStructs { get; private set; } = new List<AST.Struct>();
        public List<AST.Delegate> AllTranslatedDelegates { get; private set; } = new List<AST.Delegate>();
        public List<AST.Delegate> AllTranslatedDelegateSignatures { get; private set; } = new List<AST.Delegate>();

        public List<string> AllDependentLibraries { get; private set; } = new List<string>();

        public CppGenerator(AST.Definition definition, GeneratorSettings settings) : base(definition, settings)
        {
            PublicFolder = Path.Combine(Settings.OutputFolder, "Public");

            CommonLibraryHeader = Settings.ProjectName + ".Common.h";
            CommonLibraryImplementation = Settings.ProjectName + ".abi.cpp";
            PublicLibraryHeader = Settings.ProjectName + ".Wrappers.h";
            PublicLibraryImplementation = Settings.ProjectName + ".Wrappers.cpp";

            PreprocessDefinition();
        }

        IEnumerable<AST.Type> SelectGeneratedTypes()
        {
            return Definition.AllTypes.Where(t => t.Origin == TypeOrigin.Gluon || (t.Origin == TypeOrigin.Managed && !t.IsAttribute));
        }

        public override void GenerateAll()
        {
            if (!Directory.Exists(PublicFolder))
                Directory.CreateDirectory(PublicFolder);

            CopyBaseFiles();

            if (!Directory.Exists(Settings.OutputFolder))
                Directory.CreateDirectory(Settings.OutputFolder);

            GeneratePrivate();
            GeneratePimplWrappers();

            ModifyProjectFile(Settings.ProjectFile);

            BasicTypes.Reset();
        }

        public void GeneratePrivate()
        {
            if (Settings.ConsolidateFiles)
            {
                // Generate public header:
                WriteFile(Path.Combine(PublicFolder, Settings.ProjectName + ".public.abi.h"), false, true, writer =>
                {
                    GenerateLibraryABIHeader(writer);
                    GeneratePrototypesHeader(writer);
                    GenerateValueTypesHeader(writer);

                    if (AllGeneratedTasks.Count != 0)
                        GenerateTaskWrappersABIHeader(writer);

                    foreach(var type in AllGeneratedClasses)
                        writer.DeclareABIConstructors(type);

                    foreach (var type in AllGeneratedClasses)
                        GenerateClassABIDeclarationHeader(writer, type);
                });

                // Generate private header:
                WriteFile(Path.Combine(Settings.OutputFolder, CommonLibraryHeader), false, false, writer =>
                {
                    GenerateCommonHeader(writer);
                    GeneratePrototypesHeader(writer);
                    GenerateValueTypesHeader(writer);

                    foreach (var d in AllTranslatedDelegateSignatures)
                        GenerateDelegateConvertersHeader(writer, d);

                    if (AllGeneratedTasks.Count != 0)
                        GenerateTaskWrappersHeader(writer);
                });

                // Generate private implementation:
                WriteFile(Path.Combine(Settings.OutputFolder, CommonLibraryImplementation), false, false, writer =>
                {
                    GenerateCommonImplementation(writer);
                    GenerateValueTypeConverters(writer);
                    GenerateDelegateConvertersImplementation(writer, false);

                    if (AllGeneratedTasks.Count != 0)
                        GenerateTaskWrappersImplementation(writer);

                    writer.Strata = ApiStrata.ABI;

                    foreach (var type in AllGeneratedClasses)
                        GenerateClassABIImplementation(writer, type);
                });
            }
            else
            {
                // Generate top-level headers
                WriteFile(Path.Combine(PublicFolder, Settings.ProjectName + ".public.abi.h"), false, true, GenerateLibraryABIHeader);
                WriteFile(Path.Combine(Settings.OutputFolder, CommonLibraryHeader), false, false, GenerateCommonHeader);
                WriteFile(Path.Combine(Settings.OutputFolder, CommonLibraryHeader.Replace(".h", ".cpp")), false, true, GenerateCommonImplementation);
                WriteFile(Path.Combine(Settings.OutputFolder, DelegateConvertersHeader), false, false, file =>
                {
                    foreach (var d in AllTranslatedDelegateSignatures)
                        GenerateDelegateConvertersHeader(file, d);
                });

                // Generate public files
                WriteFile(Path.Combine(PublicFolder, PrototypesHeaderABI), false, true, GeneratePrototypes);
                WriteFile(Path.Combine(PublicFolder, ValueTypesHeaderABI), false, true, GenerateValueTypesHeader);
                if (AllGeneratedTasks.Count != 0)
                {
                    WriteFile(Path.Combine(PublicFolder, TaskWrappersHeaderABI), false, true, GenerateTaskWrappersABIHeader);
                    WriteFile(Path.Combine(Settings.OutputFolder, TaskWrappersHeader), false, false, GenerateTaskWrappersHeader);
                }

                foreach (var type in AllGeneratedClasses)
                {
                    WriteFile(Path.Combine(PublicFolder, type.Name + ".abi.h"), false, true, writer =>
                    {
                        GenerateClassABIDeclarationHeader(writer, type);
                    });
                    WriteFile(Path.Combine(Settings.OutputFolder, type.Name + ".abi.cpp"), false, true, file => GenerateClassABIImplementation(file, type));
                }

                // Generate private files
                WriteFile(Path.Combine(Settings.OutputFolder, PrototypesHeader), false, false, file =>
                {
                    file.IncludeLocal("Public/" + PrototypesHeaderABI);
                    GeneratePrototypes(file);
                });

                WriteFile(Path.Combine(Settings.OutputFolder, ValueTypesHeader), false, false, GenerateValueTypesHeader);
                WriteFile(Path.Combine(Settings.OutputFolder, ValueTypesConverters), false, false, GenerateValueTypeConverters);
                WriteFile(Path.Combine(Settings.OutputFolder, DelegateConverters), false, false, file => GenerateDelegateConvertersImplementation(file, false));

                if (AllGeneratedTasks.Count != 0)
                    WriteFile(Path.Combine(Settings.OutputFolder, TaskWrappers), false, false, GenerateTaskWrappersImplementation);
            }

            foreach (var type in AllGeneratedClasses)
            {
                var headerPath = Path.Combine(Settings.OutputFolder, type.Name + ".h");
                var implPath = Path.Combine(Settings.OutputFolder, type.Name + ".cpp");

                if (File.Exists(headerPath))
                    ModifyClassDeclarationHeader(headerPath, type);
                else
                    WriteFile(headerPath, true, false, file => GenerateClassDeclarationHeader(file, type));

                if (File.Exists(implPath))
                {
                    ModifyClassImplementation(implPath, type);
                    OutputFiles.Add(implPath);
                }
                else
                    WriteFile(implPath, true, false, file => GenerateClassImplementation(file, type));
            }
        }

        public void GeneratePimplWrappers()
        {
            if (Settings.ConsolidateFiles)
            {
                WriteFile(Path.Combine(PublicFolder, PublicLibraryHeader), false, false, file =>
                {
                    GeneratePublicLibraryHeader(file);
                    GenerateValueTypesHeader(file);
                    foreach(var del in AllTranslatedDelegateSignatures)
                        GenerateDelegateConvertersHeader(file, del);
                });

                WriteFile(Path.Combine(PublicFolder, PublicLibraryImplementation), false, false, file =>
                {
                    file.IncludeLocal(PublicLibraryHeader);
                    foreach (var type in AllGeneratedClasses)
                        GenerateClassPimplImplementation(file, type);
                    GenerateDelegateConvertersImplementation(file, true);
                    GenerateValueTypeConverters(file);
                });
            }
            else
            {
                WriteFile(Path.Combine(PublicFolder, ValueTypesHeader), false, false, GenerateValueTypesHeader);
                WriteFile(Path.Combine(PublicFolder, ValueTypesConverters), false, false, GenerateValueTypeConverters);

                WriteFile(Path.Combine(PublicFolder, PublicLibraryHeader), false, false, file =>
                {
                    GeneratePublicLibraryHeader(file);
                });

                WriteFile(Path.Combine(PublicFolder, PimplDelegatesHeader), false, false, file =>
                {
                    foreach (var del in AllTranslatedDelegateSignatures)
                        GenerateDelegateConvertersHeader(file, del);
                });

                WriteFile(Path.Combine(PublicFolder, PimplDelegates), false, false, file =>
                {
                    GenerateDelegateConvertersImplementation(file, true);

                });

                foreach (var type in AllGeneratedClasses)
                {
                    var cppPath = Path.Combine(PublicFolder, type.Name + ".cpp");
                    WriteFile(cppPath, true, false, file =>
                    {
                        file.IncludeLocal(PublicLibraryHeader);
                        GenerateClassPimplImplementation(file, type);
                    });
                }
            }
            
            foreach (var type in AllGeneratedClasses)
            {
                var headerPath = Path.Combine(PublicFolder, type.Name + ".h");
                WriteFile(headerPath, true, false, file => GenerateClassPimplHeader(file, type));
            }
        }

        public void ModifyProjectFile(string path)
        {
            if (!File.Exists(path))
            {
                Errors.Warn("Project file " + path + " not found!");
                return;
            }

            XmlDocument proj = new XmlDocument();
            proj.Load(path);
            var projectDir = Path.GetDirectoryName(path);
            bool modified = false;

            var vcxns = "http://schemas.microsoft.com/developer/msbuild/2003";
            XmlNamespaceManager nsm = new XmlNamespaceManager(proj.NameTable);
            nsm.AddNamespace("x", vcxns);

            var projectRoot = proj.SelectSingleNode("x:Project", nsm);
            var generatedGroup = proj.SelectSingleNode("x:Project/x:ItemGroup[@Label='Gluon Generated']", nsm) as XmlElement;

            if (generatedGroup == null)
            {
                generatedGroup = (XmlElement)projectRoot.AppendChild(proj.CreateElement("ItemGroup", vcxns));
                generatedGroup.SetAttribute("Label", "Gluon Generated");
                modified = true;
            }

            Action<string> ensureHeader = header =>
            {
                header = U.GetRelativePath(header, projectDir);
                var el = (XmlElement)proj.SelectSingleNode("x:Project/x:ItemGroup/x:ClInclude[translate(@Include, 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz') = '" + header.ToLower() + "']", nsm);

                if (el == null)
                {
                    el = proj.CreateElement("ClInclude", vcxns);
                    el.SetAttribute("Include", header);
                    generatedGroup.AppendChild(el);
                    modified = true;
                }
            };

            Action<string> ensureSource = source =>
            {
                source = U.GetRelativePath(source, projectDir);
                var el = (XmlElement)proj.SelectSingleNode("x:Project/x:ItemGroup/x:ClCompile[translate(@Include, 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz') = '" + source.ToLower() + "']", nsm);

                if (el == null)
                {
                    el = proj.CreateElement("ClCompile", vcxns);
                    el.SetAttribute("Include", source);
                    generatedGroup.AppendChild(el);
                    modified = true;
                }
            };

            foreach (var file in OutputFiles)
            {
                if (file.EndsWith(".h", StringComparison.InvariantCultureIgnoreCase))
                    ensureHeader(file);
                else if (file.EndsWith(".cpp", StringComparison.InvariantCultureIgnoreCase))
                    ensureSource(file);
            }

            OutputFiles.Add(path);
            if (modified)
                proj.Save(path);
        }

        public void GeneratePublicLibraryHeader(CppTreeWriter file)
        {
            // - Prototypes
            GeneratePrototypes(file);

            foreach (var type in AllGeneratedClasses)
                file.IncludeLocal(type.Name + ".h");

            if (!Settings.ConsolidateFiles)
                file.IncludeLocal(PimplDelegatesHeader);
        }

        public void GenerateClassPimplHeader(CppTreeWriter file, AST.Object type)
        {
            if (type.BaseType != null)
                file.IncludeLocal(type.BaseType.Name + ".h");
            foreach (var iface in type.Interfaces)
                file.IncludeLocal(iface.Name + ".h");

            file.Namespace(type.Namespace, false, () =>
            {
                file.GenerateWrapperDeclaration(type);
            });

            file.Line($"IS_VALUETYPE({file.TypeRef(type)}, \"{type.Id}\")");
        }

        public void GenerateClassPimplImplementation(CppTreeWriter file, AST.Object type)
        {
            file.Use(_projectDetailsNamespace);
            file.Use(Definition.LookupNamespace("GluonInternal"));
            file.Spacer();

            file.GenerateWrapperImplementation(type);
        }

        public void GenerateDelegateConvertersHeader(CppTreeWriter file, AST.Delegate type)
        {
            file.Namespace(_projectDetailsNamespace, false, () =>
            {
                file.Line("using namespace CS;");
                file.Spacer();
                file.GenerateDelegateConverterDeclaration(type);
            });
        }

        public void GenerateDelegateConvertersImplementation(CppTreeWriter file, bool pimpl)
        {
            if (pimpl)
                file.IncludeLocal(PublicLibraryHeader);
            else
                file.IncludeLocal("Public/" + Settings.ProjectName + ".public.abi.h");

            file.Use(_projectDetailsNamespace);
            file.Use(Definition.LookupNamespace("GluonInternal"));
            file.Spacer();

            file.Line("template<typename Wrapper, typename Signature>");
            file.Line("std::unordered_map<ABI::DelegateKeyContainer<Signature>, CS::weak_ptr<Wrapper>> ABI::DelegateWrapperBase<Wrapper, Signature>::_ActiveDelegates;");
            file.Spacer();
            file.Line("template<typename Wrapper, typename Signature>");
            file.Line("CriticalSection ABI::DelegateWrapperBase<Wrapper, Signature>::_CSec;");
            file.Spacer();

            foreach (var del in AllTranslatedDelegateSignatures)
                file.GenerateDelegateConverterImplementation(del);
        }

        public void GenerateLibraryABIHeader(CppTreeWriter file)
        {
            file.Include("Sharpish.h");
            file.Line();
            file.Line("using namespace CS;");
            file.Line();
            foreach (var c in AllDependentLibraries)
                file.Include(c);
            file.IncludeLocal("GluonNative.h");

            if (!Settings.ConsolidateFiles)
            {
                file.IncludeLocal(PrototypesHeaderABI);
                file.IncludeLocal(ValueTypesHeaderABI);

                foreach (var c in AllGeneratedClasses)
                    file.IncludeLocal(c.Name + ".abi.h");
            }

            file.Spacer();
            file.Line("void {0}_Initialize();", Settings.ProjectName);
        }

        public void GenerateCommonHeader(CppTreeWriter file)
        {
            file.Line("#define GLUON_BUILDING");
            file.IncludeLocal(PublicFolder, Settings.ProjectName + ".public.abi.h");

            if (!Settings.ConsolidateFiles)
            {
                file.IncludeLocal(PrototypesHeader);
                file.IncludeLocal(ValueTypesHeader);
                file.IncludeLocal(DelegateConvertersHeader);
            }
        }

        public void GeneratePrototypesHeader(CppTreeWriter file)
        {
            if (!Settings.ConsolidateFiles)
            {
                if (file.Strata != ApiStrata.ABI)
                    file.IncludeLocal("Public/" + PrototypesHeaderABI);

                file.Line();
            }


            GeneratePrototypes(file);
        }

        public void GeneratePrototypes(CppTreeWriter file)
        {
            var useabi = file.Strata == ApiStrata.ABI;
            var prototypeKeyword = useabi ? "cominterface" : "class";

            if (useabi)
            {
                foreach (var type in SelectGeneratedTypes().Where(t => t.IsStruct && !CppRender.RequiresABITranslation(t.ToVariable())))
                    file.Namespace(type.Namespace, false, () => file.Line("struct {0};", type.Name));
            }

            foreach (var type in SelectGeneratedTypes().Where(t => (t.IsStruct || t.IsObject || t.IsDelegate)).OrderBy(t => t.ConstructType))
            {
                file.Namespace(type.Namespace, useabi, () =>
                {
                    if (type.IsStruct)
                    {
                        if (useabi && !CppRender.RequiresABITranslation(type.ToVariable()))
                            file.Line("using ::{0};", type.FullName("::"));
                        else
                            file.Line("struct {0};", type.Name);
                    }
                    else if (type.IsObject)
                        file.Line("{0} {1};", prototypeKeyword, type.Name);
                });
            }
        }

        public void GenerateValueTypesHeader(CppTreeWriter file)
        {
            var strata = file.Strata;

            if (!Settings.ConsolidateFiles)
            {
                file.IncludeLocal(strata == ApiStrata.ABI ? PrototypesHeaderABI : PrototypesHeader);
                if (strata == ApiStrata.ABI)
                    file.IncludeLocal("GluonNative.h");
                else
                    file.IncludeLocal(PublicFolder, ValueTypesHeaderABI);
            }

            var allValueTypes = AllGeneratedEnums.Cast<AST.Type>()
                .Union(AllGeneratedStructs)
                .Union(AllGeneratedDelegates)
                .Where(t => t.Origin != TypeOrigin.Native);

            var noTranslationTypes = allValueTypes.Where(t => !CppRender.RequiresABITranslation(t.ToVariable()));
            var requiresTranslationTypes = allValueTypes.Where(t => CppRender.RequiresABITranslation(t.ToVariable()));

            HashSet<AST.Type> toDefine = new HashSet<AST.Type>();

            Action<IEnumerable<AST.Type>, Action<AST.Type>> generateOrderDependent = null;
            generateOrderDependent = (types, generator) =>
            {
                toDefine.Clear();
                foreach (var t in types)
                    toDefine.Add(t);

                Action<AST.Type> recurse = null;
                recurse = t =>
                {
                    if (!toDefine.Contains(t)) return;
                    toDefine.Remove(t);
                    foreach (var refType in t.Declarations.OfType<AST.Type>())
                        recurse(refType);

                    generator(t);
                };

                while (toDefine.Count != 0)
                    recurse(toDefine.First());
            };

            if (strata == ApiStrata.ABI)
            {
                generateOrderDependent(noTranslationTypes, t =>
                {
                    var s = t as AST.Struct;
                    if (s != null) file.GenerateStruct(s, false);
                    var e = t as AST.Enum;
                    if (e != null) file.Namespace(t.Namespace, false, () => file.GenerateEnum(e));
                });

                file.Line();

                foreach (var x in noTranslationTypes.Where(t => t.Namespace != BasicTypes.GlobalNamespace).OrderBy(t => t.Namespace.FullName(".")))
                    file.Namespace(x.Namespace, true, () => file.Line($"using ::{x.FullName("::")};"));

                generateOrderDependent(requiresTranslationTypes, t =>
                {
                    var s = t as AST.Struct;
                    if (s != null) file.GenerateStruct(s, true);
                    var d = t as AST.Delegate;
                    if (d != null && !d.IsGeneric) file.Namespace(t.Namespace, true, () =>
                         file.Line("typedef HRESULT (__stdcall* {0})({1});", d.Name, file.DeclParameters(d.GetABIParametersCpp())));
                });
            }
            else
            {
                generateOrderDependent(requiresTranslationTypes, t =>
                {
                    var s = t as AST.Struct;
                    if (s != null) file.GenerateStruct(s, false);
                    var d = t as AST.Delegate;
                    if (d != null && !d.IsGeneric) file.Namespace(t.Namespace, false, () =>
                         file.Line("typedef Delegate<{0}> {1};", file.Signature(d), d.Name));
                });
            }

            if (strata == ApiStrata.ABI)
            {
                foreach (var x in AllGeneratedEnums)
                {
                    if (x.Origin == TypeOrigin.Native) continue;

                    if (x.Namespace.IsGlobal)
                        file.Line(@"IS_PRIMITIVE(::{0}, ""{1}"");", x.Name, x.Id);
                    else
                        file.Line(@"IS_PRIMITIVE(::{0}::{1}, ""{2}"");", x.Namespace.FullName("::"), x.Name, x.Id);
                }
            }
            file.Spacer();

            if (strata != ApiStrata.ABI)
                foreach (var x in AllGeneratedStructs)
                {
                    if (!CppRender.RequiresABITranslation(x.ToVariable())) continue;

                    file.Line("MapStructABI({0}, {1})", file.TypeRef(x, false), file.TypeRef(x, true));
                }
        }

        public void GenerateClassABIDeclarationHeader(CppTreeWriter file, AST.Object type)
        {
            if (!Settings.ConsolidateFiles)
            {
                file.IncludeLocal(PrototypesHeaderABI);
                file.IncludeLocal(ValueTypesHeaderABI);
                file.Spacer();
                file.DeclareABIConstructors(type);
                file.Spacer();
            }

            file.Namespace(type.Namespace, true, () =>
            {
                file.GenerateInterface(type, Settings.FullIntellisense);
            });
        }

        public void GenerateClassDeclarationHeader(CppTreeWriter file, AST.Object type)
        {
            file.IncludeLocal(CommonLibraryHeader);

            if (type.BaseType != null)
                file.IncludeLocal(type.BaseType.Name + ".h");

            file.Line();

            file.Namespace(type.Namespace, false, () =>
            {
                file.GenerateClassDeclaration(type, Settings.FullIntellisense);
            });

            file.Line();
        }

        public void GenerateCommonImplementation(CppTreeWriter file)
        {
            if(!string.IsNullOrEmpty(Settings.PrecompiledHeader))
                file.IncludeLocal(Settings.PrecompiledHeader);
            file.IncludeLocal(CommonLibraryHeader);

            if (Settings.ConsolidateFiles)
                file.IncludeReferencedHeaders(AllGeneratedClasses.Cast<AST.Type>().Union(AllTranslatedStructs.Cast<AST.Type>()).Union(AllTranslatedDelegates.Cast<AST.Type>()), Definition.Assembly);

            file.Line(
@"

using namespace GluonInternal;
/*
extern __declspec(selectany)  CriticalSection g_ExceptionCSec;
extern __declspec(selectany)  HRESULT g_ExceptionHR = S_OK;
extern __declspec(selectany)  ABI::ExceptionType g_ExceptionType = ABI::ExceptionType::NoException;
extern __declspec(selectany)  std::string g_ExceptionMsg;

extern __declspec(selectany) HRESULT(*ABI::SetException)(HRESULT, ABI::ExceptionType, const char*) =
[](HRESULT hr, ABI::ExceptionType type, const char* msg)
{{
    AutoLock lock(g_ExceptionCSec);
    g_ExceptionHR = hr;
    g_ExceptionType = type;
    g_ExceptionMsg = msg;

    return hr;
}};

extern ""C"" __declspec(dllexport) HRESULT __stdcall $_GetGluonExceptionDetails(HRESULT* outHR, ABI::ExceptionType* outType, const char** outText)
{{
    if(!outHR || !outText) return E_POINTER;

    AutoLock lock(g_ExceptionCSec);
    *outHR = g_ExceptionHR;
    *outType = g_ExceptionType;
    *outText = g_ExceptionMsg.c_str();

    return S_OK;
}}
*/
void {0}_Initialize()", Settings.ProjectName, Definition.Assembly.Name.Replace('.', '_'));

            file.Block(() =>
            {
                foreach (var type in AllGeneratedClasses)
                {
                    var ns = type.Namespace.IsGlobal ? "ABI" : "ABI::" + type.Namespace.FullName("::");

                    if (!type.IsAbstract)
                    {
                        foreach (var constructor in type.Constructors)
                        {
                            file.Code($"{constructor.GetABIConstructorName(type)}(");
                            file.List(() =>
                            {
                                foreach (var arg in constructor.Parameters.GetABIParametersCpp())
                                {
                                    if (arg.IsWriteable())
                                        file.ListItem("nullptr");
                                    else
                                        file.ListItem("Def<{0}>()", file.VariableType(arg, AST.VariableContext.In, true));
                                }
                                file.ListItem("nullptr");
                            });

                            file.Line(");");
                        }
                    }
                }
            });
        }

        public void GenerateValueTypeConverters(CppTreeWriter file)
        {
            file.Strata = ApiStrata.Normal;
            if (!Settings.ConsolidateFiles)
            {
                if (!string.IsNullOrEmpty(Settings.PrecompiledHeader))
                    file.IncludeLocal(Settings.PrecompiledHeader);
                file.IncludeLocal(CommonLibraryHeader);
                file.IncludeReferencedHeaders(AllTranslatedStructs, Definition.Assembly);
                file.Line();
                file.DeferredUsings();
                file.Spacer();
            }

            file.Namespace(Definition.LookupNamespace("GluonInternal"), false, () =>
            {
                foreach (var x in AllTranslatedStructs)
                {
                    var typename = file.TypeRef(x, false);
                    var abitypename = file.TypeRef(x, true);
                    file.Line("{0} ABIUtil<{0}>::FromABI(const {1}& x)", typename, abitypename);
                    file.Block(() =>
                    {
                        file.Line("return {0}(", typename);
                        file.Indent++;
                        file.List(CodeListStyle.MultiLine, () =>
                        {
                            foreach (var field in x.Fields)
                            {
                                if (CppRender.RequiresABITranslation(field))
                                    file.ListItem("ABIUtil<{0}>::FromABI(x.{1})", file.TypeRef(field), field.Name);
                                else
                                    file.ListItem("x.{0}", field.Name);
                            }
                        });
                        file.Line(");");
                        file.Indent--;
                    });

                    file.Line("{0} ABIUtil<{1}>::ToABI(const {1}& x)", abitypename, typename);
                    file.Block(() =>
                    {
                        foreach (var field in x.Fields)
                            if (field.IsArray || field.Type.IsDelegate)
                            {
                                file.Line("auto {1}_ = ABIUtil<{2}>::ToABI(x.{1});", file.TypeRef(field.Type), field.Name, file.TypeRef(field));
                            }

                        file.Line("return {0}(", abitypename);
                        file.Indent++;
                        file.List(CodeListStyle.MultiLine, () =>
                        {
                            foreach (var field in x.Fields)
                            {
                                if (field.IsArray)
                                    file.ListItem("{0}_.begin(), (int){0}_.size()", field.Name);
                                else if (field.Type.IsDelegate)
                                    file.ListItem("({0}){1}_.Fn, {1}_.Ctx", file.TypeRef(field, true), field.Name);
                                else if (CppRender.RequiresABITranslation(field))
                                    file.ListItem("ABIUtil<{0}>::ToABI(x.{1})", file.TypeRef(field), field.Name);
                                else
                                    file.ListItem("x.{0}", field.Name);
                            }
                        });
                        file.Line(");");
                        file.Indent--;
                    });
                }
            });
        }

        public void GenerateDelegateConverters(CppTreeWriter file)
        {
            if (!Settings.ConsolidateFiles)
            {
                if (!string.IsNullOrEmpty(Settings.PrecompiledHeader))
                    file.IncludeLocal(Settings.PrecompiledHeader);
                file.IncludeLocal(CommonLibraryHeader);
                file.IncludeReferencedHeaders(AllTranslatedDelegateSignatures, Definition.Assembly);
                file.Line();
                file.DeferredUsings();
                file.Spacer();
            }

            file.Namespace(Definition.LookupNamespace("GluonInternal"), false, () =>
            {
                foreach (var x in AllTranslatedDelegateSignatures)
                    file.GenerateDelegateConverterImplementation(x);
            });
        }

        public void GenerateTaskWrappersABIHeader(CppTreeWriter file)
        {
            foreach (var tw in AllGeneratedTasks.Select(t => t.GetWrapperType(Definition)))
                file.Namespace(tw.Namespace, true, () =>
                {
                    file.GenerateInterface(tw, true);
                });
        }

        public void GenerateTaskWrappersHeader(CppTreeWriter file)
        {
            foreach (var tw in AllGeneratedTasks.Select(t => t.GetWrapperType(Definition)))
                file.Namespace(tw.Namespace, false, () =>
                {
                    file.GenerateClassDeclaration(tw, true, () =>
                    {
                        var resultProp = tw.Properties.FirstOrDefault(p => p.Name == "Result");
                        var resultTypeRef = resultProp == null ? "void" : file.TypeRef(resultProp.Type.ToVariable());

                        file.Indent--;
                        file.Line("public:");
                        file.Indent++;

                        file.Line($"{tw.Name}(concurrency::task<{resultTypeRef}>& ppl);");
                        file.Line($"concurrency::task<{resultTypeRef}>& GetPPL();");
                        file.Line("void SetException(HRESULT hr, ABI::ExceptionType type, const char* msg);");

                        file.Spacer();
                        file.Indent--;
                        file.Line("private:");
                        file.Indent++;

                        if (resultProp != null)
                            file.Line("{0} _result = DEFAULT_({0});", resultTypeRef);

                        file.Line($"concurrency::task_completion_event<{resultTypeRef}> _tce;");
                        file.Line($"concurrency::task<{resultTypeRef}> _ppl;");

                        var setCompletionCallback = tw.Methods.FirstOrDefault(m => m.Name == "SetCompletionCallback");
                        if (setCompletionCallback != null)
                        {
                            file.Line("{0} _status = DEFAULT_({0});", file.TypeRef(((AST.Delegate)setCompletionCallback.Parameters[0].Type).Parameters[1].Morph(null, AST.VariableContext.Member)));
                            file.Line($"{file.TypeRef(setCompletionCallback.Parameters[0].Morph(null, AST.VariableContext.Member))} _cb;");
                        }

                        var notifyException = tw.Methods.FirstOrDefault(m => m.Name == "NotifyException");
                        if (notifyException != null)
                        {
                            file.Line("{0} _extype = DEFAULT_({0});", file.TypeRef(notifyException.Parameters[0].Morph(null, AST.VariableContext.Member)));
                            file.Line($"{file.TypeRef(notifyException.Parameters[1].Morph(null, AST.VariableContext.Member))} _msg;");
                        }
                    });
                });
        }

        public void GenerateTaskWrappersImplementation(CppTreeWriter file)
        {
            var wrappers = AllGeneratedTasks.Select(t => t.GetWrapperType(Definition)).ToArray();

            var ns = wrappers.First().Namespace;

            file.Namespace(ns, false, () =>
            {
                // Generate wrapper implementation
                foreach (var tw in wrappers)
                {
                    var resultProp = tw.Properties.FirstOrDefault(p => p.Name == "Result");

                    foreach (var c in tw.Constructors)
                        file.ConstructorImplementation(c, tw, () => { }, new string[] { "_tce()", "_ppl(_tce)" });

                    file.Spacer();
                    file.Line(
@"{0}::{1}(concurrency::task<{2}>& ppl) : _ppl(ppl) 
{{
    _ppl.then([=]()
    {{
        auto finalStatus = GluonTaskStatus::Failed;
        try {{ _result = _ppl.get(); finalStatus = GluonTaskStatus::Complete; }}
        TRANSLATE_EXCEPTIONS
        catch(concurrency::task_canceled) {{ finalStatus = GluonTaskStatus::Canceled; }}
        _status = finalStatus;
        _cb(this, _status);
    }});
}}

{0}::SetException(HRESULT hr, ABI::ExceptionType type, const char* msg)
{{
    _extype = type;
    _msg = msg;
}}
",                      file.TypeRef(tw), tw.Name, resultProp == null ? "void" : file.TypeRef(resultProp));

                    if (resultProp != null)
                    {
                        file.MethodImplementation(resultProp.CreateGetter(), tw, () => file.Line("return _result;"));
                        file.MethodImplementation(resultProp.CreateSetter(), tw, () => file.Line("_result = value;"));
                    }

                    var setCompletionCallback = tw.Methods.FirstOrDefault(m => m.Name == "SetCompletionCallback");
                    if(setCompletionCallback != null)
                        file.MethodImplementation(setCompletionCallback, tw, () => file.Line("_cb = cb;"));

                    var getException = tw.Methods.FirstOrDefault(m => m.Name == "GetException");
                    if (getException != null)
                        file.MethodImplementation(getException, tw, () =>
                        {
                            file.Line("*type = _extype;");
                            file.Line("*msg = _msg;");
                        });

                    var notifyComplete = tw.Methods.FirstOrDefault(m => m.Name == "NotifyComplete");
                    if (notifyComplete != null)
                        file.MethodImplementation(notifyComplete, tw, () =>
                        {
                            file.Line("_status = GluonTaskStatus::Complete;");
                            file.Line("_tce.set(_result);");
                        });

                    var notifyCanceled = tw.Methods.FirstOrDefault(m => m.Name == "NotifyCanceled");
                    if (notifyCanceled != null)
                        file.MethodImplementation(notifyCanceled, tw, () =>
                        {
                            file.Line("_status = GluonTaskStatus::Canceled;");
                            file.Line("_tce.set_exception(concurrency::task_canceled());");
                        });

                    var notifyException = tw.Methods.FirstOrDefault(m => m.Name == "NotifyException");
                    if (notifyException != null)
                        file.MethodImplementation(notifyException, tw, () =>
                        {
                            file.Line("_extype = type;");
                            file.Line("_msg = msg;");
                            file.Line("_status = GluonTaskStatus::Failed;");
                            file.Line("_tce.set_exception(TRANSLATE_TASK_EXCEPTION(type, msg));");
                        });
                }
            });

            file.Namespace(ns, true, () =>
            {
                // Generate wrapper ABI implementation
                foreach (var tw in wrappers)
                    GenerateClassABIImplementation(file, tw);
            });
        }

        public void GenerateClassImplementation(CppTreeWriter file, AST.Object type)
        {
            var localTranslations = CppRender.GetLocalTranslations(type);

            file.LocalTranslationsBlock(localTranslations, () =>
            {
                if (!string.IsNullOrEmpty(Settings.PrecompiledHeader))
                    file.IncludeLocal(Settings.PrecompiledHeader);
                file.IncludeLocal(CommonLibraryHeader);
                file.IncludeLocal(type.Name + ".h");

                foreach (var r in type.SelectReferencedTypes().Where(t => t is AST.Object && t.Assembly == Definition.Assembly))
                    file.IncludeLocal(r.Name + ".h");

                file.Line();
                file.DeferredUsings();
                file.Line();
                file.Line();

                foreach (var c in type.Constructors)
                    file.ConstructorImplementation(c, type);

                foreach (var p in type.Properties.Where(prop => !prop.IsAbstract))
                {
                    file.MethodImplementation(p.CreateGetter(), type);

                    if (!p.IsReadOnly)
                        file.MethodImplementation(p.CreateSetter(), type);
                }

                foreach (var e in type.Events.Where(ev => ev.IsVirtual))
                {
                    file.MethodImplementation(e.CreateAdder(), type);
                    file.MethodImplementation(e.CreateRemover(), type);
                }

                foreach (var m in type.Methods.Where(method => !method.IsAbstract))
                    file.MethodImplementation(m, type);

                foreach (var iface in type.Interfaces.Where(i => i.Origin != TypeOrigin.Native))
                    foreach (var m in iface.Methods)
                        file.MethodImplementation(m, type);
            });
        }

        public void GenerateClassABIImplementation(CppTreeWriter file, AST.Object type)
        {
            var localTranslations = CppRender.GetLocalTranslations(type);

            if (!Settings.ConsolidateFiles)
            {
                if (!string.IsNullOrEmpty(Settings.PrecompiledHeader))
                    file.IncludeLocal(Settings.PrecompiledHeader);
                file.IncludeLocal(CommonLibraryHeader);
                file.IncludeLocal(type.Name + ".h");

                foreach (var r in type.SelectReferencedTypes().Where(t => t.Assembly == Definition.Assembly))
                {
                    if (r is AST.Object)
                    {
                        if (r.Origin == TypeOrigin.Native)
                        {
                            if (!string.IsNullOrEmpty(r.CppHeader))
                                file.Include(r.CppHeader);
                        }
                        else
                            file.IncludeLocal(r.Name + ".h");
                    }
                }

                file.Line();
                file.Line("using namespace GluonInternal;");
                file.DeferredUsings();
                file.Line();
                file.Line();
            }

            if (!Settings.FullIntellisense)
            {
                file.Directive("#ifndef __INTELLISENSE__");
                file.Line();
            }

            file.LocalTranslationsBlock(localTranslations, () =>
            {
                if (!type.IsAbstract)
                    foreach (var c in type.Constructors)
                        file.ConstructorImplementation(c, type);

                foreach (var m in type.Methods)
                {
                    if (type.IsMethodOverride(m)) continue;
                    file.MethodImplementation(m, type);
                }

                file.Strata = ApiStrata.ABI;
                foreach (var prop in type.Properties)
                {
                    file.MethodImplementation(prop.CreateGetter(), type);
                    //file.PropertyGetterImplementation(prop, type);

                    if (!prop.IsReadOnly)
                        file.MethodImplementation(prop.CreateSetter(), type);
                        //file.PropertySetterImplementation(prop, type);
                }

                foreach (var ev in type.Events)
                {
                    file.EventABIImplementation(ev, type);
                }

                foreach (var iface in type.Interfaces)
                {
                    if (iface.Origin == TypeOrigin.Native) continue;

                    foreach (var m in iface.Methods)
                        file.MethodImplementation(m, type);
                }
            });

            if (!Settings.FullIntellisense)
                file.Directive("#endif");
        }

        public void ModifyClassDeclarationHeader(string path, AST.Object type)
        {
            var writer = new CppRender();

            writer.WorkingNamespace = type.Namespace;
            writer.Strata = ApiStrata.Normal;
            writer.FullIntellisense = Settings.FullIntellisense;
            writer.PimplMode = false;

            var cpp = new CppTreeWriter(Settings);

            for (var ns = type.Namespace; ns != null && !ns.IsGlobal; ns = ns.Parent)
                cpp.Indent++;
            cpp.GenerateClassHeaderMembers(type, Settings.FullIntellisense);

            var parser = new CppParser(File.ReadAllText(path));

            var classDecl = parser.Tree.FirstOrDefault(t => t.Type == TkType.ClassDef);
            if (classDecl != null)
            {
                Token comid = null;
                bool found = false;
                foreach (var tok in classDecl.Significant)
                {
                    if (found)
                    {
                        comid = tok;
                        break;
                    }

                    if (tok.Type == TkType.KwComid)
                        found = true;
                }

                if(comid != null)
                    comid.Value = string.Format("(\"{0}\")", type.PrivateId);

                List<string> existingBaseTypes = new List<string>();
                var tpl = classDecl.Tree.FirstOrDefault(t => t.Type == TkType.TemplateBlock);
                if (tpl != null)
                {
                    StringBuilder baseSB = new StringBuilder();

                    Token start = null;
                    foreach (var tok in tpl.Significant)
                    {
                        switch(tok.Type)
                        {
                            case TkType.LAngle:
                                start = tok;
                                break;
                            case TkType.RAngle:
                            case TkType.Comma:
                                foreach (var lexTok in tpl.Lexical.SkipWhile(lt => lt != start).Skip(1).TakeWhile(lt => lt != tok))
                                    baseSB.Append(lexTok.ToString());
                                if(baseSB.Length != 0)
                                    existingBaseTypes.Add(baseSB.ToString().Trim());
                                baseSB.Clear();
                                start = tok;
                                break;
                        }
                    }

                    if (existingBaseTypes.Count > 0)
                        existingBaseTypes[0] = type.Name;
                    else
                        existingBaseTypes.Add(type.Name);

                    var baseType = type.BaseType != null ? writer.TypeName(type.BaseType) : "Object";
                    if (existingBaseTypes.Count > 1)
                        existingBaseTypes[1] = baseType;
                    else
                        existingBaseTypes.Add(baseType);

                    var abiBaseType = writer.TypeName(type, true);

                    if (!existingBaseTypes.Contains(abiBaseType))
                        existingBaseTypes.Add(abiBaseType);
                    foreach(var iface in type.Interfaces)
                    {
                        var ifaceType = writer.TypeName(iface, true);
                        if (!existingBaseTypes.Contains(ifaceType))
                            existingBaseTypes.Add(ifaceType);
                    }


                    var sb = new StringBuilder();
                    sb.Append("<");
                    sb.Append(existingBaseTypes[0]);
                    for(int i = 1;i < existingBaseTypes.Count; i++)
                    {
                        sb.Append(", ");
                        sb.Append(existingBaseTypes[i]);
                    }
                    sb.Append(">");

                    tpl.Value = sb.ToString();
                }
            }

            cpp.Tree.Resolve(writer);

            // look for gluon maintained region
            foreach (var rgn in parser.Tree.Where(t => t.Type == TkType.Region))
            {
                var sb = new StringBuilder();
                foreach (var rgntok in rgn.Significant.Where((tt, i) => i >= 3 && i < 5))
                    sb.Append(rgntok.ToString());

                if(!sb.ToString().Contains("GluonMaintained"))
                    continue;
                
                rgn.Value = writer.ToString().Trim();
                break;
            }

            U.WriteFileIfModified(path, parser.ToString());
            OutputFiles.Add(path);
        }

        public void ModifyClassImplementation(string path, AST.Object type)
        {
            var parser = new CppParser(File.ReadAllText(path));

            var funcs = parser.Contents
                .Where(token => token.Type == TkType.FunctionDef)
                .Select(token => new FunctionDefToken(token))
                .Where(token => token.BodyBlock != null).ToArray();

            List<string> pendingFuncs = new List<string>();

            var writer = new CppRender();
            writer.Strata = ApiStrata.Normal;
            writer.WorkingNamespace = type.Namespace;

            var localTranslations = CppRender.GetLocalTranslations(type);

            Action<AST.Method> processMethod = m =>
            {
                var tok = new CppTreeWriter(Settings);
                tok.LocalTranslationsBlock(localTranslations, () => tok.MethodImplementation(m, type));
                tok.Tree.Resolve(writer);
                pendingFuncs.Add(writer.ToString());
                writer.Clear();
            };

            Action<Token> stripNames = tok =>
            {
                if (tok.Type == TkType.FunctionDef)
                    tok = tok.Significant.Where(stok => stok.Type == TkType.FunctionSig).FirstOrDefault();

                if (tok == null || tok.Type != TkType.FunctionSig)
                    return;

                tok = tok.Significant.Where(stok => stok.Type == TkType.ParenBlock).FirstOrDefault();
                if (tok == null)
                    return;

                //List<Token> remove = new List<Token>();

                var sigSubs = tok.Significant.ToArray();

                if (sigSubs.Length == 2)
                    return;

                var lastTerm = sigSubs[sigSubs.Length - 2];
                if (lastTerm.Type == TkType.Identifier || lastTerm.Type == TkType.QualifiedId)
                    lastTerm.Exclude = true;
                    //remove.Add(lastTerm);

                for(int i = 1;i < sigSubs.Length - 1;i++)
                {
                    if(sigSubs[i].Type == TkType.Comma)
                    {
                        if (sigSubs[i - 1].Type == TkType.Identifier || lastTerm.Type == TkType.QualifiedId)
                            sigSubs[i - 1].Exclude = true;
                            //remove.Add(sigSubs[i - 1]);
                    }
                }

                var qns = tok.Tree.Where(t => t.Type == TkType.QualifiedId).ToArray();

                foreach(var qn in qns)
                {
                    var lastNamescope = qn.Significant.LastOrDefault(t => t.Type == TkType.Namescope);
                    if (lastNamescope != null)
                    {
                        foreach (var exToken in qn.Subs)
                        {
                            exToken.Exclude = true;
                            if (exToken == lastNamescope)
                                break;
                        }
                    }
                }

                //foreach (var r in remove)
                //    tok.Subs.Remove(r);
            };

            foreach (var f in funcs)
                stripNames(f.Original);

            var sb = new StringBuilder();
            sb.Append(parser.OriginalCode);
            if (!parser.OriginalCode.EndsWith("\n"))
                sb.AppendLine();

            foreach (var c in type.Constructors)
            {
                var tok = new CppTreeWriter(Settings);
                tok.LocalTranslationsBlock(localTranslations, () => tok.ConstructorImplementation(c, type));
                tok.Tree.Resolve(writer);
                pendingFuncs.Add(writer.ToString());
                writer.Clear();
            }

            foreach (var p in type.Properties.Where(prop => !prop.IsAbstract))
            {
                processMethod(p.CreateGetter());

                if (!p.IsReadOnly)
                {
                    processMethod(p.CreateSetter());
                }
            }

            foreach (var e in type.Events.Where(ev => ev.IsVirtual))
            {
                processMethod(e.CreateAdder());
                processMethod(e.CreateRemover());
            }

            foreach (var m in type.Methods.Where(method => !method.IsAbstract))
                processMethod(m);

            foreach (var iface in type.Interfaces.Where(i => i.Origin != TypeOrigin.Native))
                foreach (var m in iface.Methods)
                    processMethod(m);

            foreach (var fstr in pendingFuncs)
            {
                var fparser = new CppParser(fstr);

                var ftoken = fparser.Contents.FirstOrDefault(t => t.Type == TkType.FunctionDef);

                stripNames(ftoken);

                bool exists = false;
                foreach (var f in funcs)
                {
                    if (ftoken.Type != f.Original.Type)
                        continue;

                    var e1 = ftoken.SignificantLexical.GetEnumerator();
                    var e2 = f.Original.SignificantLexical.GetEnumerator();

                    Token end = f.Signature.SignificantLexical.Last();

                    bool n1, n2;
                    while (true)
                    {
                        n1 = e1.MoveNext();
                        n2 = e2.MoveNext();

                        if (!n1)
                            break;

                        if (e1.Current.Type != e2.Current.Type || e1.Current.Value != e2.Current.Value)
                        {
                            n1 = !n2;
                            break;
                        }

                        if (e2.Current == end)
                            break;
                    }

                    if (n1 == n2)
                    {
                        exists = true;
                        break;
                    }
                }

                if (!exists)
                {
                    sb.Append(fstr);
                }
            }

            U.WriteFileIfModified(path, sb.ToString());
        }

        #region Internal

        class FunctionDefToken
        {
            public Token Original { get; private set; }

            public FunctionDefToken(Token tok)
            {
                Original = tok;

                var sb = new StringBuilder();

                foreach (var sub in tok.Significant)
                {
                    if (sub.Type == TkType.Block)
                    {
                        BodyBlock = sub;

                        break;
                    }
                    if (sub.Type == TkType.FunctionSig && Signature == null)
                        Signature = sub;
                }
            }
            
            public Token Signature { get; private set; }
            public Token ParamBlock { get; private set; }
            public Token BodyBlock { get; private set; }
        }
        
        private CppTreeWriter CreateSourceFile(bool modifiable)
        {
            var writer = new CppTreeWriter(new PascalTree(), Settings);

            if (!modifiable)
            {
                writer.BlockComment(() =>
                {
                    writer.Line(Disclaimer);
                });
                writer.Line();
                writer.Line("// clang-format off");
                writer.Line();
            }

            return writer;
        }

        private void WriteFile(string path, bool modifiable, bool abi, Action<CppTreeWriter> dostuff, bool pimpl = false)
        {
            var file = CreateSourceFile(modifiable);
            file.Strata = abi ? ApiStrata.ABI : ApiStrata.Normal;
            file.TargetPath = path;

            if (path.ToLower().EndsWith(".h"))
                file.Directive("#pragma once");

            dostuff(file);
            Render(file, path, pimpl);
        }

        private void Render(PascalTreeWriter treeWriter, string path, bool pimpl = false)
        {
            var writer = new CppRender();
            writer.FullIntellisense = Settings.FullIntellisense;
            writer.PimplMode = pimpl;

            treeWriter.InsertUsings();
            treeWriter.Tree.Resolve(writer);
            U.WriteFileIfModified(path, writer.ToString());
            OutputFiles.Add(path);
        }

        private void FindDelegateSignatures()
        {
            Func<AST.IVariable, AST.IVariable, bool> argCompare = null;
            Func<AST.Delegate, AST.Delegate, bool> delegateCompare = (d1, d2) =>
            {
                if (d1 == null || d2 == null)
                    return false;

                if (d1.Parameters.Count != d2.Parameters.Count)
                    return false;

                if (!argCompare(d1.Return, d2.Return))
                    return false;

                for (int i = 0; i < d1.Parameters.Count; i++)
                    if (!argCompare(d1.Parameters[i], d2.Parameters[i]))
                        return false;

                return true;
            };

            argCompare = (arg1, arg2) =>
            {
                if (arg1.IsArray != arg2.IsArray)
                    return false;
                if (arg1.IsIn != arg2.IsIn)
                    return false;
                if (arg1.IsOut != arg2.IsOut)
                    return false;
                if (arg1.IsRef != arg2.IsRef)
                    return false;

                if (arg1.Type.ConstructType == AST.Construct.Delegate &&
                    arg2.Type.ConstructType == AST.Construct.Delegate)
                    return delegateCompare((AST.Delegate)arg1.Type, (AST.Delegate)arg2.Type);
                else
                    return arg1.Type.Equals(arg2.Type);
            };

            foreach (var type in AllTranslatedDelegates)
            {
                var has = AllTranslatedDelegateSignatures.Any(other => delegateCompare(type, other));

                if (!has)
                    AllTranslatedDelegateSignatures.Add(type);
            }
        }

        private void PreprocessDefinition()
        {
            Definition.ApplyNamespaceSubsitutions(Settings.TargetId);

            {
                var builder = new AST.Builder(Definition);
                _projectDetailsNamespace = builder.Resolve(Settings.ProjectName + "::Details");
            }

            foreach (var type in SelectGeneratedTypes())
            {
                if (type.Assembly != Definition.Assembly && type.Assembly.IsGluonDefinition) continue;

                if (type.Origin == TypeOrigin.Gluon || type.Origin == TypeOrigin.Managed)
                {
                    if (type.IsObject)
                        AllGeneratedClasses.Add((AST.Object)type);
                    else if (type.IsStruct)
                        AllGeneratedStructs.Add((AST.Struct)type);
                    else if (type.IsEnum)
                        AllGeneratedEnums.Add((AST.Enum)type);
                    else if (type.IsDelegate)
                        AllGeneratedDelegates.Add((AST.Delegate)type);
                    else if (type.IsTask)
                        AllGeneratedTasks.Add((AST.Task)type);
                }
                else if (type.CppHeader != null && !AllDependentLibraries.Contains(type.CppHeader))
                    AllDependentLibraries.Add(type.CppHeader);
            }

            foreach(var type in Definition.AllTypes)
            {
                if (type.IsDelegate)
                    AllTranslatedDelegates.Add((AST.Delegate)type);
                else if (type.IsStruct && CppRender.RequiresABITranslation(type.ToVariable()))
                    AllTranslatedStructs.Add((AST.Struct)type);
            }

            foreach (var type in BasicTypes.AllBasicTypes.Where(t => t.Namespace == BasicTypes.SystemNamespace))
                type.Namespace = BasicTypes.GlobalNamespace;

            BasicTypes.String.Name = "string";
            BasicTypes.Char.Name = "char";
            BasicTypes.SByte.Name = "int8_t";
            BasicTypes.UInt32.Name = "uint32_t";
            BasicTypes.Int64.Name = "int64_t";
            BasicTypes.UInt64.Name = "uint64_t";
            BasicTypes.IntPtr.Name = "void*";
            BasicTypes.UIntPtr.Name = "void*";
            BasicTypes.UInt16.Name = "uint16_t";

            Definition.StripAllAttributes();
            Definition.StripUnreferencedTypes(TypeOrigin.Native);
            Definition.StripEmptyNamespaces();
            Definition.ApplyNativeMappedTypes(Settings.TargetId);
            Definition.RenameParametersToClarifyContext();
            Definition.PutDefaultConstructorsFirst();
            Definition.InsertDefaultConstructorsWhereNoneAreDefined();

            // Make sure the GluonInternal and <Assembly> namespaces gets created
            var gluonInternalNS = Definition.LookupNamespace("GluonInternal");
            if(gluonInternalNS == null)
            {
                gluonInternalNS = new AST.Namespace();
                gluonInternalNS.Name = "GluonInternal";
                gluonInternalNS.Parent = BasicTypes.GlobalNamespace;
                Definition.DependentNamespaces.Add(gluonInternalNS);
            }

            FindDelegateSignatures();
        }

        private AST.Namespace _projectDetailsNamespace;

        #endregion
    }
}
