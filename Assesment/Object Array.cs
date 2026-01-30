using System;

class Program
{
    static int SumOnlyIntegers(object[] values)
    {
        int sum = 0;
        for (int i = 0; i < values.Length; i++)
        {
            if (values[i] is int x)
            {
                sum += x;
            }
        }
        return sum;
    }
    static void Main()
    {
        object[] values = { 10, "abc", true};
        int result = SumOnlyIntegers(values);
        Console.WriteLine(result);
    }
}
