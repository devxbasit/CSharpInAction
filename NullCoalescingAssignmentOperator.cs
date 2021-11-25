using System;
using System.Collections.Generic;


class NullCoalescingAssignmentOperator
{
    public static void Main()
    {
        string msg = null;
        msg ??= "Hello!";

        Console.WriteLine((msg ??= "Hi!").ToUpper());
        Console.WriteLine(msg);

        int? num = null;
        Console.WriteLine(num ??= 10);
        Console.WriteLine(num);


        List<int> numbers = null;
        (numbers ??= new List<int>()).Add(5);
        (numbers ??= new List<int>()).Add(10);
        numbers.ForEach(x => Console.Write($"{x}, "));
    }
}