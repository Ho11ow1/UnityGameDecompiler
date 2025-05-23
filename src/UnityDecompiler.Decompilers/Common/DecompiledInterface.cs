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

public class DecompiledInterface
{
    public AccessModifier accessModifier;
    public string name;
    public List<ExtractedMethod> methods = new List<ExtractedMethod>();

    public string ToString()
    {
        StringBuilder sb = new StringBuilder();

        // Interface header
        sb.AppendLine($"{accessModifier.ToString().ToLower()} interface {name}");
        sb.AppendLine("{");

        sb.AppendLine();

        // Methods
        foreach (var method in methods)
        {
            string paramsList = string.Join(", ", method.parameters.Select(p => $"{p.type} {p.name}"));
            sb.AppendLine($"    {method.returnType} {method.name}({paramsList});");
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
            case "System.Single&":
                return "float&";
            case "System.Single[]":
                return "float[]";
            // System.Int32
            case "System.Int32":
                return "int";
            case "System.Int32&":
                return "int&";
            case "System.Int32[]":
                return "int[]";
            // System.UInt32
            case "System.UInt32":
                return "uint";
            case "System.UInt32&":
                return "uint&";
            case "System.UInt32[]":
                return "uint[]";
            // System.String
            case "System.String":
                return "string";
            case "System.String[]":
                return "string[]";
            // System.Boolean
            case "System.Boolean":
                return "bool";
            case "System.Boolean&":
                return "bool&";
            case "System.Boolean[]":
                return "bool[]";
            // Special cases
            case "System.Guid":
                return "Guid";
            case "System.Void":
                return "void";
        }

        return type;
    }

}

