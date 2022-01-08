using System;

class Func_Basic {
   public static void Main() {

       Console.WriteLine($"Apply(5, 4, Math.Add) = {Apply(5, 4, Math.Add)}");
       Console.WriteLine($"Apply(5, 4, Math.Mul) = {Apply(5, 4, Math.Mul)}");

       // For convenience, .NET defines a set of generic delegates called Func to avoid defining
       // your own delegates all the time.

        Console.WriteLine($"Apply2<int>(5, 4, Math.Add) = {Apply2<int>(5, 4, Math.Add)}");
   } 

    public static T Apply2<T>(T a, T b, Func<T, T, T> f){ return f(a, b); }
   
    public static int Apply(int a, int b, Combine f) { return f(a, b); }
   
    public delegate int Combine(int a , int b);  
}


class Math {
    public static int Add(int a , int b) { return a + b; }
    public static int Mul(int a , int b) { return a * b; }
}