using System;

class Program
{
    static int LargestOfThree(int a, int b, int c)
    {
        if (a >= b && a >= c)
            return a;
        else if (b >= a && b >= c)
            return b;
        else
            return c;
    }
    static void Main()
    {
        int a = 10;
        int b = 25;
        int c = 15;
        int largest = LargestOfThree(a, b, c);
        Console.WriteLine(largest);
    }
}
