using System;
using System.IO;
using System.Linq;

class FileStream_Basic
{
    public static void Main()
    {
        // Streams represents sequence of bytes, and are conceptually group into three cat.
        // 1. Backing Store - represents source or destination of a sequence of bytes. work with bytes

        // 2. Decorators - are the streams that read or write data from or to another stream,
        //  transforming it in some way. work with bytes

        // 3. Adapters - they are not actually streams but wrappers that help us work with source of data
        //  at a higher level than bytes


        // Adapters -> Binary, Stream & Xml Reader/Writer
        // Decorator -> Buffered, Crypto, GZip & Deflate Stream
        // Backing Store -> File, Memory, Network, Pipe Stream
        
        var path = Path.ChangeExtension(Path.Combine(Path.GetTempPath(), Path.GetRandomFileName()), ".raw");

        var data = new byte[] { 0xBA, 0xAD, 0xF0, 0x0D };

        using (FileStream wr = File.Create(path))
        {
            wr.Write(data, 0, data.Length);
        }

        using(FileStream rd = File.OpenRead(path)) 
        {
            var buffer = new byte[rd.Length];
            rd.Read(buffer, 0, buffer.Length);
                Console.WriteLine(string.Join(" ", buffer.Select(e => $"{e:X02}")));
        }

        // Handling raw data can be cumbersome. For this reason, .NET provides stream adapters
        // that allow us to handle higher-level data.

        // read/write primitives

        using (var wr = new BinaryWriter(File.Create(path))) 
        {
            wr.Write(true);
            wr.Write('x');
            wr.Write(42);
            wr.Write(19.9);
            wr.Write(39.9M);
            wr.Write("Hello");
        }

        using(var rd = new BinaryReader(File.OpenRead(path))) 
        {
            Console.WriteLine(rd.ReadBoolean());
            Console.WriteLine(rd.ReadChar());
            Console.WriteLine(rd.ReadInt32());
            Console.WriteLine(rd.ReadDouble());
            Console.WriteLine(rd.ReadDecimal());
            Console.WriteLine(rd.ReadString());
        }


        // Although these two adapters can be used for processing strings, using them for reading
        // and writing text files can be cumbersome because of a lack of support for features such as
        // line handling. To handle text files, the StreamReader and StreamWriter adapters
        // should be used.

        using (StreamWriter wr = File.CreateText(path))
        {
            wr.WriteLine("1st Line");
            wr.WriteLine("2nd Line");

        }

        using (StreamReader rd = File.OpenText(path)) 
        {
            while(!rd.EndOfStream) 
                    Console.WriteLine(rd.ReadLine());
        }

        using (var rd = new StreamReader(File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read)))
         {
             while(!rd.EndOfStream)
                Console.WriteLine(rd.ReadLine());
         }

        File.Delete(path);
    }
}
