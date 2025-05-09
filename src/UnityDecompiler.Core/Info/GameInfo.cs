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
using System.Collections.Generic;

#pragma warning disable
public static class GameInfo
{
    /// <summary>
    /// Gets or sets the name of the game.
    /// </summary>
    public static string gameName { get; set; }

    /// <summary>
    /// Gets or sets the detected Unity version.
    /// </summary>
    public static string unityVersion { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the game uses IL2CPP.
    /// </summary>
    public static bool isIL2CPP { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the game is obfuscated.
    /// </summary>
    public static bool isObfuscated { get; set; }

    /// <summary>
    /// Gets or sets the path to the game's main data directory.
    /// </summary>
    public static string dataPath { get; set; }

    /// <summary>
    /// Gets or sets the path to the game's managed assemblies.
    /// </summary>
    public static string managedAssembliesPath { get; set; }

    /// <summary>
    /// Gets or sets the detected platform the game was built for.
    /// </summary>
    public static GamePlatform platform { get; set; }

    /// <summary>
    /// Gets or sets additional platform-specific information.
    /// </summary>
    public static Dictionary<string, string> platformSpecificInfo { get; set; } = new Dictionary<string, string>();

    /// <summary>
    /// Returns a string representation of the game information.
    /// </summary>
    /// <returns>A string representation of the game information.</returns>
    public static string ToString() // Cannot set override as static
    {
        return $"{gameName} (Unity {unityVersion}, {(isIL2CPP ? "IL2CPP" : "Mono")}, {platform})";
    }
}

public enum GamePlatform
{
    Unknown,
    Windows,
    MacOS,
    Linux,
    Android,
    iOS,
    WebGL,
    WindowsUniversal,
    Switch,
    PlayStation4,
    PlayStation5,
    XboxOne,
    XboxSeriesX
}
