using System;

class Singleton_EarlyLoading
{
    public static void Main()
    {
        Employee employee1 = Employee.GetInstance();
        Employee employee2 = Employee.GetInstance();
        employee2.Name = "Basit";

        Console.WriteLine($"employee1.Name = {employee1.Name}");
        Console.WriteLine($"employee2.Name = {employee2.Name}");
    }

    sealed class Employee
    {
        public string Name { get; set; }
        private static Employee INSTANCE = null;

        //  The default access modifier of a constructor is private.
        Employee() { }

        // Providing Global point of access
        public static Employee GetInstance()
        {
            if (INSTANCE is null){
                INSTANCE = new Employee();
            }
            return INSTANCE;
        }
    }
}
