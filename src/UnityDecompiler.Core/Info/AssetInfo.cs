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

public static class AssetInfo
{
    /// <summary>
    /// Gets or sets the name of the asset.
    /// </summary>
    public static string name { get; set; }

    /// <summary>
    /// Gets or sets the path to the asset file.
    /// </summary>
    public static string path { get; set; }

    /// <summary>
    /// Gets or sets the type of the asset.
    /// </summary>
    public static AssetType type { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the asset is extracted from an asset bundle.
    /// </summary>
    public static bool isFromAssetBundle { get; set; }

    /// <summary>
    /// Gets or sets the name of the asset bundle this asset is from (if applicable).
    /// </summary>
    public static string assetBundleName { get; set; }

    /// <summary>
    /// Gets or sets the output path for the extracted asset.
    /// </summary>
    public static string outputPath { get; set; }
}

public enum AssetType
{
    Unknown,
    Texture,
    Material,
    Mesh,
    Animation,
    AudioClip,
    Scene,
    Prefab,
    Script,
    Shader,
    Font,
    Video,
    TextAsset
}
