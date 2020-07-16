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

        public void LocalTranslationsBlock(Dictionary<AST.Type,string> translations, Action content)
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
                if(arg.IsWriteable())
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

        public void GenerateInterfaceMembers(AST.Object type, bool pure, bool fullIntellisense = false)
        {
            var suffix = pure ? " = 0" : "";

            if (!fullIntellisense)
                Directive("#ifndef __INTELLISENSE__");

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

            if (!fullIntellisense)
                Directive("#endif");
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
                GenerateInterfaceMembers(type, true, fullIntellisense);
            }, ";");
        }

        public void GenerateClassDeclaration(AST.Object type, bool fullIntellisense = false, Action additionalDeclarations = null)
        {
            // Set up generator state, figure out the class ID, other vars
            Strata = ApiStrata.Normal;

            // Class Signature
            Line($"class comid(\"{type.PrivateId}\")");
            Code("{0} : public ComObject<{0}, {1}, {2}",
                type.Name, type.BaseType != null ? TypeRef(type.BaseType) : "Object", TypeRef(type, true));

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
            Line($"static Delegate<{dSig}> Lookup({TypeRef(type)} fptr, IObject* ctx);");
            Line($"static HRESULT __stdcall AbiFunc({DeclParameters(type.GetABIParametersCpp(true))});");
            Indent--;
            Line("};");
            Spacer();
        }

        public void GenerateDelegateConverterImplementation(AST.Delegate type)
        {
            const string dName = "___del";

            Strata = ApiStrata.ABI;
            var typeRef = TypeRef(type, false);
            var typeRefABI = TypeRef(type, true);

            Line($"HRESULT DW{type.ShortId}::AbiFunc({DeclParameters(type.GetABIParametersCpp(true))})");
            Block(() =>
            {
                Line($"auto {dName} = runtime_cast<DW{type.ShortId}>(__i_);");
                Line($"if (!{dName}) return E_FAIL;");
                Spacer();
                ABIWrapperParameterValidation(type);
                ABIWrappedCall(type, null, $"{dName}->Func");
            });
            Spacer();

            Strata = ApiStrata.Normal;
            Line("template<>");
            Line($"{TypeRef(type, false)} ABIUtil<{typeRef}>::FromABI(void* fptr, IObject* ctx)");
            //Line($"Delegate<{Signature(type, false)}> DW{type.ShortId}::Lookup({TypeRef(type)} fptr, IObject* ctx)");
            Block(() =>
            {
                Line(
$@"if (fptr == &DW{type.ShortId}::AbiFunc)
{{
    auto wrapper = runtime_cast<DW{type.ShortId}>(ctx);
    if (!wrapper) throw Exception(""Unexpected context type for delegate translation"");
    return wrapper->Func;
}}

return [fn = ({typeRefABI})fptr, cp = com_ptr<IObject>(ctx)]({DeclParameters(type.Parameters)})");

                if (!type.Return.IsVoid)
                    Code("    -> {0} ", VariableType(type.Return, AST.VariableContext.Return));

                Block(() =>
                {
                    CallToABIMethodBody(type.Rename("fn"), "cp.Get()");
                }, ";");
            });
            Spacer();

            Line("template<>");
            Line("ABIOf<{0}> ABIUtil<{0}>::ToABI(const {0}& x)", typeRef);
            Block(() =>
            {
                Line($"ABIOf<{typeRef}> x_abi;");
                Line($"x_abi.Fn = &DW{type.ShortId}::AbiFunc;");
                Line($"x_abi.Ctx = DW{type.ShortId}::GetWrapper(x);");
                Line("return x_abi;");
            });
        }

        public void GenerateWrapperDeclaration(AST.Object type, Action additionalDeclarations = null)
        {
            Strata = ApiStrata.Normal;

            foreach (var ctor in type.Constructors.Where(c => c.Access == AST.Access.Public))
            {
                WriteXmlDocumentation(ctor.XmlDoc);
                Line($"{type.Name} Create{type.Name}({DeclParameters(ctor.Parameters)});");
            }
            Spacer();
            WriteXmlDocumentation(type.XmlDoc);
            Line($"class {type.Name} : public {(type.BaseType != null ? TypeRef(type.BaseType) : "ABI::Wrapper")}");
            Line("{");
            GenerateWrapperHeaderMembers(type);

            if (additionalDeclarations != null)
            {
                Spacer();
                additionalDeclarations();
            }
            Code("};");
        }

        public void GenerateWrapperHeaderMembers(AST.Object type)
        {
            Line("#pragma region Gluon Maintained");
            Line("// clang-format off");
            Line($"    typedef {(type.BaseType == null ? "ABI::Wrapper" : TypeRef(type.BaseType))} Base;");
            Line($"    WRAPPER_CORE({type.Name}, ::ABI::{type.FullName("::")})");

            AST.Construct currentConstruct = AST.Construct.Constructor;

            Indent++;
            Region(() =>
            {
                var localTranslations = GenerateLocalTranslations(type);
                UseLocalTranslations = true;

                LocalTranslationsBlock(localTranslations, () =>
                {
                    //Spacer();
                    //Line($"{type.Name}();");
                    //Line($"{type.Name}(std::nullptr_t);");
                    //Line($"{type.Name}(const {type.Name}& copy);");
                    //Line($"{type.Name}({type.Name}&& move);");
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
                                Line($"VirtualEvent<{Signature(ev)}, {type.Name}> {ev.Name}");
                                Line("    {{ this, &{0}::Add{1}Handler, &{0}::Remove{1}Handler }};", type.Name, ev.Name);
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

                    var allEvents = type.Members.Where(m => m.Access == AST.Access.Public).OfType<AST.Event>().ToArray();

                    if (allEvents != null && allEvents.Length > 0)
                    {
                        Spacer();
                        Indent--;
                        Line("private:");
                        Indent++;
                        Spacer();

                        foreach (var ev in allEvents)
                        {
                            GenerateMethodDeclaration(type, ev.CreateAdder().AsConst());
                            GenerateMethodDeclaration(type, ev.CreateRemover().AsConst());
                        }
                    }
                });

            });
            Indent--;
            Spacer();

            Line("// clang-format on");
            Line("#pragma endregion");
        }

        public void GenerateWrapperImplementation(AST.Object type)
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

                    // ABI interface members
                    GenerateInterfaceMembers(type, false, fullIntellisense);
                    Spacer();

                    foreach (var iface in type.Interfaces)
                    {
                        if (iface.Origin == TypeOrigin.Native) continue;

                        GenerateInterfaceMembers(iface, false, fullIntellisense);
                        Spacer();
                    }

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
                Line(" override;");
            else if (method.IsAbstract)
                Line(" = 0;");
            else
                Line(";");
        }

        public void WrapperConstructorImplementation(AST.Constructor c, AST.Object owner)
        {
            Line($"{TypeRef(owner)} {owner.Namespace.FullName("::")}::Create{owner.Name}({DeclParameters(c.Parameters)})");
            Block(() =>
            {
                Line($"{TypeRef(owner, true)}* instance;");

                CallToABIMethodBody(c.Rename(c.GetABIConstructorName(owner)));

                Line($"return ::ABI::Wrap<{TypeRef(owner)}>(instance);");
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
                        if (Settings.Mode == CppMode.PimplWrapper)
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
                Code("{0} {1}::{2}(", VariableType(m.Return), TypeRef(type), m.Name);
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
                    else if (Settings.Mode == CppMode.PimplWrapper)
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
