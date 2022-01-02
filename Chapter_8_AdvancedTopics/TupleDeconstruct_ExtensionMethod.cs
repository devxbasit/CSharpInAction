using System.Threading;
using System.Net.Http.Headers;
using System;

class TupleDeconstruct_ExtensionMethod
{
    public static void Main()
    {

    }

}

class Engine {
    public string Name { get;}
    public int Capacity { get;}
    public double Power { get; }

    public Engine(string name, int capacity, double power) {
        Name = name;
        Capacity = capacity;
        Power = power;
    }
}

static class ExtensionMethod {
   // pending
}