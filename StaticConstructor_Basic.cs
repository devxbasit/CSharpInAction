using System.Data.Common;
using System.Net.Mime;
using System.IO;
using System;

class StaticConstructor_Basic {

    public static void Main(){

        // A static constructor has no parameters or access modifiers and cannot be called by the user.

        // A static constructor is called by the CLR automatically in the following instances:
            // • In a static class when the first static member of the class is accessed for the first time
            // • In a non-static class when the class is instantiated for the first time

        
        // static constructors are useful for initializing static fields.

        Employee e1 = Employee.Create("Ritik");
        Employee e2 = Employee.Create("Basit");

        Console.WriteLine($"e1.EmployeeId = {e1.EmployeeId}");
        Console.WriteLine($"e2.EmployeeId = {e2.EmployeeId}");
    }

    class Employee {
        private static int _id;

        public int EmployeeId { get; private set; }
        public string Name { get; private set; }


        static Employee(){
            string text = "1";

            try {
                text = File.ReadAllText("app.data");
            } catch { }

            int.TryParse(text, out _id);
        }

        private Employee (int id, string name) {
            EmployeeId = id;
            Name = name;
        }

        public static Employee Create(string name){
            var employee = new Employee(_id++, name);
            File.WriteAllText("app.data", _id.ToString());
            return employee;
        }
    }
}