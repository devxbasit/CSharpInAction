using System;

// https://www.pluralsight.com/guides/csharp-in-out-ref-parameters

class InOutRef_Out
{
    public static void Main()
    {
        Student student = new Student();
        student.Name = "Basit";
        // out is used to state that the parameter passed must be modified by the method.
        // When using out, you must initialize the parameter you pass inside the method. The parameter being passed in often is null.
        OutTest(out student);
        Console.WriteLine($"student.Name = {student.Name}");

        // out with Value Types

        int x = 10;
        ValueTypeTest(out x);
        Console.WriteLine($"x = {x}");

        int min;
        bool minConvertSuccess = Int32.TryParse("20", out min);
        bool maxConvertsuccess = Int32.TryParse("200", out int max);
        Console.WriteLine($"Min = {min}, Max = {max}");
    }

    public static void OutTest(out Student student)
    {
        // we cannot pass data to function from outside, first we have to initialize out declared variable
        // below line throws error - Use of unassigned out parameter 'student'
        //Console.WriteLine(student.Name);

        student = new Student();
        student.Name = "Ritik";
        Console.WriteLine($"Inside Method OutTest(): student.Name = {student.Name}");
    }

    public static void ValueTypeTest(out int x)
    {
        x = 55;
    }


    public class Student
    {
        public string Name { get; set; }
    }

}