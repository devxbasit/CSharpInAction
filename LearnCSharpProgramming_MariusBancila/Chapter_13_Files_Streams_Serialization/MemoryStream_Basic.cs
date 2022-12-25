using System;
using System.IO;
using System.Xml.Serialization;
using System.Text;


class MemoryStream_Basic
{
    public static void Main()
    {

        // A memory stream is a backing store for local memory. Such a stream is useful for
        // operations when we need temporary storage for transforming data. Examples can include
        // XML serialization or data compression and decompression.

        Employee e = new Employee("Basit");
        var text = Serializer<Employee>.Serialize(e);
        var result = Serializer<Employee>.Deserialize(text);

        Console.WriteLine(e);
        Console.WriteLine(text);
        Console.WriteLine(result);


        // The other example we mentioned when a memory stream is handy is in the
        // compression and decompression of data

    }
}

public static class Serializer<T>
{
    static readonly XmlSerializer _serializer = new XmlSerializer(typeof(T));
    static readonly Encoding _encoding = Encoding.UTF8;

    public static string Serialize(T value)
    {
        // resizable memory stream, initially empty and grows as needed
        using (var ms = new MemoryStream())
        {
            _serializer.Serialize(ms, value);
            return _encoding.GetString(ms.ToArray());
        }
    }

    public static T Deserialize(string value)
    {
        // non resizable memory stream, read only memory stream
        using (var ms = new MemoryStream(_encoding.GetBytes(value)))
        {
            return (T)_serializer.Deserialize(ms);
        }
    }
}


public class Employee
{
    public string Name { get; set; }

    // Employee cannot be serialized because it does not have a parameterless constructor
    public Employee() { }
    public Employee(string name)
    {
        Name = name;
    }

    public override string ToString() => $"Name = {Name}";

}