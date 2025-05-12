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
using System.IO;

#pragma warning disable
public class FileLogger : ILogger
{
    public FileLogger()
    {
        if (File.Exists(Globals.logFile)) { File.Delete(Globals.logFile); } // Purely for testing
    }

    public void Debug(string message)
    {
        using (var sw = new StreamWriter(Globals.logFile, true))
        {
            sw.WriteLine($"DEBUG: {message}.");
        }
    }

    public void Info(string message)
    {
        using (var sw = new StreamWriter(Globals.logFile, true))
        {
            sw.WriteLine($"INFO: {message}.");
        }
    }

    public void Warning(string message)
    {
        using (var sw = new StreamWriter(Globals.logFile, true))
        {
            sw.WriteLine($"WARNING: {message}.");
        }
    }

    public void Error(string message)
    {
        using (var sw = new StreamWriter(Globals.logFile, true))
        {
            sw.WriteLine($"ERROR: {message}.");
        }
    }

    public void Exception(Exception exception, string message = null)
    {
        using (var sw = new StreamWriter(Globals.logFile, true))
        {
            sw.WriteLine($"EXCEPTION: {exception} | {message}.");
        }
    }
}
