using System;
using System.IO;

class WorkingWithPaths
{
    public static void Main()
    {
        Console.WriteLine(Directory.GetCurrentDirectory());

        var path = "/sys/kernal/kexec_loaded.txt";

        Console.WriteLine(Path.HasExtension(path));
        Console.WriteLine(Path.IsPathFullyQualified(path));
        Console.WriteLine(Path.IsPathRooted(path));

        Console.WriteLine();

        Console.WriteLine(Path.GetPathRoot(path));
        Console.WriteLine(Path.GetDirectoryName(path));
        Console.WriteLine(Path.GetFileName(path));
        Console.WriteLine(Path.GetFileNameWithoutExtension(path));
        Console.WriteLine(Path.GetExtension(path));

        Console.WriteLine();

        Console.WriteLine(Path.ChangeExtension(path, ".png"));

        Console.WriteLine();

        var path1 = Path.Combine("../", "readme.md");
        Console.WriteLine($"Path1 = {path1}");
        Console.WriteLine(Path.IsPathFullyQualified(path1));

        Console.WriteLine();

        var path2 = Path.Combine(
            "../Chapter_5_OOPs/HidingBaseClassMember.cs",
            "../Chapter_6_Generics",
            "../readme.md"
        );
        Console.WriteLine($"Path2 = {path2}");
        Console.WriteLine(Path.IsPathFullyQualified(path2));

        Console.WriteLine();

        Console.WriteLine(Path.GetTempPath());

        // creates a temp file on disk
        var tempfile = Path.GetTempFileName();
        Console.WriteLine(tempfile);
        File.Delete(tempfile);

        // Return a cryptographically strong random name that can be used for the name of a file or directory.
        // the return value is only a name, not a full path
        // this method does not create a file on disk, this method should be preferred over  GetTempFileName() when security is key
        Console.WriteLine(Path.GetRandomFileName());

        var temp = Path.GetTempPath();
        var name = Path.GetRandomFileName();
        var path3 = Path.Combine(temp, name);
        Console.WriteLine(path3);

        var path4 = Path.GetTempFileName();

        Console.WriteLine(path4);
        File.Delete(path4);
    }
}
