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
using System.Text;

#pragma warning disable
public class BuildMethodAnalyzer
{
    public string GetBuildMethod(string gameFolder)
    {
        string gameAssemblyPath = PathUtils.SetGameAssemblyPath(gameFolder);
        string metadataPath = PathUtils.SetMetadataPath(gameFolder);

        if (File.Exists(gameAssemblyPath) && File.Exists(metadataPath))
        {
            GameInfo.isIL2CPP = true;
        }

        return GameInfo.isIL2CPP ? "IL2CPP" : "Mono";
    }


}
