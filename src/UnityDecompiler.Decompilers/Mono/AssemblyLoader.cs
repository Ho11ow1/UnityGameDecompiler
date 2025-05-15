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
using System.Collections.Generic;

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
                DecompiledClass dc = new DecompiledClass();

                // var accessModifier = type.IsPublic ? "public" : "private";
                // fl.Info($"Class: {accessModifier} {type.FullName}");

                dc.accessModifier = type.IsPublic ? AccessModifier.Public : AccessModifier.Private;
                dc.name = type.FullName.ToString();

                // Variables
                foreach (var field in type.Fields)
                {
                    // var access = field.IsPrivate ? "private" : "public";
                    // var instance = field.IsStatic ? "static" : "";
                    // var serializable = !field.IsNotSerialized ? "[SerializeField] " : "";
                    // fl.Info($"  Field: {serializable} {access} {instance}".Trim() + $" {field.FieldType} {field.Name}");

                    dc.variables.Add(new ExtractedVariable(
                        !field.IsNotSerialized ? true : false,
                        field.IsPublic ? AccessModifier.Public : AccessModifier.Private,
                        field.IsStatic ? true : false,
                        dc.ConvertTypeToLiteral(field.FieldType.ToString()),
                        field.Name
                    ));
                }

                // Methods
                foreach (var method in type.Methods)
                {
                    // string parameters = string.Join(", ", method.Parameters.Select(p => $"{p.ParameterType} {p.Name}"));
                    // fl.Info($"  Method: {method.ReturnType} {method.Name}({parameters})");

                    var parametersList = method.Parameters.Select(p => new MethodParameter
                    {
                        type = dc.ConvertTypeToLiteral(p.ParameterType.ToString()),
                        name = p.Name
                    }).ToList();

                    dc.methods.Add(new ExtractedMethod(
                        method.IsPublic ? AccessModifier.Public : AccessModifier.Private,
                        dc.ConvertTypeToLiteral(method.Name),
                        dc.ConvertTypeToLiteral(method.ReturnType.ToString()),
                        parametersList
                    ));
                }

                fl.Info(dc.ToString(), "info.txt");
            }
        }
        catch (Exception ex) 
        {
            fl.Error($"Failed to read assembly: {ex.Message}");
        }
    }
}