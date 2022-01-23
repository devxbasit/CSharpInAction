using System;
using System.Collections;

class IEnumerator_Example
{
    public static void Main()
    {
        // Supports a simple iteration over a non-generic collection

        foreach (int n in new InfiniteSequence())
        {
            Console.WriteLine(n);
            if (n > 5) break;
        }
    }
}

class InfiniteSequence : IEnumerable, IEnumerator
{
    int num = 0;

    public object Current { get; set; }

    public IEnumerator GetEnumerator()
    {
        return (IEnumerator)this;
    }

    public bool MoveNext()
    {
        Current = num++;
        return true;
    }

    public void Reset()
    {
        num = 0;
    }
}