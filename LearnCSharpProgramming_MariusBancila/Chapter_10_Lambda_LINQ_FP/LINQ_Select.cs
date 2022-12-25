using System;
using System.Linq;
using System.Collections.Generic;

class LINQ_Select
{
    public static void Main()
    {
        IEnumerable<string> names = new List<string> { "One", "Two", "Three", "Four" };
        IEnumerable<int> result = names.Select(x => x.Length);

        foreach (var len in result)
        {
            Console.WriteLine($"len = {len}");
        }
    }
}