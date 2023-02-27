using Gluon;

[assembly: GluonLibraryDefinition]

[assembly: GluonTargetCpp("Cpp", 
    OutputFolder = @"..\..\..\..\SampleImageFilterCpp",
    ProjectFile = @"..\..\..\..\SampleImageFilterCpp\SampleImageFilterCpp.vcxproj",
    FullIntellisense = true)]

[assembly: GluonTargetCSharp("CSharp",
    OutputFolder = @"..\..\..\..\SampleImageFilterCs",
    ProjectFile = @"..\..\..\..\SampleImageFilterCs\SampleImageFilterCs.csproj",
    ImportedDll = "SampleImageFilterCpp.dll")]