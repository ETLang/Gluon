using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Gluon
{
    public class CsRender : PascalRender
    {
        protected override string ScopeOperator => ".";

        public override string TypeName(AST.IVariable v, bool? abi = null)
        {
            var useabi = RequiresABITranslation(v) && (abi ?? Strata == ApiStrata.ABI);

            if (v.IsVoid)
                return "void";

            var t = v.Type;

            if (useabi && v.Context == AST.VariableContext.Member)
            {
                if (v.IsArray)
                    return "ArrayBlob";
                else if (t.IsString)
                    return "IntPtr";
                else if (t.IsDelegate)
                    return "DelegateBlob";
            }

            if (v.IsArray)
            {
                if (useabi && v.Type.IsDelegate)
                    return "DelegateBlob[]";
                else
                    return TypeName(t, abi) + "[]";
            }
            else
                return TypeName(t, abi);
        }

        public override string TypeName(AST.Type t, bool? abi = null)
        {
            var useabi = RequiresABITranslation(t.ToVariable()) && (abi ?? Strata == ApiStrata.ABI);

            if (t.IsVoid)
                return "void";

            if (t == BasicTypes.IUnknown)
                t = BasicTypes.IntPtr;

            if (useabi && (/*v.IsArray ||*/ t.IsObject))
                return "IntPtr";

            var qn = t.Name;

            if (t.IsDelegate)
            {
                var d = (AST.Delegate)t;

                if (useabi)
                    return "IntPtr";
                else if (d.IsGeneric)
                {
                    CsRender writer = new CsRender();

                    if (!d.Return.IsVoid)
                    {
                        writer.Code("Func<");
                        writer.BeginList(CodeListStyle.Compact);
                        foreach (var arg in d.Parameters)
                            writer.ListItem(TypeName(arg, false));
                        writer.ListItem(TypeName(d.Return));
                        writer.EndList();
                        writer.Code(">");
                    }
                    else if (d.Parameters.Count == 0)
                        return "Action";
                    else
                    {
                        writer.Code("Action<");
                        writer.BeginList(CodeListStyle.Compact);
                        foreach (var arg in d.Parameters)
                            writer.ListItem(TypeName(arg, false));
                        writer.EndList();
                        writer.Code(">");
                    }

                    return writer.ToString();
                }
            }

            if ((t.IsObject || t.IsDelegate || t.IsStruct) && (WorkingABINamespace != useabi || WorkingNamespace != t.Namespace))
            {
                if (useabi)
                {
                    if (t.IsObject || t.IsDelegate)
                        return "IntPtr";
                    else
                        return "ABI." + t.FullName(".");
                }
                else
                    return "global::" + t.FullName(".");
            }

            if (t.IsEnum && WorkingABINamespace)
                return "global::" + t.FullName(".");

            return ScopeTo(t.Namespace) + qn;
        }

        public string AttributeType(AST.Attribute t, bool? abi = null)
        {
            var n = TypeName(t.Type, abi);
            return n.Remove(n.Length - 9);
        }

        public string MarshalParameter(AST.IVariable t, int paramIndex)
        {
            if (Strata != ApiStrata.ABI) return null;

            if (!t.IsArray)
            {
                switch (t.Type.ConstructType)
                {
                    case AST.Construct.Primitive:
                        if (t.Type == BasicTypes.Boolean)
                            return "MarshalAs(UnmanagedType.I1)";
                        else
                            return null;
                    case AST.Construct.String:
                        return "MarshalAs(UnmanagedType.LPStr)";
                    case AST.Construct.Struct:
                        return null;
                    case AST.Construct.Object:
                    default:
                        return null;
                }
            }
            else
            {
                switch (t.Type.ConstructType)
                {
                    case AST.Construct.Primitive:
                    {
                        if(t.Type.IsBool)
                            return "MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.I1, SizeParamIndex = " + (paramIndex + 1).ToString() + ")";
                        else
                            return "MarshalAs(UnmanagedType.LPArray, SizeParamIndex = " + (paramIndex + 1).ToString() + ")";
                    }
                    case AST.Construct.String:
                        return "MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr, SizeParamIndex = " + (paramIndex + 1).ToString() + ")";
                    case AST.Construct.Struct:
                        return "MarshalAs(UnmanagedType.LPArray, SizeParamIndex = " + (paramIndex + 1).ToString() + ")";
                    case AST.Construct.Object:
                        return "MarshalAs(UnmanagedType.LPArray, SizeParamIndex = " + (paramIndex + 1).ToString() + ")";
                    case AST.Construct.Delegate:
                        return "MarshalAs(UnmanagedType.LPArray, SizeParamIndex = " + (paramIndex + 1).ToString() + ")";
                    default:
                        return null;
                }
            }
        }

        public static bool RequiresABITranslation(AST.IVariable arg)
        {
            var ctx = arg.Context;

            if (arg.IsArray && ctx == AST.VariableContext.Member)
                return true;

            if (arg.Type.IsPrimitive)
                return false;
            if (arg.Type.IsVoid)
                return false;
            if (arg.Type.IsString)
                return ctx == AST.VariableContext.Member;
            if (arg.Type.IsEnum)
                return false;
            if (arg.Type.IsObject)
                return true;
            if (arg.Type.IsDelegate)
                return true;

            if (arg.Type.IsStruct)
            {
                var argStruct = arg.Type as AST.Struct;

                foreach (var field in argStruct.Fields)
                    if (RequiresABITranslation(field))
                        return true;

                return false;
            }

            if (arg.Type.Origin == TypeOrigin.Managed)
                return false;

            return true;
        }

        public override bool Use(AST.Namespace ns, bool abi)
        {
            var added = base.Use(ns, abi);

            if (added)
            {
                if (abi)
                    Line("using ABI.{0};", ns.FullName("."));
                else
                    Line("using {0};", ns.FullName("."));
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

            string nsname = "";

            for (AST.Namespace nsi = ns; nsi != top && !nsi.IsGlobal; nsi = nsi.Parent)
            {
                if (!string.IsNullOrEmpty(nsname))
                    nsname = nsi.Name + "." + nsname;
                else
                    nsname = nsi.Name;
            }

            if (abi && _nestedNS.Count == 0)
            {
                if (string.IsNullOrEmpty(nsname))
                    nsname = "ABI";
                else
                    nsname = "ABI." + nsname;
            }

            WorkingNamespace = ns;
            _nestedNS.Push(ns);
            BeginNamespace(nsname);
            content();
            EndNamespace();
            _nestedNS.Pop();
            WorkingNamespace = top;
        }

        public override string ToLiteral(object value, AST.Type type = null)
        {
            if (value == null)
                return "null";

            var t = value.GetType();

            if (t == typeof(float) || t == typeof(Single))
                return ((float)value).ToString("G9") + "f";
            else if (t == typeof(double) || t == typeof(Double))
                return ((double)value).ToString("G17");
            else if (t.IsEnum)
                return t.Name + "." + value.ToString();
            else if (t == typeof(string) || t == typeof(String))
                return "@\"" + ((string)value).Replace("\"", "\"\"") + "\"";
            else if (t.IsPrimitive)
                return value.ToString();

            Errors.UnsupportedTypeInAttribute(t);
            return null;
        }

        public void WriteAttribute(AST.Attribute attr)
        {
            var strata = Strata;

            Strata = ApiStrata.Normal;

            if (attr.UnnamedParameters.Count + attr.NamedParameters.Count == 0)
                Line("[{0}]", AttributeType(attr));
            else
            {
                Code("[{0}(", AttributeType(attr));
                BeginList();

                foreach (var attrarg in attr.UnnamedParameters)
                    ListItem(ToLiteral(attrarg));

                foreach (var attrarg in attr.NamedParameters)
                    ListItem("{0}: {1}", attrarg.Name, ToLiteral(attrarg.Value));
                EndList();
                Line(")]");
            }

            Strata = strata;
        }

        public override void ParameterType(AST.IVariable arg, bool? abi = null)
        {
            var t = arg.Type;
            var isOut = arg.IsOut;
            string adorn = arg.IsRef ? "ref " : isOut ? "out " : "";

            string attr = MarshalParameter(arg, CurrentListSize);

            if (attr != null)
                Code("[{0}] {1}{2}", attr, adorn, TypeName(arg));
            else
                Code("{0}{1}", adorn, TypeName(arg));
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

        Stack<AST.Namespace> _nestedNS = new Stack<AST.Namespace>();

        #endregion
    }
}
