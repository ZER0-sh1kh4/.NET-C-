# Day 02 – .NET (C#)

### Problem Statement
Credit and Debit

```csharp
using System;

class Account
{
    public static void Main(string[] args)
    {
        Debit debit=new Debit();
        Credit credit=new Credit();
        while (true)
        {

            Console.WriteLine("Main Menu Options...\n"+" 1-Debit operartions\n"+"2-Credit operations \n"+"3-Exit");
            int a=0;
            a=Convert.ToInt32(Console.ReadLine());
            switch (a)
            {
                case 1:
                Debit.Menu();
                break;
                case 2:
                Credit.Menu();
                break;
                case 3:
                Exit();
                return;
                
            }
        }
    }
        public static void Exit()
    {
        Console.WriteLine("babyeeeeee"); 
    }
}

    

class Debit
{
    public static void Menu()
    {
        Console.WriteLine("Main Menu Options....\n "+ "1-ATM Withdrawl Limit Validation \n"+ "2-EMI Burden Evaluation \n"+"3-Transactions-Based Daily Spending Calculator \n"+"4-Minimum Balance Compliance Check \n"+"5-Exit");
        int a =Convert.ToInt32(Console.ReadLine());
        switch (a)
        {
            case 1:
            ATMWithdrawl();
            break;
            case 2:
            EMI();
            break;
            case 3:
            TransactionsBasedCalculator();
            break;
            case 4:
            MinimumBalance();
            break;
            case 5:
            Exit();
            break;
        }
    }
    public static void ATMWithdrawl()
    {
        Console.WriteLine("Enter withdrawal amount: ");
        int Withdrawl=Convert.ToInt32(Console.ReadLine());
        if (Withdrawl <= 40000)
        {
            Console.WriteLine("Withdrawl permitted within daily limit.");
        }
        else
        {
            Console.WriteLine("Daily ATM withdrawl limit exceeded");
        }

    }
    public static void EMI()
    {
        Console.WriteLine("Enter the monthly income: ");
        int monthly=Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter EMI Amount: ");
        int EMI=Convert.ToInt32(Console.ReadLine());
        int res=monthly*40/100;
        if (EMI <= monthly)
        {
            Console.WriteLine("EMI is financially manageable.");
        }
        else
        {
            Console.WriteLine("EMI exceeds safe income limit.");
        }
    }
    public static void TransactionsBasedCalculator()
    {
        Console.WriteLine("Enter your balance: ");
        int balance=Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter no. of transcations: ");
        int no=Convert.ToInt32(Console.ReadLine());
        for(int i = 0; i <= no; i++)
        {
            Console.Write("Enter transcation no. "+i +":");
            int amount = Convert.ToInt32(Console.ReadLine());
            balance -= amount;
        }
        Console.WriteLine("Total debit amount for teh day: " +balance);
        }
    
    public static void MinimumBalance()
    {
        Console.WriteLine("Enter the current blance: ");
        int balance=Convert.ToInt32(Console.ReadLine());
        if (balance < 2000)
        {
            Console.WriteLine("Minimium Balance not maintained. Penalty applicable.");
        }
        else
        {
            Console.WriteLine("Minimum Blance requiremnet satisfied");
        }
    }

    public static void Exit()
    {
        Console.WriteLine("babyeeeeee"); 
    }
}
class Credit
{
    public static void Menu()
    {
        Console.WriteLine("Main Menu Options....\n "+ "1-Net Salary Credit Calculation \n"+ "2-Fised Deposit Maturity Calculation \n"+"3-Credit Card Reward Points Evaluation \n"+"4-Employee Bonus Eligibility Check \n"+"5-Exit");
        int a =Convert.ToInt32(Console.ReadLine());
        switch (a)
        {
            case 1:
            NetSalary();
            break;
        
            case 2:
            FixedDeposit();
            break;
            case 3:
            RewardPoint();
            break;
            case 4:
            BonusEligibility();
            break;
            case 5:
            Exit();
            break;
        }

        
    }
    public static void NetSalary()
    {
        Console.WriteLine("Enter teh gross salary: ");
        int gross=Convert.ToInt32(Console.ReadLine());
        gross=gross-gross*10/100;
        Console.WriteLine("Net salary crredited: "+gross);
    }
    public static void FixedDeposit()
    {
        Console.Write("Enter the principle amount: ");
        int principle=Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter the rate of intrest:  ");
        int interest=Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter the time period: ");
        int time=Convert.ToInt32(Console.ReadLine());
        int SI=(principle*interest*time)/100;
        int final=principle+SI;
        Console.WriteLine("FISED DEposit maturity amount: "+final);
    }
    public static void RewardPoint()
    {
        Console.WriteLine("Enter the credit card spending: ");
        int creditcard=Convert.ToInt32(Console.ReadLine());
        int point=creditcard*100;
        Console.WriteLine("Reward points earned: "+ point);
    }
    public static void BonusEligibility()
    {
        Console.WriteLine("Enter anuual salary: ");
        int annual=Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter yaers of service: ");
        int years=Convert.ToInt32(Console.ReadLine());
        if(annual >= 500000 && years >= 3)
        {
            Console.WriteLine("Employee eligible for bonus");
        }
        else
        {
            Console.WriteLine("not eligible");
        }
    }
    public static void Exit()
    {
        Console.WriteLine("babyeeeeee"); 
  
    }
}
```
