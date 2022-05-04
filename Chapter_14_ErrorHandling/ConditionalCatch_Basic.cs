using System;
using System.IO;

class ConditionalCatch_Basic
{
    public static void Main()
    {
        var sourcePath = "./sourcefile.txt";
        CopyFrom(sourcePath);

    }

    public static void CopyFrom(string sourcefile)
    {
        string target = "";
        try
        {
            target = CreateFileName(sourcefile);

            // method signature
            // public static void Copy(string sourceFileName, string destFileName);
            File.Copy(sourcefile, target);

        }
        catch (ArgumentException err) when (err.ParamName == "destFileName")
        {
            Console.WriteLine($"The parameter {err.ParamName} is invalid");
            return;
        }
        finally
        {
            if (File.Exists(target)) File.Delete(target);
        }
    }

    public static string CreateFileName(string sourcefile)
    {
        string target = "";
        target = Path.ChangeExtension(Path.Combine("./", Path.GetRandomFileName()), ".txt");

        return target;
    }
}