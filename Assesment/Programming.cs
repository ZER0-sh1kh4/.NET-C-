using System;

class Program
{
        static int SumOf(int num)
    {
        int sum = 0;
        while (num > 0)
        {
            sum += num % 10;
            num /= 10;
        }
        return sum;
    }
    static bool IsPrime(int num)
    {
        if (num <= 1)
            return false;

        for (int i = 2; i * i <= num; i++)
        {
            if (num % i == 0)
                return false;
        }
        return true;
    }

    static void Main()
    {
        int m = 20;
        int n = 30;
        int count = 0;

        for (int x = m; x <= n; x++)
        {
            if (IsPrime(x))
                continue;
            int s1 = SumOf(x);
            int s2 = SumOf(x * x);
            if (s2 == s1 * s1)
            {
                count++;
            }
        }
        Console.WriteLine(count);
    }
}
