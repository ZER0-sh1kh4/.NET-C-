# Day 09 – .NET (C#)

### Problem Statements

```csharp
class Program
{
    public static void Main()
    {
        int a = 10;
        int b = 0;

        try
        {
            int res = a / b;
        }
        catch (Exception e)
        {
            Console.WriteLine("ERR: " + e.Message);
        }
    }
}
```

### Problem Statements

```csharp
try
{
    try
    {
        File.ReadAllText("transaction.txt");
    }
    catch (IOException ioEx)
    {
        throw new ApplicationException(
            "Unable to load transaction data",
            ioEx
        ); //exception wrapping
    }
}
catch (Exception ex)
{
    Console.WriteLine("Message: " + ex.Message);
    Console.WriteLine("Root Cause: " + ex.InnerException.Message);
}
```

### Problem Statements

```csharp

class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException(string message) : base(message) { }
}
public class BankAccount
{
    public decimal Balance { get; private set; }

    public BankAccount(decimal initialBalance)
    {
        if (initialBalance < 0)
            throw new ArgumentException(
                "Initial balance cannot be negative",
                nameof(initialBalance));

        Balance = initialBalance;
    }
    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException(
                "Withdrawal amount must be greater than zero",
                nameof(amount));

        if (amount > Balance)
            throw new InsufficientBalanceException(
                $"Cannot withdraw {amount:C}. Available balance: {Balance:C}");

        Balance -= amount;
    }
    public static void Main()
    {
        BankAccount bank=new BankAccount(5000);
        bank.Withdraw(-100);
         Console.WriteLine("Remaining balance: " + bank.Balance);
    }
}
```
### Problem Statement

```csharp
class Program
{
    public static void Main()
    {
        FileStream file=null;
        try
        {
            file=new FileStream("data.txt",FileMode.Open);
            int data=file.ReadByte();
            Console.WriteLine("byte value: "+data);

        }catch(FileNotFoundException ex)
        {
            Console.WriteLine("File not found: "+ex.Message);

        }
        finally
        {
            if (file != null)
            {
                file.Close();
                Console.WriteLine("File STREAM CLOSED IN FINALLY CLOSED");
            }
        }
    }
}
```

### Problem Statements
REGEX

```csharp
string sentence="abc123";
string pattern=@"\d";//true
```
```csharp
string sentence="123_123";
string pattern=@"\d";//true
```
```csharp
string sentence="shikha123456";
string pattern=@"\d+";
string sentence="Amount=5000";
//string pattern=@"(\d{4}-(\d{2})-(\d{2}))";
// string pattern=@"Amount=(?<value>\d+)";
string sent1="2000-01-02";
string sent2="02-03-3000";
string pattern2 = @"(?<year>\d{4})-(?<month>\d{2})-(?<date>\d{2})";
// bool res=Regex.IsMatch(sentence,pattern);
// Console.WriteLine(res);
Match result=Regex.Match(sent1,pattern2);
Console.WriteLine("sent1 yaer: "+result.Groups["year"].Value);
Console.WriteLine("sent1 month: "+result.Groups["month"].Value);
Console.WriteLine("val"+result.Groups[1].Value);
Match result2=Regex.Match(sent2,pattern2);
Console.WriteLine("sent2 yaer: "+result2.Groups["year"].Value);
Console.WriteLine("sent2 month: "+result2.Groups["month"].Value);
// Console.WriteLine("match: "+result);
MatchCollection m=Regex.Matches(sent1,pattern2);
foreach(Match i in m){ Console.WriteLine("matches:"+i.Value);}
MatchCollection m1=Regex.Matches(sent2,pattern2);
foreach(Match i in m1){ Console.WriteLine("matches:"+i.Value);}
```
```csharp
string resi=Regex.Replace("ID123",@"\d",@"\*");
Console.WriteLine(resi);
string[] s=Regex.Split("one,two;three",@"[,;]");
foreach (string i in s)
{
    Console.WriteLine(i);
}
```
```csharp
string Sentence = "Amount=5000";
string Pattern = @"Amount=(?<value>\d+)";

Match m = Regex.Match(Sentence, Pattern);
Console.WriteLine(m.Groups["value"].Value);
```

### Problem Statements

```csharp
Pattern = @"(?<year>\d{4})-(?<month>\d{2})-(?<date>\d{2})";

string input = "1992-02-23, 1990-01-01";

Match m1 = Regex.Match(input, Pattern);
MatchCollection m2 = Regex.Matches(input, Pattern);
        foreach (Match x in m2)
        {
            Console.WriteLine(x.Value);
        }

Console.WriteLine(m1.Groups["year"].Value);
Console.WriteLine(m1.Groups["month"].Value);
```
```csharp
string input1="grapple";
string pattern=@"..a....";
MatchCollection m=Regex.Matches(input1,pattern);
foreach(Match i in m)
{
    Console.WriteLine(i.Value);
}
```
### Problem Statements

```csharp
List<string> Emails = new List<string>
{
    "john.doe@gmail.com",
    "alice_123@yahoo.in",
    "mark.smith@company.com",
    "support-abc@banking.co.in",
    "user.nametag@domain.org",
  "john.doe@gmail",          // Missing domain extension
    "alice@@yahoo.com",        // Double @
    "mark.smith@.com",         // Domain missing name
    "support@banking..com",    // Double dot in domain
    "user name@gmail.com",     // Space not allowed
    "@domain.com",             // Missing username
    "admin@domain",            // No top-level domain
    "info@domain,com",         // Comma instead of dot
    "finance#dept@corp.com",   // Invalid character #
    "plainaddress" ,            // Missing @ and domain
    "sdf@gmail.edu.au"
};
string pattern = @"^[\w.-]+@[\w.-]+(\.\w{2,})+\b";

foreach (string email in Emails)
        {
            if (Regex.IsMatch(email, pattern))
            {
                Console.WriteLine(email + ": VALID");
            }
}
```
