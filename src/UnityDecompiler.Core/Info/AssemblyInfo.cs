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
public static class AssemblyInfo
{
    /// <summary>
    /// Gets or sets the name of the assembly.
    /// </summary>
    public static string name { get; set; }

    /// <summary>
    /// Gets or sets the path to the assembly file.
    /// </summary>
    public static string path { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this is a game assembly or a Unity/system assembly.
    /// </summary>
    public static bool isGameAssembly { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the assembly is obfuscated.
    /// </summary>
    public static bool isObfuscated { get; set; }

    /// <summary>
    /// Gets or sets the list of namespaces in the assembly.
    /// </summary>
    public static List<string> namespaces { get; set; } = new List<string>();

    /// <summary>
    /// Gets or sets the list of references to other assemblies.
    /// </summary>
    public static List<string> references { get; set; } = new List<string>();
}
