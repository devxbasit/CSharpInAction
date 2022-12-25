using System;

class FactoryMethodDemo
{

    public static void Main()
    {
        var factories = new AbstractVehicleFactory();

        factories.GetMarutiFactory().CreateCar();
        factories.GetMarutiFactory().CreateBike();

        factories.GetSuzukiFactory().CreateCar();
        factories.GetSuzukiFactory().CreateBike();

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

public class Bike
{
    public string name;

    public Bike(string name)
    {
        this.name = name;
    }
}



// Concrete implementation 3 - this can be implemented with nested interfaces 
public class AbstractVehicleFactory : IFactory
{
    public IMarutiFactory GetMarutiFactory() { return new MarutiFactory(); }
    public ISuzukiFactory GetSuzukiFactory() { return new SuzikiFactory(); }
}




// concrete implementation 1
public class MarutiFactory : IMarutiFactory
{
    public Car CreateCar()
    {
        Console.WriteLine("Maruti Factory Creating Car.....");
        return new Car("Maruti Car");
    }

    public Bike CreateBike()
    {
        Console.WriteLine("Maruti Factory Creating Bike.....");
        return new Bike("Maruti Bike");
    }
}


// concrete implementation 2
public class SuzikiFactory : ISuzukiFactory
{
    public Car CreateCar()
    {
        Console.WriteLine("Suzuki Factory Creating Car.....");
        return new Car("Suzuki Car");
    }

    public Bike CreateBike()
    {
        Console.WriteLine("Suzuki Factory Creating Bike.....");
        return new Bike("Suzuki Bike");
    }
}





// factory creating other factories
public interface IFactory
{
    public IMarutiFactory GetMarutiFactory();
    public ISuzukiFactory GetSuzukiFactory();
}



// factory 1
public interface IMarutiFactory
{
    public Car CreateCar();
    public Bike CreateBike();

}


// factory 2
public interface ISuzukiFactory
{
    public Car CreateCar();
    public Bike CreateBike();
}
