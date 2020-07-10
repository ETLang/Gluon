using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gluon
{
    static class GluonData
    {
        public static Dictionary<string, Func<AST.Definition, GeneratorSettings, Generator>> AllGenerators =
            new Dictionary<string, Func<AST.Definition, GeneratorSettings, Generator>>
            {
                { "Cpp", (def, settings) => new CppGenerator(def, settings) },
                { "CSharp", (def, settings) => new CsGenerator(def, settings) }
            };

        public static string InputDll { get; set; }
        public static Dictionary<string, GeneratorSettings> AllTargets { get; private set; } = new Dictionary<string, GeneratorSettings>();
        public static HashSet<string> SelectedTargets { get; private set; } = new HashSet<string>();
    }
}
