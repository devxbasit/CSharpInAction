using System;

class TypeConversionWithHelperClasses
{
    // Conversion with a helper class or method is useful to convert between incompatible 
    //types, such as between a string and an integer or a System.DateTime object.
    public static void Main()
    {
        try
        {
            // see first - in, out, ref

            bool IdConversion;
            // int x = int.Parse("hello"); // error, throws exception 
            IdConversion = int.TryParse("hello", out int resultId); // error, returns false

            if (IdConversion)
            {
                Console.WriteLine($"Conversion Failed! ResultId = {resultId}");
            }
            else
            {
                Console.WriteLine($"Conversion Succeed! ResultId = {resultId}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: " + ex.Message);
        }
    }
}