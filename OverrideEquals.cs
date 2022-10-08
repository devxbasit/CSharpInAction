#nullable enable
using System;


class OverrideEquals
{

    public static void Main()
    {
        Student s1 = new Student("A");
        Student s2 = new Student("A");

        Console.WriteLine(s1 == s2);
        Console.WriteLine(s1.Equals(s1));

        Console.WriteLine(s1.ToString());

        Console.WriteLine(s1.GetHashCode());
        Console.WriteLine(s2.GetHashCode());

    }
}

class Student
{
    public string name;
    public Student(string name) => this.name = name;

    public override bool Equals(object? other)
    {
        if (other is null) return false;

        if (!(other is Student)) return false;

        return this.name == ((Student)other).name;
    }

    public override int GetHashCode()
    {
        // rule of thumb - if two object are equal, then they should return same hash code, but reverse is not true always
        //
        return this.name.GetHashCode();
    }


    public override string ToString()
    {
        return this.name;
    }
}
