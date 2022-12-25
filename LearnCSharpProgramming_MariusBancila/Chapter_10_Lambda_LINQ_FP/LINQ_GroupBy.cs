using System;
using System.Linq;

class LINQ_GroupBy
{
    public static void Main()
    {
        var text = @"Lorem ipsum dolor sit amet, consectetur adipiscing
                        elit, sed do eiusmod tempor incididunt ut labore et dolore
                        magna aliqua.";
        
        var groups = text.Split(new char[] {' ', ',', '.'})
                     .GroupBy(w => w.Length, w => w.ToLower())
                     .Select(g => new {Length = g.Key, Words = g})
                     .Where(g => g.Length > 0)
                     .OrderBy(g => g.Length);

        foreach (var group in groups)
        {
            Console.WriteLine($"Length = {group.Length}");

            foreach (var word in group.Words)
            {
                Console.WriteLine(word);
            }

            Console.WriteLine();
        }      
    }
}