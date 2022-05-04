using System;
using System.IO;

class ErrorHandling_Basic
{
    public static void Main()
    {
        var sourcePath = "./sourcefile.txt";
        var targetPath = "./targetfile.txt";
        var message = "Hello World!";

        using (var wr = new BinaryWriter(File.Create(sourcePath)))
        {
            wr.Write(message);
        }

        try
        {
            // Regardless of how deep the call stack is, the try..catch blocks will protect this code
            // from any case of IOException

            CopyReversedTextFile(sourcePath, targetPath);

        }
        catch (IOException)
        {
            // stack unwinding - looking for a compatible handler in the caller chain

            // IOException Handler
        }

    }

    public static void CopyReversedTextFile(string source, string target)
    {
        try
        {
            var content = ReadTextFile(source);
            content = content.Replace("\r\n", "\r");
            WriteAllText(target, content);
        }
        catch (IOException)
        {
            // IOException handler

        }
    }

    public static string ReadTextFile(string filename)
    {
        // no IOException handler

        try
        {
            var content = File.ReadAllText(filename);
            return content;
        }
        catch (ArgumentException)
        {

        }

        return null;
    }

    public static void WriteAllText(string filename, string content)
    {

        // no IOException handler

        try
        {
            File.WriteAllText(filename, content);
        }
        catch (ArgumentException)
        {

        }
    }
}