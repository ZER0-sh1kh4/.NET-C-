using System;

class Program
{
    static int SumValid(string[] tokens)
    {
        int sum = 0;
        int value;
        for (int i = 0; i < tokens.Length; i++)
        {
            if (int.TryParse(tokens[i], out value))
            {
                sum += value;
            }
        }
        return sum;
    }
    static void Main()
    {
        string[] tokens = { "10", "abc", "20", "9999", "-5" };
        int result = SumValid(tokens);
        Console.WriteLine(result);
    }
}
