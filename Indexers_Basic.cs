using System.ComponentModel.Design.Serialization;
using System.Collections.Generic;
using System;

class Indexers_Basic{

    public static void Main(){

        //  Indexers and finalizers cannot be declared static.
        
        Employee employee = new Employee()
        {
            EmployeeId = 101,
            Name = "Ritik"
        };

        employee.Roles[1] = "Dev";
        employee.Roles[3] = "SA";

        for (int i = 1; i <= 5; i++) {
            try {
                Console.WriteLine($"Project {i}: role is {employee.Roles[i]}");
            }catch(Exception ex){
                Console.WriteLine(ex.Message);
            }
        }
    }


    class Employee {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public ProjectRoles Roles { get; private set; }
        public Employee() => Roles = new ProjectRoles();
    }

    class ProjectRoles {
        readonly Dictionary<int, string> roles =
            new Dictionary<int, string>();

        public string this[int projectId] {
            get {
                if (!roles.TryGetValue(projectId, out string role))
                    throw new Exception("Project ID not found!");

                return role;
            }

            set {
                roles[projectId] = value;
            }
        }
    }
}