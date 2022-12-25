using System;

class Generic_TypeInitializationAndState
{
    public static void Main()
    {
        GenericCounter<string>.Increment();
        GenericCounter<string>.Increment();
        GenericCounter<string>.Display();

        GenericCounter<int>.Display();
        GenericCounter<int>.Increment();
        GenericCounter<int>.Display();

    }
}


class GenericCounter<T>
{
    private static int value;
    static GenericCounter()
    {
        Console.WriteLine("Initializing counter for {0}", typeof(T));
    }

    public static void Increment()
    {
        value++;
    }

    public static void Display()
    {
        Console.WriteLine("Counter for {0} : {1}", typeof(T), value);
    }
}