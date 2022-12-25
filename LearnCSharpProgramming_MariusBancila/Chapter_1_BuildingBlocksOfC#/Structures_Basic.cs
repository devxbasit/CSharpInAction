using System;

class Structures_Basic{
    public static void Main(){


        // C# does allow structs to derive from classes. All structs derive from the same class, System.ValueType, which derives from System.Object.
        
        // A structure cannot declare a default (parameterless) constructor
        // In a structure declaration, fields cannot be initialized unless they are declared const or static.

        // We can instantiate this either using the new operator, which would call the default
        // constructor initializing all the member fields with their default value, or directly, without
        // the new operator. In this case, the member fields would remain uninitialized. This could
        // be useful for performance reasons, but such an object cannot be used until all of its fields
        // are properly initialized

        Point p1 = new Point(){
            x = 10,
            y = 20
        };


        Point p2;
        p2.x = 55;
        p2.y = 22;


        // A structure should be used in the following cases
        // • When it represents a single value (such as a point, a GUID, and so on)
        // • When it is small (typically no larger than 16 bytes)
        // • When it is immutable
        // • When it is short-lived
        // • When it is not used frequently in boxing and unboxing operations (which alter
        // performance)

        // throws error - non-nullable value type
        // p1 = null;

        Point? p3 = null;
        
        Console.WriteLine($"p1.x = {p1.x}, p1.y = {p1.y}");
        Console.WriteLine($"p2.x = {p2.x}, p2.y = {p2.y}");

    }

    struct Point{
        public int x;
        public int y;
    }
}
