using System;

class RangesAndIndices
{
    public static void Main()
    {
        // Indices

        var countries = new[] { "India", "China", "Russia" };
        var length = countries.Length;

        Console.WriteLine(countries[1] == "China");

        var chinaIndex = new Index(1);
        Console.WriteLine(countries[1] == countries[chinaIndex]);


        // The interesting part is when we need to address the item starting from the end of the sequence

        var russiaIndex = new Index(1, true);
        Console.WriteLine(countries[length - 1] == countries[russiaIndex]);

        // The new ^ operator provides us with a succinct and effective way to get the last item
        Console.WriteLine(countries[^1] == countries[russiaIndex]);

        // It is very important to note that, while zero is the first index when counting from the 
        // beginning, it points to one item beyond the total length when counting from the end. This 
        // means that the [^0] expression will always throw IndexOutOfRangeException


        // Ranges - TBD
    }
}