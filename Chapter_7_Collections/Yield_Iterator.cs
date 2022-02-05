using System;
using System.Collections.Generic;

class Yield_Return
{
    public static void Main()
    {
        // Book - C# in Depth
        // Iterators are executed lazily.


        foreach (var num in InfiniteSequence())
        {
            Console.WriteLine(num);
        }
    }

    public static IEnumerable<int> CreateSimpleIterator(bool breakSequence)
    {
        yield return 10;

        for (int i = 11; i <= 15; i++)
        {
            yield return i;
        }

        yield return 16;
        yield return 17;

        if (breakSequence) yield break;

        yield return 18;
        yield return 19;
        yield return 20;
    }
}