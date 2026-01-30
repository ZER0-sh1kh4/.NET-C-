using System;

class Program
{
    static int[] Multi(int n, int upto)
    {
        int[] result = new int[upto];
        for (int i = 1; i <= upto; i++)
        {
            result[i - 1] = n * i;
        }
        return result;
    }
    static void Main()
    {
        int n = 3;
        int upto = 5;
        int[] row = Multi(n, upto);
        for (int i = 0; i < row.Length; i++)
        {
            Console.Write(row[i] + " ");
        }
    }
}
