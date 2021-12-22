using System;

class PartialClasses {   
    public static void Main() {

        // If a partial method does not have an implementation, it is removed from the class definition at compile time. 
        // Partial methods cannot have an access modifier and are implicitly private. Also, a partial 
        // method cannot return a value; the return type of a partial method must be void.

        Employee employee = new Employee()
        {
            EmployeeId = 1,
            EmployeeName = "Ritik"
        };

        Console.WriteLine($"employee.EmployeeId = {employee.EmployeeId}, employee.EmployeeName = {employee.EmployeeName}");
    }
}

partial class Employee{
    public int EmployeeId { get; set; }

    // partial function
    partial void DoSomething();
}

partial class Employee{

    public string EmployeeName { get; set; }
    partial void DoSomething(){
        Console.WriteLine("Doing Something ...");
    }
}

