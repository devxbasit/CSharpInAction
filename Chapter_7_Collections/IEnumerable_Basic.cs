using System;
using System.Collections;

class IEnumerable_Basic
{
    public static void Main()
    {
        int j = 1;

        InfiniteSequence sequence =  new InfiniteSequence();
        foreach (int i in sequence)
        {
            Console.WriteLine($"i = {i}");
            if (++j > 3) break;
        }

        j = 1;

        IEnumerator sequenceEnumerator = sequence.GetEnumerator();
        while (sequenceEnumerator.MoveNext())
        {
            Console.WriteLine($"i = {sequenceEnumerator.Current}");
            if (++j > 3) break;
        }
    }
}

class InfiniteSequence : IEnumerable
{
    public IEnumerator GetEnumerator() => new InfiniteSequenceNumerator();
}

class InfiniteSequenceNumerator : IEnumerator
{
    private int i;
    public object Current { get; private set; }

    public bool MoveNext()
    {
        Current = (object)++i;
        return true;
    }

    public void Reset()
    {
        i = 0;
        Current = (object)0;
    }
}