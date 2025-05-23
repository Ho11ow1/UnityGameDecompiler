/* Copyright 2025 Hollow1
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
*     http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/
using System;
using System.IO;

public static class Program
{
    // string outputPath;
    // #if DEBUG
    //         outputPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "UnityDecompiler");
    // #endif
    // #if RELEAE
    //         outputPath = args[2];
    // #endif
    public static void Main(string[] args)
    {
        if (String.IsNullOrEmpty(args[0])) // ExePath
        {
            throw new ArgumentNullException(args[0]);
        }
        if (String.IsNullOrEmpty(args[1])) // GameFolder
        {
            throw new ArgumentNullException(args[1]);
        }
        if (String.IsNullOrEmpty(args[2])) // OutputPath
        {
            throw new ArgumentNullException(args[2]);
        }
        var exePath = args[0];
        var gameFolderPath = args[1];
        var outputPath = args[2];

        ExtractorSettings.outputPath = outputPath;
        // Set GameInfo
        GameInfo.gameName = Path.GetFileNameWithoutExtension(Path.GetFileName(exePath));
        GameInfo.unityVersion = UnityVersionDetector.GetUnityVersion(gameFolderPath);
        GameInfo.isIL2CPP = BuildMethodAnalyzer.IsIL2CPP(gameFolderPath);
        GameInfo.dataPath = PathUtils.SetDataPath(gameFolderPath);
        GameInfo.platform = BuildMethodAnalyzer.GetBuildMethod();


        if (!GameInfo.isIL2CPP)
        {
            GameInfo.managedAssembliesPath = Mono.PathUtils.SetManagedPath(gameFolderPath);

            AssemblyInfo.path = Mono.PathUtils.SetGameAssemblyPath(gameFolderPath);
            AssemblyInfo.name = Path.GetFileNameWithoutExtension(Path.GetFileName(AssemblyInfo.path));

            MonoDecompiler md = new MonoDecompiler();
            ProjectWriter pw = new ProjectWriter();

            AssemblyLoader.ReadAssembly(AssemblyInfo.path);
            md.Decompile();

            pw.GenerateProjectStrucute();
        }
        else
        {
            var assembly = IL2CPP.PathUtils.SetGameAssemblyPath(gameFolderPath);

            MetadataParser.ReadAssembly(assembly);
        }
            

    }
}
