using System;


class NullableReferenceType_ForgivingOperator
{
    public static void Main()
    {
        Console.WriteLine(new Student("Basit").NameLength);
        Console.WriteLine(new Student().NameLength);
    }
}

class Student
{
    private string _name;

    public Student()
    {

    }

    public Student(string name)
    {
        _name = name;

    }

    public int NameLength
    {
        get => _name.Length;
    }
}