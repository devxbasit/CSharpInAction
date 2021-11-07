using System;

class InOutRef_Ref
{
    public static void Main()
    {
        Student student = new Student();
        student.Name = "Basit";

        Student studentRefCopy = student;

        Console.WriteLine($"student == studentRefCopy = {student == studentRefCopy}");
        CallByReference(ref student);
        Console.WriteLine($"student == studentRefCopy = {student == studentRefCopy}");

        Console.WriteLine($"student.Name = {student.Name}, studentRefCopy.Name = {studentRefCopy.Name}");

        // value Types
        int x = 10;
        ValueTypeTest(ref x);
        Console.WriteLine($"x = {x}");
    }
    public static void CallByReference(ref Student student)
    {
        // allows to change the reference, and this change will also affect outside the function
        student = new Student();
        student.Name = "Ritik";
    }

    public static void ValueTypeTest(ref int x)
    {
        x++;
    }


    public class Student
    {
        public string Name { get; set; }
    }
}