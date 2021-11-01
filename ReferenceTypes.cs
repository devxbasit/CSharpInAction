using System;

class ReferenceTypes
{
    public static void Main()
    {

        // The built-in data types object and string are reference types.
        // Arrays, interfaces, delegates, and any user-defined type defined as a class are also called reference types. 

        int[] nums1 = new int[] { 1, 2, 3 };
        int[] nums2 = nums1;

        nums2[0] = 90;

        Console.WriteLine(nums1[0]);
        Console.WriteLine(nums2[0]);


        // string immutability
        string s1 = "Hi!";
        string s2 = s1;
        s2 = "Bye!";

        Console.WriteLine(s1);
        Console.WriteLine(s2);

    }
}