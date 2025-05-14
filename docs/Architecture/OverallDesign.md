# Project Design

## Simplified architecture

UnityDecompiler is built on a modular architecture:

1. **Core**:<br/>
    `
        Contains the core functionality, logic, pipeline processing, game information analysis + common utilities
    `
2. **Decompilers**:<br/>
    `
        Specialized modules for IL2CPP and Mono decompilation with a common decompiled class / project layout
    `
3. **Asset Extractors**:<br/>
    `
        Extracts and converts various assets
    `
4. **Project Generation**:<br/>
    `
        Reconstructs the decompiled game into a Unity project based on a project and script template
    `
5. **UI**:<br/>
    `
        An electron-based GUI that communicates with the C# backend 
    `

## Relationships


<br/>

## Complete structure
```
UnityDecompiler/
│
├── UnityDecompiler.sln
│
├── src/
│   ├── UnityDecompiler.Core/
│   │   ├── UnityDecompiler.Core.csproj
│   │   ├── GameAnalyzer/
│   │   │   ├── UnityVersionDetector.cs       # Detects Unity version from game files
│   │   │   ├── BuildMethodAnalyzer.cs        # Determines Mono vs IL2CPP
│   │   │   └── GameStructureMapper.cs        # Maps game file structure
│   │   │
│   │   ├── Pipeline/
│   │   │   ├── ExtractionPipeline.cs         # Main extraction orchestration
│   │   │   ├── PipelineContext.cs            # Shared context between pipeline stages
│   │   │   └── PipelineStage.cs              # Base class for pipeline stages
│   │   │
│   │   ├── Common/
│   │   │   ├── Logging/
│   │   │   │   ├── ILogger.cs                # Logging interface
│   │   │   │   └── FileLogger.cs             # File-based logger implementation
│   │   │   │
│   │   │   ├── Config/
│   │   │   │   ├── AppConfig.cs              # Application configuration
│   │   │   │   └── ExtractorSettings.cs      # Settings for extraction process
│   │   │   │
│   │   │   └── Utils/
│   │   │       ├── FileUtils.cs              # File handling utilities
│   │   │       ├── PathUtils.cs              # Path manipulation utilities
│   │   │       └── TypeUtils.cs              # Type handling utilities
│   │   │
│   │   └── Info/
│   │       ├── GameInfo.cs                   # Game metadata
│   │       ├── AssemblyInfo.cs               # Assembly metadata
│   │       └── AssetInfo.cs                  # Asset metadata
│   │
│   ├── UnityDecompiler.Decompilers/
│   │   ├── UnityDecompiler.Decompilers.csproj
│   │   │
│   │   ├── Mono/
│   │   │   ├── MonoDecompiler.cs             # Mono assembly decompiler
│   │   │   ├── AssemblyLoader.cs             # Loads .NET assemblies
│   │   │   └── CSharpCodeGenerator.cs        # Generates C# from IL
│   │   │
│   │   ├── IL2CPP/
│   │   │   ├── IL2CPPDecompiler.cs           # IL2CPP decompiler main class
│   │   │   ├── MetadataParser.cs             # Parses IL2CPP metadata
│   │   │   ├── HeaderReconstructor.cs        # Reconstructs C++ headers
│   │   │   └── TypeReconstructor.cs          # Reconstructs types from IL2CPP
│   │   │
│   │   └── Common/
│   │       ├── DecompilerBase.cs             # Base class for decompilers
│   │       ├── DecompiledProject.cs          # Represents decompiled project
│   │       └── DecompiledClass.cs            # Represents decompiled class
│   │
│   ├── UnityDecompiler.AssetExtractors/
│   │   ├── UnityDecompiler.AssetExtractors.csproj
│   │   │
│   │   ├── Texture/
│   │   │   ├── TextureExtractor.cs           # Extracts texture assets
│   │   │   ├── TextureConverter.cs           # Converts Unity texture formats
│   │   │   └── TextureMetadata.cs            # Texture metadata handling
│   │   │
│   │   ├── Model/
│   │   │   ├── ModelExtractor.cs             # Extracts 3D models
│   │   │   ├── RigExtractor.cs               # Extracts rigging information
│   │   │   └── MaterialLinker.cs             # Links models to materials
│   │   │
│   │   ├── Audio/
│   │   │   ├── AudioExtractor.cs             # Extracts audio files
│   │   │   └── AudioConverter.cs             # Converts audio formats
│   │   │
│   │   ├── Scene/
│   │   │   ├── SceneExtractor.cs             # Extracts scene data
│   │   │   ├── SceneHierarchyBuilder.cs      # Rebuilds scene hierarchies
│   │   │   └── PrefabExtractor.cs            # Extracts prefabs
│   │   │
│   │   └── Common/
│   │       ├── AssetBundle/
│   │       │   ├── AssetBundleReader.cs      # Reads Unity asset bundles
│   │       │   └── AssetBundleExtractor.cs   # Extracts from asset bundles
│   │       │
│   │       ├── SerializedAsset.cs            # Represents serialized Unity asset
│   │       └── AssetDatabase.cs              # Manages extracted assets
│   │
│   ├── UnityDecompiler.ProjectGeneration/
│   │   ├── UnityDecompiler.ProjectGeneration.csproj
│   │   │
│   │   ├── Templates/
│   │   │   ├── ProjectTemplate.cs            # Base Unity project template
│   │   │   └── ScriptTemplates.cs            # Script template generation
│   │   │
│   │   ├── CodeImport/
│   │   │   ├── CodeImporter.cs               # Imports decompiled code
│   │   │   └── ReferenceResolver.cs          # Resolves code references
│   │   │
│   │   ├── AssetImport/
│   │   │   ├── AssetImporter.cs              # Imports extracted assets
│   │   │   └── AssetLinker.cs                # Links assets to scripts
│   │   │
│   │   └── Output/
│   │       ├── ProjectWriter.cs              # Writes project to disk
│   │       └── ProjectValidator.cs           # Validates generated project
│   │
│   └── UnityDecompiler.UI/                   # Electron-based UI layer
│       ├── UnityDecompiler.UI.csproj         # UI project file
│       │
│       ├── electron/                         # Electron main process
│       │   ├──  main.js                      # Main electron process entry point
│       │   └── preload.js                    # Preload script for IPC
│       │
│       ├── public/                           # Public assets
│       │   └── .gitkeep
│       │
│       └── src/                              # Frontend source code
│           ├── js/
│           │   └── renderer.js               # Renderer process script
│           │
│           ├── styles/
│           │   ├── base.css                  # Base styling
│           │   └── style.css                 # Application styling
│           │
│           ├── .gitignore                    # Git ignore for UI files
│           ├── index.html                    # UI entry point
│           ├── package-lock.json
│           └── package.json
│
├── tools/                                    # Helper tools and scripts
│   ├── SampleGames/                          # Sample games for testing
│   │   └── README.md                         # Instructions for samples
│   │
│   ├── SetupDev                          # Development environment setup
│   └── GenerateTestData                  # Test data generation script
│
├── docs/
│   ├── architecture/                         # Architecture documentation
│   │   ├── OverallDesign.md                  # System design document
│   │   └── DataFlow.md                       # Data flow documentation
│   │
│   ├── development/                          # Developer documentation
│   │   ├── GettingStarted.md                 # Developer onboarding
│   │   └── Workflow.md                       # Development workflow
│   │
│   └── user/                                 # User documentation
│       ├── Installation.md                   # Installation guide
│       └── UserGuide.md                      # User manual
│
├── lib/
│   ├── README.md                             # Library documentation
│   └── .gitkeep
│
├── .gitignore
├── README.md
├── LICENSE
└── CONTRIBUTING.md
```