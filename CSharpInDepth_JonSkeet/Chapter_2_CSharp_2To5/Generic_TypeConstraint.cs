using System;
using System.Collections;
using System.Collections.Generic;

class Generic_TypeConstraint
{
    public static void Main()
    {

        //Reference type constraint, Value  type  constraint, Constructor constraint, Conversion constraint
        // examples - TBD
    }

    public static void DoSomeThing<T>() where T : IEnumerable<T>
    {
    }
    public static void DoSomeThing<T, U>() where T : IEnumerable<T>
    {
    }

    public static void DoSomeThing<T, U, V>(T a) where T : new()
    {
        // The type argument must have a public parameterless constructor. This enables the use of newT() within the body of the code to construct a new instance of T
        var x = new T();
    }

}
