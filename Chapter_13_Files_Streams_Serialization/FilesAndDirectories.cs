using System;
using System.IO;

class FilesAndDirectories
{
    public static void Main()
    {
        var dir = new DirectoryInfo("/usr/share");

        Console.WriteLine(dir.FullName);
        Console.WriteLine(dir.Name);
        Console.WriteLine(dir.Parent);
        Console.WriteLine(dir.Root);
        Console.WriteLine(dir.CreationTime);

        foreach (var subdir in dir.EnumerateDirectories())
        {
            Console.WriteLine(subdir.Name);
        }

        // DirectoryInfo also allows us to create and delete directories

        var dir1 = new DirectoryInfo("/tmp/temp10/dir/sub");
        Console.WriteLine(dir1.Exists);
        dir1.Create();

        DirectoryInfo sub = dir1.CreateSubdirectory("sub1/sub2/sub3");
        Console.WriteLine(sub.Name);

        // will delete only, if the directory is empty, otherwise throws exception, directory not empty
        sub.Delete();

        // working with files
        var f = Path.ChangeExtension(
            Path.Combine(Path.GetTempPath(), Path.GetRandomFileName()),
            ".txt"
        );

        Console.WriteLine(f);

        using (var file = new StreamWriter(File.Create(f)))
        {
            file.Write("Hello temp file");
        }
    }
}
