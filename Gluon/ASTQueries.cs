using Gluon.AST;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gluon
{
    public static class ASTQueries
    {
        public static IEnumerable<Type> SelectReferencedTypes(this Node node)
        {
            return node.Declarations
                .OfType<AST.Type>()
                .Where(t => t != node)
                .Distinct();
        }

        public static IEnumerable<IHasAttributes> SelectNodesWithGluonAttributes(this Node node)
        {
            return node.Declarations
                .Where(n => n is IHasAttributes)
                .Distinct()
                .Cast<IHasAttributes>()
                .Where(i => i.Attributes.Any(a => a.Type.Namespace != null && a.Type.Namespace.Name == "Gluon"));
        }

        public static IEnumerable<Namespace> SelectReferencedNamespaces(this Node node, Namespace local)
        {
            return node.Declarations
                .Where(n => n is Namespace && n != local)
                .Distinct()
                .Cast<Namespace>();
        }

        public static IEnumerable<Namespace> SelectNestedNamespaces(this Definition def, Namespace parent)
        {
            foreach (var ns in def.DependentNamespaces)
                if (ns.Parent == parent)
                    yield return ns;
        }

        public static IEnumerable<Type> SelectTypesInNamespace(this Definition def, Namespace ns)
        {
            return def.AllTypes.WhereInNamespace(ns);
        }

        public static IEnumerable<Type> WhereInNamespace(this IEnumerable<Type> types, Namespace ns)
        {
            return types.Where(t => t.Namespace == ns);
        }

        public static IEnumerable<Type> SelectTypesInAssembly(this Definition def, Assembly assembly)
        {
            return def.AllTypes.WhereInAssembly(assembly);
        }

        public static IEnumerable<Type> WhereInAssembly(this IEnumerable<Type> types, Assembly assembly)
        {
            return types.Where(t => t.Assembly == assembly);
        }

        public static IEnumerable<Type> SelectGeneratedTypes(this IEnumerable<Type> types, TypeOrigin includedNonGluonOrigin = TypeOrigin.Gluon)
        {
            return types.Where(t => t.Origin == TypeOrigin.Gluon || t.Origin == includedNonGluonOrigin);
        }

        private static IEnumerable<Type> SelectArrayedTypes(Struct type)
        {
            if (type == null) yield break;

            foreach (var field in type.Fields)
                if (field.IsArray)
                    yield return field.Type;
        }

        private static IEnumerable<Type> SelectArrayedTypes(Object type)
        {
            if (type == null) yield break;

            foreach (var p in type.Properties)
                if (p.IsArray)
                    yield return p.Type;

            foreach(var m in type.Methods)
            {
                if (m.Return.IsArray)
                    yield return m.Return.Type;

                foreach (var arg in m.Parameters)
                    if (arg.IsArray)
                        yield return arg.Type;
            }

            foreach(var e in type.Events)
            {
                if (e.Return.IsArray)
                    yield return e.Return.Type;

                foreach (var arg in e.Parameters)
                    if (arg.IsArray)
                        yield return arg.Type;
            }

            foreach (var c in type.Constructors)
            {
                foreach (var arg in c.Parameters)
                    if (arg.IsArray)
                        yield return arg.Type;
            }
        }

        private static IEnumerable<Type> SelectArrayedTypes(Delegate type)
        {
            if (type == null) yield break;

            if (type.Return.IsArray)
                yield return type.Return.Type;

            foreach (var arg in type.Parameters)
                if (arg.IsArray)
                    yield return arg.Type;
        }

        private static IEnumerable<Type> SelectArrayedTypes_(Definition def)
        {
            foreach(var t in def.AllTypes)
            {
                foreach (var tt in SelectArrayedTypes(t as Struct))
                    yield return tt;
                foreach (var tt in SelectArrayedTypes(t as Object))
                    yield return tt;
                foreach (var tt in SelectArrayedTypes(t as Delegate))
                    yield return tt;
            }
        }

        public static IEnumerable<Type> SelectArrayedTypes(this Definition def)
        {
            return SelectArrayedTypes_(def).Distinct();
        }

        public static bool SignatureEquals(this ICallSignature a, ICallSignature b)
        {
            if (!a.Return.Equals(b.Return) || a.Parameters.Count != b.Parameters.Count)
                return false;

            for (int i = 0; i < a.Parameters.Count; i++)
                if (!a.Parameters[i].Equals(b.Parameters[i]))
                    return false;

            return true;
        }

        public static bool IsMethodOverride(this Object node, Method method)
        {
            var bt = node.BaseType;

            while (bt != null)
            {
                if (bt.SyntaxExpandedMethods.Any(bm => bm.Name == method.Name && bm.SignatureEquals(method)))
                    return true;

                bt = bt.BaseType;
            }

            return false;
        }

        public static string GetComCompatibleName(this ICallSignature sig)
        {
            if (sig.OverloadOrdinal == 0)
                return sig.Name;
            else
                return sig.Name + "_" + sig.OverloadOrdinal.ToString();
        }

        // TODO Remove
        //public static bool IsPropertyGetterOverride(this Object node, Property prop)
        //{
        //    var bt = node.BaseType;

        //    while (bt != null)
        //    {
        //        if (bt.Properties.Any(bp => bp.Name == prop.Name))
        //            return true;

        //        bt = bt.BaseType;
        //    }

        //    return false;
        //}

        //public static bool IsPropertySetterOverride(this Object node, Property prop)
        //{
        //    if (!prop.IsReadOnly)
        //        return false;

        //    var bt = node.BaseType;

        //    while (bt != null)
        //    {
        //        if (bt.Properties.Any(bp => bp.Name == prop.Name && !bp.IsReadOnly))
        //            return true;

        //        bt = bt.BaseType;
        //    }

        //    return false;
        //}


        public static IVariable ToVariable(this Type node, VariableContext ctx = VariableContext.Member, string name = null)
        {
            return new Parameter()
            {
                Type = node,
                Name = name,
                Context = ctx
            };
        }

        public static string FullName(this AST.Namespace ns, string scopeOperator)
        {
            if (ns.IsGlobal)
                return "";
            else if (ns.Parent.IsGlobal)
                return ns.Name;
            else
                return FullName(ns.Parent, scopeOperator) + scopeOperator + ns.Name;
        }

        public static string FullName(this AST.Type t, string scopeOperator)
        {
            if (t.Namespace.IsGlobal || t.IsVoid || t.IsPrimitive || t.IsString)
                return t.Name;
            else
                return FullName(t.Namespace, scopeOperator) + scopeOperator + t.Name;
        }

        public static IVariable Morph(this IVariable p, string name, VariableContext? context = null, Type type = null, bool? isArray = null)
        {
            return new Parameter()
            {
                Name = name ?? p.Name,
                Type = type ?? p.Type,
                Context = context ?? p.Context,
                IsArray = isArray ?? p.IsArray
            };
        }

        public static ICallSignature Rename(this ICallSignature c, string name)
        {
            var m = new Method()
            {
                Access = Access.Public,
                Name = name,
                Return = c.Return,
                Nature = MemberNature.Abstract,
                IsConst = c.IsConst
            };

            foreach (var arg in c.Parameters)
                m.Parameters.Add(arg);

            return m;
        }

        public static Method AsConst(this Method c, bool isConst = true)
        {
            var m = new Method()
            {
                Access = c.Access,
                Name = c.Name,
                Return = c.Return,
                Nature = c.Nature,
                OverloadOrdinal = c.OverloadOrdinal,
                IsConst = isConst
            };

            foreach (var arg in c.Parameters)
                m.Parameters.Add(arg);

            return m;
        }

        public static bool IsWriteable(this IVariable arg)
        {
            return arg.IsRef || arg.IsOut;
        }

        public static IEnumerable<IVariable> GetABIParametersCs(this ICallSignature sig, bool explicitContext = false)
        {
            foreach(var v in GetABIParametersCpp(sig, explicitContext))
            {
                if (v.IsArray && v.IsWriteable())
                    yield return v.Morph(null, null, BasicTypes.IntPtr, false);
                else
                    yield return v;
            }
        }

        public static IEnumerable<IVariable> GetABIParametersCs(this IVariable arg)
        {
            foreach (var v in arg.GetABIParametersCpp())
            {
                if (v.IsArray && v.IsWriteable())
                    yield return v.Morph(null, null, BasicTypes.IntPtr, false);
                else
                    yield return v;
            }
        }

        public static IEnumerable<IVariable> GetABIParametersCs(this IEnumerable<IVariable> args)
        {
            foreach (var v in args.GetABIParametersCpp())
            {
                if (v.IsArray && v.IsWriteable())
                    yield return v.Morph(null, null, BasicTypes.IntPtr, false);
                else
                    yield return v;
            }
        }

        public static IEnumerable<IVariable> GetABIParametersCpp(this IVariable arg)
        {
            yield return arg;

            if(arg.IsArray)
                yield return new Parameter(BasicTypes.Int32, arg.Name + "_count", arg.Context, false);
            else if (arg.Type.IsDelegate)
                yield return new Parameter(BasicTypes.IObject, arg.Name + "_context", arg.Context, false);
        }

        public static IEnumerable<IVariable> GetABIParametersCpp(this IEnumerable<IVariable> args)
        {
            foreach (var arg in args)
                foreach (var subarg in arg.GetABIParametersCpp())
                    yield return subarg;
        }

        public static IEnumerable<IVariable> GetABIParametersCpp(this ICallSignature sig, bool explicitContext = false)
        {
            if(explicitContext)
                yield return new Parameter(BasicTypes.IObject, "__i_", VariableContext.In, false);

            foreach (var arg in sig.Parameters.GetABIParametersCpp())
                yield return arg;

            if (sig.Return != null && !sig.Return.IsVoid)
                foreach (var arg in sig.Return.Morph("___ret", VariableContext.Out).GetABIParametersCpp())
                    yield return arg;
        }

        public static string GetABIConstructorName(this AST.Constructor ctor, AST.Object owner)
        {
            int index = owner.Constructors.IndexOf(ctor) + 1;
            return $"Create_{owner.FullName("_")}_{index}";
        }
    }
}
