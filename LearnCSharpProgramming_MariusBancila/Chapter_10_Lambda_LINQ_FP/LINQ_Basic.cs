using System;
using System.Linq;

class LINQ_Basic
{
    public static void Main()
    {
        int[] nums = new int[] { 1, 2, 3, 4 };
        var sum = nums.Where(x => x % 2 == 0).Sum();
        Console.WriteLine($"sum = { sum }");

        var text = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod 
                     tempor incididunt ut labore et dolore magna aliqua.";

        // count words 
        var count = text.Split(new char[] { ' ', ',', '.' })
                        .Where(w => !string.IsNullOrEmpty(w))
                        .Count();

    }
}