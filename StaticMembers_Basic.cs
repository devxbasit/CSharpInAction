using System;

class StaticMembers_Basic{

    public static void Main(){
        
        // static things belong to Type/Class;
        
        Employee e1 = Employee.Create("Ritik");
        Employee e2 = Employee.Create("Basit");

        Console.WriteLine($"e1.EmployeeId = {e1.EmployeeId}, e1.Name = {e1.Name}");
        Console.WriteLine($"e2.EmployeeId = {e2.EmployeeId}, e2.Name = {e2.Name}");

        // Trows Error, Create() belong to Type, not to object
        // e2 = e1.Create();
    }


    class Employee {

        // stores next employee Id
        private static int _id = 1;

        public int EmployeeId { get; private set; }
        public string Name { get; private set; }

        private Employee(int id, string name){
            EmployeeId = id;
            Name = name;
        }

        public static Employee Create(string name) {
            return new Employee(_id++, name);
        }
    }
}