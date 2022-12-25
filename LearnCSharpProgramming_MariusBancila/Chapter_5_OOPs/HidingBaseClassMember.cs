using System;

class HidingBaseClassMember{
    public static void Main(){
        Student s = new Student();
        Person p = new Student();

        // hiding base class member here
        Console .WriteLine($"s.Get() = {s.Get()}");

        
        Console.WriteLine($"p.Get() = {p.Get()}");

        s.Print();
        p.Print();



    }
}

class Person {
    public int Get() => 0;
    public virtual void Print() => Console.WriteLine("Person Print Called.");
}

class Student : Person {
    public int Get() => 20000;
    public override void Print() => Console.WriteLine("Student Print Called.");
}