using Gluon.AST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Gluon
{
    public class VarConversion
    {
        private static readonly char[] _Splitter = new char[] { '$' };
        public readonly string Prefix;
        public readonly string Suffix;
        public readonly string Item;

        // Other Variables: RequiresConversion,IsCallback,

        private static string[] NoTranslation = new string[]
        {
            // Calls
            /* In  */ "{0}",
            /* Out */ "out {0}",
            /* Ref */ "ref {0}",
            /* Ret */ "{1} {0}; $ out {0} $ return {0};",
            /* Mak */ "",

            // Callbacks
            /* In  */ "{0}",
            /* Out */ "out {0}",
            /* Ref */ "ref {0}",
            /* Ret */ "{0} = ",
        };

        private static string[] BasicTranslation = new string[]
        {
            // Calls
            /* In  */ "{ToABI:$}",
            /* Out */ "{2} {0}_abi; $ out {0}_abi $ {0} = {FromABI:$_abi};",
            /* Ref */ "var {0}_abi = {ToABI:$}; $ ref {0}_abi $ {0} = {FromABI:$_abi};",
            /* Ret */ "{2} {0}_abi; $ out {0}_abi $ return {FromABI:$_abi};",
            /* Mak */ "{2} {0}_abi; $ out {0}_abi $ return {0}_abi;",

            // Callbacks
            /* In  */ "{FromABI:$}",
            /* Out */ "{1} {0}_wrap; $ out {0}_wrap $ {0} = {ToABI:$_wrap};",
            /* Ref */ "var {0}_wrap = {FromABI:$}; $ ref {0}_wrap $ {0} = {ToABI:$_wrap};",
            /* Ret */ "$ var {0}_wrap = $ {0} = {ToABI:$_wrap};",
        };

        private static int TranslationIndex(VariableContext ctx, bool isCallback)
        {
            int index = 0;
            
            if (isCallback)
                index += 5;

            return index + (int)ctx;
        }
        
        public static Dictionary<Construct, string> ToABI = new Dictionary<Construct, string>
        {
            { Construct.Struct, "{2}.ToABI({0})" },
            { Construct.Object, "({0} == null ? IntPtr.Zero : {0}.NativePtr)" },
            { Construct.Delegate, "D{3}.Unwrap({0})" },
        };

        public static Dictionary<Construct, string> ToABIArray = new Dictionary<Construct, string>
        {
            { Construct.Struct, "{2}.ToABI_Array({0})" },
            { Construct.Object, "GluonObject.ArrayUnwrap({0})" },
            { Construct.Delegate, "D{3}.ToABI_Array({0})" },
        };

        public static Dictionary<Construct, string> ToABIArrayBlob = new Dictionary<Construct, string>
        {
            { Construct.Primitive, "MConv_.ToABI_{1}({0})" },
            { Construct.Struct, "Gluon.MConv.ToABI{3}({0})" },
            { Construct.Object, "MConv_.ToABI_Object({0})" },
            { Construct.Delegate, "MConv.ToABI{3}({0})" },
        };

        public static Dictionary<Construct, string> FromABI = new Dictionary<Construct, string>
        {
            { Construct.Struct, "{2}.FromABI({0})" },
            { Construct.Object, "GluonObject.Of<{1}>({0})" },
            { Construct.Delegate, "D{3}.Wrap({0}, {0}_context)" },
        };

        public static Dictionary<Construct, string> FromABIArray = new Dictionary<Construct, string>
        {
            { Construct.Struct, "{2}.FromABI_Array({0})" },
            { Construct.Object, "GluonObject.ArrayWrap<{1}>({0})" },
            { Construct.Delegate, "D{3}.FromABI_Array({0})" },
        };

        public static Dictionary<Construct, string> FromABIArrayBlob = new Dictionary<Construct, string>
        {
            { Construct.Primitive, "MConv_.FromABI_{1}({0}.Ptr, {0}.Count)" },
            { Construct.Struct, "MConv.FromABI{3}({0}.Ptr, {0}.Count)" },
            { Construct.Object, "MConv_.FromABI_Object<{1}>({0}.Ptr, {0}.Count)" },
            { Construct.Delegate, "Gluon.MConv.FromABI{3}({0}.Ptr, {0}.Count)" }
        };

        public static string[] GetChannels(AST.IVariable v)
        {
            if (v.IsArray)
                return new string[] { "Ptr", "Count" };
            else if (v.Type.IsDelegate)
                return new string[] { "Fn", "Ctx" };
            else
                return null;
        }

        private static Regex _Replacer = new Regex(@"\{(?<Label>[a-zA-Z0-9]+)(\:(?<Format>[^\}]+))?\}", RegexOptions.Compiled);

        public static string GenerateConverter(AST.IVariable v, VariableContext ctx, bool isCallback)
        {
            var requiresTranslation = CsRender.RequiresABITranslation(v);
            var channels = GetChannels(v);

            if (v.IsArray) return null;
            if (v.IsRef && v.Type.IsObject) return null;

            if (!requiresTranslation)
                return NoTranslation[TranslationIndex(ctx, isCallback)];
            else
            {
                if (channels == null)
                {
                    return _Replacer.Replace(BasicTranslation[TranslationIndex(ctx, isCallback)],
                        m =>
                        {
                            var label = m.Groups["Label"];
                            var format = m.Groups["Format"];

                            if (!label.Success)
                                return m.Value;
                            if (label.Value == "ToABI")
                            {
                                string fmt = format.Success ? format.Value.Replace("$", "{0}") : "{0}";
                                return ToABI[v.Type.ConstructType].Replace("{0}", fmt);
                            }
                            else if (label.Value == "FromABI")
                            {
                                string fmt = format.Success ? format.Value.Replace("$", "{0}") : "{0}";
                                return FromABI[v.Type.ConstructType].Replace("{0}", fmt);
                            }
                            else
                                return m.Value;
                        });
                }
            }

            return null;
        }

        private static string[] PrimitiveConverters = new string[]
        {
            /* In  */ "{0}",                            // X
            /* Out */ "out {0}",                        // OUT X
            /* Ref */ "ref {0}",                        // REF X
            /* Ret */ "$ out {1} {0} $ return {0};",    // OUT T X $ RET X
        };

        private static string[] PrimitiveCBConverters = new string[]
        {
            /* In  */ "{0}",                            // X
            /* Out */ "out {0}",                        // OUT X
            /* Ref */ "ref {0}",                        // REF X
            /* Ret */ "{0} = ",                         // X = 
        };

        private static string[] StructConverters = new string[]
        {
            /* In  */ "{2}.ToABI({0})",                 // TOABI(X)
            /* Out */ "$ out {2} {0}_abi $ {0} = {2}.FromABI({0}_abi);",        // OUT T X_ABI $ X = FROMABI(X_ABI)
            /* Ref */ "var {0}_abi = {2}.ToABI({0}); $ ref {0}_abi $ {0} = {2}.FromABI({0}_abi);",      // X_ABI = TOABI(X) $ REF X_ABI $ X = FROMABI(X_ABI)
            /* Ret */ "$ out {2} {0}_abi $ return {2}.FromABI({0}_abi);"            // OUT T X_ABI $ RET FROMABI(X_ABI)
        };

        private static string[] StructCBConverters = new string[]
        {
            /* In  */ "{2}.FromABI({0})",           // FROMABI(X)
            /* Out */ "$ out {1} {0}_wrap $ {0} = {2}.ToABI({0}_wrap);",        // OUT T X_WRAP $ X = TOABI(X_WRAP)
            /* Ref */ "var {0}_wrap = {2}.FromABI({0}); $ ref {0}_wrap $ {0} = {2}.ToABI({0}_wrap);",   // X_WRAP = FROMABI(X) $ REF X_WRAP $ X = TOABI(X_WRAP)
            /* Ret */ "$ var {0}_wrap = $ {0} = {2}.ToABI({0}_wrap);"   // X_WRAP = $ X = TOABI(X_WRAP)
        };

        private static string[] ObjectConverters = new string[]
        {
            /* In  */ "({2})({0} == null ? null : {0}.NativePtr)",      // TOABI(X)
            /* Out */ "$ out {2} {0}_abi $ {0} = MConv_.FromABI_Object<{1}>({0}_abi);", // $ OUT T X_ABI $ X = FROMABI(X_ABI)
            /* Ref */ "var {0}_abi = MConv_.ToABI_Object({0}); $ ref {0}_abi $ {0} = MConv_.FromABI_Object<{1}>({0}_abi);", // X_ABI = TOABI(X) $ REF X_ABI $ X = FROMABI(X_ABI)
            /* Ret */ "$ out {2} {0}_abi $ return GluonObject.Of<{1}>({0}_abi);",   // OUT T X_ABI $ RET FROMABI(X_ABI)
            /* Mak */ "$ out {2} {0}_abi $ return {0}_abi;"     // $ OUT T X_ABI $ RET X_ABI
        };

        private static string[] ObjectCBConverters = new string[]
        {
            /* In  */ "GluonObject.Of<{1}>({0})",       // FROMABI(X)
            /* Out */ "$ out {1} {0}_wrap $ {0} = MConv_.ToABI_Object<{2}>({0}_wrap);", // $ OUT T X_WRAP $ X = TOABI(X_WRAP)
            /* Ref */ "var {0}_wrap = GluonObject.Of<{1}>({0}); $ ref {0}_wrap $ var {0}_old = {0}; {0} = MConv_.ToABI_Object({0}_wrap); if({0}_old != IntPtr.Zero) Marshal.Release({0}_old);", // X_WRAP = FROMABI(X) $ REF X_WRAP $ X = TOABI(X_WRAP)
            /* Ret */ "$ var {0}_wrap = $ {0} = ({0}_wrap == null ? null : ({2}){0}_wrap.NativeObj);" // X_WRAP = $ X = TOABI(X_WRAP)
        };

        private static string[] StringConverters = new string[]
        {
            /* In  */ "{0}",            // X
            /* Out */ "out {0}",        // OUT X
            /* Ref */ "ref {0}",        // REF X
            /* Ret */ "$ out {1} {0} $ return {0};"     // $ OUT T X $ RET X
        };

        private static string[] StringCBConverters = new string[]
        {
            /* In  */ "{0}",
            /* Out */ "out {0}",
            /* Ref */ "ref {0}",
            /* Ret */ "{0} = ;"
        };

        private static string[] DelegateConverters = new string[]
        {
            /* In  */ "var {0}_abi = D{3}.Unwrap({0}); $ {0}_abi.Fn, {0}_abi.Ctx",          // X_ABI = TOABI(X) $ CH(X_ABI,0), CH(X_ABI,1)
            /* Out */ "IntPtr {0}_abi_fn; IntPtr {0}_abi_ctx; $ out {0}_abi_fn, out {0}_abi_ctx $ {0} = D{3}.Wrap({0}_abi_fn, {0}_abi_ctx);", // T X_ABI $ OUT CH(X_ABI,0), OUT CH(X_ABI,1) $ X = FROMABI(X_ABI)
            /* Ref */ "var {0}_abi = D{3}.Unwrap({0}); $ ref {0}_abi.Fn, ref {0}_abi.Ctx $ {0} = D{3}.Wrap({0}_abi.Fn, {0}_abi.Ctx);", // X_ABI = TOABI(X) $ REF X_ABI $ X = FROMABI(X_ABI)
            /* Ret */ "IntPtr {0}_abi_fn; IntPtr {0}_abi_ctx; $ out {0}_abi_fn, out {0}_abi_ctx $ return D{3}.Wrap({0}_abi_fn, {0}_abi_ctx);" // T X_ABI $ OUT X_ABI $ RET FROMABI(X_ABI)
        };

        private static string[] DelegateCBConverters = new string[]
        {
            /* In  */ "var {0}_wrap = D{3}.Wrap({0}, {0}_context); $ {0}_wrap",  // X_WRAP = FROMABI(X) $ X_WRAP
            /* Out */ "{1} {0}_wrap; $ out {0}_wrap $ var {0}_abi = D{3}.Unwrap({0}_wrap); {0} = {0}_abi.Fn; {0}_context = {0}_abi.Ctx;", // T X_WRAP $ OUT X_WRAP $ X_ABI = TOABI(X_WRAP) X = X_ABI
            /* Ref */ "var {0}_wrap = D{3}.Wrap({0}, {0}_context); $ ref {0}_wrap $ var {0}_abi = D{3}.Unwrap({0}_wrap); {0} = {0}_abi.Fn; {0}_context = {0}_abi.Ctx;", // X_WRAP = FROMABI(X) $ REF X_WRAP $ X_ABI = TOABI(X_WRAP) X = X_ABI
            /* Ret */ "$ var {0}_wrap = $ var {0}_abi = D{3}.Unwrap({0}_wrap); {0} = {0}_abi.Fn; {0}_context = {0}_abi.Ctx;" // X_WRAP = $ X_ABI = TOABI(X_WRAP) X = X_ABI
        };

        private static string[] PrimitiveArrayConverters = new string[]
        {
            /* In  */ "{0}, {0}.Length",
            /* Out */ "ArrayBlob {0}_abi; $ out {0}_abi.Ptr, out {0}_abi.Count $ {0} = MConv_.FromABI_{1}({0}_abi.Ptr, {0}_abi.Count);",
            /* Ref */ "ArrayBlob {0}_abi = MConv_.ToABI_{1}({0}); $ ref {0}_abi.Ptr, ref {0}_abi.Count $ {0} = MConv_.FromABI_{1}({0}_abi.Ptr, {0}_abi.Count);",
            /* Ret */ "ArrayBlob {0}_abi; $ out {0}_abi.Ptr, out {0}_abi.Count $ return MConv_.FromABI_{1}({0}_abi.Ptr, {0}_abi.Count);"
        };

        private static string[] PrimitiveArrayCBConverters = new string[]
        {
            /* In  */ "{0}",
            /* Out */ "$ out {1}[] {0}_wrap $ var {0}_abi = MConv_.ToABI_{1}({0}_wrap); {0} = {0}_abi.Ptr; {0}_count = {0}_abi.Count;",
            /* Ref */ "{1}[] {0}_wrap = MConv_.FromABI_{1}({0}, {0}_count); $ ref {0}_wrap $ var {0}_abi = MConv_.ToABI_{1}({0}_wrap); {0} = {0}_abi.Ptr; {0}_count = {0}_abi.Count;",
            /* Ret */ "$ var {0}_wrap = $ var {0}_abi = MConv_.ToABI_{1}({0}_wrap); {0} = {0}_abi.Ptr; {0}_count = {0}_abi.Count;"
        };

        private static string[] StructArrayConverters = new string[]
        {
            /* In  */ "var {0}_abi = {2}.ToABI_Array({0}); $ {0}_abi, {0}_abi.Length",
            /* Out */ "ArrayBlob {0}_abi; $ out {0}_abi.Ptr, out {0}_abi.Count $ {0} = MConv.FromABI{3}({0}_abi.Ptr, {0}_abi.Count);",
            /* Ref */ "var {0}_abi = MConv.ToABI{3}({0}); $ ref {0}_abi.Ptr, ref {0}_abi.Count $ {0} = MConv.FromABI{3}({0}_abi.Ptr, {0}_abi.Count);",
            /* Ret */ "ArrayBlob {0}_abi; $ out {0}_abi.Ptr, out {0}_abi.Count $ return MConv.FromABI{3}({0}_abi.Ptr, {0}_abi.Count);"
        };

        private static string[] StructArrayCBConverters = new string[]
        {
            /* In  */ "{2}.FromABI_Array({0})",
            /* Out */ "$ out {1}[] {0}_wrap $ var {0}_abi = MConv.ToABI{3}({0}_wrap); {0} = {0}_abi.Ptr; {0}_count = {0}_abi.Count;",
            /* Ref */ "var {0}_wrap = MConv.FromABI{3}({0}, {0}_count); $ ref {0}_wrap $ var {0}_abi = MConv.ToABI{3}({0}_wrap); {0} = {0}_abi.Ptr; {0}_count = {0}_abi.Count;",
            /* Ret */ "$ var {0}_wrap = $ var {0}_abi = MConv.ToABI{3}({0}_wrap); {0} = {0}_abi.Ptr; {0}_count = {0}_abi.Count;"
        };

        private static string[] BlittableStructArrayConverters = new string[]
        {
            /* In  */ "{0}, {0}.Length",
            /* Out */ "ArrayBlob {0}_abi; $ out {0}_abi.Ptr, out {0}_abi.Count $ {0} = MConv.FromABI{3}({0}_abi.Ptr, {0}_abi.Count);",
            /* Ref */ "var {0}_abi = MConv.ToABI{3}({0}); $ ref {0}_abi.Ptr, ref {0}_abi.Count $ {0} = MConv.FromABI{3}({0}_abi.Ptr, {0}_abi.Count);",
            /* Ret */ "ArrayBlob {0}_abi; $ out {0}_abi.Ptr, out {0}_abi.Count $ return MConv.FromABI{3}({0}_abi.Ptr, {0}_abi.Count);"
        };

        private static string[] BlittableStructArrayCBConverters = new string[]
        {
            /* In  */ "{0}",
            /* Out */ "$ out {1}[] {0}_wrap $ var {0}_abi = MConv.ToABI{3}({0}_wrap); {0} = {0}_abi.Ptr; {0}_count = {0}_abi.Count;",
            /* Ref */ "var {0}_wrap = MConv.FromABI{3}({0}, {0}_count); $ ref {0}_wrap $ var {0}_abi = MConv.ToABI{3}({0}_wrap); {0} = {0}_abi.Ptr; {0}_count = {0}_abi.Count;",
            /* Ret */ "$ var {0}_wrap = $ var {0}_abi = MConv.ToABI{3}({0}_wrap); {0} = {0}_abi.Ptr; {0}_count = {0}_abi.Count;"
        };

        private static string[] ObjectArrayConverters = new string[]
        {
            /* In  */ "var {0}_abi = GluonObject.ArrayUnwrap({0}); $ {0}_abi, {0}_abi.Length",
            /* Out */ "ArrayBlob {0}_abi; $ out {0}_abi.Ptr, out {0}_abi.Count $ {0} = MConv_.FromABI_Object<{1}>({0}_abi.Ptr, {0}_abi.Count);",
            /* Ref */ "ArrayBlob {0}_abi = MConv_.ToABI_Object({0}); $ ref {0}_abi.Ptr, ref {0}_abi.Count $ {0} = MConv_.FromABI_Object<{1}>({0}_abi.Ptr, {0}_abi.Count);",
            /* Ret */ "ArrayBlob {0}_abi; $ out {0}_abi.Ptr, out {0}_abi.Count $ return MConv_.FromABI_Object<{1}>({0}_abi.Ptr, {0}_abi.Count);"
        };
        
        private static string[] ObjectArrayCBConverters = new string[]
        {
            /* In  */ "GluonObject.ArrayWrap<{1}>({0})",
            /* Out */ "$ out {1}[] {0}_wrap $ var {0}_abi = MConv_.ToABI_Object({0}_wrap); {0} = {0}_abi.Ptr; {0}_count = {0}_abi.Count;",
            /* Ref */ "var {0}_wrap = MConv_.FromABI_Object<{1}>({0}, {0}_count); $ ref {0}_wrap $ var {0}_abi = MConv_.ToABI_Object({0}_wrap); {0} = {0}_abi.Ptr; {0}_count = {0}_abi.Count;",
            /* Ret */ "$ var {0}_wrap = $ var {0}_abi = MConv_.ToABI_Object({0}_wrap); {0} = {0}_abi.Ptr; {0}_count = {0}_abi.Count;"
        };

        private static string[] DelegateArrayConverters = new string[]
        {
            /* In  */ "var {0}_abi = D{3}.ToABI_Array({0}); $ {0}_abi, {0}_abi.Length",
            /* Out */ "ArrayBlob {0}_abi; $ out {0}_abi.Ptr, out {0}_abi.Count $ {0} = MConv.FromABI{3}({0}_abi.Ptr, {0}_abi.Count);",
            /* Ref */ "ArrayBlob {0}_abi = MConv.ToABI{3}({0}); $ ref {0}_abi.Ptr, ref {0}_abi.Count $ {0} = MConv.FromABI{3}({0}_abi.Ptr, {0}_abi.Count);",
            /* Ret */ "ArrayBlob {0}_abi; $ out {0}_abi.Ptr, out {0}_abi.Count $ return MConv.FromABI{3}({0}_abi.Ptr, {0}_abi.Count);"
        };

        private static string[] DelegateArrayCBConverters = new string[]
        {
            /* In  */ "D{3}.FromABI_Array({0})",
            /* Out */ "$ out {1}[] {0}_wrap $ var {0}_abi = MConv.ToABI{3}({0}_wrap); {0} = {0}_abi.Ptr; {0}_count = {0}_abi.Count;",
            /* Ref */ "var {0}_wrap = MConv.FromABI{3}({0}, {0}_count); $ ref {0}_wrap $ var {0}_abi = MConv.ToABI{3}({0}_wrap); {0} = {0}_abi.Ptr; {0}_count = {0}_abi.Count;",
            /* Ret */ "$ var {0}_wrap = $ var {0}_abi = MConv.ToABI{3}({0}_wrap); {0} = {0}_abi.Ptr; {0}_count = {0}_abi.Count;"
        };

        public static VarConversion Get(IVariable v, PascalEnvironment writer, bool unwrap)
        {
            string conv;

            if (v == null)
                return null;
            if (v.IsVoid)
                return null;

            conv = GenerateConverter(v, v.Context, unwrap);

            if (conv == null)
            {
                if (unwrap)
                {
                    if (v.IsArray)
                    {
                        if (v.Type.IsPrimitive || v.Type.IsString)
                            conv = PrimitiveArrayCBConverters[(int)v.Context];
                        else if (v.Type.IsStruct)
                        {
                            if (CsRender.RequiresABITranslation(v))
                                conv = StructArrayCBConverters[(int)v.Context];
                            else
                                conv = BlittableStructArrayCBConverters[(int)v.Context];
                        }
                        else if (v.Type.IsObject)
                            conv = ObjectArrayCBConverters[(int)v.Context];
                        else if (v.Type.IsDelegate)
                            conv = DelegateArrayCBConverters[(int)v.Context];
                        else
                            return null;
                    }
                    else if (!CsRender.RequiresABITranslation(v))
                        conv = PrimitiveCBConverters[(int)v.Context];
                    else if (v.Type.IsStruct)
                        conv = StructCBConverters[(int)v.Context];
                    else if (v.Type.IsObject)
                        conv = ObjectCBConverters[(int)v.Context];
                    else if (v.Type.IsString)
                        conv = StringCBConverters[(int)v.Context];
                    else if (v.Type.IsDelegate)
                        conv = DelegateCBConverters[(int)v.Context];
                    else
                        return null;
                }
                else
                {
                    if (v.IsArray)
                    {
                        if (v.Type.IsPrimitive || v.Type.IsString)
                            conv = PrimitiveArrayConverters[(int)v.Context];
                        else if (v.Type.IsStruct)
                        {
                            if (CsRender.RequiresABITranslation(v))
                                conv = StructArrayConverters[(int)v.Context];
                            else
                                conv = BlittableStructArrayConverters[(int)v.Context];
                        }
                        else if (v.Type.IsObject)
                        {
                            conv = ObjectArrayConverters[(int)v.Context];
                        }
                        else if (v.Type.IsDelegate)
                            conv = DelegateArrayConverters[(int)v.Context];
                        else
                            return null;
                    }
                    else if (!CsRender.RequiresABITranslation(v))
                        conv = PrimitiveConverters[(int)v.Context];
                    else if (v.Type.IsStruct)
                        conv = StructConverters[(int)v.Context];
                    else if (v.Type.IsObject)
                        conv = ObjectConverters[(int)v.Context];
                    else if (v.Type.IsString)
                        conv = StringConverters[(int)v.Context];
                    else if (v.Type.IsDelegate)
                        conv = DelegateConverters[(int)v.Context];
                    else
                        return null;
                }
            }

            return new VarConversion(conv,
                v.Name,
                writer.TypeName(v.Morph(null, null, null, false), false),
                writer.TypeName(v.Morph(null, null, null, false), true),
                v.Type.ShortId);
        }

        public static VarConversion Get(IVariable v, PascalTreeWriter writer, bool unwrap)
        {
            string conv;

            if (v == null)
                return null;
            if (v.IsVoid)
                return null;

            conv = GenerateConverter(v, v.Context, unwrap);

            if (conv == null)
            {
                if (unwrap)
                {
                    if (v.IsArray)
                    {
                        if (v.Type.IsPrimitive || v.Type.IsString)
                            conv = PrimitiveArrayCBConverters[(int)v.Context];
                        else if (v.Type.IsStruct)
                        {
                            if (CsRender.RequiresABITranslation(v))
                                conv = StructArrayCBConverters[(int)v.Context];
                            else
                                conv = BlittableStructArrayCBConverters[(int)v.Context];
                        }
                        else if (v.Type.IsObject)
                            conv = ObjectArrayCBConverters[(int)v.Context];
                        else if (v.Type.IsDelegate)
                            conv = DelegateArrayCBConverters[(int)v.Context];
                        else
                            return null;
                    }
                    else if (!CsRender.RequiresABITranslation(v))
                        conv = PrimitiveCBConverters[(int)v.Context];
                    else if (v.Type.IsStruct)
                        conv = StructCBConverters[(int)v.Context];
                    else if (v.Type.IsObject)
                        conv = ObjectCBConverters[(int)v.Context];
                    else if (v.Type.IsString)
                        conv = StringCBConverters[(int)v.Context];
                    else if (v.Type.IsDelegate)
                        conv = DelegateCBConverters[(int)v.Context];
                    else
                        return null;
                }
                else
                {
                    if (v.IsArray)
                    {
                        if (v.Type.IsPrimitive || v.Type.IsString)
                            conv = PrimitiveArrayConverters[(int)v.Context];
                        else if (v.Type.IsStruct)
                        {
                            if (CsRender.RequiresABITranslation(v))
                                conv = StructArrayConverters[(int)v.Context];
                            else
                                conv = BlittableStructArrayConverters[(int)v.Context];
                        }
                        else if (v.Type.IsObject)
                        {
                            conv = ObjectArrayConverters[(int)v.Context];
                        }
                        else if (v.Type.IsDelegate)
                            conv = DelegateArrayConverters[(int)v.Context];
                        else
                            return null;
                    }
                    else if (!CsRender.RequiresABITranslation(v))
                        conv = PrimitiveConverters[(int)v.Context];
                    else if (v.Type.IsStruct)
                        conv = StructConverters[(int)v.Context];
                    else if (v.Type.IsObject)
                        conv = ObjectConverters[(int)v.Context];
                    else if (v.Type.IsString)
                        conv = StringConverters[(int)v.Context];
                    else if (v.Type.IsDelegate)
                        conv = DelegateConverters[(int)v.Context];
                    else
                        return null;
                }
            }

            return new VarConversion(conv,
                v.Name,
                writer.TypeRef(v.Morph(null, null, null, false), false),
                writer.TypeRef(v.Morph(null, null, null, false), true),
                v.Type.ShortId);
        }

        public static List<VarConversion> Get(PascalEnvironment writer, bool unwrap, params IVariable[] vars)
        {
            var ret = new List<VarConversion>();

            foreach (var v in vars)
                ret.Add(Get(v, writer, unwrap));

            return ret;
        }

        public static List<VarConversion> Get(PascalTreeWriter writer, bool unwrap, params IVariable[] vars)
        {
            var ret = new List<VarConversion>();

            foreach (var v in vars)
                ret.Add(Get(v, writer, unwrap));

            return ret;
        }

        public VarConversion(string format, params object[] args)
        {
            format = string.Format(format, args);
            var arr = format.Split(_Splitter);
            switch (arr.Length)
            {
                case 1:
                    Item = arr[0].Trim();
                    break;
                case 2:
                    Prefix = arr[0].Trim();
                    Item = arr[1].Trim();
                    break;
                case 3:
                    Prefix = arr[0].Trim();
                    Item = arr[1].Trim();
                    Suffix = arr[2].Trim();
                    break;
                default:
                    throw new InvalidOperationException("Bad conversion format");
            }

            if (string.IsNullOrEmpty(Prefix)) Prefix = null;
            if (string.IsNullOrEmpty(Item)) Item = null;
            if (string.IsNullOrEmpty(Suffix)) Suffix = null;
        }

        public void WritePrefix(PascalRender writer)
        {
            if (Prefix != null)
                writer.Line(Prefix);
        }

        public void WriteItem(PascalRender writer)
        {
            if (Item != null)
                writer.ListItem(Item);
        }

        public void WriteSuffix(PascalRender writer)
        {
            if (Suffix != null)
                writer.Line(Suffix);
        }

        public void WritePrefix(PascalTreeWriter writer)
        {
            if (Prefix != null)
                writer.Line(Prefix);
        }

        public void WriteItem(PascalTreeWriter writer)
        {
            if (Item != null)
                writer.ListItem(Item);
        }

        public void WriteSuffix(PascalTreeWriter writer)
        {
            if (Suffix != null)
                writer.Line(Suffix);
        }
    }
}
