using System;
using System.IO;

class ThrowingExceptions
{
    public static void Main()
    {
        var content = ReadLog("demo.log");
        Console.WriteLine(content);
    }

    public static string ReadLog(string logName)
    {
        // ***
        // Make sure to never specify the name of the argument as a literal. Using nameof() guarantees
        // that the name is always valid and avoids problems during refactoring.

        if (logName is null) throw new ArgumentNullException(nameof(logName));

        var filename = "./" + (logName.EndsWith(".log") ? logName : logName + ".log");
        return File.ReadAllText(filename);

        // The throw statement is very simple but please remember to use it only for exceptional
        // cases; otherwise, you may incur performance problems.

    }
}
