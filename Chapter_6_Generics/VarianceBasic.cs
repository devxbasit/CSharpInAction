using System;
using System.Collections.Generic;

class VarianceBasic
{
    static void Main()
    {
        //https://stackoverflow.com/questions/2662369/covariance-and-contravariance-real-world-example

        //contraVariance is just for convenience that allows a less derived type to be passed in as a more derived type, but it will still be used as the original less derived type.

        var redFruit = new RedFruit();
        var blueApple = new BlueApple();

        Test(blueApple);

        // ContraVariant - passing less derived in place of more derived
        Test(redFruit);

        // Covariant
        IEnumerable<object> o = new List<string>();
    }

    public static void Test(IContravariant<Apple> impl)
    {
        impl.SayHello();
    }
}

public class Fruit { }
public class Apple : Fruit { }
public interface IContravariant<in T> { void SayHello(); }


public class RedFruit : IContravariant<Fruit>
{
    public virtual void SayHello() => Console.WriteLine("Red Fruit");
}

public class BlueApple : IContravariant<Apple>
{
    public virtual void SayHello() => Console.WriteLine("Blue Apple");
}