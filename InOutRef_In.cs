using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Threading;
using System.Runtime.CompilerServices;
using System;

// https://www.pluralsight.com/guides/csharp-in-out-ref-parameters
class Ref
{
    public static void Main()
    {
        // in is used to state that the parameter passed cannot be modified by the method.
        // motivation behind 'in' - https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-7.2/readonly-ref#motivation

        // when used with reference types, it only prevents from assigning new ReferenceAssemblyAttribute


        Student student = new Student();
        student.Name = "Basit";

        Console.WriteLine($"In Main(): student.Name = {student.Name}");
        Test(in student, ref student);
        Console.WriteLine($"In Main(): student.Name = {student.Name}");

        int x = 10;
        ValueTest(in x);
    }

    public static void Test(in Student student1, ref Student student2)
    {
        Console.WriteLine($"student1 == student2 = {student1 == student2}");
        student2.Name = "Ritik";

        Console.WriteLine($"In Test(): student2.Name = {student2.Name}");

        // throws error -  Cannot assign to variable 'in Ref.Student' because it is a readonly variable 
        //student1 = new Student();

        student2 = new Student();
        student2.Name = "Wasit";
        Console.WriteLine($"student1 == student2 = {student1 == student2}");
    }

    public static void ValueTest(in int x)
    {
        Console.WriteLine($"x = {x}");
        // throws error - Cannot assign to variable 'in int' because it is a readonly variable
        //x++;
    }

    public class Student
    {
        public string Name { get; set; }
    }
}