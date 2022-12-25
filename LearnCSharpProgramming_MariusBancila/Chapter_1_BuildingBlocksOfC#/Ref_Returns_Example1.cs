using System;

class Ref_Returns_Example1{

    public static void Main(){

        Employee employee = new Employee("Ritik", "saxenaaa");
        Project project = new Project("ASMSC", employee);

        Console.WriteLine(project.ToString());


        // Returning by reference breaks the encapsulation because the caller gets full access to 
        // the state, or parts of the state, of an object.
        
        // change owner
        ref Employee owner = ref project.GetOwner();
        owner = new Employee("Aafridah", "Manzoor");

        Console.WriteLine(project.ToString());
    }


    class Project {
        private Employee _owner;
        
        public string Name { get; private set; }

        public Project(string name, Employee owner){
            Name = name;
            _owner = owner;
        }

        public ref Employee GetOwner() {
            return ref _owner;
        }

        public override string ToString() => $"Project: {Name}, {{ Owner: {_owner.FirstName} {_owner.LastName} }}";

    }

    class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Employee(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}