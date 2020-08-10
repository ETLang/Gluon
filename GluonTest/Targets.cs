using Gluon;

[assembly: GluonLibraryDefinition]

// The C++ project that implements the locator. It builds a static .lib
[assembly: GluonTargetCpp("Cpp", CppMode.Implementation,
    OutputFolder = @"..\..\..\GluonTestResults\cpp",
    ProjectName = "GluonTest",
    ProjectFile = @"..\..\..\GluonTestResults\GluonTestResults.vcxproj",
    FullIntellisense = false,
    ConsolidateFiles = true)]

// Generates wrapper classes for the Locator UWP DLL, which can be deployed to the HoloLens.
[assembly: GluonTargetCSharp("UWP", CSharpMode.Default,
    OutputFolder = @"..\..\..\GluonTestResults\cs",
    ProjectFile = @"..\..\..\GluonTestResultsCs\GluonTestResults.csproj",
    ImportedDll = "GluonTestResultsCpp.dll",
    ConsolidateFiles = false)]

// Generates wrapper classes for the Locator UWP DLL, which can be deployed to the HoloLens.
[assembly: GluonTargetCSharp("UWPConsolidated", CSharpMode.Default,
    OutputFolder = @"..\..\..\GluonTestResults\cs",
    ProjectFile = @"..\..\..\GluonTestResultsConsolidatedCs\GluonTestResultsConsolidatedCs.csproj",
    ImportedDll = "GluonTestResultsCpp.dll",
    ConsolidateFiles = true)]
