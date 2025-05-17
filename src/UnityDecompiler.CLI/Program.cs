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

#pragma warning disable
public static class Program
{
    public static void Main(string[] args)
    {
        if (String.IsNullOrEmpty(args[0])) // ExePath
        {
            throw new ArgumentNullException();
        }
        if (String.IsNullOrEmpty(args[1])) // GameFolder
        {
            throw new ArgumentNullException();
        }
        if (String.IsNullOrEmpty(args[2])) // OutputPath
        {
            throw new ArgumentNullException();
        }
        var exePath = args[0];
        var gameFolderPath = args[1];
        var outputPath = args[2];

        // Usually same output as Path.GetFileNameWithoutExtension but best be safe
        GameInfo.gameName = Path.GetFileNameWithoutExtension(Path.GetFileName(exePath));
        ExtractorSettings.outputPath = outputPath;
        FileLogger fl = new FileLogger();

        GameInfo.unityVersion = UnityVersionDetector.GetUnityVersion(gameFolderPath);
        BuildMethodAnalyzer.IsIL2CPP(gameFolderPath);
        if (!GameInfo.isIL2CPP)
        {
            var assembly = Mono.PathUtils.SetGameAssemblyPath(gameFolderPath);
			fl.Debug("Game compiled with: Mono");

            //AssemblyLoader.ReadAssembly(assembly);
            AssemblyLoader al = new AssemblyLoader();
            al.ReadAssembly(assembly);

            // ProjectWriter.GenerateProjectStrucute();
            ProjectWriter pw = new ProjectWriter();
            pw.GenerateProjectStrucute();
        }
        else
        {
            var assembly = IL2CPP.PathUtils.SetGameAssemblyPath(gameFolderPath);
            fl.Debug("Game compiled with: IL2CPP");
            MetadataParser.ReadAssembly(assembly);
        }
            

    }
}
