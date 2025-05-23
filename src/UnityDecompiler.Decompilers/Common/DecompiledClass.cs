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
using System.Text;

#pragma warning disable
public class DecompiledClass
{
    public string inheritedClass = null;
    public AccessModifier accessModifier;
    public string name;
    public List<ExtractedVariable> variables = new List<ExtractedVariable>();
    public List<ExtractedMethod> methods = new List<ExtractedMethod>();

    public string ToString()
    {
        StringBuilder sb = new StringBuilder();

        // Class header
        sb.AppendLine($"{accessModifier.ToString().ToLower()} class {name} {(inheritedClass != null ? $": {inheritedClass}" : "")}");
        sb.AppendLine("{");

        // Variables
        foreach (var variable in variables)
        {
            sb.AppendLine($"    {variable.accessModifier.ToString().ToLower()}{(variable.isStatic ? " static " : " ")} {variable.type} {variable.name};");
        }

        sb.AppendLine();

        // Methods
        foreach (var method in methods)
        {
            string paramsList = string.Join(", ", method.parameters.Select(p => $"{p.type} {p.name}"));
            sb.AppendLine($"    {method.accessModifier.ToString().ToLower()}{(method.isStatic ? " static" : " ")} {method.returnType} {method.name}({paramsList})");
            sb.AppendLine("    {");
            sb.AppendLine("        // Method body not available");
            sb.AppendLine("    }");
        }

        sb.AppendLine("}");

        return sb.ToString();
    }

    public string ConvertTypeToLiteral(string type) // To be improved | Dictionary for quick lookups?
    {
        switch (type)
        {
            // System.Single
            case "System.Single":
                return "float";
                break;
            case "System.Single&":
                return "float&";
                break;
            case "System.Single[]":
                return "float[]";
                break;
            // System.Int32
            case "System.Int32":
                return "int";
                break;
            case "System.Int32&":
                return "int&";
                break;
            case "System.Int32[]":
                return "int[]";
                break;
            // System.UInt32
            case "System.UInt32":
                return "uint";
                break;
            case "System.UInt32&":
                return "uint&";
                break;
            case "System.UInt32[]":
                return "uint[]";
                break;
            // System.String
            case "System.String":
                return "string";
                break;
            case "System.String[]":
                return "string[]";
                break;
            // System.Boolean
            case "System.Boolean":
                return "bool";
                break;
            case "System.Boolean&":
                return "bool&";
                break;
            case "System.Boolean[]":
                return "bool[]";
                break;
            // Special cases
            case "System.Guid":
                return "Guid";
                break;
            case "System.Void":
                return "void";
                break;
            case ".ctor":
            case ".cctor":
                return this.name;
                break;
        }

        return type;
    }
}

