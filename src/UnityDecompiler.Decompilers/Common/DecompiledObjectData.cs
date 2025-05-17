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

#pragma warning disable
public enum AccessModifier
{
    Public,
    Private,
    Protected,
    Internal
}

public class ExtractedVariable
{
    public ExtractedVariable(AccessModifier accessModifier, bool isStatic, string type, string name)
    {
        this.accessModifier = accessModifier;
        this.isStatic = isStatic;
        this.type = type;
        this.name = name;
    }

    public AccessModifier accessModifier;
    public bool isStatic;
    public string type;
    public string name;
}

public class ExtractedMethod
{
    public ExtractedMethod(AccessModifier accessModifier, bool isStatic, string name, string returnType, List<MethodParameter> parameters)
    {
        this.accessModifier = accessModifier;
        this.isStatic = isStatic;
        this.name = name;
        this.returnType = returnType;
        this.parameters = parameters;
    }

    public AccessModifier accessModifier;
    public bool isStatic;
    public string name;
    public string returnType;
    public List<MethodParameter> parameters { get; set; } = new List<MethodParameter>();
}

public class MethodParameter
{
    public string type;
    public string name;
}