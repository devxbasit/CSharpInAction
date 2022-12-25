using System;

class Delegate_UnicastMulticast
{
    public static void Main()
    {
        SaySomething hiDelegate, byeDelegate, hiByeDelegate;

        //unicast delegate
        hiDelegate = SayHi;
        byeDelegate = SayBye;


        // A MulticastDelegate has a linked list of delegates, called an invocation list, 
        // consisting of one or more elements. When a multicast delegate is invoked, 
        // the delegates in the invocation list are called synchronously in the order in which they appear.
        hiByeDelegate = hiDelegate + byeDelegate;

        // value from last delegate call will be assigned
        int value = hiByeDelegate();
        Console.WriteLine($"value = {value}");



        hiByeDelegate -= byeDelegate;
        hiByeDelegate();

    }

    public static int SayHi() { Console.WriteLine("Hi"); return 1; }
    public static int SayBye() { Console.WriteLine("Bye"); return 200000; }
    public delegate int SaySomething();
}