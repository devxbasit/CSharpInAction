using System;

class NullCoalescingOperator
{
    public static void Main()
    {
        Nullable<int> x = null;
        int y;
        y = x ?? 1;
        Console.WriteLine($"Y = {y}");

        // The null-coalescing operators are right-associative

        // the type of the left - hand operand of the ?? and ??= 
        //operators cannot be a non-nullable value type.

        // below line throws error
        // y = 1 ?? x;

        int? n = null;
        int? temp = x ?? n;
        
        if (temp == null)
            Console.WriteLine("Temp Contains Null Value");

    }
}