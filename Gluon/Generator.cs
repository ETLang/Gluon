﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Gluon
{
    public enum ApiStrata
    {
        Normal,
        ABI,
    }

    public enum TypeOrigin
    {
        /// <summary>
        /// Gluon-originated type. Will generate C++ types, ABI, and C# wrappers.
        /// </summary>
        Gluon,

        /// <summary>
        /// Native types. Native interfaces will not have anything generated. and can be left empty. Native structs and enums will have C# wrappers generated.
        /// </summary>
        Native,

        /// <summary>
        /// Types defined in non-Gluon managed assemblies. Structs, enums, and delegates will have C++ representations generated. Cannot apply to interfaces.
        /// </summary>
        Managed,

        /// <summary>
        /// Compatible types defined in both non-Gluon managed assemblies and in native code. Gluon will generate conversion code.
        /// </summary>
        Mapped,

        /// <summary>
        /// Intermediary type generated by Gluon to facilitate type mappings between known C# types and known C++ types.
        /// </summary>
        MappedIntermediary
    }

    public enum ConversionContext
    {
        ToABI,
        ABIOutToMember,
        FromABIRef,
        MemberToIn,
        FromABI,
        MemberToABIRef,
        ReturnToABIOut
    }

    public abstract class Generator
    {
        #region Constants

        public static readonly string Disclaimer =
@"This file is automatically maintained by Gluon.
Do not attempt to modify, as any modifications will be overwritten.";

        #endregion

        public AST.Definition Definition { get; private set; }
        public GeneratorSettings Settings { get; private set; }
        //public string OutputFolder { get; private set; }
        //public string GeneratorType { get; private set; }
        public List<string> OutputFiles { get; set; }

        public Generator(AST.Definition definition, GeneratorSettings settings)
        {
            Definition = definition;
            Settings = settings;
            OutputFiles = new List<string>();
        }

        protected void CopyBaseFiles()
        {
            // Copy Gluon base to output
            var gluonBasePath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetCallingAssembly().Location), Settings.GeneratorType);

            if (Directory.Exists(gluonBasePath))
                foreach (var file in Directory.GetFiles(gluonBasePath, "*", SearchOption.AllDirectories))
                {
                    var relative = file.Remove(0, gluonBasePath.Length + 1);
                    var dest = Path.Combine(Settings.OutputFolder, relative);

                    var dir = Path.GetDirectoryName(dest);

                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);

                    File.Copy(file, dest, true);
                    OutputFiles.Add(dest);
                }
        }

        public abstract void GenerateAll();
    }
}
