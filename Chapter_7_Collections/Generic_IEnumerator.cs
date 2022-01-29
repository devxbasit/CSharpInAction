using System;
using System.Collections.Generic;

class Generic_IEnumerator
{
    public static void Main()
    {
        EvenSequence sequence = new EvenSequence();

        int i = 0;
        while (sequence.MoveNext())
        {
            i++;
            Console.WriteLine($"sequence.Current = {sequence.Current}");

            if (i > 3) break;
        }

        sequence.MoveNext();
        Console.WriteLine($"sequence.Current = {sequence.Current}");
    }
}

class EvenSequence : IEnumerator<int>
{
    private int i = 0;

    // generic 
    public int Current { get { return i; } }

    // non generic 
    object System.Collections.IEnumerator.Current { get { return Current; } }

    public bool MoveNext()
    {
        i += 2;
        return true;
    }

    public void Reset()
    {
        i = 0;
    }

    public void Dispose()
    {
    }
}