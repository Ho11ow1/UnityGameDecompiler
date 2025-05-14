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
namespace Mono
{
    public static class PathUtils
    {
        public static string SetGameAssemblyPath(string gameFolder)
        {
            string[] managedFolders = {
                Path.Combine(gameFolder, "Managed"),
                Path.Combine(gameFolder, "Data", "Managed"),
                Path.Combine(gameFolder, "_Data", "Managed"),
                Path.Combine(gameFolder, Path.GetFileNameWithoutExtension(gameFolder) + "_Data", "Managed")
            };

            foreach (var folder in managedFolders)
            {
                string assemblyPath = Path.Combine(folder, "Assembly-CSharp.dll");
                if (File.Exists(assemblyPath))
                {
                    return assemblyPath;
                }
            }

            return null;
        }


    }
}

namespace IL2CPP
{
    public static class PathUtils
    {
        public static string SetGameAssemblyPath(string path)
        {
            string assemblyPath = Path.Combine(path, "GameAssembly.dll");
            return File.Exists(assemblyPath) ? assemblyPath : null;
        }

        public static string SetMetadataPath(string path)
        {
            // Check for the game name pattern in the path
            string gameName = Path.GetFileNameWithoutExtension(path);

            string[] possiblePaths = {
                    Path.Combine(path, "Game_Data", "il2cpp_data", "Metadata", "global-metadata.dat"),
                    Path.Combine(path, gameName + "_Data", "il2cpp_data", "Metadata", "global-metadata.dat")
                };

            foreach (var metadataPath in possiblePaths)
            {
                if (File.Exists(metadataPath))
                {
                    return metadataPath;
                }
            }

            return null;
        }


    }
}

public static class PathUtils
{
    public static string SetGlobalGameManagerPath(string path)
    {
        string gameName = Path.GetFileNameWithoutExtension(path);

        string[] possiblePaths = {
            Path.Combine(path, "Game_Data", "globalgamemanager"),
            Path.Combine(path, "Game_Data", "globalgamemanagers"),
            Path.Combine(path, gameName + "_Data", "globalgamemanager"),
            Path.Combine(path, gameName + "_Data", "globalgamemanagers")
        };

        foreach (var globalManagerPath in possiblePaths)
        {
            if (File.Exists(globalManagerPath))
            {
                return globalManagerPath;
            }
        }

        return null;
    }
}