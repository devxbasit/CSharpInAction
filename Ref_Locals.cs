using System;

class Ref_Locals
{    public static void Main()
    {
        string[] colors = new string[] { "Red", "Blue", "Green" };
        ref string color = ref colors[0];
        color = "Blue";
        Console.WriteLine(string.Join(",", colors));

        // To get a reference of a ref return value, you will need to use ref locals 
    }
}
