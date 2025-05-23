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
using System.IO;
using System.Threading.Tasks;

public class ProjectWriter
{
    private readonly ParallelOptions parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = 4 };

    public ProjectWriter()
    {
        GenerationDirectories.assetsPath = Path.Combine(GenerationDirectories.projectOutputPath, "Assets");
        GenerationDirectories.audioPath = Path.Combine(GenerationDirectories.assetsPath, "Audio");
        GenerationDirectories.imagesPath = Path.Combine(GenerationDirectories.assetsPath, "Images");
        GenerationDirectories.scenesPath = Path.Combine(GenerationDirectories.assetsPath, "Scenes");
        GenerationDirectories.resourcesPath = Path.Combine(GenerationDirectories.assetsPath, "Resources");
        GenerationDirectories.scriptsPath = Path.Combine(GenerationDirectories.assetsPath, "Scripts");
        GenerationDirectories.interfacesPath = Path.Combine(GenerationDirectories.scriptsPath, "Interfaces");
    }

    public void GenerateProjectStrucute()
    {
        FileLogger fl = new FileLogger();
        
        GenerateFolders(fl);
        
        GenerateScripts(fl);
        GenerateInterfaces(fl);
        
        // GenerateScenes(fl);
        // GenerateModels(fl);
        // GenerateAudios(fl);

    }

    private void GenerateFolders(FileLogger fl)
    {
        try
        {
            Directory.CreateDirectory(GenerationDirectories.assetsPath);
            Directory.CreateDirectory(GenerationDirectories.audioPath);
            Directory.CreateDirectory(GenerationDirectories.imagesPath);

            Directory.CreateDirectory(GenerationDirectories.scenesPath);
            Directory.CreateDirectory(GenerationDirectories.resourcesPath);


            Directory.CreateDirectory(GenerationDirectories.scriptsPath);
            Directory.CreateDirectory(GenerationDirectories.interfacesPath);

        }
        catch (Exception ex)
        {
            fl.Exception(ex, "Tried generating directories");
        }
    }

    // -------------------------------------------------------------- CODE GENERATION --------------------------------------------------------------

    private void GenerateScripts(FileLogger fl)
    {
        Parallel.ForEach(DecompiledProject.classList, parallelOptions, CS => {
            try
            {
                using (var sw = new StreamWriter(Path.Combine(GenerationDirectories.scriptsPath, $"{CS.name}.cs"), false))
                {
                    sw.WriteLine("using System.Collections;");
                    sw.WriteLine("using System.Collections.Generic;");
                    sw.WriteLine("using UnityEngine;");
                    sw.WriteLine();
                    sw.Write(CS.ToString());
                }
            }
            catch (Exception ex)
            {
                fl.Exception(ex, $"Failed to generate script for: {CS.name}");
            }

        });
    }

    private void GenerateInterfaces(FileLogger fl)
    {
        Parallel.ForEach(DecompiledProject.interfaceList, parallelOptions, IF => {
            try
            {
                using (var sw = new StreamWriter(Path.Combine(GenerationDirectories.interfacesPath, $"{IF.name}.cs"), false))
                {
                    sw.WriteLine("using System.Collections;");
                    sw.WriteLine("using System.Collections.Generic;");
                    sw.WriteLine("using UnityEngine;");
                    sw.WriteLine();
                    sw.Write(IF.ToString());
                }
            }
            catch (Exception ex)
            {
                fl.Exception(ex, $"Failed to generate interface for: {IF.name}");
            }

        });
    }

    // -------------------------------------------------------------- ASSET GENERATION --------------------------------------------------------------

    private void GenerateScenes(FileLogger fl)
    {
        Parallel.ForEach(ExtractedAssets.sceneList, parallelOptions, scene =>
        {
            try
            {
                using (var sw = new StreamWriter(Path.Combine(GenerationDirectories.scenesPath, $"{scene.name}.unity"), false))
                {

                }
            }
            catch (Exception ex)
            {
                fl.Exception(ex, $"Failed to generate scene for: {scene.name}");
            }

        });
    }

    private void GenerateModels(FileLogger fl)
    {
        Parallel.ForEach(ExtractedAssets.modelList, parallelOptions, model =>
        {
            try
            {
                using (var sw = new StreamWriter(Path.Combine(GenerationDirectories.scenesPath, $"{model.name}.{model.modelType.ToString()}"), false))
                {

                }
            }
            catch (Exception ex)
            {
                fl.Exception(ex, $"Failed to generate model for: {model.name}");
            }

        });
    }

    private void GenerateAudios(FileLogger fl)
    {
        Parallel.ForEach(ExtractedAssets.audioList, parallelOptions, audio =>
        {
            try
            {
                using (var sw = new StreamWriter(Path.Combine(GenerationDirectories.scenesPath, $"{audio.name}.{audio.audioFormat.ToString()}"), false))
                {

                }
            }
            catch (Exception ex)
            {
                fl.Exception(ex, $"Failed to generate audioFIle for: {audio.name}");
            }

        });
    }
}