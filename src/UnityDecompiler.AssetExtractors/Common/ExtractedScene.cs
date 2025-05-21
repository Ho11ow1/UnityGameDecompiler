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
using System.Text;

#pragma warning disable
public class ExtractedScene
{
    public string name;
    public const string extension = ".unity";
    private readonly Dictionary<Int64, GameObject> objectList = new Dictionary<Int64, GameObject>();
    public IReadOnlyDictionary<Int64, GameObject> readonlyObjectList => objectList;

    public string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Scene: {name}");
        sb.AppendLine($"GameObjects: {objectList.Count}");


        return sb.ToString();
    }

    public void AddGameObject(Int64 id, GameObject gameObject)
    {
        objectList[id] = gameObject;
    }
}