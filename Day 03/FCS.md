
# Day 03 – .NET (C#)

### Problem Statement

```csharp
using System;
class FCS
{
    public static void  Main(string[] args)
    {
       Console.WriteLine("Choose a option: \n"+ "1-loan eligibility \n "+"2-income tax calculation \n "+ " 3- trnascations \n "+ "4- exit");
       int a=0;
       a=Convert.ToInt32(Console.ReadLine());
        switch (a)
        {
            case 1:
                LoanEligibility();
                break;
            case 2:
                IncomeTax();
                break;
            case 3:
                Transactions();
                break;
            case 4:
                Exit();
                break;
            default:
            Console.WriteLine("invalid");
            break;

        }
    }
    

        public static void LoanEligibility()
        {
            Console.WriteLine("Enter your age: ");
            int age=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the monthly income: ");
            int monthlyincome=Convert.ToInt32(Console.ReadLine());
        if (age >= 21 && monthlyincome >=30000)
        {
            Console.WriteLine("Client is eligible ");
        }
        else
        {
            Console.WriteLine("Client is not eligible");
        }

        
        }
        public static void IncomeTax()
    {

        Console.WriteLine("Enter your Income: ");
        int income=Convert.ToInt32(Console.ReadLine());
        if (income <= 250000)
        {
            Console.WriteLine("Congo no tax for you ");
        }
        else if( income >= 250001 || income <= 500000)
        {
            income=income-income*5/100;
            Console.WriteLine("for you 5%");
            Console.WriteLine("balance is :" + income);
        }
        else if(income >= 5000001 || income <= 1000000)
        {
            income=income-income*20/100;

            Console.WriteLine("For you 20%");
            Console.WriteLine("balance is :" + income);

        }
        else
        {
            income=income-income*30/100;

            Console.WriteLine("well pay tax 30%");
            Console.WriteLine("balance is :" + income);

        }

    }
    public static void Transactions()
    {
        Console.WriteLine("Enter your income: ");
        int balance=Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter your choice D for debit C for credit: ");
        char c=Convert.ToChar(Console.ReadLine());
        switch(c)
        {
            case 'C':
            Console.WriteLine("enter the amount for credit: ");
            int amount=Convert.ToInt32(Console.ReadLine());

            balance -= amount;
            break;
            case 'D':
            Console.WriteLine("enter the amount for debit: ");
            amount=Convert.ToInt32(Console.ReadLine());

            balance += amount;
            break;

        }
        Console.WriteLine("all you have now: "+balance);

    }
    public static void Exit()
    {
        Console.WriteLine("babyeeeeee");
    }
}

```    
