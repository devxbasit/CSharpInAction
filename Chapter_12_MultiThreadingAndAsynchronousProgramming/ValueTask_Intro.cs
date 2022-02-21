using System;
using System.Threading.Tasks;

class ValueTask_Intro
{
    public static void Main()
    {
        ValueTask<int> t1 = AddAsync(4, 4); ;
        Task<int> t2 = AddAsync(4, 4, 4);

        Console.WriteLine($"t1.Result = {t1.Result}");
        Console.WriteLine($"t2.Result = {t2.Result}");
    }

    public static ValueTask<int> AddAsync(int a, int b)
    {
        // The ValueTask immutable struct is a convenient wrapper around either a synchronous
        // result or Task.
        return new ValueTask<int>(a + b);
    }

    public static Task<int> AddAsync(int a, int b, int c)
    {
        return new ValueTask<int>(a + b + c).AsTask();
    }
}