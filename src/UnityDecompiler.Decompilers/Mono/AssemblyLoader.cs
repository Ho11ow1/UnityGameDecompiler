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
        var assembly = AssemblyDefinition.ReadAssembly(assemblyPath);
        FileLogger fl = new FileLogger();

        foreach (var type in assembly.MainModule.Types)
        {
            //Console.WriteLine($"Class: {type.FullName}");
            fl.Info($"Class: {type.FullName}");

            // Get fields (variables)
            foreach (var field in type.Fields)
            {
                //Console.WriteLine($"  Field: {field.FieldType} {field.Name}");
                fl.Info($"  Field: {field.FieldType} {field.Name}");
            }

            // Get methods
            foreach (var method in type.Methods)
            {
                //Console.WriteLine($"  Method: {method.ReturnType} {method.Name}({string.Join(", ", method.Parameters.Select(p => $"{p.ParameterType} {p.Name}"))})");
                fl.Info($"  Method: {method.ReturnType} {method.Name}({string.Join(", ", method.Parameters.Select(p => $"{p.ParameterType} {p.Name}"))})");
            }
        }
    }
}