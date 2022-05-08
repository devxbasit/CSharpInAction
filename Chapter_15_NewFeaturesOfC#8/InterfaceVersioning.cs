using System;

class InterfaceVersioning
{
\    public static void Main()
    {

        // Since the implementation is provided by the interface and the class does not provide an 
        // implementation for the Greet method, it is still not accessible from a Person reference.

        IWelcome person = new Person("Basit", "abc");
        Console.WriteLine(person.Greet());

        // What are the changes that could make sense on an interface? Removal of a member can be 
        // avoided by discouraging its usage via ObsoleteAttribute and maybe, a few versions 
        // later, it will start throwing NotImplementedException, without ever needing to 
        // remove that member from the interface.

        // Changing a member is always a bad practice because interfaces are contracts; usually, the 
        // need for a change can be modeled by a new member with a different name and signature.
    }
}


// Default implementation at the time of Version 1(IWelcome)
public class Person : IWelcome
{
    public string FirstName { get; }
    public string LastName { get; }
    public Person(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }
}


public interface IWelcome
{
    // version 1 - V1
    string FirstName { get; }
    string LastName { get; }


    // Method Added later , V2
    string Greet() => $"Welcome {FirstName}";

}