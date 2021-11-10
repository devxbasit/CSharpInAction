using System;

// https://www.pluralsight.com/guides/csharp-in-out-ref-parameters

class InOutRef_Ref
{
    public static void Main()
    {
        Student student = new Student();
        student.Name = "Basit";

        Student studentRefCopy = student;

        // passing by reference has performance benefits - see this 
        // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-7.2/readonly-ref#motivation 
        Console.WriteLine($"student == studentRefCopy = {student == studentRefCopy}");
        // ref is used to state that the parameter passed may be modified by the method.
        CallByReference(ref student);
        Console.WriteLine($"student == studentRefCopy = {student == studentRefCopy}");

        Console.WriteLine($"student.Name = {student.Name}, studentRefCopy.Name = {studentRefCopy.Name}");

        // ref with value Types
        int x = 10;
        ValueTypeTest(ref x);
        Console.WriteLine($"x = {x}");
        //Both the ref and in require the parameter to have been initialized before being passed to a method. 
    }
    public static void CallByReference(ref Student student)
    {
        Console.WriteLine($"Inside Method CallByReference(): student.Name = {student.Name}");
        // ref allows to change the reference(pure call by reference), and this change will also be visible outside the function
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