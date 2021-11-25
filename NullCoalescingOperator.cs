using System.Reflection.Emit;
using System;

class NullCoalescingOperator
{
    public static void Main()
    {
        string name = null;
        Console.WriteLine(name ?? "No Name");

        // Both ?? and ??= are right-associative. That means, the expression a ?? b ?? c is 
        // evaluated as a ?? (b ?? c). Similarly, the expression a ??= b ??= c is evaluated 
        // as a ??= (b ??= c).
        // left hand operand should be Nullable Type
        Console.WriteLine($"GetDisplayName(null, null) = {GetDisplayName(null, null)}");
        Console.WriteLine($@"GetDisplayName(""Basit"",""B@Gamil""){{}} = {GetDisplayName("Basit","Basit@Gamil")}");


        // The null-coalescing operator can also be used in argument checking. 

        string value = "Hello!";
        Console.WriteLine($"nameof(value) = {nameof(value)}");
        string text = value ?? throw new ArgumentNullException(nameof(value));


    }
    public static string GetDisplayName(string name, string email){
        return name ?? email ?? "Guest User";
    }
}