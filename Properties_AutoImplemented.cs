using System.Net.Http.Headers;
using System.Diagnostics.Contracts;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System;

class Properties_Basic
{
    public static void Main()
    {
        Employee employee = new Employee(20, 50000);
        employee.Name = "Ritik";

        // Throws Error - setter is private
        //employee.Age = 20;

        // Throws Error - Property cannot be assigned to - it is read only
        // employee.Salary = 20000;

         
        employee.DoSomething();
        Console.WriteLine($"In Main(), employee.Age = {employee.Age}");

        employee.Address = "Srinagar";
        Console.WriteLine($"In Main(), employee.Address = {employee.Address}");

    }

    class Employee
    {
       public string Name { get; set; }

        // setter is private not property 
        public int Age { get; private set; } = 0;
        public Decimal Salary { get; }


        public Employee(int age, Decimal salary){
            Age = age;
            Salary = salary;
        }

        private string address;
        public string Address {
            get => address.ToUpper();
            set => address = $"R/O: {value}";
        }



        public void DoSomething(){

        }
    }
}