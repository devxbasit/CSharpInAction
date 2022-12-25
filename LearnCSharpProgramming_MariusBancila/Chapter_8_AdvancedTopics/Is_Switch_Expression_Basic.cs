using System;

class Is_Switch_Expression
{
    public static void Main()
    {
        // forms of pattern matching:
        // Type pattern 
        // Constant pattern
        // The var pattern


    }


    public bool IsTrue(object value)
    {
        if (value is null) return false;
        else if (value is true) return true;
        else if (value is "true") return true;
        else if (value is 1) return true;
        else if (value is "1") return true;
        else return false;
    }

    // is pattern
    public void SetInMotion1(object vehicle)
    {
        if (vehicle is null)
            throw new ArgumentNullException(message: "Vehicle must not be null",
                                            paramName: nameof(vehicle));
        else if (vehicle is Airplane a)
            a.Fly();
        else if (vehicle is Bike b)
            b.Ride();
        else if (vehicle is Car c)
        {
            if (c.HasAutoDrive) c.AutoDrive();
            else c.Drive();
        }
        else
        {
            throw new ArgumentException(message: "Unexpected Vehicle Type",
                                        paramName: nameof(vehicle));
        }
    }

    //switch pattern
    public void SetInMotion2(object vehicle)
    {
        switch (vehicle)
        {

            case Airplane a:
                a.Fly();
                break;

            case Bike b:
                b.Ride();
                break;

            case Car c when c.HasAutoDrive:
                c.AutoDrive();
                break;

            case Car c:
                c.Drive();
                break;

            case null:
                throw new ArgumentNullException(
                    message: "Vehicle must not be null",
                    paramName: nameof(vehicle)
                );

            default:
                throw new ArgumentException(
                    message: "Unexpected vehicle type",
                    paramName: nameof(vehicle)
                );
        }
    }
}

class Airplane { public void Fly() { } }
class Bike { public void Ride() { } }

class Car
{
    public bool HasAutoDrive { get; }
    public void Drive() { }
    public void AutoDrive() { }
}