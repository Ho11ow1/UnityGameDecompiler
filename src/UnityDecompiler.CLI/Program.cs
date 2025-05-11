using System;

public static class Program
{
    public static void Main(string[] args)
    {
        FileLogger fl = new FileLogger(); // Purely for testing
        if (File.Exists(Globals.logFile)) { File.Delete(Globals.logFile); } // Purely for testing

        fl.Debug("Debug statement"); // Purely for testing
        fl.Info("Info statement"); // Purely for testing
        fl.Warning("warning statement"); // Purely for testing
        fl.Exception(new ArgumentNullException(), "Happened"); // Purely for testing
    }
}