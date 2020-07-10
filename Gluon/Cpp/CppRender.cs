using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Gluon
{
    public class CppRender : PascalRender
    {
        public Dictionary<AST.Type, string> LocalTranslations { get; private set; } = new Dictionary<AST.Type, string>();
        public bool UseLocalTranslations { get; set; } = true;
        public bool FullIntellisense { get; set; } = false;
        public bool PimplMode { get; set; } = false;
        protected override string ScopeOperator => "::";

        public static Dictionary<AST.Type, string> GetLocalTranslations(AST.Type type)
        {
            var ret = new Dictionary<AST.Type, string>();

            var obj = type as AST.Object;
            var st = type as AST.Struct;

            // Classes that have properties with the same name as declared types (happens a lot) 
            // need to be disambiguated.
            // We do that by locally renaming the type to TypeName_t

            var allRefs = type.SelectReferencedTypes();

            Dictionary<string, AST.Type> refNames = new Dictionary<string, AST.Type>();
            foreach (var r in allRefs)
                refNames[r.Name] = r;

            if (obj != null)
                foreach (var p in obj.Properties)
                {
                    AST.Type refType;

                    if (refNames.TryGetValue(p.Name, out refType))
                        ret[refType] = p.Name + "_t";
                }

            if (st != null)
                foreach (var p in st.Fields)
                {
                    AST.Type refType;

                    if (refNames.TryGetValue(p.Name, out refType))
                        ret[refType] = p.Name + "_t";
                }

            return ret;
        }

        public override string TypeName(AST.IVariable t, bool? abi = null)
        {
            if (t.IsArray)
            {
                var prefix = "";
                if (abi.HasValue && abi.Value != WorkingABINamespace && (t.Type.Origin == TypeOrigin.Gluon || t.Type.Origin == TypeOrigin.Managed))
                    prefix = (abi.Value ? "ABI::" : "CS::");

                return prefix + "Array<" + GetParameterType(t.Type.ToVariable(), abi) + ">";
            }

            return TypeName(t.Type, abi);
        }

        public override string TypeName(AST.Type type, bool? abi = null)
        {
            string ret = type.Name;

            if (abi ?? Strata == ApiStrata.ABI)
            {
                if (type == BasicTypes.String)
                    return "char*";
                else if (type == BasicTypes.IUnknown)
                    return "IUnknown";
                else if (type == BasicTypes.IObject)
                    return "IObject";

                if (type.IsDelegate)
                {
                    var del = (AST.Delegate)type;
                    return "fn_ptr<" + SignatureOf(del, abi) + ">";
                }
            }
            else
            {
                if (type == BasicTypes.Boolean)
                    return "bool";
                else if (type == BasicTypes.IUnknown)
                    return "IUnknown";
                else if (type == BasicTypes.IObject)
                    return "IObject";

                if (type.IsDelegate)
                {
                    var del = (AST.Delegate)type;
                    if (del.IsGeneric)
                        return "Delegate<" + SignatureOf(del, abi) + ">";
                }
            }

            bool useabi =
                (abi ?? Strata == ApiStrata.ABI) &&
                !type.IsPureReference &&
                (type.IsStruct || type.IsObject) &&
                type.Origin != TypeOrigin.Mapped &&
                type.Origin != TypeOrigin.Native;

            string local = null;

            if (!useabi)
            {
                local = GetLocalTranslation(type);

                if (local != null)
                    return local;
            }

            if (WorkingNamespace == null || (WorkingABINamespace != useabi))
            {
                if (!useabi)
                {
                    for (var ns = type.Namespace; !ns.IsGlobal; ns = ns.Parent)
                    {
                        if(type.Origin == TypeOrigin.Gluon || type.Origin == TypeOrigin.Managed)
                            ret = ns.Name + "::" + ret;
                        else
                            ret = "::" + ns.Name + "::" + ret;
                    }
                }
                else if (useabi && (type.Origin == TypeOrigin.Gluon || type.Origin == TypeOrigin.Managed))
                {
                    for (var ns = type.Namespace; !ns.IsGlobal; ns = ns.Parent)
                        ret = ns.Name + "::" + ret;
                    ret = "::ABI::" + ret;
                }
            }
            else if (type.Namespace != null)
                ret = ScopeTo(type.Namespace) + ret;

            return ret;
        }

        public static bool RequiresABITranslation(AST.IVariable arg)
        {
            var ctx = arg.Context;

            if (arg.Type == BasicTypes.IUnknown)
                return (ctx == AST.VariableContext.Ref || ctx == AST.VariableContext.Out);
            if (arg.IsArray)
                return true;
            if (arg.Type.IsPrimitive)
                return (ctx == AST.VariableContext.Ref || ctx == AST.VariableContext.Out);
            if (arg.Type.IsVoid)
                return false;
            if (arg.Type.IsString)
                return true;
            if (arg.Type.IsEnum)
                return (ctx == AST.VariableContext.Ref || ctx == AST.VariableContext.Out);

            if (arg.Type.IsStruct)
            {
                if (ctx == AST.VariableContext.Ref || ctx == AST.VariableContext.Out)
                    return true;

                var argStruct = arg.Type as AST.Struct;

                foreach (var field in argStruct.Fields)
                    if (RequiresABITranslation(field))
                        return true;

                return false;
            }

            if (arg.Type.Origin == TypeOrigin.Native)
                return false;

            return true;
        }

        public override bool Use(AST.Namespace ns, bool abi)
        {
            var added = base.Use(ns, abi);

            if (added)
            {
                var oldIndent = Indent;
                Indent = 0;
                if (abi)
                    Line("using namespace ABI::{0};", ns.FullName("::"));
                else
                    Line("using namespace {0};", ns.FullName("::"));
                Indent = oldIndent;
            }
            return added;
        }

        public override void Namespace(AST.Namespace ns, bool abi, Action content)
        {
            if (ns != null && ns.IsGlobal)
                ns = null;

            var top = _nestedNS.Count != 0 ? _nestedNS.Peek() : null;

            if (_nestedNS.Count != 0 && WorkingABINamespace != abi)
                throw new InvalidOperationException("abi mismatch in nested namespaces");

            if (ns != null && top != null && !ns.IsWithin(top))
                throw new InvalidOperationException("namespace is not properly nested");

            if (ns == top)
            {
                content();
                return;
            }

            WorkingABINamespace = abi;

            List<AST.Namespace> scopeList = new List<AST.Namespace>();

            for (var nsi = ns; nsi != top && !nsi.IsGlobal; nsi = nsi.Parent)
                scopeList.Insert(0, nsi);

            if (abi && _nestedNS.Count == 0)
                BeginNamespace("ABI");

            foreach (var nsi in scopeList)
                BeginNamespace(nsi.Name);

            WorkingNamespace = ns;
            _nestedNS.Push(ns);
            content();
            _nestedNS.Pop();
            WorkingNamespace = top;

            foreach (var nsi in scopeList)
                EndNamespace();

            if (abi && _nestedNS.Count == 0)
                EndNamespace();

            if (abi && _nestedNS.Count == 0)
                WorkingABINamespace = false;
        }

        public override string ToLiteral(object value, AST.Type type = null)
        {
            if (value == null)
                return "null";

            var t = value.GetType();
            var enumType = type as AST.Enum;

            if (t == typeof(float) || t == typeof(Single))
            {
                var fvalue = (float)value;
                return (fvalue).ToString("G9") + (Math.Floor(fvalue) != fvalue ? "f" : "");
            }
            else if (t == typeof(double) || t == typeof(Double))
                return ((double)value).ToString("G17");
            else if (t.IsEnum)
            {
                var x = (int)value;

                if (enumType == null)
                    return x.ToString();

                string entryName = null;

                foreach (var e in enumType.Entries)
                    if (e.Value == x)
                    {
                        entryName = e.Name;
                        break;
                    }

                return TypeName(enumType) + "::" + entryName;
            }
            else if (t == typeof(string) || t == typeof(String))
                return "L\"" + U.StringLiteral((string)value) + "\"";
            else if (t.IsPrimitive)
                return value.ToString();

            Errors.UnsupportedTypeInAttribute(t);
            return null;
        }

        public override void ParameterType(AST.IVariable arg, bool? abi = null)
        {
            Code(GetParameterType(arg, abi));
        }

        #region Internal

        private void BeginNamespace(string ns)
        {
            Line(@"namespace {0}
{{", ns);
            Indent++;
            BeginRegion();
        }

        private void EndNamespace()
        {
            EndRegion();
            Indent--;
            Line("}");
            Spacer();
        }

        private string GetParameterType(AST.IVariable arg, bool? abi = null)
        {
            bool useabi = abi ?? Strata == ApiStrata.ABI;
            var usePimpl = PimplMode && !useabi && arg.Type != BasicTypes.IUnknown;
            var ctx = arg.Context;

            if (arg.Type.IsVoid)
                return "void";

            bool refAdorn = ctx == AST.VariableContext.Ref;
            bool constAdorn = false;

            var output = TypeName(arg.Type, abi);

            Func<string, string> adornCom = s => useabi ? s + "*" : usePimpl ? s : "com_ptr<" + s + ">";

            if (arg.IsArray)
            {
                var element = GetParameterType(arg.Type.ToVariable(), abi);

                refAdorn = false;
                constAdorn = false;
                if (useabi)
                {
                    if (ctx == AST.VariableContext.Member)
                        output = "ABI::Array<" + element + ">";
                    else
                        output = element + "*";
                }
                else
                    output = "Array<" + element + ">";

                switch (ctx)
                {
                    case AST.VariableContext.In:
                        // public: Array<T>
                        // private: Array<T>
                        break;
                    case AST.VariableContext.Out:
                    case AST.VariableContext.Ref:
                        // public: Array<T>*
                        // private: Array<T>&
                        refAdorn = !useabi;
                        break;
                    case AST.VariableContext.Return:
                        // public: Array<T>
                        // private: Array<T>
                        break;
                    case AST.VariableContext.Member:
                        // public: Array<T>
                        // private: Array<T>
                        break;
                    default:
                        Errors.InternalFailure();
                        throw new Exception();
                }
            }
            else
            {
                if (arg.Type.IsString)
                {
                    switch (ctx)
                    {
                        case AST.VariableContext.In:
                            // public: char*
                            // private: String
                            break;
                        case AST.VariableContext.Out:
                        case AST.VariableContext.Ref:
                            // public: char**
                            // private: String&
                            refAdorn = !useabi;
                            break;
                        case AST.VariableContext.Return:
                            // public: char*
                            // private: String
                            break;
                        case AST.VariableContext.Member:
                            // public: char*
                            // private: String
                            break;
                        default:
                            Errors.InternalFailure();
                            throw new Exception();
                    }
                }
                else if (arg.Type.IsPrimitive || arg.Type.IsEnum)
                {
                    switch (ctx)
                    {
                        case AST.VariableContext.In:
                            break;
                        case AST.VariableContext.Out:
                        case AST.VariableContext.Ref:
                            refAdorn = !useabi;
                            break;
                        case AST.VariableContext.Return:
                            break;
                        case AST.VariableContext.Member:
                            break;
                        default:
                            Errors.InternalFailure();
                            throw new Exception();
                    }
                }
                else if (arg.Type.IsStruct)
                {
                    switch (ctx)
                    {
                        case AST.VariableContext.In:
                            // public: ABI::MyStruct
                            // private: const MyStruct&
                            refAdorn = !useabi;
                            constAdorn = !useabi;
                            break;
                        case AST.VariableContext.Out:
                        case AST.VariableContext.Ref:
                            // public: ABI::MyStruct*
                            // private: MyStruct&
                            refAdorn = !useabi;
                            break;
                        case AST.VariableContext.Return:
                            // public: ABI::MyStruct
                            // private: MyStruct
                            break;
                        case AST.VariableContext.Member:
                            // public: ABI::MyStruct
                            // private: MyStruct
                            break;
                        default:
                            Errors.InternalFailure();
                            throw new Exception();
                    }
                }
                else if (arg.Type.IsDelegate)
                {
                    switch (ctx)
                    {
                        case AST.VariableContext.In:
                            // public: ABI::DelegateBlob<Sig>
                            // private: const Delegate<Sig>&
                            refAdorn = !useabi;
                            constAdorn = !useabi;
                            break;
                        case AST.VariableContext.Out:
                            // public: ABI::DelegateBlob<Sig>*
                            // private: Delegate<Sig>*
                            refAdorn = !useabi;
                            break;
                        case AST.VariableContext.Ref:
                            // public: ABI::DelegateBlob<Sig>*
                            // private: Delegate<Sig>&
                            refAdorn = !useabi;
                            break;
                        case AST.VariableContext.Return:
                            // public: ABI::DelegateBlob<Sig>
                            // private: Delegate<Sig>
                            break;
                        case AST.VariableContext.Member:
                            if (useabi)
                                output = "ABI::DelegateBlob";
                            // public: ABI::DelegateBlob<Sig>
                            // private: Delegate<Sig>
                            break;
                        default:
                            Errors.InternalFailure();
                            throw new Exception();
                    }
                }
                else if (arg.Type.IsObject)
                {
                    switch (ctx)
                    {
                        case AST.VariableContext.In:
                            // public: ABI::MyType*
                            // private: MyType*
                            if(!usePimpl)
                                output += "*";
                            refAdorn = constAdorn = usePimpl;
                            break;
                        case AST.VariableContext.Out:
                        case AST.VariableContext.Ref:
                            // public: ABI::MyType**
                            // private: com_ptr<MyType>&
                            output = adornCom(output);
                            refAdorn = !useabi;
                            break;
                        case AST.VariableContext.Return:
                            // public: ABI::MyType*
                            // private: com_ptr<MyType>
                            output = adornCom(output);
                            break;
                        case AST.VariableContext.Member:
                            // public: ABI::MyType*
                            // private: com_ptr<MyType>
                            output = adornCom(output);
                            break;
                        default:
                            Errors.InternalFailure();
                            throw new Exception();
                    }
                }
                else
                {
                    Errors.IncompatibleType(arg.Type);
                    throw new Exception();
                }
            }

            if (refAdorn)
                output += "&";
            else if (ctx == AST.VariableContext.Out || ctx == AST.VariableContext.Ref)
                output += "*";
            if (constAdorn)
                output = "const " + output;

            return output;
        }

        private string SignatureOf(AST.ICallSignature d, bool? abi = null)
        {
            var writer = new CppRender();
            var useabi = abi ?? Strata == ApiStrata.ABI;

            if (useabi)
            {
                writer.Code("HRESULT(");
            }
            else
            {
                writer.Code(GetParameterType(d.Return.InContext(AST.VariableContext.Return), abi));
                writer.Code("(");
            }

            writer.BeginList(useabi ? CodeListStyle.Compact : CodeListStyle.SingleLine);

            foreach (var arg in useabi ? d.GetABIParametersCpp(true) : d.Parameters)
                writer.ListItem(GetParameterType(arg, useabi));

            writer.EndList();
            writer.Code(")");

            return writer.ToString();
        }

        private string GetLocalTranslation(AST.Type type)
        {
            if (!UseLocalTranslations)
                return null;

            string ret;
            if (LocalTranslations.TryGetValue(type, out ret))
                return ret;
            else
                return null;
        }

        private Stack<AST.Namespace> _nestedNS = new Stack<AST.Namespace>();

        #endregion
    }
}
