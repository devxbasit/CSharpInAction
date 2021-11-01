using System;

class StringImmutability
{
    public static void Main()
    {

        string s1, s2, s3;

        s1 = "Hello";
        s2 = s1;

        Console.WriteLine($"s1 = {s1}, s2 = {s2}");
        Console.WriteLine($"{{s1 == s2}} =>  {s1 == s2}" );

        Console.WriteLine();
        s2 = "Hello World";

        Console.WriteLine($"s1 = {s1}, s2 = {s2}");
        Console.WriteLine($"{{s1 == s2}} =>  {s1 == s2}" );


    }
}