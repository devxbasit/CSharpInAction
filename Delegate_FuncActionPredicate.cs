using System;

class Delegate_FuncActionPredicate
{
    public static void Main()
    {
        Func<int, int, int> Sum = (a, b) => a + b;
        Func<int> GetRandomNumber = () => new Random().Next(10, 20);

        Console.WriteLine(Sum(50, 50));
        Console.WriteLine(GetRandomNumber());



        // Action with Lambda expression
        Action<string> SaySomething = (msg) => Console.WriteLine(msg);

        // Action with anonymous function
        Action<string> SaySomething2 = delegate (string msg)
        {
            Console.WriteLine(msg);
        };

        SaySomething("Hello");
        SaySomething2("Hello");



        // predicate delegate
        Predicate<int> IsEven = (x) => x % 2 == 0;
        Console.WriteLine($"IsEven(2) = {IsEven(2)}");
    }
}