using System;

class In_Basic {

    public static void Main() {

        int i = 10;
        string s = "Hi!";

        // Specifying the in keyword when passing the arguments to the method is optional
        // DontTouch(i, s);
        DontTouch(in i, in s);

        // An in parameter is basically a readonly ref parameter.
        // In argument cannot be modified by the called method
        // A variable that is passed as an in argument must be initialized before being passed as an argument in a method called

    }  

    public static void DontTouch(in int value, in string text){       
        //throws error
        // value = 20;
        // text = "Hello!";

    }
}