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

public static class GenerationDirectories
{
    public static string projectOutputPath = Path.Combine(ExtractorSettings.outputPath, $"{GameInfo.gameName}");

    public static string assetsPath = "";
    public static string audioPath = "";
    public static string imagesPath = "";

    public static string scenesPath = "";
    public static string resourcesPath = "";

    public static string scriptsPath = "";
    public static string interfacesPath = "";
}