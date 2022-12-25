using System;

class PassingReferenceType_Array
{
    public static void Main()
    {
        int[] nums = { 1, 2, 3 };
        Test(nums);
        Console.WriteLine(nums[0]);
    }

    public static void Test(int[] nums)
    {
        nums[0] = 100;
        nums = new int[] { 9, 9, 9, 9 };
        Console.WriteLine(nums[0]);
    }
}