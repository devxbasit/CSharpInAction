using System.Reflection.Metadata.Ecma335;
using System;

class ElvisOperator
{
    public static void Main()
    {
        // null condition Operator 
        //1.  ?.
        //2. ?[]

        //The expression A?.B evaluates to B if the left operand (A) is non-null; otherwise, it   evaluates to null.
        //The type of the expression A?.B is the type of B, in cases where B is a reference type. 

        string s = null;
        Nullable<int> x = s?.Length;
        Console.WriteLine($"x = {x}");

        Person p1 = null;
        int? i = p1?.run();
        Console.WriteLine($"i = {i}");

        Person[] persons = null;
        
        //  If persons is null, person1 is assigned the value null
        var person1 = persons?[0];
        Console.WriteLine($"person1 = {person1}");
        
        var person2 = persons?[0]?.FirstName?.ToUpper();
        Console.WriteLine($"person2 = {person2}");

        Person person3 = new Person()
        {
            FirstName = "David",
            Age = 10,
            Spouse = null
        };

        var spouseNameTest = person3?.Spouse?.FirstName?.ToUpper();

        Console.WriteLine($"spouseNameTest = {spouseNameTest}");

    }
    class Person {
        public string FirstName { get; set; }
        public int Age { get; set; }
        public Person Spouse { get; set; }

        public int run(){
            return 10;
        }
    }
}