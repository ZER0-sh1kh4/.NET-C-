# Day 06 – .NET (C#)

### Problem Statement

```csharp
struct StockPrice
{
    public string symbol;
    public int Price;
}
class Trade
{
    public int TradeId;
    public string symbol;
   public int quantity;
}
class Program
{
    public static void Main()
    {
        StockPrice st=new StockPrice
        {
            symbol="aapl",
            Price=250
        };
        StockPrice copy=st;
        copy.Price=155;
        Trade t=new Trade
        {
            TradeId=23,
            symbol="aa",
            quantity=300
        };
        Trade coptt=t;
        coptt.quantity=400;
        Console.WriteLine("original: "+st.Price+" COPIED IS : "+copy.Price);
        Console.WriteLine("Original is : "+t.quantity+" copied is: "+coptt.quantity);

    }
}
```
-because of memory allocation ..class operates by refrence so the memeory address of new and copied is used<br>
-struct operates by value so memory address of both values are different

### Problem Statement

```csharp
class Portfolio
{
    public string Name;

    public override bool Equals(object obj)
    {
        Portfolio p = obj as Portfolio;
        return p != null && p.Name == Name;
    }
    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}

class Program
{
    static void Main()
    {
        Portfolio p1 = new Portfolio { Name = "Growth" };
        Portfolio p2 = new Portfolio { Name = "Growth" };

        Console.WriteLine(p1.Equals(p2));
        Console.WriteLine(p1.GetHashCode());
        Console.WriteLine(p2.GetHashCode());
    }
}
```

### Problem Statement

```csharp
class Trade { }

class EquityTrade : Trade { }

class Program
{
    static void Main()
    {
        Trade t = new EquityTrade();
        Console.WriteLine(t.GetType());  //beacsuse trade is by refrence   so result id EquityTrade
        Trade t2=t;
        Trade t3=new EquityTrade();
        Console.WriteLine(ReferenceEquals(t,t2));
        Console.WriteLine(ReferenceEquals(t2,t3));

    }
}

class Cal
{
    public  T Calculate<T> (T a ,T b)
    {
        return a;
    }

}
class Program
{
    public static void Main(){
    Cal cal=new Cal();
    int res=cal.Calculate(10,20);
    Console.WriteLine(res);
    Double res2=cal.Calculate(10.30,40.67);
    Console.WriteLine(res2);
    }

}
```
### Problem Statement

```csharp
class Trade
{
    public int TradeId;
    public string Symbol;
}

class Program
{
    public static void Main()
    {
        List<T> list=new List<T>();
        list.Add();
        list.Add();
        foreach (int n in list)
        {
            Console.WriteLine(n);
        }


    }
}
```



