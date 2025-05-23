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


public class MonoDecompiler
{
    public void Decompile()
    {
        FileLogger fl = new FileLogger();
        SceneExtractor se = new SceneExtractor();

        ExtractScripts(fl);
        se.ExtractScenes();
    }

    private void ExtractScripts(FileLogger fl)
    {
        try
        {
            // Type instances
            foreach (var type in DecompiledProject.assembly.MainModule.Types)
            {
                if (type.IsClass)
                {
                    DecompiledClass dc = new DecompiledClass
                    {
                        accessModifier = type.IsPublic ? AccessModifier.Public : AccessModifier.Private,
                        name = type.FullName.ToString()
                    };

                    try
                    {
                        var baseType = type.BaseType.Resolve();
                        if (baseType.ToString() != "System.Object")
                        {
                            dc.inheritedClass = baseType.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        fl.Info($"Could not resolve the base type for class {type.FullName}");
                    }

                    // Variables
                    foreach (var field in type.Fields)
                    {
                        // var access = field.IsPrivate ? "private" : "public";
                        // var instance = field.IsStatic ? "static" : "";
                        // var serializable = !field.IsNotSerialized ? "[SerializeField] " : "";
                        // fl.Info($"  Field: {serializable} {access} {instance}".Trim() + $" {field.FieldType} {field.Name}");

                        dc.variables.Add(new ExtractedVariable(
                            field.IsPublic ? AccessModifier.Public : AccessModifier.Private,
                            field.IsStatic,
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
                            method.IsStatic,
                            dc.ConvertTypeToLiteral(method.Name),
                            dc.ConvertTypeToLiteral(method.ReturnType.ToString()),
                            parametersList
                        ));
                    }
                    fl.Info(dc.ToString(), "info.txt");
                    DecompiledProject.classList.Add(dc);

                }
                else if (type.IsInterface)
                {
                    DecompiledInterface di = new DecompiledInterface
                    {
                        accessModifier = type.IsPublic ? AccessModifier.Public : AccessModifier.Private,
                        name = type.FullName.ToString()
                    };

                    // Methods
                    foreach (var method in type.Methods)
                    {
                        // string parameters = string.Join(", ", method.Parameters.Select(p => $"{p.ParameterType} {p.Name}"));
                        // fl.Info($"  Method: {method.ReturnType} {method.Name}({parameters})");

                        var parametersList = method.Parameters.Select(p => new MethodParameter
                        {
                            type = di.ConvertTypeToLiteral(p.ParameterType.ToString()),
                            name = p.Name
                        }).ToList();

                        di.methods.Add(new ExtractedMethod(
                            method.IsPublic ? AccessModifier.Public : AccessModifier.Private,
                            method.IsStatic,
                            di.ConvertTypeToLiteral(method.Name),
                            di.ConvertTypeToLiteral(method.ReturnType.ToString()),
                            parametersList
                        ));
                    }
                    fl.Info(di.ToString(), "info.txt");
                    DecompiledProject.interfaceList.Add(di);

                }
            }
        }
        catch (Exception ex)
        {
            fl.Exception(ex, "Failed to read assembly");
        }

    }


}

