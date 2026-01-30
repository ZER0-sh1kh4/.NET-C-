using System;

class Program
{
    static int Zero(int[] nums)
    {
        int sum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
                break;
            if (nums[i] < 0)
                continue;
            sum += nums[i];
        }
        return sum;
    }
    static void Main()
    {
        int[] nums = { 5, -3, 7, 2, 0, 9 };
        int result = Zero(nums);
        Console.WriteLine(result);
    }
}
