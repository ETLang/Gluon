using Gluon.PascalTreeCsExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Gluon
{
    public class CsTreeWriter : PascalTreeWriter
    {
        public CsTreeWriter(bool targetMono = false) { TargetMono = targetMono; }
        public CsTreeWriter(PascalTree tree, bool targetMono = false) : base(tree) { TargetMono = targetMono; }

        public bool TargetMono { get; private set; }

        #region Writer Ops

        public void WriteAttribute(AST.Attribute attr)
        {
            Insert(new AttributeNode(attr));
            Line();
        }

        #endregion

        #region High Level Generators

        public void DefineDelegate(AST.Delegate type, string name = null)
        {
            if (name == null)
                name = type.Name;

            Namespace(type.Namespace, false, () =>
            {
                WriteXmlDocumentation(type.XmlDoc);
                Line($"{(Strata == ApiStrata.ABI ? "internal" : "public")} delegate {TypeRef(type.Return)} {name}({DeclParameters(type.Parameters)});");
            });
        }

        public void DefineEnum(AST.Enum type)
        {
            Namespace(type.Namespace, false, () =>
            {
                WriteXmlDocumentation(type.XmlDoc);
                Line($"public enum {type.Name} : {type.UnderlyingType.Name}");
                Block(() =>
                {
                    List(CodeListStyle.MultiLine, () =>
                    {
                        bool canPresume = true;

                        for (int i = 0; i < type.Entries.Count; i++)
                        {
                            var entry = type.Entries[i];

                            canPresume &= i == entry.Value;

                            WriteXmlDocumentation(entry.XmlDoc);
                            if (canPresume)
                                Code(type.Entries[i].Name);
                            else
                                Code($"{type.Entries[i].Name} = {type.Entries[i].Value}");

                            NextListItem();
                        }
                    });
                });
            });
        }

        public void DefineStruct(AST.Struct type)
        {
            bool useabi = Strata == ApiStrata.ABI;

            Namespace(type.Namespace, useabi, () =>
            {
                Spacer();
                if (!useabi)
                    WriteXmlDocumentation(type.XmlDoc);
                foreach (var attr in type.Attributes)
                    WriteAttribute(attr);
                Line($"{(useabi ? "internal" : "public")} struct {type.Name}");
                Block(() =>
                {
                    foreach (var field in type.Fields)
                    {
                        WriteXmlDocumentation(field.XmlDoc);
                        Line($"public {TypeRef(field)} {field.Name};");
                    }

                    Spacer();

                    if (useabi)
                    {
                        var tn = TypeRef(type, false);

                        Line($"public static {type.Name} ToABI({tn} x)");
                        Block(() =>
                        {
                            Line($"return new {type.Name}");
                            Block(() =>
                            {
                                List(CodeListStyle.MultiLine, () =>
                                {
                                    foreach (var field in type.Fields)
                                    {
                                        if (field.IsArray)
                                        {
                                            if (field.Type.IsPrimitive || field.Type.IsString)
                                                ListItem("{0} = MConv_.ToABI_{1}(x.{0})", field.Name, field.Type.Name);
                                            else if (field.Type.IsObject)
                                                ListItem("{0} = MConv_.ToABI_Object(x.{0} == null ? IntPtr.Zero : (({1})x.{0}).IPtr)", field.Name, TypeRef(field, false));
                                            else
                                                ListItem("{0} = ABI.{1}.MConv.ToABI{2}(x.{0})", field.Name, type.Assembly.Name, field.Type.ShortId);
                                        }
                                        else if (field.Type.IsString)
                                            ListItem("{0} = MConv_.ToABI_string(x.{0})", field.Name);
                                        else if (field.Type.IsObject)
                                            ListItem("{0} = MConv_.ToABI_Object(x.{0} == null ? IntPtr.Zero : (({1})x.{0}).IPtr)", field.Name, TypeRef(field, false));
                                        else if (field.Type.IsStruct && CsRender.RequiresABITranslation(field.Type.ToVariable()))
                                            ListItem("{0} = {1}.ToABI(x.{0})", field.Name, TypeRef(field, true));
                                        else if (field.Type.IsDelegate)
                                            ListItem("{0} = ABI.{1}.D{2}.Unwrap(x.{0})", field.Name, type.Assembly.Name, field.Type.ShortId);
                                        else
                                            ListItem("{0} = x.{0}", field.Name);
                                    }
                                });
                            }, ";");
                        });
                        Line($"public static {tn} FromABI({type.Name} x)");
                        Block(() =>
                        {
                            Action<string> fill = prefix =>
                            {
                                List(CodeListStyle.MultiLine, () =>
                                {
                                    foreach (var field in type.Fields)
                                    {
                                        if (field.IsArray)
                                        {
                                            if (field.Type.IsPrimitive || field.Type.IsString)
                                                ListItem(prefix + "MConv_.FromABI_{1}(x.{0}.Ptr, x.{0}.Count)", field.Name, field.Type.Name);
                                            else if (field.Type.IsObject)
                                                ListItem(prefix +"MConv_.FromABI_Object<{1}>(x.{0}.Ptr, x.{0}.Count)", TypeRef(field.Type, false), field.Name);
                                            else
                                                ListItem(prefix + "ABI.{1}.MConv.FromABI{2}(x.{0}.Ptr, x.{0}.Count)", field.Name, type.Assembly.Name, field.Type.ShortId);
                                        }
                                        else if (field.Type.IsString)
                                            ListItem(prefix + "MConv_.FromABI_string(x.{0})", field.Name);
                                        else if (field.Type.IsObject)
                                            ListItem(prefix + "GluonObject.Of<{1}>(x.{0})", field.Name, TypeRef(field.Type, false));
                                        else if (field.Type.IsStruct && CsRender.RequiresABITranslation(field.Type.ToVariable()))
                                            ListItem(prefix + "{1}.FromABI(x.{0})", field.Name, TypeRef(field, true));
                                        else if (field.Type.IsDelegate)
                                            ListItem(prefix + "ABI.{1}.D{2}.Wrap(x.{0}.Fn, x.{0}.Ctx)", field.Name, type.Assembly.Name, field.Type.ShortId);
                                        else
                                            ListItem(prefix + "x.{0}", field.Name);
                                    }
                                });
                            };

                            if (type.PredefinedFullConstructor)
                            {
                                Line($"return new {tn}(");
                                Indent++;
                                fill("");
                                Indent--;
                                Line(");");
                            }
                            else
                            {
                                Line($"return new {tn}");
                                Block(() => fill("{0} = "), ";");
                            }
                        });

                        Line(
@"public static {0}[] ToABI_Array({1}[] x)
{{
    if (x == null) return null;
    var r = new {0}[x.Length];

    for (int i = 0; i < x.Length; i++)
        r[i] = ToABI(x[i]);
    return r;
}}

public static {1}[] FromABI_Array({0}[] x)
{{
    if (x == null) return null;
    var r = new {1}[x.Length];

    for (int i = 0; i < x.Length; i++)
        r[i] = FromABI(x[i]);
    return r;
}}", type.Name, tn);
                    }
                    else
                    {
                        Line("public {0}({1})", type.Name, DeclParameters(type.Fields.Select(f => f.Morph("_" + f.Name))));
                        Block(() =>
                        {
                            foreach (var field in type.Fields)
                                Line("{0} = _{0};", field.Name);
                        });
                    }
                });
            });
        }

        public void DefineDelegateWrapper(AST.Delegate type)
        {
            Strata = ApiStrata.ABI;
            
            Line($"public class D{type.ShortId} : Gluon.D_Base");
            Block(() =>
            {
                var argstring = DeclParameters(type.GetABIParametersCs(true));

                Line(
$@"private NativeDel _abi;
internal static readonly NativeDel FnDel = new NativeDel(Fn);
public static readonly IntPtr FnPtr = Marshal.GetFunctionPointerForDelegate(FnDel);
internal delegate HResult NativeDel({argstring});");

                Line();
                if (TargetMono)
                    Line("[AOT.MonoPInvokeCallback(typeof(NativeDel))]");
                Line($"private static HResult Fn({argstring})");
                Block(() =>
                {
                    Strata = ApiStrata.Normal;

                    Line($"var del = ((GCHandle)Marshal.GetObjectForIUnknown(__i_)).Target as {TypeRef(type)};");
                    Line();
                    Line("try");
                    Block(() =>
                    {
                        WriteWrappedCall(true, "del", type.Return, null, type.Parameters.ToArray());
                    });
                    Line("catch (Exception e)");
                    Block(() =>
                    {
                        foreach (var arg in type.GetABIParametersCs(true).Where(a => a.IsOut))
                            Line($"{arg.Name} = default({TypeRef(arg, true)});");

                        Line("return GluonObject.ExceptionToHResult(e);");
                    });
                });

                Line(
@"private D{1}(IntPtr fn, IntPtr ctx) : base(ctx)
{{
    _abi = (NativeDel)Marshal.GetDelegateForFunctionPointer(fn, typeof(NativeDel));
}}

public static {0} Wrap(IntPtr fn, IntPtr ctx)
{{
    if (fn == IntPtr.Zero)
        return null;
    else if (fn == D{1}.FnPtr)
        return ((GCHandle)Marshal.GetObjectForIUnknown(ctx)).Target as {0};
    else
        return new D{1}(fn, ctx).Call;
}}

public static DelegateBlob Unwrap({0} x)
{{
    return x == null ? new DelegateBlob(IntPtr.Zero, IntPtr.Zero) :
        new DelegateBlob(FnPtr, Marshal.GetIUnknownForObject(GCHandle.Alloc(x)));
}}

public static DelegateBlob[] ToABI_Array({0}[] x)
{{
    if (x == null) return null;
    var r = new DelegateBlob[x.Length];
    for (int i = 0; i < x.Length; i++) r[i] = Unwrap(x[i]);
    return r;
}}

public static {0}[] FromABI_Array(DelegateBlob[] x)
{{
    if (x == null) return null;
    var r = new {0}[x.Length];

    for (int i = 0; i < x.Length; i++)
        r[i] = Wrap(x[i].Fn, x[i].Ctx);
    return r;
}}
", TypeRef(type), type.ShortId);

                Line($"private {TypeRef(type.Return)} Call({DeclParameters(type.Parameters)})");
                Block(() =>
                {
                    Strata = ApiStrata.Normal;
                    WriteWrappedCall(false, "(int)_abi", type.Return, new AST.Parameter() { Type = BasicTypes.IntPtr, Name = "_ctx" }, type.Parameters.ToArray());
                    Strata = ApiStrata.ABI;
                });
            });
        }

        public void DefineClass(AST.Object type)
        {
            bool useabi = Strata == ApiStrata.ABI;

            Namespace(type.Namespace, useabi, () =>
            {
                if (!useabi)
                    DefineWrapperClass(type);
                else
                    DefineInterfaceUsingVTableWrapper(type);
            });
        }

        public void WriteArrayMemberConverter(AST.Type type)
        {
            var tn = TypeRef(type, false);
            var tnabi = TypeRef(type, true);

            if (type.IsDelegate)
                tnabi = "DelegateBlob";

            Line("public static {0}[] FromABI{1}(IntPtr data, int count)", tn, type.ShortId);
            Block(() =>
            {
                Line("if(data == IntPtr.Zero) return null;");
                Line("var sz = Marshal.SizeOf<{0}>();", tnabi);
                Line("var r = new {0}[count];", tn);
                Line("for(int i = 0;i < count;i++)");
                Block(() =>
                {
                    if (type.IsStruct)
                    {
                        if (CsRender.RequiresABITranslation(type.ToVariable()))
                            Line("r[i] = {0}.FromABI(Marshal.PtrToStructure<{0}>((IntPtr)((long)data + i * sz)));", tnabi);
                        else
                            Line("r[i] = Marshal.PtrToStructure<{0}>((IntPtr)((long)data + i * sz));", tnabi);
                    }
                    else if (type.IsDelegate)
                    {
                        Line("var blob = Marshal.PtrToStructure<{0}>((IntPtr)((long)data + i * sz));", tnabi);
                        Line("r[i] = D{0}.Wrap(blob.Fn, blob.Ctx);", type.ShortId);
                    }
                    else if (type.IsObject)
                    {
                        Line("r[i] = GluonObject.Of<{0}>(Marshal.ReadIntPtr((IntPtr)((long)data + i * sz)));", tn);
                    }
                    else
                        throw new InvalidOperationException("This writer only designed to write for structs, delegates, and classes");
                });
                Line("Marshal.FreeCoTaskMem(data);");
                Line("return r;");
            });

            Line("public static ArrayBlob ToABI{1}({0}[] arr)", tn, type.ShortId);
            Block(() =>
            {
                Line("if(arr == null) return new ArrayBlob();");
                Line("var sz = Marshal.SizeOf<{0}>();", tnabi);
                Line("var r = new ArrayBlob(Marshal.AllocCoTaskMem(sz * arr.Length), arr.Length);");
                Line("for(int i = 0;i < arr.Length;i++)");
                Block(() =>
                {
                    if (type.IsStruct)
                    {
                        if (CsRender.RequiresABITranslation(type.ToVariable()))
                            Line("Marshal.StructureToPtr({0}.ToABI(arr[i]), r.Ptr + sz * i, false);", tnabi);
                        else
                            Line("Marshal.StructureToPtr(arr[i], r.Ptr + sz * i, false);", tnabi);
                    }
                    else if (type.IsDelegate)
                    {
                        Line("var blob = D{0}.Unwrap(arr[i]);", type.ShortId);
                        Line("Marshal.StructureToPtr(blob, (IntPtr)((long)r.Ptr + sz * i), false);");
                    }
                    else if (type.IsObject)
                    {
                        Line("var item = arr[i];");
                        Line("Marshal.WriteIntPtr((IntPtr)((long)r.Ptr + sz * i), item == null ? IntPtr.Zero : item.IPtr);");
                    }
                });
                Line("return r;");
            });

            Line("public static void FreeABI{0}(IntPtr data, int count)", type.ShortId);
            Block(() =>
            {
                Line("Marshal.FreeCoTaskMem(data);");
            });
        }

        public void WriteWrappedCall(bool isCallback, string callName, AST.IVariable retType, AST.Parameter contextArg, params AST.Parameter[] args)
        {
            WriteWrappedCall(true, isCallback, callName, retType, contextArg, args);
        }

        public void WriteWrappedCall(bool doConversion, bool isCallback, string callName, AST.IVariable retType, AST.Parameter contextArg, params AST.Parameter[] args)
        {
            var argConv = VarConversion.Get(this, isCallback, args);
            var retConv = VarConversion.Get(retType, this, isCallback);

            if (isCallback)
            {
                if(doConversion)
                    foreach (var arg in argConv)
                        arg.WritePrefix(this);

                if (retConv != null && retConv.Item != null)
                    Code("{0} ", retConv.Item);
                Code("{0}(", callName);
                List(() =>
                {
                    if (contextArg != null)
                        ListItem(contextArg.Name);

                    foreach (var arg in argConv)
                        arg.WriteItem(this);
                });
                Line(");");

                if(doConversion)
                    foreach (var arg in argConv)
                        arg.WriteSuffix(this);

                if (retConv != null)
                    retConv.WriteSuffix(this);

                Line("return HResult.S_OK;");
            }
            else
            {
                if (retConv != null)
                    argConv.Add(retConv);

                if(doConversion)
                    foreach (var arg in argConv)
                        arg.WritePrefix(this);

                Code("Native.Throw({0}(", callName);
                List(() =>
                {
                    if (contextArg != null)
                        ListItem(contextArg.Name);

                    foreach (var arg in argConv)
                        arg.WriteItem(this);
                });
                Line("));");

                if(doConversion)
                    foreach (var arg in argConv)
                        arg.WriteSuffix(this);
            }
        }

        public void WriteWrappedMemberCall(string callName, bool isStatic, AST.IVariable retType, params AST.Parameter[] args)
        {
            AST.Parameter ctxarg = null;

            if (!isStatic)
                ctxarg = new AST.Parameter() { Type = BasicTypes.IntPtr, Name = "IPtr", Context = AST.VariableContext.In };

            Line("Check();");
            WriteWrappedCall(false, MemberCallScope(isStatic) + callName, retType, ctxarg, args);
        }

        #endregion

        #region Internal

        [Obsolete("Directly wrapping the VTable is preferred over ComImport stuff. Fewer abstraction layers to deal with.")]
        private void DefineInterfaceUsingComImport(AST.Object type)
        {
            Strata = ApiStrata.ABI;

            foreach (var attr in type.Attributes)
                WriteAttribute(attr);

            Line("[ComImport, Guid(\"{0}\")]", type.Id);
            Line("[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]");
            Code("internal interface {0}", type.Name);
            Block(() =>
            {
                WriteInterfaceMembersUsingComImport(type);
            });

            if (!type.IsAbstract)
            {
                Line("internal static partial class Factory", type.Name);
                Block(() =>
                {
                    if (type.Constructors.Count == 0)
                    {
                        Line("[DllImport(Native.DllPath)]");
                        Line("public static extern int Create_{0}(out {1} newInstance);", type.FullName("_"), type.Name);
                        Spacer();
                    }

                    int index = 1;
                    foreach (var c in type.Constructors)
                    {
                        Line("[DllImport(Native.DllPath)]");
                        Line("public static extern int Create_{0}_{1}({2});", type.FullName("_"), index,
                            DeclParameters(c.GetABIParametersCs(), "out " + type.Name + " newInstance"));
                        Spacer();
                        index++;
                    }
                });
            }
        }

        private void DefineInterfaceUsingVTableWrapper(AST.Object type)
        {
            Strata = ApiStrata.ABI;

            foreach (var attr in type.Attributes)
                WriteAttribute(attr);

            Line("[Guid(\"{0}\")]", type.Id);
            Line("[StructLayout(LayoutKind.Sequential)]");
            Line("internal struct {0}", type.Name);
            Block(() =>
            {
                Line("public readonly VTUnknown Unknown;");
                Spacer();

                WriteInterfaceMembersUsingVTableWrapper(type);
            });

            if (!type.IsAbstract)
            {
                Line("internal static partial class Factory", type.Name);
                Block(() =>
                {
                    if (type.Constructors.Count == 0)
                    {
                        Line("[DllImport(Native.DllPath)]");
                        Line("public static extern int Create_{0}(out IntPtr newInstance);", type.FullName("_"));
                        Spacer();
                    }

                    int index = 1;
                    foreach (var c in type.Constructors)
                    {
                        Line("[DllImport(Native.DllPath)]");
                        Line("public static extern int Create_{0}_{1}({2});", type.FullName("_"), index,
                            DeclParameters(c.GetABIParametersCs(), "out IntPtr newInstance"));
                        Spacer();
                        index++;
                    }
                });
            }
        }

        private void WriteInterfaceMemberUsingVTableWrapper(AST.ICallSignature call)
        {
            Line(
@"[MarshalAs(UnmanagedType.FunctionPtr)]
public readonly {0}_sig {0};
[UnmanagedFunctionPointer(CallingConvention.StdCall)]
public delegate int {0}_sig({1});",
                call.GetComCompatibleName(), DeclParameters(call.GetABIParametersCs(true)));
            Spacer();
        }

        private void WriteInterfaceMembersUsingVTableWrapper(AST.Object type)
        {
            foreach (var m in type.Methods)
            {
                if (type.IsMethodOverride(m)) continue;
                WriteInterfaceMemberUsingVTableWrapper(m);
            }

            foreach (var p in type.Properties)
            {
                var getter = p.CreateGetter();
                if (!type.IsMethodOverride(getter))
                    WriteInterfaceMemberUsingVTableWrapper(getter);

                if (!p.IsReadOnly)
                {
                    var setter = p.CreateSetter();
                    if (!type.IsMethodOverride(setter))
                        WriteInterfaceMemberUsingVTableWrapper(p.CreateSetter());
                }
            }

            foreach (var e in type.Events)
            {
                WriteInterfaceMemberUsingVTableWrapper(e.CreateAdder());
                WriteInterfaceMemberUsingVTableWrapper(e.CreateRemover());
            }
        }

        private void WriteInterfaceMemberUsingComImport(AST.ICallSignature call)
        {
            Line("[PreserveSig]");
            Line($"int {call.Name}({DeclParameters(call.GetABIParametersCs())});");
            Spacer();
        }

        private void WriteInterfaceMembersUsingComImport(AST.Object type)
        {
            foreach (var m in type.Methods)
            {
                if (type.IsMethodOverride(m)) continue;
                WriteInterfaceMemberUsingComImport(m);
            }

            foreach (var p in type.Properties)
            {
                var getter = p.CreateGetter();
                if (!type.IsMethodOverride(getter))
                    WriteInterfaceMemberUsingVTableWrapper(getter);

                if (!p.IsReadOnly)
                {
                    var setter = p.CreateSetter();
                    if (!type.IsMethodOverride(setter))
                        WriteInterfaceMemberUsingVTableWrapper(p.CreateSetter());
                }
            }

            foreach (var e in type.Events)
            {
                WriteInterfaceMemberUsingComImport(e.CreateAdder());
                WriteInterfaceMemberUsingComImport(e.CreateRemover());
            }
        }

        private void DefineWrapperClass(AST.Object type)
        {
            var abiName = TypeRef(type, true);

            WriteXmlDocumentation(type.XmlDoc);

            Line($"[Guid(\"{type.PrivateId}\")]");
            Line($"[GluonGenerated(abi: typeof(global::ABI.{type.FullName(".")}))]");
            foreach (var attr in type.Attributes)
                WriteAttribute(attr);
            Line("{0} {3} class {1} : {2}", type.Access.ToString().ToLower(), type.Name, type.BaseType != null ? TypeRef(type.BaseType) : "GluonObject", type.IsAbstract ? "abstract partial" : "partial");
            Block(() =>
            {
                Line(
$@"static partial void StaticInit();
partial void Init();
partial void PartialDispose(bool finalizing);

static {type.Name}()
{{
    ABI.{type.Assembly.Name}.Native.RegisterTypes();
    StaticInit();
}}");
                Spacer();

                foreach (var c in type.Constructors)
                {
                    WriteXmlDocumentation(c.XmlDoc);

                    if (c.Parameters.Count == 0)
                        LineStyle = CodeLineStyle.SingleLine;

                    Line(
$@"{c.Access.ToString().ToLower()} {type.Name}({DeclParameters(c.Parameters)})
    : this(new AbiPtr(Make({List(c.Parameters, arg => {
        var adorn = arg.IsRef ? "ref " : arg.IsOut ? "out " : "";
        return $"{adorn}{arg.Name}"; })})))
{{
    {ForEach(type.Events, e => Line(
        $"_{e.Name}_abi = D{e.HandlerType.ShortId}.Unwrap(_Call_{e.Name});"))}
    Init();
}}");
                    Spacer();

                    LineStyle = CodeLineStyle.Standard;
                }

                Line(
$@"protected override void OnDispose(bool finalizing)
{{
    PartialDispose(finalizing);
    {ForEach(type.Events, e => Line(
       $"if(_{e.Name} != null) _vt.Remove{e.Name}Handler(IPtr, _{e.Name}_abi.Fn, _{e.Name}_abi.Ctx);"))}
    IPtr = IntPtr.Zero;
    base.OnDispose(finalizing);
}}");
                Spacer();

                foreach (var e in type.Events)
                {
                    Line("#region {0}", e.Name);
                    Line();
                    WriteXmlDocumentation(e.XmlDoc);

                    Line(
$@"{e.Access.ToString().ToLower()} event {TypeRef(e.HandlerType)} {e.Name}
{{
    add
    {{
        Check();
        if(_{e.Name} == null)
            _vt.Add{e.Name}Handler(IPtr, _{e.Name}_abi.Fn, _{e.Name}_abi.Ctx);

        _{e.Name} += value;
    }}
    remove
    {{
        Check();
        _{e.Name} -= value;
        if(_{e.Name} == null)
            _vt.Remove{e.Name}Handler(IPtr, _{e.Name}_abi.Fn, _{e.Name}_abi.Ctx);
    }}
}}

private void _Call_{e.Name}({DeclParameters(e.Parameters)})
{{
    try
    {{
        _{e.Name}({List(e.Parameters, arg => arg.Name)});
    }}
    catch(Exception ___ex)
    {{
        CallbackEventExceptionHandler?.Invoke(___ex);
    }}
}}

private {TypeRef(e.HandlerType)} _{e.Name};
private DelegateBlob _{e.Name}_abi;

#endregion");

                    Spacer();
                }

                foreach (var p in type.Properties)
                {
                    string typeName = TypeRef(p);
                    string abiType = TypeRef(p, true);

                    WriteXmlDocumentation(p.XmlDoc);

                    if (p.IsReadOnly)
                        LineStyle = CodeLineStyle.SingleLine;

                    Line("{0} {1} {2}", p.Access.ToString().ToLower(), typeName, p.Name);
                    Block(() =>
                    {
                        LineStyle = CodeLineStyle.SingleLine;
                        Line("get");
                        Block(() => WriteWrappedMemberCall("Get" + p.Name, false, p.InContext(AST.VariableContext.Return, "x")));

                        if (!p.IsReadOnly)
                        {
                            Line("set");
                            Block(() => WriteWrappedMemberCall("Set" + p.Name, false, null, p.InContext(AST.VariableContext.In, "value")));
                            LineStyle = CodeLineStyle.Standard;
                        }
                    });

                    if(p.IsReadOnly)
                        LineStyle = CodeLineStyle.Standard;
                }

                foreach (var m in type.Methods)
                {
                    if (type.IsMethodOverride(m)) continue;

                    WriteXmlDocumentation(m.XmlDoc);
                    Line($"{m.Access.ToString().ToLower()} {TypeRef(m.Return)} {m.Name}({DeclParameters(m.Parameters)})");
                    Block(() =>
                    {
                        WriteWrappedMemberCall(m.GetComCompatibleName(), false, m.Return, m.Parameters.ToArray());
                    });
                }

                Line(
$@"#region Internal

[System.Diagnostics.Conditional(""DEBUG"")]
private void Check()
{{
    if (IPtr == IntPtr.Zero)
        throw new ObjectDisposedException(GetType().Name + "" has been disposed"");
}}

internal {type.Name}(AbiPtr i) : base(i)
{{
    IntPtr iptr;
    Native.Throw(Marshal.QueryInterface(i.Value, ref _ID, out iptr));
    Marshal.Release(iptr);
    IPtr = iptr;
    _vt = VTUnknown.GetVTable<ABI.{type.FullName(".")}>(IPtr);
    {ForEach(type.Events, e => Line($"_{e.Name}_abi = D{e.HandlerType.ShortId}.Unwrap(_Call_{e.Name});"))}
    Init();
}}
");
                var index = 1;
                foreach (var c in type.Constructors)
                {
                    Line($"private static {abiName} Make({DeclParameters(c.Parameters)})");
                    Block(() =>
                    {
                        WriteWrappedCall(
                            false,
                            $"ABI.{type.Namespace.FullName(".")}.Factory.Create_{type.FullName("_")}_{index}",
                            new AST.Parameter()
                            {
                                Context = AST.VariableContext.Make,
                                Type = type,
                                Name = "instance"
                            },
                            null,
                            c.Parameters.ToArray());
                    });
                    index++;
                }

                Line(
$@"public {(type.BaseType != null ? "new " : "")}{abiName} IPtr {{ get; private set; }} //{abiName} _i;
ABI.{type.FullName(".")} _vt;
static Guid _ID = new Guid(""{type.Id}"");

#endregion");
            });
        }

        private string MemberCallScope(bool isStatic)
        {
            if (isStatic)
                return "";
            else
                return "_vt.";
        }

        #endregion
    }
}
