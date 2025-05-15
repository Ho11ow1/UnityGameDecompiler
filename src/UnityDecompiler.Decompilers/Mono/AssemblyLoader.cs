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
using Mono.Cecil;

#pragma warning disable
public class AssemblyLoader
{
    public static void ReadAssembly(string assemblyPath)
    {
        FileLogger fl = new FileLogger();

        try
        {
            var assembly = AssemblyDefinition.ReadAssembly(assemblyPath);

            // Classes
            foreach (var type in assembly.MainModule.Types)
            {
                var accessModifier = type.IsPublic ? "public" : "private";
                fl.Info($"Class: {accessModifier} {type.FullName}");

                // Variables
                foreach (var field in type.Fields)
                {
                    var access = field.IsPrivate ? "private" : "public";
                    var instance = field.IsStatic ? "static" : "";
                    var serializable = !field.IsNotSerialized ? "[SerializeField] " : "";
                    fl.Info($"  Field: {serializable} {access} {instance}".Trim() + $" {field.FieldType} {field.Name}");
                }

                // Methods
                foreach (var method in type.Methods)
                {
                    string parameters = string.Join(", ", method.Parameters.Select(p => $"{p.ParameterType} {p.Name}"));
                    fl.Info($"  Method: {method.ReturnType} {method.Name}({parameters})");
                }


            }
        }
        catch (Exception ex) 
        {
            fl.Error($"Failed to read assembly: {ex.Message}");
        }
    }
}