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

#pragma warning disable
public class ProjectWriter
{
    private static readonly string gameOutputPath = Path.Combine(ExtractorSettings.outputPath, $"{GameInfo.gameName}");
    private readonly string assetsPath = Path.Combine(gameOutputPath, "Assets");
    private readonly string audioPath = Path.Combine(gameOutputPath, "Assets/Audio");
    private readonly string imagesPath = Path.Combine(gameOutputPath, "Assets/Images");

    private readonly string scenePath = Path.Combine(gameOutputPath, "Assets/Scenes");
    private readonly string resourcesPath = Path.Combine(gameOutputPath, "Assets/Resources");

    private readonly string scriptsPath = Path.Combine(gameOutputPath, "Assets/Scripts");
    private readonly string interfacesPath = Path.Combine(gameOutputPath, "Assets/Scripts/Interfaces");

    public void GenerateProjectStrucute()
    {
        FileLogger fl = new FileLogger();
        
        GenerateFolders(fl);
        GenerateScripts(fl);
        GenerateInterfaces(fl);
    }

    private void GenerateFolders(FileLogger fl)
    {
        try
        {
            Directory.CreateDirectory(assetsPath);
            Directory.CreateDirectory(audioPath);
            Directory.CreateDirectory(imagesPath);

            Directory.CreateDirectory(scenePath);
            Directory.CreateDirectory(resourcesPath);


            Directory.CreateDirectory(scriptsPath);
            Directory.CreateDirectory(interfacesPath);

        }
        catch (Exception ex)
        {
            fl.Exception(ex, "Tried generating directories");
        }
    }

    private void GenerateScripts(FileLogger fl)
    {
        //var parallelOptions = new ParallelOptions
        //{
        //    MaxDegreeOfParallelism = 2 // Limited to 2 threads 
        //};

        //Parallel.ForEach(DecompiledProject.classList, parallelOptions, CS =>
        //{
        //    using (var sw = new StreamWriter(Path.Combine(scriptsPath, $"{CS.name}.cs"), false))
        //    {
        //        sw.WriteLine("using System.Collections");
        //        sw.WriteLine("using System.Collections.Generic");
        //        sw.WriteLine("using UnityEngine\n");
        //        sw.Write(CS.ToString());
        //    }
        //});

        foreach (var CS in DecompiledProject.classList)
        {
            try
            {
                using (var sw = new StreamWriter(Path.Combine(scriptsPath, $"{CS.name}.cs"), false))
                {
                    sw.WriteLine("using System.Collections;");
                    sw.WriteLine("using System.Collections.Generic;");
                    sw.WriteLine("using UnityEngine;\n");
                    sw.Write(CS.ToString());
                }
            }
            catch (Exception ex)
            {
                fl.Exception(ex, "Tried generating script files");
                fl.Exception(ex, $"Failed to generate script for: {CS.name}");
            }
        }
    }

    private void GenerateInterfaces(FileLogger fl)
    {
        //var parallelOptions = new ParallelOptions
        //{
        //    MaxDegreeOfParallelism = 2 // Limited to 2 threads 
        //};

        //Parallel.ForEach(DecompiledProject.interfaceList, parallelOptions, IF => // 
        //{
        //    using (var sw = new StreamWriter(Path.Combine(interfacesPath, $"{IF.name}.cs"), false))
        //    {
        //        sw.WriteLine("using System.Collections");
        //        sw.WriteLine("using System.Collections.Generic");
        //        sw.WriteLine("using UnityEngine\n");
        //        sw.Write(IF.ToString());
        //    }
        //});

        foreach (var IF in DecompiledProject.interfaceList)
        {
            try
            {
                using (var sw = new StreamWriter(Path.Combine(interfacesPath, $"{IF.name}.cs"), false))
                {
                    sw.WriteLine("using System.Collections;");
                    sw.WriteLine("using System.Collections.Generic;");
                    sw.WriteLine("using UnityEngine;\n");
                    sw.Write(IF.ToString());
                }
            }
            catch (Exception ex)
            {
                fl.Exception(ex, "Tried generating interface files");
                fl.Exception(ex, $"Failed to generate interface for: {IF.name}");
            }
        }
    }
}