using Microsoft.Win32.SafeHandles;
using System;

class StaticClass_Basic{

    public static void Main(){


        //Since we cannot create instances of a static class, we access the class 
        // members using the class name itself. All members of a static class must themselves be static

        //A static class is typically used to define methods that operate only on their parameters 
        //(if any) and do not rely on class fields. This is often the case with utility classes.

        var lbs = MassConverters.KgToPound(42.5);
        var kgs = MassConverters.PoundToKg(180);

    }

    static class MassConverters{

        // all members should be static 
        //public int x;
        
        public static double PoundToKg(double pound){
            return pound * 0.453;
        }
        public static double KgToPound(double kgs) {
            return kgs * 2.204;
        }
    }
}