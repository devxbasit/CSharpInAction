using System;
using System.Threading;

class Thread_Example1
{
    public static void Main()
    {

    }
}

class Primes : IEnumerable<long>
{
    public long Max { get; private set; }
    public Primes(long Max = long.MaxValue)
    {
        this.Max = Max;
    }   
}