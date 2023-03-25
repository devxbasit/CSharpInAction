using System.Threading;
using System.Linq;
using System.Collections.Generic;
using System;

class Yield_Basic
{
    public static void Main()
    {

        //A yield return statement returns an item as soon as it is available.

        foreach (var number in GetNumbers().Take(5))
        {
            Console.WriteLine($"Consumed: {number}");
        }
    }

    public static IEnumerable<int> GetNumbers()
    {

        // var list = new List<int>();

        for (int i = 0; i < 10; i++)
        {

            Thread.Sleep(1000);
            Console.WriteLine($"Produced: {i}");
            yield return i;

            //list.Add(i);
        }
        //return list;
    }
}
