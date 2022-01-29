using System;
using System.Collections;

class IEnumerator_Example1
{
    public static void Main()
    {
        // Can't use Iterator with foreach loop

        InfiniteSequence sequence = new InfiniteSequence();

        int i = 0;

        while (sequence.MoveNext())
        {
            Console.WriteLine($"sequence.Current = {sequence.Current}");
            if (i++ > 3) break;
        }

        sequence.MoveNext();

        PrintSequence(sequence);
        Console.WriteLine($"sequence.Current = {sequence.Current}");
    }
    public static void PrintSequence(IEnumerator sequence)
    {

        // IEnumerator cursor retains its state - see example2
        // https://www.pluralsight.com/guides/foreach-and-enumerables-csharp

        sequence.MoveNext();
        Console.WriteLine($"sequence.Current = {sequence.Current}");

        sequence.Reset();

        sequence.MoveNext();
        sequence.MoveNext();
        sequence.MoveNext();
    }
}

class InfiniteSequence : IEnumerator
{
    private int i = -1;
    public object Current { get { return i; } }
    public bool MoveNext()
    {
        i++;
        return true;
    }

    public void Reset()
    {
        i = -1;
    }
}