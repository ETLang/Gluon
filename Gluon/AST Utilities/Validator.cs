using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gluon
{
    public static class Validator
    {
        public static void Validate(this AST.Definition def)
        {
            foreach (var t in def.AllTypes.SelectGeneratedTypes().OfType<AST.Struct>())
                t.Validate();
            foreach (var t in def.AllTypes.SelectGeneratedTypes().OfType<AST.Object>())
                t.Validate();
        }

        public static void Validate(this AST.Struct x)
        {
            foreach (var m in x.Fields)
                m.Validate();
        }

        public static void Validate(this AST.Field x)
        {
            Validate((AST.IVariable)x);
        }

        public static void Validate(this AST.Property x)
        {
            Validate((AST.IVariable)x);
        }

        public static void Validate(this AST.Constructor x)
        {
            Validate((AST.ICallSignature)x);
        }

        public static void Validate(this AST.Method x)
        {
            Validate((AST.ICallSignature)x);
        }

        public static void Validate(AST.ICallSignature x)
        {
            if(x.Return != null)
                Validate(x.Return);

            foreach (var p in x.Parameters)
                Validate(p);
        }

        public static void Validate(AST.IVariable x)
        {
        }

        public static void Validate(this AST.Object x)
        {
            foreach (var p in x.Properties)
                p.Validate();

            foreach (var c in x.Constructors)
                c.Validate();

            foreach (var m in x.Methods)
                m.Validate();
        }
    }
}
