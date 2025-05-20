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
public class ExtractedAudio
{
    public string name;
    public ExtensionType extensionType;

    public string ToString()
    {
        StringBuilder sb = new StringBuilder();



        return sb.ToString();
    }
}

public enum ExtensionType
{
    wav,
    ogg,
    mp3,
    aiff
}