using System;

class Action_Basic {
    public static void Main() {

        // After applying the function, but before returning
        // the result, this action is invoked 
        
        Apply(5, 4, Add, Console.WriteLine);
        Apply(5, 4, Add, null);

    }

    public static T Apply<T>(T a, T b, Func<T, T, T> f, Action<string> log) {
        var res = f(a, b);
        log?.Invoke($"{f.Method.Name} ({a}, {b}) = {res}");
        return res;
    }
    
    public static int Add(int a, int b) => a + b;
}