# Day 03 – .NET (C#)

### Problem Statement

```csharp
class MathOps
{
    public int Add(int a, int b)
    {
        return a+b;
    }
    public static double Add(double a, double b=10.0)
    {
        return a+b;
    }
}
class Program
{
    public static void Main()
    {
        MathOps math=new MathOps();
        Console.WriteLine(math.Add(5, 6));
        Console.WriteLine(MathOps.Add(2.3));
    }
}
```

### Problem Statement

```csharp
class BankAccount
{
    public int AccountNumber;
    public double Balance;
}
class Employee
{
    public string Name;
    public double Salary;
    public void DisplayDetails()
    {
        Console.WriteLine(Name +" earns " + Salary);       

    }
}
class Program
{
    public static void Main()
    {
        BankAccount acc1=new BankAccount();
        acc1.AccountNumber=101;
        acc1.Balance=500;
        Console.WriteLine("Account Number "+ acc1.AccountNumber);
        Console.WriteLine("Balance: "+acc1.Balance);
        Employee emp1=new Employee();
        emp1.Name="shikha";
        emp1.Salary=74698379;
        emp1.DisplayDetails();

    }
}
```

### Problem Statement

```csharp
class Wallet
{
    private double money;
    public void AddMoney(double amount)
    {
        money += amount;
    }
    public double GetBalance()
    {
        return money;
    }
}
class Program
{
    static void Main()
    {
        Wallet myWallet = new Wallet();
        myWallet.AddMoney(1000);
        Console.WriteLine("Wallet Balance:" + myWallet.GetBalance());
    }
}
```

### Problem Statement

```csharp
string name="shikha";
foreach(char i in name)
{
    Console.Write(i);
}
```
### Problem Statement

```csharp
class Params
{
    public int Sum(/*int x, int a=10,*/params int[] arr)
    {
        int total=0;
        foreach(int i in arr)
        {
            total+=i;
        }
        return total;
    }
}
class P
{
    public static void Main(){
    Params p=new Params();
    int res=p.Sum(10,101,101,10,10);
    Console.WriteLine(res);
    }
}
```
-cant use ref with parmas and also in, out<br>

### Problem Statement

```csharp
class P
{
    public int x=10;
    public void Increaseby10(ref int a)
    {
        a=a+10;
    }
}
class Program
{
    public static void Main()
    {
        P p =new P();
        p.Increaseby10(ref p.x);
        Console.WriteLine(p.x);

    }
}
```

### Problem Statement

```csharp
class Cal
{
    public static void Divide(int a, int b, out int qu,out int re)
    {
        qu=a/b;
        re=a%b;
    }
}
class Program
{ 
    public static void Main(){
    int q,r;
    Cal.Divide(10,3,out q,out r);
    Console.WriteLine("Quoitent: "+q);
    Console.WriteLine("REainder: "+r);
    }

}
```

### Problem Statement

```csharp
class Print
{
    public void Printy(int x=10){
    Console.WriteLine(x);
    }
}
class Program
{
    public static void Main(){
    Print p=new Print();
    p.Printy(50);
    p.Printy(60);
    Console.WriteLine();
    }
}
```

### Problem Statement

```csharp
class Pogram
{
   public void Process()
{
    string status = "Processing...";

    void PrintMsg()
    {
        Console.WriteLine(status);
    }

    PrintMsg();

}
    public static void Main()
    {
        Pogram p=new Pogram();
       p.Process();
    }
}
```

### Problem Statement

```csharp
class Cal
{
    public void Calculator()
    {

        int ADD(int a, int b){
            int res=a+b;
            return res;
        }
        int SUB(int a,int b)
        {
            int res=a-b;
            return res;
        }
        Console.WriteLine(ADD(10,20));
        Console.WriteLine(SUB(10,20));
    }
    public static void Main()
    {
        Cal c = new Cal();
        c.Calculator();
    }          
}
```

### Problem Statement

```csharp
class Lamda{
public void Example()
{
    int Square(int x)
    {
        return x * x;
    }
    Func<int, int> squareLambda = x => x * x;

    Console.WriteLine(Square(4));
    Console.WriteLine(squareLambda(4));
}
public static void Main()
    {
        Lamda l=new Lamda();
        l.Example();
    }
}
```

### Problem Statement

```csharp
class Test
{
    static int number = 5;

    static void Calculate()
    {
        static int Square(int x)
        {
            return x * x;
        }

        Console.WriteLine(Square(number));
    }
    static void Main()
    {
        Console.WriteLine(number);
    }
}
```

