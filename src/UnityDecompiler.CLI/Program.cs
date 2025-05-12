using System;

public static class Program
{
    public static void Main(string[] args)
    {
        if (String.IsNullOrEmpty(args[0]))
        {
            throw new ArgumentNullException();
        }
        if (String.IsNullOrEmpty(args[1]))
        {
            throw new ArgumentNullException();
        }
        GameInfo.dataPath = args[0];
        Globals.outputPath = args[1];
    }
}