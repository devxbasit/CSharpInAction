using System;
using System.Collections.Generic;


class LazyEagerExecution
{
    public static void Main()
    {

        foreach (int i in SimpleIterator())
        {
            Console.WriteLine(i);
            break;
        }

        Console.WriteLine("--------------------------------");

        foreach (int i in GetList())
        {
            Console.WriteLine(i);
            break;
        }

    }

    // Lazy Execution
    public static IEnumerable<int> SimpleIterator()
    {
        yield return 100;

        for (int i = 0; i < 5; i++) yield return i;

        yield return 500;
        yield return 600;
        Console.WriteLine("Bye!");
    }


    // Eager Execution
    public static IEnumerable<int> GetList()
    {
        List<int> list = new List<int>();

        list.Add(100);

        for (int i = 0; i < 5; i++) list.Add(i);

        list.Add(500);
        list.Add(600);

        Console.WriteLine($"Bye! {String.Join(',', list)}");
        return list;
    }
}