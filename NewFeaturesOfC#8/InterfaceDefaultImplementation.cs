using System;

class InterfaceDefaultImplementation
{
    public static void Main()
    {
        Calc c = new Calc();

        c.Mul(1, 2);

        // error - Add, and Sub does not belong to Calc class, (Fix - use interface variable)
        // c.Add(1, 2);
        // c.Sub(1, 2);

        ICalc ic = new Calc();
        ic.Add(1, 2);
        ic.Sub(1, 2);
        ic.Mul(1, 2);

    }
}

public interface ICalc
{
    int Add(int x, int y) => x + y;
    int Sub(int x, int y) => x - y;
    int Mul(int x, int y);

}


// ***
public class Calc : ICalc
{
    // Add() and Sub() does not belong to this class
    public int Mul(int x, int y) => x * y;
}
