using System;
using System.Threading;
using System.Collections.Generic;

// https://www.pluralsight.com/guides/foreach-and-enumerables-csharp

class IEnumerator_Example2
{
    public static void Main()
    {
        /*
            A word of advice: If you would like tho sequentially go through a collection, 
            you should use the IEnumerable interface. If you would like to retain the cursor position 
            and pass it between functions, you should use IENumerator.
        */

        List<string> list = new List<string>();
        list.Add("Programming"); list.Add("is"); list.Add("really"); list.Add("fun");
        list.Add("if"); list.Add("you"); list.Add("do"); list.Add("it"); list.Add("right");

        IEnumerable<string> ienumerableToBeIterated = (IEnumerable<string>)list;
        IEnumerator<string> ienumeratorToBeIterated = list.GetEnumerator();

        foreach (string s in ienumerableToBeIterated) Console.Write(s + " ");
        Console.WriteLine();
        while (ienumeratorToBeIterated.MoveNext()) Console.Write(ienumeratorToBeIterated.Current + " ");
        Console.WriteLine();


        List<int> myList = new List<int>(10);
        for (int i = 1; i <= 10; i++) myList.Add(i);


        IEnumerator<int> myListEnum = myList.GetEnumerator();

        myListEnum.MoveNext();
        OddProcessor(myListEnum);
    }

    public static void OddProcessor(IEnumerator<int> i)
    {

        if (i.Current == 0)
        {
            Console.WriteLine("The list was processed, exiting!");
            Thread.Sleep(5);
            i.Dispose();
        }
        else if (i.Current % 2 == 0)
        {
            Console.WriteLine("Number is Even, calling Even Processor.");
            EvenProcessor(i);
        }
        else if (i.Current % 2 != 0)
        {
            Console.WriteLine($"Processing Odd: {i.Current}");
            Console.WriteLine("Odd Number Processed!");
            i.MoveNext();

            //***
            OddProcessor(i);
        }
        else { i.Dispose(); }
    }

    public static void EvenProcessor(IEnumerator<int> i)
    {

        if (i.Current == 0)
        {
            Console.WriteLine("The list was processed, exiting!");
            Thread.Sleep(10);
            i.Dispose();
        }
        else if (i.Current % 2 != 0)
        {
            Console.WriteLine("Number is Odd, calling Odd Processor.");
            OddProcessor(i);
        }
        else if (i.Current % 2 == 0)
        {
            Console.WriteLine($"Processing Even: {i.Current}");
            Console.WriteLine("Even Number Processed!");
            i.MoveNext();

            // ***
            EvenProcessor(i);
        }
        else { i.Dispose(); }
    }
}