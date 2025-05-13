# UnityDecompiler
[![Status: Work In Progress](https://img.shields.io/badge/Status-Work%20In%20Progress-yellow.svg)](https://github.com/Ho11ow1/UnityGameDecompiler)
[![Version: 0.1.0-alpha](https://img.shields.io/badge/Version-0.1.0--alpha-blue.svg)](https://github.com/Ho11ow1/UnityGameDecompiler/releases)
[![.NET Core](https://img.shields.io/badge/.NET%20Core-8.0-purple.svg)](https://dotnet.microsoft.com/download)
[![Electron](https://img.shields.io/badge/Electron-Latest-brightgreen.svg)](https://www.electronjs.org/)
[![License: Apache-2-0](https://img.shields.io/badge/License-Apache%202%200-green.svg)](https://opensource.org/license/apache-2-0)
<br/>
A comprehensive `work in progress` decompilation tool for Unity games, providing extraction and reconstruction of game assets and code. 
<br/><br/>

## Overview

UnityDecompiler extracts and rebuilds Unity game projects by decompiling code (IL2CPP/Mono) and extracting assets (models, textures, scenes, etc.). It's designed to provide a streamlined workflow for game analysis, modding, and learning purposes.

The tool bridges the gap between compiled Unity games and editable projects, allowing you to:
- Decompile game code from both IL2CPP and Mono builds
- Extract and convert game assets
- Analyze code structure and dependencies
- Generate workable Unity projects from decompiled games

## Project Status

> ⚠️ **Important Note**: This project is currently in super-early alpha development. Features are being actively implemented and the project may change significantly between versions.

Current Development Phase:
- [x] Core architecture design
- [x] UI framework transition to Electron
- [ ] Basic decompiler implementation
- [ ] Asset extraction pipeline
- [ ] Project generation module
- [ ] Comprehensive testing with various Unity versions
- [ ] First beta release


## Key Features

- **Multi-format Decompilation**: Support for both Mono and IL2CPP compilation methods
- **Comprehensive Asset Extraction**: Extract textures, models, audio, scenes, and more
- **Unity Project Generation**: Reconstruct a working Unity project from decompiled assets
- **Modern Electron UI**: User-friendly interface for all decompilation tasks
- **Pipeline Architecture**: Modular and extensible extraction process


## Code matching

- Byte matching: ❌
- Instruction matching: 🟡
- Functional matching: 🟡


## Documentation
For more detailed information, please refer to the following documentation:

- [Data Flow](docs/Architecture/DataFlow.md): How data moves through the decompilation process `(Work.In.Progress)`
- [Overall Design](docs/Architecture/OverallDesign.md): System architecture and component relationships `(Work.In.Progress)`
- [Getting Started](docs/Development/GettingStarted.md): Developer onboarding guide `(Work.In.Progress)`
- [Workflow](docs/Development/Workflow.md): Development practices and processes `(Work.In.Progress)`
- [Installation](docs/User/Installation.md): User installation instructions `(Work.In.Progress)`
- [User Guide](/docs/User/UserGuide.md): Comprehensive usage instructions `(Work.In.Progress)`

## License
APACHE-2.0 License - see [LICENSE](LICENSE)

## Contributing
Contributions are welcome! Please see [CONTRIBUTING.md](CONTRIBUTING.md) for details.

