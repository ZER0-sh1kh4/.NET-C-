using System;

class Program
{
    static int FinalBalance(int initialBalance, int[] transactions)
    {
        int balance = initialBalance;
        for (int i = 0; i < transactions.Length; i++)
        {
            int t = transactions[i];
            if (t >= 0)
            {
                balance += t; 
            }
            else
            {
                if (balance + t >= 0)
                {
                    balance += t; 
                }
            }
        }
        return balance;
    }
    static void Main()
    {
        int initialBalance = 1000;
        int[] transactions = { 200, -300};
        int result = FinalBalance(initialBalance, transactions);
        Console.WriteLine(result);
    }
}
