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
public class AssemblyInfo
{
    /// <summary>
    /// Gets or sets the name of the assembly.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the path to the assembly file.
    /// </summary>
    public string Path { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this is a game assembly or a Unity/system assembly.
    /// </summary>
    public bool IsGameAssembly { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the assembly is obfuscated.
    /// </summary>
    public bool IsObfuscated { get; set; }

    /// <summary>
    /// Gets or sets the list of namespaces in the assembly.
    /// </summary>
    public List<string> Namespaces { get; set; } = new List<string>();

    /// <summary>
    /// Gets or sets the list of references to other assemblies.
    /// </summary>
    public List<string> References { get; set; } = new List<string>();
}
