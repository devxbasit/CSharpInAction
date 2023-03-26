using System;
#nullable enable

public class NullableReferenceTypes
{
    public string Id { get; set; } = null!; // no warning 

    public static void Main()
    {
        // see also - Parameter null checking feature

        String Name = null; // warning - Converting null literal or possible null value to non-nullable type.

        String? Message = null; // no warning

        String Address = null!; // no warning - null forgiving operator in action (damn it or bang operator)

        string x = Message; // warning - Converting null literal or possible null value to non-nullable type.

        string y = Message ?? ""; // no warning

        PrintMessage(null);  //warning - Cannot convert null literal to non-nullable reference type.
        PrintMessage(Message);  // warning - Possible null reference argument for parameter
        PrintMessage(null!);
        PrintMessage(Message!);

        Console.WriteLine("GetTextLength() :" + GetTextLength(""));
        Console.WriteLine("GetTextLength() :" + GetTextLength(null));

    }

    public static void PrintMessage(string message)
    {
        Console.WriteLine(message);
    }

    public static int GetTextLength(string? text)
    {

        // warning - Dereference of a possibly null reference
        //return text.Length;

        // warning fix 1 - forgive operator
        //return text!.Length;

        // warning fix 2 -  null conditional operator & null coalescing Operator
        return text?.Length ?? -1;

    }
}