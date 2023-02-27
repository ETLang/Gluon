using Gluon.PascalTreeCppExtensions;
using Gluon.PascalTreeNodes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gluon
{
    public class CppTreeWriter : PascalTreeWriter
    {
        public CppTreeWriter(GeneratorSettingsCpp settings) { Settings = settings; }
        public CppTreeWriter(PascalTree tree, GeneratorSettingsCpp settings) : base(tree) { Settings = settings; }
        public GeneratorSettingsCpp Settings { get; private set; }
        public bool PimplMode { get; set; }

        public string TargetPath { get; set; }

        #region Writer Ops

        #region UseLocalTranslations

        public bool UseLocalTranslations
        {
            get { return _UseLocalTranslations; }
            set
            {
                if (_UseLocalTranslations == value) return;
                _UseLocalTranslations = value;

                Insert(new LocalTranslationStateNode(value));
            }
        }
        private bool _UseLocalTranslations = true;

        #endregion

        public IncludeBlock DeferredIncludes()
        {
            var block = new IncludeBlock();
            Insert(block);
            return block;
        }

        public void IncludeLocal(string dir, string file)
        {
            IncludeLocal(Path.Combine(dir, file));
        }

        public void Include(string path)
        {
            Insert(new IncludeNode(path));
        }

        public void IncludeLocal(string path)
        {
            if (Path.IsPathRooted(path))
                path = U.GetRelativePath(path, Path.GetDirectoryName(TargetPath));

            Insert(new IncludeNode(path, true));
        }

        public void LocalTranslationsBlock(Dictionary<AST.Type, string> translations, Action content)
        {
            InsertAndPushTarget(new LocalTranslationsBlock(translations));
            content();
            PopTarget();
        }

        #endregion

        #region High Level Generators

        public string Signature(AST.ICallSignature d, bool? abi = null)
        {
            var sigNode = new PascalTree();
            InsertAndPushTarget(sigNode);

            var useabi = abi ?? Strata == ApiStrata.ABI;

            if (useabi)
                Code("HRESULT");
            else
                Code(VariableType(d.Return, AST.VariableContext.Return, useabi));

            Code("(");
            List(useabi ? CodeListStyle.Compact : CodeListStyle.SingleLine, () =>
            {
                foreach (var arg in useabi ? d.GetABIParametersCpp(true) : d.Parameters)
                    ListItem(VariableType(arg, useabi));
            });
            Code(")");

            PopTarget();
            Index--;
            Delete();

            return InlineNode(sigNode);
        }

        public void ABIWrapperParameterValidation(AST.ICallSignature m)
        {
            foreach (var arg in m.GetABIParametersCpp())
            {
                if (arg.IsWriteable())
                    Line("if(!{0}) return E_POINTER;", arg.Name);
            }
            Spacer();
        }

        public void ABIWrappedCall(AST.ICallSignature m, string returnArg = null, string callNameOverride = null)
        {
            string name = m.Name;
            if (!string.IsNullOrEmpty(callNameOverride))
                name = callNameOverride;

            if (returnArg == null)
                returnArg = m.Return.Name;

            Code("try ");
            Block(() =>
            {
                var args = m.Parameters;

                if (!m.Return.IsVoid)
                {
                    if (m.Return.IsArray)
                    {
                        string refType = VariableType(m.Return.Type.ToVariable(), true);
                        Code("ABI::ArrayRef<{0}>({1}, {1}_count) = ABIUtil<{2}>::ToABI({3}(",
                            refType, returnArg, TypeRef(m.Return, false), name);
                    }
                    else if (m.Return.Type.IsDelegate)
                    {
                        string refType = TypeRef(m.Return.Type, true);
                        Code("ABI::DelegateRef<{0}>({1}, {1}_context) = ABIUtil<{2}>::ToABI({3}(",
                            refType, returnArg, TypeRef(m.Return, false), name);
                    }
                    else if (CppRender.RequiresABITranslation(m.Return))
                        Code("*{0} = ABIUtil<{1}>::ToABI({2}(", returnArg, TypeRef(m.Return, false), name);
                    else
                        Code("*{0} = {1}(", returnArg, name);
                }
                else
                    Code($"{name}(");

                if (args.Count > 1)
                    Line();

                List(args.Count > 1 ? CodeListStyle.MultiLine : CodeListStyle.SingleLine, () =>
                {
                    if (args.Count > 1)
                        Indent++;

                    foreach (var arg in args)
                    {
                        if (CppRender.RequiresABITranslation(arg))
                        {
                            string fwd;

                            if (arg.IsArray)
                                fwd = arg.Name + ", " + arg.Name + "_count";
                            else if (arg.Type.IsDelegate)
                                fwd = "(void**)" + arg.Name + ", " + arg.Name + "_context";
                            else
                                fwd = arg.Name;

                            if (arg.IsOut || arg.IsRef)
                                ListItem($"ABIUtil<{TypeRef(arg, false)}>::Ref({fwd})");
                            else
                                ListItem($"ABIUtil<{TypeRef(arg, false)}>::FromABI({fwd})");
                        }
                        else
                            ListItem(arg.Name);
                    }

                    if (args.Count > 1)
                        Indent--;
                });

                if (!m.Return.IsVoid && CppRender.RequiresABITranslation(m.Return))
                    Line("));");
                else
                    Line(");");
                Line("return S_OK;");
            }, " TRANSLATE_EXCEPTIONS");
        }

        public void GenerateEnum(AST.Enum type)
        {
            Spacer();
            WriteXmlDocumentation(type.XmlDoc);
            Line("enum class {0} : {1}", type.Name, TypeRef(type.UnderlyingType));
            Block(() =>
            {
                List(CodeListStyle.MultiLine, () =>
                {
                    int len = type.Entries.Max(entry => entry.Name.Length) + 1;
                    bool broke = false;

                    for (int i = 0; i < type.Entries.Count; i++)
                    {
                        var entry = type.Entries[i];
                        broke = broke || entry.Value != i;

                        WriteXmlDocumentation(entry.XmlDoc);
                        if (broke)
                            ListItem("{0,-" + len + "} = 0x{1:X8}", entry.Name, entry.Value);
                        else
                            ListItem(entry.Name);
                    }
                });
            }, ";");
        }

        public void GenerateStruct(AST.Struct type, bool abi)
        {
            var strata = Strata;
            Guid id = (strata == ApiStrata.ABI ? type.Id : type.PrivateId);

            Namespace(type.Namespace, abi, () =>
            {
                var localTranslations = CppRender.GetLocalTranslations(type);

                if (strata == ApiStrata.ABI)
                    localTranslations = null;

                var fields = type.Fields;

                Spacer();

                WriteXmlDocumentation(type.XmlDoc);
                Line("struct comid(\"{0}\") {1}", id, type.Name);
                Block(() =>
                {
                    if (strata == ApiStrata.Normal && CppRender.RequiresABITranslation(type.ToVariable()))
                    {
                        Line("typedef {0} ABIType;", TypeRef(type, true));
                        Spacer();
                    }

                    if (localTranslations != null)
                    {
                        UseLocalTranslations = false;
                        foreach (var kvp in localTranslations)
                            Line("using {0} = {1};", kvp.Value, TypeRef(kvp.Key, false));
                        UseLocalTranslations = true;
                        Spacer();
                    }

                    LocalTranslationsBlock(localTranslations, () =>
                    {
                        foreach (var field in fields)
                        {
                            WriteXmlDocumentation(field.XmlDoc);
                            Line("{0} {1};", VariableType(field, AST.VariableContext.Member), field.Name);
                        }

                        Spacer();

                        // Default constructor
                        Line("{0}() {{ }}", type.Name);

                        // Full constructor
                        var constructorArgs = fields.Select(f => f.Morph("_" + f.Name, AST.VariableContext.In));
                        if (strata == ApiStrata.ABI)
                            constructorArgs = constructorArgs.GetABIParametersCpp();

                        Line("{0}({1}) : ", type.Name, DeclParameters(constructorArgs));
                        Indent++;
                        List(() =>
                        {
                            foreach (var field in fields)
                            {
                                if (strata == ApiStrata.ABI && field.IsArray)
                                    ListItem("{0}(_{0}, _{0}_count)", field.Name);
                                else if (strata == ApiStrata.ABI && field.Type.IsDelegate)
                                    ListItem("{0}(_{0}, _{0}_context)", field.Name);
                                else
                                    ListItem("{0}(_{0})", field.Name);
                            }
                        });
                        Indent--;
                        Line();
                        Line("{ }");
                    });
                }, ";");
            });

            var prefix = (abi ? "::ABI" : "");

            if (type.Namespace.IsGlobal)
                Line(@"IS_VALUETYPE({0}::{1}, ""{2}"");", prefix, type.Name, id);
            else
                Line(@"IS_VALUETYPE({0}::{1}::{2}, ""{3}"");", prefix, type.Namespace.FullName("::"), type.Name, id);
        }

        public void GenerateInterfaceMembers(AST.Object type, bool pure)
        {
            var suffix = pure ? " = 0" : "";

            Region(() =>
            {
                Action<AST.Method> declare = m =>
                {
                    if (type.IsMethodOverride(m)) return;

                    Line($"METHOD _{m.GetComCompatibleName()}({DeclParameters(m.GetABIParametersCpp())}){suffix};");
                };

                foreach (var method in type.Methods)
                    declare(method);
                Spacer();

                foreach (var prop in type.Properties)
                {
                    declare(prop.CreateGetter());

                    if (!prop.IsReadOnly)
                        declare(prop.CreateSetter());
                }
                Spacer();

                foreach (var ev in type.Events)
                {
                    declare(ev.CreateAdder());
                    declare(ev.CreateRemover());
                }
            });
        }

        public void DeclareABIConstructors(AST.Object type)
        {
            Strata = ApiStrata.ABI;
            if (!type.IsAbstract)
            {
                foreach (var constructor in type.Constructors)
                    Line($"ABI_CONSTRUCTOR {constructor.GetABIConstructorName(type)}({DeclParameters(constructor.GetABIParametersCpp(), $"{TypeRef(type, true)}** outInstance")});");
            }
        }

        public void GenerateInterface(AST.Object type, bool fullIntellisense = false)
        {
            Strata = ApiStrata.ABI;
            Line($"cominterface comid(\"{type.Id}\") {type.Name} : public IUnknown");
            Block(() =>
            {
                if (!fullIntellisense)
                    Directive("#ifndef __INTELLISENSE__");

                GenerateInterfaceMembers(type, true);

                if (!fullIntellisense)
                    Directive("#endif");
            }, ";");
        }

        public void GenerateClassDeclaration(AST.Object type, bool fullIntellisense = false, Action additionalDeclarations = null)
        {
            // Set up generator state, figure out the class ID, other vars
            Strata = ApiStrata.Normal;

            // Class Signature
            Line($"class comid(\"{type.PrivateId}\")");
            Code("{0} : public ComObject<{0}, {1}, ::ABI::IGluonObject, {2}",
                type.Name,
                type.BaseType != null ? TypeRef(type.BaseType) : "Object",
                TypeRef(type, true));

            foreach (var iface in type.Interfaces)
                Code($", {TypeRef(iface, true)}");

            Line(">");
            Line("{");
            GenerateClassHeaderMembers(type, fullIntellisense);

            if (additionalDeclarations != null)
            {
                Spacer();
                additionalDeclarations();
            }
            Code("};");
        }

        public void GenerateDelegateConverterDeclaration(AST.Delegate type)
        {
            var name = "DW" + type.ShortId;

            Strata = ApiStrata.ABI;
            var dSig = Signature(type, false);
            Line(
$@"class comid(""{type.Id}"") {name} : public ComObject<{name}, Object>, public ABI::DelegateWrapperBase<{name},
    {dSig}>
{{
public:");
            Indent++;
            Line($"DW{type.ShortId}(const Delegate<{dSig}>& d) : DBase(d) {{ }}");
            //Line($"static Delegate<{dSig}> Lookup({TypeRef(type)} fptr, IObject* ctx);");
            Code($"static HRESULT __stdcall AbiFunc({DeclParameters(type.GetABIParametersCpp(true))})");

            if (PimplMode)
            {
                Block(() =>
                {
                    Code("return __P_AbiFunc(");
                    List(CodeListStyle.SingleLine, () =>
                    {
                        foreach (var p in type.GetABIParametersCpp(true))
                            ListItem(p.Name);
                    });
                    Line(");");
                });
            }
            else
                Line(";");

            Indent--;

            if (PimplMode)
            {
                Line("private:");
                Indent++;
                Line("template<typename = void>");
                Line($"static HRESULT __P_AbiFunc({DeclParameters(type.GetABIParametersCpp(true))});");
                Indent--;
            }

            Line("};");
            Spacer();
        }

        public void GenerateDelegateConverterUtilDeclaration(AST.Delegate type, AST.Namespace converterNS)
        {
            var typeRef = TypeRef(type, false);

            Strata = ApiStrata.Normal;
            Line($"template<> struct ABIUtil<{typeRef}> : public ABIUtilForDelegates<{Signature(type)}>");
            Block(() =>
            {
                Line($"typedef {converterNS.FullName("::")}::DW{type.ShortId} DW{type.ShortId};");
                Spacer();
                
                //Line($"Delegate<{Signature(type, false)}> DW{type.ShortId}::Lookup({TypeRef(type)} fptr, IObject* ctx)");
                Code($"static {typeRef} FromABI(void* fptr, IObject* ctx)");
                if (PimplMode)
                {
                    Line();
                    DelegateFromAbiImplementation(type);
                    Spacer();
                }
                else
                    Line(";");

                Code($"static ABI::DelegateBlob ToABI(const {typeRef}& x)");
                if (PimplMode)
                {
                    Line();
                    DelegateToAbiImplementation(type);
                    Spacer();
                }
                else
                    Line(";");

                Line($"static {typeRef} FromABI(const ABI::DelegateBlob& abi)");
                Block(() =>
                {
                    Line($"return FromABI(abi.Fn, abi.Ctx);");
                });
            }, ";");
        }

        public void GenerateDelegateConverterImplementation(AST.Delegate type)
        {
            const string dName = "___del";

            Strata = ApiStrata.ABI;
            var typeRef = TypeRef(type, false);
            var typeRefABI = TypeRef(type, true);

            if (PimplMode)
                Line("template<typename>");
            Line($"HRESULT DW{type.ShortId}::{(PimplMode ? "__P_" : "")}AbiFunc({DeclParameters(type.GetABIParametersCpp(true))})");
            Block(() =>
            {
                Line($"auto {dName} = runtime_cast<DW{type.ShortId}>(__i_);");
                Line($"if (!{dName}) return E_FAIL;");
                Spacer();
                ABIWrapperParameterValidation(type);
                ABIWrappedCall(type, null, $"{dName}->Func");
            });
            Spacer();
        }

        public void GenerateDelegateConverterUtilImplementation(AST.Delegate type)
        {
            var typeRef = TypeRef(type, false);

            var staticness = PimplMode ? "static " : "";

            Line($"{staticness}{typeRef} GluonInternal::ABIUtil<{typeRef}>::FromABI(void* fptr, IObject* ctx)");
            DelegateFromAbiImplementation(type);
            Spacer();

            Line($"{staticness}ABIOf<{typeRef}> GluonInternal::ABIUtil<{typeRef}>::ToABI(const {typeRef}& x)");
            DelegateToAbiImplementation(type);
            Spacer();
        }

        public void DelegateFromAbiImplementation(AST.Delegate type)
        {
            Block(() =>
            {
                var originalStrata = Strata;
                Strata = ApiStrata.Normal;

                Line(
$@"if (fptr == &DW{type.ShortId}::AbiFunc)
{{
    auto wrapper = runtime_cast<DW{type.ShortId}>(ctx);
    if (!wrapper) throw Exception(""Unexpected context type for delegate translation"");
    return wrapper->Func;
}}

return [fn = ({TypeRef(type, true)})fptr, cp = com_ptr<IObject>(ctx)]({DeclParameters(type.Parameters)})");

                if (!type.Return.IsVoid)
                    Code($"    -> {VariableType(type.Return, AST.VariableContext.Return)} ");

                Block(() =>
                {
                    CallToABIMethodBody(type.Rename("fn"), "cp.Get()");
                }, ";");

                Strata = originalStrata;
            });
        }

        public void DelegateToAbiImplementation(AST.Delegate type)
        {
            Block(() =>
            {
                Line($"ABIOf<{TypeRef(type, false)}> x_abi;");
                Line($"x_abi.Fn = &DW{type.ShortId}::AbiFunc;");
                Line($"x_abi.Ctx = DW{type.ShortId}::GetWrapper(x);");
                Line("return x_abi;");
            });
        }

        public void GenerateWrapperDeclaration(AST.Object type, bool fullIntellisense, Action additionalDeclarations = null)
        {
            Strata = ApiStrata.Normal;

            WriteXmlDocumentation(type.XmlDoc);
            Line($"class _P_{type.Name} : public {(type.BaseType != null ? ("_P_" + TypeRef(type.BaseType)) : "ABI::Wrapper")}");
            Line("{");
            GenerateWrapperHeaderMembers(type, fullIntellisense);

            if (additionalDeclarations != null)
            {
                Spacer();
                additionalDeclarations();
            }
            Code("};");

            Spacer();
            foreach (var ctor in type.Constructors.Where(c => c.Access == AST.Access.Public))
            {
                WriteXmlDocumentation(ctor.XmlDoc);
                Line($"template<typename = void>");
                Line($"{type.Name} Create{type.Name}({DeclParameters(ctor.Parameters)})");
                Block(() =>
                {

                    Code($"return _P_{type.Name}::__P_Create(");
                    List(CodeListStyle.SingleLine, () =>
                    {
                        foreach (var p in ctor.Parameters)
                            ListItem(p.Name);
                    });
                    Line(");");
                });
                Spacer();
            }
        }

        public void GenerateWrapperHeaderMembers(AST.Object type, bool fullIntellisense)
        {
            //Line("#pragma region Gluon Maintained");
            //Line("// clang-format off");

            Indent++;

            foreach (var ctor in type.Constructors.Where(c => c.Access == AST.Access.Public))
                Line($"template<typename> friend {type.Name} Create{type.Name}({DeclParameters(ctor.Parameters)});");

            Line($"typedef {(type.BaseType == null ? "ABI::Wrapper" : ("_P_" + TypeRef(type.BaseType)))} Base;");
            Line($"WRAPPER_CORE(_P_{type.Name}, ::ABI::{type.FullName("::")})");

            AST.Construct currentConstruct = AST.Construct.Constructor;

            Region(() =>
            {
                var localTranslations = GenerateLocalTranslations(type);
                UseLocalTranslations = true;

                LocalTranslationsBlock(localTranslations, () =>
                {
                    var currentAccess = AST.Access.Private;

                    foreach (var member in type.Members/*.Where(m => m.Access == AST.Access.Public)*/.OrderBy(m => m.ConstructType).OrderBy(m => m.Access))
                    {
                        if (member is AST.Constructor) continue;

                        if (member.ConstructType != currentConstruct)
                        {
                            Spacer();
                            currentConstruct = member.ConstructType;
                        }

                        if(member.Access != currentAccess)
                        {
                            Spacer();
                            Indent--;
                            Line($"{member.Access.ToString().ToLower()}:");
                            Indent++;
                            currentAccess = member.Access;
                        }

                        WriteXmlDocumentation(member.XmlDoc);

                        switch(member)
                        {
                            case AST.Constructor constructor:
                                //Line("{0}({1});", type.Name, DeclParameters(true, constructor.Parameters));
                                break;
                            case AST.Event ev:
                                Line($"VirtualEvent<{Signature(ev)}, _P_{type.Name}> {ev.Name}");
                                Line("    {{ this, &_P_{0}::Add{1}Handler, &_P_{0}::Remove{1}Handler }};", type.Name, ev.Name);
                                break;
                            case AST.Property prop:
                                Line("PROPERTY{0}({1}, {2});", prop.IsReadOnly ? "_READONLY" : "",
                                    VariableType(prop, (prop.Type.IsStruct || prop.Type.IsDelegate || (prop.Type.IsObject && prop.IsFactory)) ?
                                    AST.VariableContext.Return : AST.VariableContext.In), prop.Name);

                                GenerateMethodDeclaration(type, prop.CreateGetter().AsConst());

                                if (!prop.IsReadOnly)
                                    GenerateMethodDeclaration(type, prop.CreateSetter().AsConst());
                                break;
                            case AST.Method method:
                                GenerateMethodDeclaration(type, method.AsConst());
                                break;
                            default:
                                throw new Exception("Oops, unhandled member type: " + member.ConstructType.ToString());
                        }
                    }

                    if (currentAccess != AST.Access.Private)
                    {
                        Spacer();
                        Indent--;
                        Line($"private:");
                        Indent++;
                        currentAccess = AST.Access.Private;
                    }

                    foreach (var ev in type.Events.Where(m => m.Access == AST.Access.Public))
                    {
                        GenerateMethodDeclaration(type, ev.CreateAdder().AsConst());
                        GenerateMethodDeclaration(type, ev.CreateRemover().AsConst());
                    }

                    if (!fullIntellisense)
                        Directive("#ifndef __INTELLISENSE__");

                    foreach (var ctor in type.Constructors)
                    {
                        Line("template<typename = void>");
                        Line($"static {type.Name} __P_Create({DeclParameters(ctor.Parameters)});");
                        Spacer();
                    }

                    var abiparam = $"{VariableType(type.ToVariable(AST.VariableContext.In), true)} abi";

                    foreach (var member in type.SyntaxExpandedMethods.Where(m => m.Access == AST.Access.Public).OrderBy(m => m.ConstructType))
                    {
                        Line("template<typename = void>");
                        Line($"{TypeRef(member.Return)} __P_{member.Name}({DeclParameters(/*abiparam,*/ member.Parameters)}) const;");
                        Spacer();
                    }

                    if (!fullIntellisense)
                        Directive("#endif");
                });

            });
            Indent--;
            Spacer();

            //Line("// clang-format on");
            //Line("#pragma endregion");
        }

        public void GenerateWrapperImplementation(AST.Object type)
        {
            Strata = ApiStrata.Normal;

            Namespace(type.Namespace, false, () =>
            {
                var localTranslations = CppRender.GetLocalTranslations(type);
                LocalTranslationsBlock(localTranslations, () =>
                {
                    foreach (var ctor in type.Constructors.Where(c => c.Access == AST.Access.Public))
                    {
                        WrapperConstructorImplementation(ctor, type);
                    }

                    Spacer();

                    foreach (var member in type.Members.OrderBy(m => m.ConstructType))
                    {
                        switch (member)
                        {
                            case AST.Constructor ctor:
                                break;
                            case AST.Property prop:
                                MethodImplementation(prop.CreateGetter().AsConst(), type);

                                if (!prop.IsReadOnly)
                                    MethodImplementation(prop.CreateSetter().AsConst(), type);
                                break;
                            case AST.Event ev:
                                MethodImplementation(ev.CreateAdder().AsConst(), type);
                                MethodImplementation(ev.CreateRemover().AsConst(), type);
                                break;
                            case AST.Method method:
                                MethodImplementation(method.AsConst(), type);
                                break;
                            default:
                                throw new Exception("Oops, unhandled member type: " + member.ConstructType.ToString());
                        }
                    }
                });
            });
        }

        public Dictionary<AST.Type, string> GenerateLocalTranslations(AST.Object type)
        {
            var localTranslations = CppRender.GetLocalTranslations(type);

            UseLocalTranslations = false;
            foreach (var kvp in localTranslations)
                Line("using {0} = {1};", kvp.Value, TypeRef(kvp.Key, false));
            UseLocalTranslations = true;

            return localTranslations;
        }

        public void GenerateClassHeaderMembers(AST.Object type, bool fullIntellisense = false)
        {
            if (type.Origin != TypeOrigin.MappedIntermediary)
            {
                Line("#pragma region Gluon Maintained");
                Line("// clang-format off");
            }

            Region(() =>
            {
                Indent++;

                var localTranslations = GenerateLocalTranslations(type);

                Indent--;
                Spacer();

                LocalTranslationsBlock(localTranslations, () =>
                {
                    Line("public:");
                    Indent++;

                    // ABI type declaration
                    Line("typedef {0} ABIType;", TypeRef(type, true));
                    Spacer();

                    AST.Access currentAccess = AST.Access.Public;
                    AST.Construct currentConstruct = AST.Construct.Void;

                    foreach (var member in type.Members.OrderBy(m => m.Access))
                    {
                        var access = member.Access;

                        if (access == AST.Access.Internal)
                            access = AST.Access.Public;

                        if (access != currentAccess)
                        {
                            currentAccess = access;
                            Indent--;
                            Spacer();

                            Line(access.ToString().ToLower() + ":");
                            Indent++;
                        }

                        var construct = member.ConstructType;

                        if (construct != currentConstruct)
                        {
                            Spacer();
                            currentConstruct = construct;
                        }

                        switch (construct)
                        {
                        case AST.Construct.Constructor:
                            {
                                var constructor = (AST.Constructor)member;

                                Line("{0}({1});", type.Name, DeclParameters(true, constructor.Parameters));
                            }
                            break;
                        case AST.Construct.Event:
                            {
                                var ev = (AST.Event)member;
                                if (ev.IsAbstract || ev.IsVirtual)
                                {
                                    Line("VirtualEvent<{0}, {1}> {2}", Signature(ev), type.Name, ev.Name);
                                    Line("    {{ this, &{0}::Add{1}Handler, &{0}::Remove{1}Handler }};", type.Name, ev.Name);
                                }
                                else
                                    Line("Event<{0}> {1} {{_{1}}};", Signature(ev), ev.Name);
                            }
                            break;
                        case AST.Construct.Property:
                            {
                                var prop = (AST.Property)member;


                                Spacer();
                                Line("PROPERTY{0}({1}, {2});", prop.IsReadOnly ? "_READONLY" : "", 
                                    VariableType(prop, (prop.Type.IsStruct || prop.Type.IsDelegate || (prop.Type.IsObject && prop.IsFactory)) ?
                                    AST.VariableContext.Return : AST.VariableContext.In), prop.Name);

                                GenerateMethodDeclaration(type, prop.CreateGetter());

                                if (!prop.IsReadOnly)
                                    GenerateMethodDeclaration(type, prop.CreateSetter());
                            }
                            break;
                        case AST.Construct.Method:
                            {
                                var method = (AST.Method)member;
                                GenerateMethodDeclaration(type, method);
                            }
                            break;
                        default:
                            throw new Exception("Oops, unhandled member type: " + construct.ToString());
                        }
                    }

                    Spacer();
                    if (currentAccess != AST.Access.Public)
                    {
                        Indent--;
                        Line("public:");
                        Indent++;
                        currentAccess = AST.Access.Public;
                    }

                    // Wrapped Interface Implementation
                    foreach (var iface in type.Interfaces)
                    {
                        if (iface.Origin == TypeOrigin.Native) continue;

                        BlockComment(() => Code(iface.Name));

                        foreach (var method in iface.Methods)
                            GenerateMethodDeclaration(type, method);
                        Spacer();
                    }


                    Spacer();
                    foreach (var ev in type.Events)
                    {
                        if (currentAccess != AST.Access.Private)
                        {
                            Indent--;
                            Line("private:");
                            Indent++;
                            currentAccess = AST.Access.Private;
                        }

                        if (ev.IsAbstract || ev.IsVirtual)
                        {
                            Line("virtual void Add{0}Handler(const Delegate<{1}>& handler){2};", ev.Name, Signature(ev), ev.IsAbstract ? " = 0" : "");
                            Line("virtual void Remove{0}Handler(const Delegate<{1}>& handler){2};", ev.Name, Signature(ev), ev.IsAbstract ? " = 0" : "");
                        }
                        else
                            Line("EventTrigger<{0}> _{1};", Signature(ev), ev.Name);
                    }
                    Spacer();

                    Strata = ApiStrata.ABI;

                    if (currentAccess != AST.Access.Private)
                    {
                        Indent--;
                        Line("private:");
                        Indent++;
                        currentAccess = AST.Access.Private;
                    }

                    if (!fullIntellisense)
                        Directive("#ifndef __INTELLISENSE__");

                    Line($"METHOD GetObjectTypeId(UUID* outID) {{ if(!outID) return E_POINTER; *outID = _uuidof({TypeRef(type, true)}); return S_OK; }}");
                    Line($"METHOD GetObjectTypeName(const char** outStr) {{ if(!outStr) return E_POINTER; *outStr = \"{type.FullName(".")}\"; return S_OK; }}");
                    Spacer();

                    //METHOD GetObjectTypeId(UUID* outID) = 0;
                    //METHOD GetObjectTypeName(const char** outStr) = 0;
                    // ABI interface members
                    GenerateInterfaceMembers(type, false);
                    Spacer();

                    foreach (var iface in type.Interfaces)
                    {
                        if (iface.Origin == TypeOrigin.Native) continue;

                        GenerateInterfaceMembers(iface, false);
                        Spacer();
                    }

                    if (!fullIntellisense)
                        Directive("#endif");

                    Strata = ApiStrata.Normal;
                });
            });

            Indent--;

            if (type.Origin != TypeOrigin.MappedIntermediary)
            {
                Line("// clang-format on");
                Line("#pragma endregion");
            }
        }

        public void GenerateMethodDeclaration(AST.Object type, AST.Method method)
        {
            bool isOverride = type.IsMethodOverride(method);

            if (method.IsAbstract || (method.IsVirtual && !isOverride))
                Code("virtual ");

            Code("{0} {1}({2})", VariableType(method.Return), method.Name, DeclParameters(true, method.Parameters));

            if (method.IsConst)
                Code(" const");

            if (isOverride)
                Code(" override");
            else if (method.IsAbstract)
                Code(" = 0");

            if (Strata == ApiStrata.Normal && PimplMode == true)
            {
                Line();
                Block(() =>
                {
                    if (!method.Return.IsVoid)
                        Code("return ");

                    Code($"__P_{method.Name}(");

                    List(CodeListStyle.SingleLine, () =>
                    {
                        foreach (var p in method.Parameters)
                            ListItem(p.Name);
                    });

                    Line(");");
                });
            }
            else
                Line(";");
        }

        public void WrapperConstructorImplementation(AST.Constructor c, AST.Object owner)
        {
            Line("template<typename>");
            Line($"{TypeRef(owner)} _P_{owner.Name}::__P_Create({DeclParameters(c.Parameters)})");
            Block(() =>
            {
                Line($"{TypeRef(owner, true)}* instance;");

                CallToABIMethodBody(c.Rename(c.GetABIConstructorName(owner)));

                Line($"return ::ABI::Wrapper::Of<{TypeRef(owner)}>(instance);");
            });
        }

        public void ConstructorImplementation(AST.Constructor c, AST.Object owner, Action implementation = null, IEnumerable<string> initializers = null)
        {
            if (Strata == ApiStrata.Normal)
            {
                Code("{0}::{1}({2})", TypeRef(owner), owner.Name, DeclParameters(c.Parameters));

                if (owner.BaseType != null && owner.BaseType.Constructors.Count != 0 && owner.BaseType.Constructors[0].Parameters.Count != 0)
                {
                    Code(" : ");

                    List(() =>
                    {
                        if (PimplMode)
                            Line($"{owner.BaseType.Name}(nullptr)");
                        else
                        {
                            Code("Base(");

                            List(() =>
                            {
                                var bc = owner.BaseType.Constructors[0];
                                foreach (var bcarg in bc.Parameters)
                                    ListItem("DEFAULT_({0})", TypeRef(bcarg));
                            });
                            Line(")");
                            NextListItem();

                            if (initializers != null)
                            {
                                foreach (var str in initializers)
                                    ListItem(str);
                            }
                        }
                    });
                }
                else
                    Line();

                if (implementation == null)
                    Block(() => Line("Not_Implemented_Warning"));
                else
                    Block(() => implementation());
            }
            else
            {
                Line($"ABI_CONSTRUCTOR {c.GetABIConstructorName(owner)}({DeclParameters(c.GetABIParametersCpp(), $"{TypeRef(owner, true)}** outInstance")})");
                Block(() =>
                {
                    if (implementation != null)
                    {
                        implementation();
                        return;
                    }

                    Code("try ");
                    Block(() =>
                    {
                        ABIWrapperParameterValidation(c);

                        Line("if(!outInstance) return E_POINTER;");
                        Line($"*outInstance = new {TypeRef(owner, false)}(");


                        List(CodeListStyle.MultiLine, () =>
                        {
                            Indent++;
                            foreach (var arg in c.Parameters)
                            {
                                string extra = "";

                                if (arg.IsArray)
                                    extra = ", " + arg.Name + "_count";
                                else if (arg.Type.IsDelegate)
                                    extra = ", " + arg.Name + "_context";

                                ListItem($"ABIUtil<{TypeRef(arg, false)}>::{(arg.IsWriteable() ? "Ref" : "FromABI")}({arg.Name}{extra})");
                            }
                            Indent--;
                        });
                        Line(");");

                        Line("return S_OK;");
                    }, " TRANSLATE_EXCEPTIONS");
                });
            }
        }

        public void MethodImplementation(AST.ICallSignature m, AST.Type type, Action implementation = null)
        {
            if (Strata == ApiStrata.Normal)
            {
                UseLocalTranslations = false;

                if (PimplMode)
                    Line("template<typename>");

                Code($"{VariableType(m.Return)} {(PimplMode ? "_P_" : "")}{TypeRef(type)}::{(PimplMode ? "__P_" : "")}{m.Name}(");
                UseLocalTranslations = true;
                Code(DeclParameters(m.Parameters));

                if (m.IsConst)
                    Line(") const");
                else
                    Line(")");

                Block(() =>
                {
                    if (implementation != null)
                        implementation();
                    else if (PimplMode)
                        CallToABIMethodBody(m.Rename("_abi->_" + m.GetComCompatibleName()));
                    else
                        PlaceholderMethodBody(m);
                });
            }
            else
            {
                var args = m.Parameters;

                Line("HRESULT {0}::_{1}({2})", TypeRef(type.ToVariable(), false), m.GetComCompatibleName(), DeclParameters(m.GetABIParametersCpp()));
                Strata = ApiStrata.Normal;
                Block(() =>
                {
                    if (implementation == null)
                        CallFromABIMethodBody(m);
                    else
                        implementation();
                });
                Strata = ApiStrata.ABI;
            }
        }

        public void PlaceholderMethodBody(AST.ICallSignature m)
        {
            Line("Not_Implemented_Warning");

            if (!m.Return.IsVoid)
            {
                Line();
                Line("return DEFAULT_({0});", TypeRef(m.Return));
            }
        }

        public void CallToABIMethodBody(AST.ICallSignature m, params string[] prependArgs)
        {
            AST.IVariable returnArg;

            bool isCtor = m.Return == null;

            if (!isCtor)
                returnArg = m.Return.Morph("___ret", AST.VariableContext.Out);
            else
                returnArg = new AST.Parameter(BasicTypes.Void, "", AST.VariableContext.Return, false);

            foreach (var arg in m.Parameters)
            {
                if (arg.IsArray || arg.Type.IsDelegate)
                {
                    if (arg.IsWriteable())
                        Line("ABICallbackRef<{0}> {1}_abi({1});", TypeRef(arg), arg.Name);
                    else
                        Line("auto {0}_abi = ABIUtil<{1}>::ToABI({0});", arg.Name, TypeRef(arg));
                }
            }

            if (!returnArg.IsVoid)
            {
                Line("{0} {1};", VariableType(returnArg, AST.VariableContext.Member, isCtor), returnArg.Name);

                if (returnArg.IsArray || returnArg.Type.IsDelegate)
                {
                    Line("{");
                    Indent++;
                    Line("ABICallbackRef<{0}> {1}_abi({1});", TypeRef(returnArg), returnArg.Name);
                }
            }

            Line($"TRANSLATE_TO_EXCEPTIONS({m.Name}(");
            Indent++;
            List(CodeListStyle.MultiLine, () =>
            {
                foreach (var arg in prependArgs)
                    ListItem(arg);

                Action<AST.IVariable, string> translateArg = (arg, name) =>
                {
                    if (arg.IsArray || arg.Type.IsDelegate)
                        name += "_abi";

                    if (arg.IsArray)
                    {
                        if (arg.IsWriteable() || arg.Context == AST.VariableContext.Return)
                            ListItem("&{0}.Data, &{0}.Count", name);
                        else
                            ListItem("{0}.begin(), {0}.size()", name);
                    }
                    else if (arg.Type.IsDelegate)
                    {
                        if (arg.IsWriteable() || arg.Context == AST.VariableContext.Return)
                            ListItem("({0}*)&{1}.Fn, &{1}.Ctx", TypeRef(arg, true), name);
                        else
                            ListItem("({0}){1}.Fn, {1}.Ctx", TypeRef(arg, true), name);
                    }
                    else if (arg.IsWriteable() || arg.Context == AST.VariableContext.Return)
                        ListItem("ABICallbackRef<{0}>({1})", TypeRef(arg), name);
                    else if (CppRender.RequiresABITranslation(arg))
                        ListItem("ABIUtil<{0}>::ToABI({1})", TypeRef(arg), name);
                    else ListItem(name);
                };

                foreach (var arg in m.Parameters)
                    translateArg(arg, arg.Name);

                if (isCtor)
                    ListItem("&instance");
                else if (!returnArg.IsVoid)
                    translateArg(returnArg, returnArg.Name);
            });

            Indent--;
            Line("));");

            //if (!returnArg.IsVoid)
            //{
            //    Line("{0} {1};", VariableType(returnArg, AST.VariableContext.Member, isCtor), returnArg.Name);

            //    if (returnArg.IsArray || returnArg.Type.IsDelegate)
            if (!returnArg.IsVoid)
            {
                if (returnArg.IsArray || returnArg.Type.IsDelegate)
                {
                    Indent--;
                    Line("}");
                }
                Line("return {0};", returnArg.Name);
            }
        }

        public void CallFromABIMethodBody(AST.ICallSignature m)
        {
            ABIWrapperParameterValidation(m);
            ABIWrappedCall(m);
        }

        public void EventABIImplementation(AST.Event ev, AST.Object owner)
        {
            Debug.Assert(Strata == ApiStrata.ABI);

            Line("HRESULT {0}::_Add{1}Handler({2} handler, IObject* context)", TypeRef(owner, false), ev.Name, TypeRef(ev.HandlerType));
            Block(() =>
            {
                Code("try ");
                Block(() =>
                {
                    Line("{0} += ABIUtil<{1}>::FromABI(handler, context);", ev.Name, TypeRef(ev.HandlerType, false));
                    Line("return S_OK;");
                }, " TRANSLATE_EXCEPTIONS");
            });

            Line("HRESULT {0}::_Remove{1}Handler({2} handler, IObject* context)", TypeRef(owner, false), ev.Name, TypeRef(ev.HandlerType));
            Block(() =>
            {
                Code("try ");
                Block(() =>
                {
                    Line("{0} -= ABIUtil<{1}>::FromABI(handler, context);", ev.Name, TypeRef(ev.HandlerType, false));
                    Line("return S_OK;");
                }, " TRANSLATE_EXCEPTIONS");
            });
        }

        public void IncludeReferencedHeaders(IEnumerable<AST.Type> types, AST.Assembly generatingAssembly)
        {
            IEnumerable<AST.Type> allRefs = types.ToArray();

            foreach (var type in types)
                allRefs = allRefs.Union(type.SelectReferencedTypes().Where(t => t.Assembly == generatingAssembly));

            foreach (var header in allRefs.Where(t => !string.IsNullOrEmpty(t.CppHeader)).Select(t => t.CppHeader).Distinct())
                Include(header);

            foreach (var r in allRefs.Where(t => t.Origin == TypeOrigin.Gluon && t.IsObject).Distinct())
                IncludeLocal(r.Name + ".h");
        }

        #endregion
    }
}
