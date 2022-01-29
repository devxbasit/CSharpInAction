using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;


class Thread_Example1
{
    public static void Main()
    {


    }
}

class Primes : IEnumerable<long>
{
    public Primes(long Max = long.MaxValue)
    {
        this.Max = Max;
    }

    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<long>)this).GetEnumerator();

    public IEnumerator<long> GetEnumerator()
    {
        yield return 1;

        bool bFlag;
        long start = 2;
        while (start < Max)
        {
            bFlag = false;
            var number = start;
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    bFlag = true;
                    break;
                }
            }

            if (!bFlag)
            {
                yield return number;
            }

            start++;
        }
    }
}