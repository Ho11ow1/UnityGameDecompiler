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
using System.Text.RegularExpressions;

public static partial class UnityVersionDetector
{
    public static string GetUnityVersion(string gameFolder)
    {
        string globalGameManagerPath = PathUtils.SetGlobalGameManagerPath(gameFolder);

        if (!File.Exists(globalGameManagerPath))
        {
            throw new Exception("GlobalGameManager file not found.");
        }

        byte[] buffer = new byte[512];
        using (var fs = new FileStream(globalGameManagerPath, FileMode.Open, FileAccess.Read))
        {
            fs.Read(buffer, 0, buffer.Length);
        }

        string content = System.Text.Encoding.ASCII.GetString(buffer);
        Match match = VersionRegex().Match(content);

        if (match.Success)
        {
            GameInfo.unityVersion = match.Value;
            return GameInfo.unityVersion;
        }

        return null;
    }

    [GeneratedRegex(@"20\d{2}\.\d+\.\d+[a-z]\d+")]
    private static partial Regex VersionRegex();
}