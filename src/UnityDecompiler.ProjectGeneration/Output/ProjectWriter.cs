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

#pragma warning disable
public class ProjectWriter
{
    private static readonly string gameOutputPath = Path.Combine(ExtractorSettings.outputPath, $"{GameInfo.gameName}");
    private readonly string assetsPath = Path.Combine(gameOutputPath, "Assets");
    private readonly string audioPath = Path.Combine(gameOutputPath, "Assets/Audio");
    private readonly string imagesPath = Path.Combine(gameOutputPath, "Assets/Images");

    private readonly string scenesPath = Path.Combine(gameOutputPath, "Assets/Scenes");
    private readonly string resourcesPath = Path.Combine(gameOutputPath, "Assets/Resources");

    private readonly string scriptsPath = Path.Combine(gameOutputPath, "Assets/Scripts");
    private readonly string interfacesPath = Path.Combine(gameOutputPath, "Assets/Scripts/Interfaces");

    private readonly ParallelOptions parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = 2 };

    public void GenerateProjectStrucute()
    {
        FileLogger fl = new FileLogger();
        
        GenerateFolders(fl);
        GenerateProjectAsync(fl); // Set for testing
    }

    private async Task GenerateProjectAsync(FileLogger fl) // Set for testing
    {
        var tasks = new List<Task>();

        tasks.Add(Task.Run(() => GenerateScripts(fl)));
        tasks.Add(Task.Run(() => GenerateInterfaces(fl)));
        //tasks.Add(Task.Run(() => GenerateScenes(fl))); // TODO: Create basic extraction module first
        //tasks.Add(Task.Run(() => GenerateModels(fl))); // TODO: Create basic extraction module first
        //tasks.Add(Task.Run(() => GenerateAudios(fl))); // TODO: Create basic extraction module first

        await Task.WhenAll(tasks);
    }

    private void GenerateFolders(FileLogger fl)
    {
        try
        {
            Directory.CreateDirectory(assetsPath);
            Directory.CreateDirectory(audioPath);
            Directory.CreateDirectory(imagesPath);

            Directory.CreateDirectory(scenesPath);
            Directory.CreateDirectory(resourcesPath);


            Directory.CreateDirectory(scriptsPath);
            Directory.CreateDirectory(interfacesPath);

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
                using (var sw = new StreamWriter(Path.Combine(scriptsPath, $"{CS.name}.cs"), false))
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
                fl.Exception(ex, "Tried generating script files");
                fl.Exception(ex, $"Failed to generate script for: {CS.name}");
            }

        });

    }

    private void GenerateInterfaces(FileLogger fl)
    {
        Parallel.ForEach(DecompiledProject.interfaceList, parallelOptions, IF => {
            try
            {
                using (var sw = new StreamWriter(Path.Combine(interfacesPath, $"{IF.name}.cs"), false))
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
                fl.Exception(ex, "Tried generating interface files");
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

            }
            catch (Exception ex)
            {
                fl.Exception(ex, "Tried generating scene files");
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

            }
            catch (Exception ex)
            {
                fl.Exception(ex, "Tried generating model files");
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

            }
            catch (Exception ex)
            {
                fl.Exception(ex, "Tried generating audio files");
                fl.Exception(ex, $"Failed to generate audioFIle for: {audio.name}");
            }

        });
    }
}