using System.Collections.Generic;
using System;

class LambdaExpression_Basic
{
    public static void Main()
    {
        /*
            A lambda does not have a type of its own. Instead, its type is either the type of delegate
            that it is assigned to or the System.Expression type when lambdas are used to build
            expression trees. 
            A lambda that does not return a value corresponds to a System.
            Action delegate (and can be assigned to one). A lambda that does return a value
            corresponds to a System.Func delegate.
        */

        var list = new List<int>() { 1, 2, 3, 4, 5, 6 };

        list.RemoveAll(IsOdd);
        list.RemoveAll(delegate (int n) { return n % 2 == 1; });
        list.RemoveAll(n => n % 2 == 1);
        Console.WriteLine(String.Join(",", list));

        /*
            Lambdas may use variables that are in the scope of the method or the type that contains
            the lambda expression. When a variable is used in a lambda, it is captured so that it can be
            used even if it goes out of scope. These variables must be definitely assigned before they
            are used in the lambda. In the following example, the lambda expression is capturing two
            variables—the value function parameter and the Data class member

            • A lambda cannot capture in, ref, or out parameters from the enclosing method.
            
            • Variables that are captured by a lambda expression are not garbage collected, even if
              they would otherwise go out of scope until the delegate that the lambda is assigned
              to is garbage collected.
        */

        Foo f = new Foo(5);
        f.Scrable(2, 3);
        Console.WriteLine($"Data = {f.Data}");


    }
    public static bool IsOdd(int n) { return n % 2 == 1; }
}

class Foo
{
    public int Data { get; private set; }

    public Foo(int value) { Data = value; }

    public void Scrable(int value, int iterations)
    {

        // lambda capturing Data & value
        Func<int, int> apply = (i) => Data ^ i + value;

        for (int i = 0; i < iterations; i++)
        {
            Data = apply(i);
            Console.WriteLine(Data);
        }
    }
}