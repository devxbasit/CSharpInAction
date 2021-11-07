using System.Security.Principal;
using System.Reflection.Emit;
using System;

class PassingReferenceType
{
    public static void EnrollStudent(Student student)
    {
        student.Enrolled = true;
        student.Name = "Jhons";

        student = new Student();
        student.Enrolled = false;
        student.Name = "Ritik";
    }
    public static void Main()
    {
        Student student = new Student()
        {
            Name = "Basit",
            Enrolled = false,
        };

        EnrollStudent(student);

        Console.WriteLine($"Enrolled = {student.Enrolled}, Name = {student.Name}");
        // see also - in, out, ref
    }
}



class Student
{
    public string Name { get; set; }
    public bool Enrolled { get; set; }

}