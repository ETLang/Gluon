using GluonTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GluonTestRunner
{
    class Program
    {
        static string S(object x)
        {
            if (x == null)
                return "<null>";

            if (x is BlittableStruct)
            {
                var b = (BlittableStruct)x;
                return string.Format("{{ {0}, {1}, {2}, {3} }}", b.u, b.v, b.x, b.y);
            }

            if (x is ComplexStruct)
            {
                var c = (ComplexStruct)x;
                return string.Format("{{ {0} Del(3,4) = {1}, {2} }}", c.Name, S(c.Del(3,4)), S(c.Sub));
            }

            if(x is DummyClass)
            {
                return ((DummyClass)x).Nugget;
            }

            if (x is NamedDelegate)
            {
                return S(((NamedDelegate)x)("a", "z"));
            }

            if (x is Array)
            {
                var a = (Array)x;
                var sb = new StringBuilder();

                sb.Append("{ ");

                if (a.Length > 0)
                    sb.Append(S(a.GetValue(0)));

                for (int i = 1; i < a.Length; i++)
                    sb.AppendFormat(", {0}", S(a.GetValue(i)));

                sb.Append(" }");

                return sb.ToString();
            }

            return x.ToString();
        }
        static void PrintSend<InT, RefT>(string title, InT x, RefT refx)
        {
            Console.WriteLine("{0}(C#) Sent:", title);
            Console.WriteLine("x = {0}", S(x));
            Console.WriteLine("refx = {0}", S(refx));
            Console.WriteLine();
        }

        static void PrintRecv<OutT, RefT, RetT>(string title, OutT outx, RefT refx, RetT ret)
        {
            Console.WriteLine("{0}(C#) Received:", title);
            Console.WriteLine("outx = {0}", S(outx));
            Console.WriteLine("refx = {0}", S(refx));
            Console.WriteLine("ret = {0}", S(ret));
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            var unitTest = new ConversionUnitTest();

            {
                string title = "Primitives";
                bool x = false;
                int refx = 98;
                PrintSend(title, x, refx);
                var ret = unitTest.Primitives(x, out char outx, ref refx);
                PrintRecv(title, outx, refx, ret);
            }

            {
                string title = "Strings";
                var x = "Hello C++";
                var refx = "Have A String";
                PrintSend(title, x, refx);
                var ret = unitTest.Strings(x, out string outx, ref refx);
                PrintRecv(title, outx, refx, ret);
            }

            {
                string title = "SimpleStructs";
                var x = new BlittableStruct(1, 3, 3, 7);
                var refx = new BlittableStruct(8, 8, 8, 8);
                PrintSend(title, x, refx);
                var ret = unitTest.SimpleStructs(x, out BlittableStruct outx, ref refx);
                PrintRecv(title, outx, refx, ret);
            }

            {
                string title = "Objects";
                var x = new DummyClass() { Nugget = "DummyC#In" };
                var refx = new DummyClass() { Nugget = "DummyC#Ref" };
                PrintSend(title, x, refx);
                var ret = unitTest.Objects(x, out DummyClass outx, ref refx);
                refx.Dispose();
                x.Dispose();
                PrintRecv(title, outx, refx, ret);
            }

            {
                string title = "NamedDelegates";
                NamedDelegate x = (a, b) => a.Length + b.Length;
                NamedDelegate refx = (a, b) => (int)a[0] * (int)b[0];
                PrintSend(title, x, refx);
                var ret = unitTest.NamedDelegates(x, out NamedDelegate outx, ref refx);
                PrintRecv(title, outx, refx, ret);
            }

            {
                string title = "ComplexStructs";
                var x = new ComplexStruct("ComplexC#In", new BlittableStruct(5, 4, 6, 3), new DummyClass() { Nugget = "WelcomeNugget" }, (u, v) => u | v);
                var refx = new ComplexStruct("ComplexC#Ref", new BlittableStruct(9, 0, 0, 9), new DummyClass() { Nugget = "RefNugget" }, (u, v) => u * u * v);
                PrintSend(title, x, refx);
                var ret = unitTest.ComplexStructs(x, out ComplexStruct outx, ref refx);
                PrintRecv(title, outx, refx, ret);
            }

            {
                string title = "PrimitiveArrays";
                var x = new bool[] { true, false, false, true, false, true };
                var refx = new int[] { 10, 100, 1000, 10000 };
                PrintSend(title, x, refx);
                var ret = unitTest.PrimitiveArrays(x, out char[] outx, ref refx);
                PrintRecv(title, outx, refx, ret);
            }

            {
                string title = "StringArrays";
                var x = new string[] { "The", "Quick", "Brown", "Fox" };
                var refx = new string[] { "Some", "Strings" };
                PrintSend(title, x, refx);
                var ret = unitTest.StringArrays(x, out string[] outx, ref refx);
                PrintRecv(title, outx, refx, ret);
            }

            {
                string title = "SimpleStructArrays";
                var x = new BlittableStruct[] { new BlittableStruct(1001, 1002, 1003, 1004), new BlittableStruct(2001, 2002, 2003, 2004), new BlittableStruct(3001, 3002, 3003, 3004) };
                var refx = new BlittableStruct[] { new BlittableStruct(-1, -2, -3, -4), new BlittableStruct(-5, -6, -7, -8) };
                PrintSend(title, x, refx);
                var ret = unitTest.SimpleStructArrays(x, out BlittableStruct[] outx, ref refx);
                PrintRecv(title, outx, refx, ret);
            }

            {
                string title = "ComplexStructArrays";
                var x = new ComplexStruct[]
                {
                    new ComplexStruct("ComplexArrC#[0]" ,new BlittableStruct(-1, 0, 1, 0), new DummyClass() { Nugget = "ComplexArrNugget[0]" }, (a,b) => a*a*b*b),
                    new ComplexStruct("ComplexArrC#[1]", new BlittableStruct(4,3,2,1), new DummyClass() { Nugget = "ComplexArrNugget[1]" }, (a,b) => b*b - a*a)
                };
                var refx = new ComplexStruct[]
                {
                    new ComplexStruct("ComplexArrRefC#[0]", new BlittableStruct(11, 12, 13, 14), new DummyClass() { Nugget = "ComplexArrRefNugget[0]" }, (a,b) => a-b)
                };
                PrintSend(title, x, refx);
                var ret = unitTest.ComplexStructArrays(x, out ComplexStruct[] outx, ref refx);
                PrintRecv(title, outx, refx, ret);
            }

            {
                string title = "ObjectArrays";
                var x = new DummyClass[]
                {
                    new DummyClass() { Nugget = "Arr0" },
                    new DummyClass() { Nugget = "Arr1" },
                    null,
                    new DummyClass() { Nugget = "Arr3" }
                };
                var refx = new DummyClass[]
                {
                    null,
                    null
                };
                PrintSend(title, x, refx);
                var ret = unitTest.ObjectArrays(x, out DummyClass[] outx, ref refx);
                PrintRecv(title, outx, refx, ret);
            }

            {
                string title = "NamedDelegateArrays";
                var x = new NamedDelegate[]
                {
                    (a,b) => a.Length * b.Length,
                    (a,b) => a.Length + (int)b[0],
                };
                var refx = new NamedDelegate[]
                {
                    (a,b) => (int)a[0] * (int)b[0]
                };
                PrintSend(title, x, refx);
                var ret = unitTest.NamedDelegateArrays(x, out NamedDelegate[] outx, ref refx);
                PrintRecv(title, outx, refx, ret);
            }

            {
                try
                {
                    Func<char[], string> refx = null;
                    //unitTest.GenericDelegates(null, out var outx, ref refx);
                }
                catch(Exception e)
                {
                    Console.WriteLine("Caught Exception : " + e.GetType().Name);
                }
            }

            var test = new ITestClass();

            Console.WriteLine(string.Format("RO Property = {0}", test.ReadOnlyProperty));
            Console.WriteLine(string.Format("Property = {0}", test.Property));
            test.Property = 17;
            Console.WriteLine(string.Format("Property = {0}", test.Property));


            try
            {
                Console.WriteLine("Testing AccessDeniedException...");
                unitTest.ExCheckAccessDenied();
                Console.WriteLine("Error: No Exception Thrown!");
            }
            catch (AccessViolationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: Improper exception: ");
                Console.WriteLine(e.ToString());
            }

            try
            {
                Console.WriteLine("Testing ArgumentException...");
                unitTest.ExCheckArgument();
                Console.WriteLine("Error: No Exception Thrown!");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: Improper exception: ");
                Console.WriteLine(e.ToString());
            }

            try
            {
                Console.WriteLine("Testing ArgumentNullException...");
                unitTest.ExCheckArgumentNull();
                Console.WriteLine("Error: No Exception Thrown!");
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: Improper exception: ");
                Console.WriteLine(e.ToString());
            }

            try
            {
                Console.WriteLine("Testing Generic Exceptions...");
                unitTest.ExCheckGeneric();
                Console.WriteLine("Error: No Exception Thrown!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Console.WriteLine("Testing Generic STD Exceptions...");
                unitTest.ExCheckGenericStd();
                Console.WriteLine("Error: No Exception Thrown!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Console.WriteLine("Testing InvalidOperationException...");
                unitTest.ExCheckInvalidOperation();
                Console.WriteLine("Error: No Exception Thrown!");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: Improper exception: ");
                Console.WriteLine(e.ToString());
            }

            try
            {
                Console.WriteLine("Testing NotImplementedException...");
                unitTest.ExCheckNotImplemented();
                Console.WriteLine("Error: No Exception Thrown!");
            }
            catch (NotImplementedException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: Improper exception: ");
                Console.WriteLine(e.ToString());
            }

            try
            {
                Console.WriteLine("Testing NullReferenceException...");
                unitTest.ExCheckNullReference();
                Console.WriteLine("Error: No Exception Thrown!");
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: Improper exception: ");
                Console.WriteLine(e.ToString());
            }
        }
    }
}
