# DAY-09 .NET(C#)

### Problem Statements

```csharp
class InsufficientBalanceException: Exception
{
    public InsufficientBalanceException(string message) : base(message){}

}
class BankAccount
{
    public decimal Balance{get; private set;} =5000;
    public void Withdraw(decimal amount)
    {
        if(amount<=0) throw new ArgumentException("Withdrawl amount must be greater than zero.");
        if (amount > Balance) throw new InsufficientBalanceException("Insufficient balance");
        Balance-=amount;

    }
}
class Program
{
    public static void Main()
    {
        try
        {
            Console.Write("Enter withdrawl amount: ");
            decimal amount=decimal.Parse(Console.ReadLine());
            int serviceCharge=100;
            int divisionCheck=serviceCharge/ int.Parse("0");
            string data=File.ReadAllText("amount.txt");
            //Business Logic
            BankAccount account=new BankAccount();
            account.Withdraw(amount);
            Console.WriteLine("Withdrawl successful");
        }
        catch(FormatException ex)
        {
            LogException(ex);
            Console.WriteLine("invalid input format.");
        }
        catch(DivideByZeroException ex)
        {
            LogException(ex);
            Console.WriteLine("Arthmetic error occured.");
        }
        catch(FileNotFoundException ex)
        {
            LogException(ex);
            Console.WriteLine("File not found.");
        }
        catch(InsufficientBalanceException ex)
        {
            LogException(ex);
            Console.WriteLine(ex.Message);
        }
        catch(Exception ex)
        {
            LogException(ex);
            Console.WriteLine("unexcepted error occured.");
        }
        finally
        {
            Console.WriteLine("Transaction attempt completed.");
        }

    }
    static void LogException(Exception ex)
    {
        File.AppendAllText("error.log",DateTime.Now + " | "+ex.GetType().Name+" | "+Environment.NewLine);
    }
}
```
