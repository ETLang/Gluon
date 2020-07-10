using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Gluon
{
    class Program
    {
        static void Main(string[] args)
        {
            var assembly = ParseArgs(args);

            if (assembly == null)
                return;

            var cd = Path.GetDirectoryName(GluonData.InputDll);

            if (!string.IsNullOrEmpty(cd))
                Directory.SetCurrentDirectory(cd);

            foreach (var target in GluonData.AllTargets.Values)
                if (!target.CleanAndValidate(assembly.GetName().Name))
                    return;

            var types = assembly.GetTypes();

            foreach (var target in GluonData.SelectedTargets)
            {
                GeneratorSettings settings;

                if(!GluonData.AllTargets.TryGetValue(target, out settings))
                {
                    Errors.Generic("Target not found: " + target);
                    return;
                }

                var astBuilder = new AST.Builder();

                astBuilder.BuildFromAssembly(assembly);
                astBuilder.Product.Analyze();
                astBuilder.Product.Validate();

                if (Errors.ErrorCount > 0)
                    return;

                var generator = GluonData.AllGenerators[settings.GeneratorType](astBuilder.Product, settings);
                generator.GenerateAll();
            }

            Environment.ExitCode = 0;
        }

        static void DisplayTargets(Assembly assembly)
        {
            Console.WriteLine("Targets Found:");
            Console.WriteLine();

            bool notargets = true;
            foreach(var target in assembly.GetCustomAttributes<GluonTargetAttribute>())
            {
                notargets = false;
                var cpp = target as GluonTargetCppAttribute;
                var cs = target as GluonTargetCSharpAttribute;

                Console.WriteLine("Target: " + (string.IsNullOrEmpty(target.TargetID) ? "<ERROR: No ID>" : target.TargetID));
                Console.WriteLine("Generator: " + (cpp != null ? "Cpp" : (cs != null) ? "CSharp" : "<ERROR: Unknown Generator>"));
                Console.WriteLine("Mode: " + target.Mode);
                Console.WriteLine("Name: " + (string.IsNullOrEmpty(target.ProjectName) ? assembly.FullName + " (default)" : target.ProjectName));

                if (cpp != null)
                {
                    Console.WriteLine("Project File: " + (string.IsNullOrEmpty(cpp.ProjectFile) ? assembly.FullName + ".vcxproj (default)" : cpp.ProjectFile));
                    Console.WriteLine("Precompiled Header: " + (string.IsNullOrEmpty(cpp.PrecompiledHeader) ? "(none)" : cpp.PrecompiledHeader));
                }

                if (cs != null)
                {
                    Console.WriteLine("Project File: " + (string.IsNullOrEmpty(cs.ProjectFile) ? assembly.FullName + ".csproj (default)" : cpp.ProjectFile));
                }

                Console.WriteLine("Output: " +
                    (string.IsNullOrEmpty(target.OutputFolder) ? ".\\" +
                    (string.IsNullOrEmpty(target.TargetID) ? "<ERROR>" : target.TargetID) + " (default)" : target.OutputFolder));

                Console.WriteLine();
            }

            if (notargets)
            {
                Console.WriteLine(@"
No targets defined in assembly. Defaulting to:

Target: Cpp
Generator: Cpp
Mode: Implementation
Name: " + assembly.GetName().Name + @"
Project File: " + assembly.GetName().Name + @".vcxproj
Precompiled Header: PCH.h
Output: .\Cpp

Target: CSharp
Generator: CSharp
Mode: DotNet
Name: " + assembly.GetName().Name + @"
Project file: " + assembly.GetName().Name + @".csproj
Output: .\CSharp
");
            }
        }

        static bool ParseTargets(Assembly assembly)
        {
            bool notargets = true;
            foreach (var target in assembly.GetCustomAttributes<GluonTargetAttribute>())
            {
                notargets = false;
                var cpp = target as GluonTargetCppAttribute;
                var cs = target as GluonTargetCSharpAttribute;

                if (string.IsNullOrEmpty(target.TargetID))
                {
                    Errors.Generic("Target has no ID!");
                    return false;
                }
                if (cpp != null && cs != null)
                {
                    Errors.Generic("Unrecognized generator type indicated by attribute: " + target.GetType().FullName);
                    return false;
                }

                if (cpp != null)
                {
                    CppMode mode;

                    if (!Enum.TryParse(cpp.Mode, out mode))
                    {
                        Errors.Generic("Invalid mode specified for Cpp generator: " + cpp.Mode);
                        return false;
                    }

                    var settings = new GeneratorSettingsCpp(cpp.TargetID);
                    settings.Mode = mode;
                    settings.ProjectName = string.IsNullOrEmpty(cpp.ProjectName) ? assembly.GetName().Name : cpp.ProjectName;
                    settings.OutputFolder = string.IsNullOrEmpty(cpp.OutputFolder) ? ".\\" + cpp.TargetID : cpp.OutputFolder;
                    settings.ProjectFile = string.IsNullOrEmpty(cpp.ProjectFile) ? assembly.GetName().Name + ".vcxproj" : cpp.ProjectFile;
                    settings.PrecompiledHeader = cpp.PrecompiledHeader;
                    settings.ConsolidateFiles = cpp.ConsolidateFiles;
                    settings.FullIntellisense = cpp.FullIntellisense;

                    GluonData.AllTargets[cpp.TargetID] = settings;
                }

                if (cs != null)
                {
                    CSharpMode mode;

                    if(!Enum.TryParse(cs.Mode, out mode))
                    {
                        Errors.Generic("Invalid mode specified for CSharp generator: " + cs.Mode);
                        return false;
                    }

                    var settings = new GeneratorSettingsCSharp(cs.TargetID);
                    settings.Mode = mode;
                    settings.ProjectName = string.IsNullOrEmpty(cs.ProjectName) ? assembly.GetName().Name : cs.ProjectName;
                    settings.OutputFolder = string.IsNullOrEmpty(cs.OutputFolder) ? ".\\" + cs.TargetID : cs.OutputFolder;
                    settings.ProjectFile = string.IsNullOrEmpty(cs.ProjectFile) ? assembly.GetName().Name + ".csproj" : cs.ProjectFile;
                    settings.ImportedDll = string.IsNullOrEmpty(cs.ImportedDll) ? assembly.GetName().Name + ".Cpp.dll" : cs.ImportedDll;
                    settings.ConsolidateFiles = cs.ConsolidateFiles;

                    GluonData.AllTargets[cs.TargetID] = settings;
                }
            }

            if (notargets)
            {
                var cpp = new GeneratorSettingsCpp("Cpp");
                GluonData.AllTargets["Cpp"] = cpp;

                var cs = new GeneratorSettingsCSharp("CSharp");
                GluonData.AllTargets["CSharp"] = cs;
            }

            return true;
        }
        
        static Assembly ParseArgs(string[] args)
        {
            if (args.Length == 0)
                return null;

            if (!File.Exists(args[0]))
                Errors.Generic("Input file " + args[0] + " was not found");

            GluonData.InputDll = args[0];

            var assembly = Assembly.LoadFrom(GluonData.InputDll);

            if (!ParseTargets(assembly))
            {
                DisplayTargets(assembly);
                return null;
            }

            for (int i = 1; i < args.Length; i++)
            {
                string follow = (i + 1 < args.Length) ? args[i + 1] : null;

                if (args[i] == "-listTargets")
                {
                    DisplayTargets(assembly);
                    return null;
                }

                if (follow == null)
                {
                    Errors.Generic("incomplete argument passed to Gluon.exe: " + args[i]);
                    return null;
                }

                if (args[i] == "-gen")
                {
                    foreach (var t in follow.Split(','))
                        if(!GluonData.SelectedTargets.Contains(t))
                            GluonData.SelectedTargets.Add(t);
                }
                else if (args[i] == "-?" || args[i] == "/?" || args[i] == "-help")
                {
                    Console.WriteLine(@"
Gluon Arguments:
Gluon <input DLL> -option [value]

-listTargets - list all targets defined in the assembly.
-gen <generator targets> - defaults to all targets defined in the assembly.
    targets can be any target defined by the assembly, or a generator name.
    Available generator names are:
    Cpp
    CSharp

Target-specific options. If no target is specified, it will apply to all.
Targeting syntax is -targetID:option

-name <name> - name of the project. Defaults to the assembly name.
-out <output dir> - defaults to .\<targetID>
-mode <generator mode> - possible modes are listed below
-proj <proj file> - project file. Defaults too <outdir>\<project name>.<ext>
-pch <PCH file> - Specifies the PCH filename. Defaults to PCH.h. Cpp only.
-dllImport <Dll name> - name of the DLL for the wrapper to import. CSharp only.
                        Defaults to <project name>.Cpp.Dll.
-intellisense - Enables intellisense on ABI code. Disabled by default.
-consolidate - Consolidates generated code into a minimal set of files.

Cpp Generator Modes:
   Implementation - C++ class definitions for implementation. Default for C++.
   PimplWrapper - Pimpl wrapper for C++ use of an external DLL.

CSharp Generator Modes:
   DotNet - Wrapper for Microsoft .Net 4.5. Default for C#.
   Mono - Wrapper for Mono (Unity compatible)
");
                    return null;
                }
                else
                {
                    var tokens = args[i].Remove(0, 1).Split(':');
                    bool fail = false;

                    string argTarget, arg;
                    if (tokens.Length == 1)
                    {
                        argTarget = null;
                        arg = tokens[0];
                    }
                    else if (tokens.Length == 2)
                    {
                        argTarget = tokens[0];
                        arg = tokens[1];
                    }
                    else
                    {
                        Errors.Generic("Malformed argument: " + args[i]);
                        return null;
                    }

                    Action<Action<GeneratorSettings>> apply = act =>
                    {
                        if (argTarget == null)
                        {
                            foreach (var t in GluonData.AllTargets.Values)
                                act(t);
                        }
                        else
                        {
                            GeneratorSettings settings;
                            if(!GluonData.AllTargets.TryGetValue(argTarget, out settings))
                            {
                                Errors.Generic("Unknown target ID: " + argTarget);
                                fail = true;
                            }

                            act(settings);
                        }
                    };

                    Action<Action<GeneratorSettingsCpp>> apply_cpp = act =>
                    {
                        apply(settings =>
                        {
                            var cpp = settings as GeneratorSettingsCpp;
                            if (cpp != null)
                                act(cpp);
                        });
                    };

                    Action<Action<GeneratorSettingsCSharp>> apply_cs = act =>
                    {
                        apply(settings =>
                        {
                            var cs = settings as GeneratorSettingsCSharp;
                            if (cs != null)
                                act(cs);
                        });
                    };

                    if (arg == "name")
                        apply(settings => settings.ProjectName = follow);
                    else if (arg == "out")
                        apply(settings => settings.OutputFolder = follow);
                    else if (arg == "mode")
                        apply(settings => settings.Mode = follow);
                    else if (arg == "proj")
                    {
                        apply_cpp(cpp => cpp.ProjectFile = follow);
                        apply_cs(cs => cs.ProjectFile = follow);
                    }
                    else if (arg == "pch")
                        apply_cpp(cpp => cpp.PrecompiledHeader = follow);
                    else if (arg == "dllImport")
                        apply_cs(cs => cs.ImportedDll = follow);
                    else if (arg == "intellisense")
                        apply_cpp(cpp => cpp.FullIntellisense = true);
                    else if (arg == "consolidate")
                        apply(settings => settings.ConsolidateFiles = true);
                    else
                    {
                        Errors.Generic("Unrecognized argument: " + arg);
                        fail = true;
                    }

                    if(fail)
                        return null;

                    i++;
                }
            }

            if(GluonData.SelectedTargets.Count == 0)
            {
                foreach (var target in GluonData.AllTargets.Keys)
                    GluonData.SelectedTargets.Add(target);
            }

            return assembly;
        }
    }
}
