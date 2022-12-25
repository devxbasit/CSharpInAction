using System;

class FactoryMethodDemo
{

    public static void Main()
    {
        // user - create factory
        var factory = new CarFactory();

        // user don't know creation logic of car
        var car1 = factory.Create();
        Console.WriteLine(car1.name);

        var car2 = factory.Create();
        Console.WriteLine(car2.name);
    }
}

public class Car
{
    public string name;

    public Car(string name)
    {
        this.name = name;
    }
}

public class CarFactory : IFactory
{
    public Car Create()
    {

        Console.WriteLine("Factory Creating Car.....");
        return new Car("Maruti Suzuki");
    }
}

public interface IFactory
{
    // factory that creates product
    public Car Create();
}
