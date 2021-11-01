using System;

class Complex
{
    public double Real { get; private set; }
    public double Imaginary { get; private set; }
    public Complex(double real, double imaginary)
    {
        Real = real; Imaginary = imaginary;
    }

    public static Complex operator +(Complex c1, Complex c2)
    {
        return new Complex(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary);
    }

    public static string operator -(Complex c1, Complex c2)
    {
        double sum = c1.Real - c2.Real;
        return sum.ToString();
    }
}


class OperatorOverloading
{
    public static void Main()
    {

        Complex c1 = new Complex(100D, 200D);
        Complex c2 = new Complex(30D, 40D);


        Complex c3 = c1 + c2;
        Console.WriteLine($"Real: {c3.Real}, Imaginary: {c3.Imaginary}");

        string resultComplexString = c1 - c2;
        Console.WriteLine(resultComplexString);
    }
}