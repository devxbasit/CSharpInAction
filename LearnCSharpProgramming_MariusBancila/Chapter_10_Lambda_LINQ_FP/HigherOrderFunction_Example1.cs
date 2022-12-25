using System;

class HigherOrderFunction_Example1
{
    public static void Main()
    {
        var res = ApplyReverse<int>(Math.Add)(1, 4);
        var res2 = ApplyReverse<string>((a, b) => a + b)("Hello", "World ");

        Console.WriteLine($"res = {res}");
        Console.WriteLine($"res2 = {res2}");

        Func<int, int, Func<int, int, int>, int> apply = (a, b, f) => f(a, b);
        var s = apply(1, 4, (a, b) => a + b);
        Console.WriteLine($"s = {s}");
        
    }

    // function as argument and return value
    public static Func<T, T, T> ApplyReverse<T>(Func<T, T, T> f)
    {
        return delegate (T a, T b) { return f(b, a); };
    }
}

class Math
{
    public static int Add(int a, int b) => a + b;
}