using System;
using System.Threading;

class PassingDataToThreadFunction
{

    public static void Main()
    {
        // pass data to thread function in a type-safe manner
        new Thread(new DoSomeWorkHelper(10).DoSomeWork).Start();
    }
}


class DoSomeWorkHelper
{
    private int _max;
    public DoSomeWorkHelper(int max) => this._max = max;

    public void DoSomeWork()
    {
        for (var i = 0; i < _max; i++)
        {
            Console.WriteLine($"i: {i}");
        }
    }
}