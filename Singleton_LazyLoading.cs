using System;

class Singleton_Lazy
{
    public static void Main()
    {

        Employee employee1 = Employee.GetInstance();
        employee1.Name = "Basit";

        // Throws error: constructor inaccessible
        // Employee employee2 = new Employee();

        Employee employee2 = Employee.GetInstance();
        employee2.Name = "Ritik";

        Console.WriteLine($"employee1.Name = {employee1.Name}");
        Console.WriteLine($"employee2.Name = {employee2.Name}");

    }

    sealed class Employee
    {
        public string Name { get; set; }
        private static Employee INSTANCE = new Employee();

        //  The default access modifier of a constructor is private.
        Employee() { }

        // Providing Global point of access
        public static Employee GetInstance()
        {
            return INSTANCE;
        }
    }
}
