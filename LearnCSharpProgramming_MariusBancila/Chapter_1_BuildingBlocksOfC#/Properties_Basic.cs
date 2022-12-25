using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System;

class Properties_Basic
{
    public static void Main()
    {
        // Abstraction over private field is called property
        
        Employee employee = new Employee();
        employee.Name = "Basit";
        Console.WriteLine($"employee.Name = {employee.Name}");
    }

    class Employee
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
    }
}