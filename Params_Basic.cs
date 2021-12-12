using System;

class Params_Basic {

    public static void Main(){

        bool allTrue1 = VarArgs(true, true, false, true, false);
        bool allTrue2 = VarArgs(true, true);
        bool allTrue3 = VarArgs();

        Console.WriteLine($"allTrue1 = {allTrue1}");
        Console.WriteLine($"allTrue2 = {allTrue2}");
        Console.WriteLine($"allTrue3 = {allTrue3}");
    }

    public static bool VarArgs(params bool[] values){

        if (values.Length == 0) return false;

        foreach(bool value in values)
            if (!value) return false;
        
        return true;
    }
}