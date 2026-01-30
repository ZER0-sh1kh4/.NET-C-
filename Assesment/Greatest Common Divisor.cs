using System;

class Program
{
    static int GCD(int a, int b)
    {
        if (b == 0)
            return a;
        return GCD(b, a % b);
    }
    static void Main()
    {
        int a = 48;
        int b = 18;
        Console.WriteLine(GCD(a, b));
    }
}
