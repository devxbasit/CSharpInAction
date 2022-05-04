using System;
using System.IO;

class ExceptionObjects
{
    public static void Main()
    {
        int[] fileLengths;

        fileLengths = GetFileLengths("./sourcefile.txt", "./sourcefile.txt", "./sourcefile.txt");
        // fileLengths = GetFileLengths("./sourcefile.t", "./sourcefile.t", "./sourcefile.t");

        if (fileLengths != null)
            foreach (var fileLength in fileLengths) Console.WriteLine(fileLength);

    }

    public static int[] GetFileLengths(params string[] filenames)
    {
        try
        {
            var sizes = new int[filenames.Length];
            int i = -1;

            foreach (var filename in filenames)
            {
                var content = File.ReadAllText(filename);
                sizes[++i] = content.Length;
            }

            return sizes;
        }
        catch (FileNotFoundException err)
        {
            Console.WriteLine($"Cannot find {err.FileName}");
            return null;
        }
    }
}