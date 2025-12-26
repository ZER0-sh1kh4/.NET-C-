# Day 06 – .NET (C#)

### Problem Statement

```csharp
struct PriceSnapshot
{
    public string symbol;
    public int Price;
}
abstract class Trade{
    public int tradeID;
    public string symbol;
    public int quantity;
    public abstract double CalculateTrade();
    public override string ToString()
    {
        return "trade: "+tradeID+" ,symbol: "+symbol+" ,quantity: "+quantity;
    }

}
class EquityTrade : Trade
{
    public double?MarketPrice;
    public override double CalculateTrade()
    {
        double res=MarketPrice??0;
        return quantity*res;
    }
    public override string ToString()
    {
        return base.ToString() + " ,Market price: "+MarketPrice;
    }
}
class TradeRepository<T> where T : Trade
{
    List<T> list=new List<T>();
   // int TotalTrade=0;
    public void AddTrade(T trade)
    {
        list.Add(trade);
        TradeAnalytics.TotalTrade++;
    }
    public void ShowTrade()
    {
        foreach(T trade in list)
        {
            Console.WriteLine(trade);
        }

    }
    
}
static class TradeAnalytics
    {
       public static int TotalTrade=0;
       public static void ShowAnalytics()
    {
        Console.WriteLine("total trades in list: "+TotalTrade);
    }

}
static class Extensions
{
    public static double BrokerageCal(this double amount)
    {
        return amount*0.1;
    }
    public static double TaxCal(this double amount)
    {
        return amount*0.18;
    }
}
class Process
{
    public void TradeProcessing(Trade trade)
    {
        if(trade is EquityTrade eT)
        {
            Console.WriteLine("Pattern matching");
        }
    }
}
class Program
{
    public static void Main()
    {
        PriceSnapshot price=new PriceSnapshot
        {
            symbol="aapl",
            Price=234
        };
        Console.WriteLine("symbol: "+price.symbol);
        Console.WriteLine("price: "+price.Price);
        Process pro =new Process();
        EquityTrade tr1=new EquityTrade
        {
            tradeID=1,
            symbol="aapl",
            quantity=10,
            MarketPrice=234
        };
        pro.TradeProcessing(tr1);
        Console.WriteLine(tr1.ToString());
        Console.WriteLine("calculated trade value: "+tr1.CalculateTrade());

        EquityTrade tr2=new EquityTrade
        {
            tradeID=1,
            symbol="aapl",
            quantity=10,
            MarketPrice=null
        };
        pro.TradeProcessing(tr2);
        Console.WriteLine(tr2.ToString());
        Console.WriteLine("calculated trade value: "+tr2.CalculateTrade());

        TradeRepository<EquityTrade> list=new TradeRepository<EquityTrade>();
        list.AddTrade(tr1);
        list.AddTrade(tr2);
        list.ShowTrade();
        TradeAnalytics.ShowAnalytics();

        double tradevalue=tr1.CalculateTrade();
        Console.WriteLine("Trade value: "+tradevalue);
        double broker=tradevalue.BrokerageCal();
        Console.WriteLine("Broker charge: "+broker);
        double tax=tradevalue.TaxCal();
        Console.WriteLine("Tax deduction: "+tax);

        Object boxed=TradeAnalytics.TotalTrade;
        int unboxed=(int)boxed;
        Console.WriteLine("Boxed result for trade count: "+boxed);
        Console.WriteLine("Unoxed result for trade count: "+unboxed);

    }
}
```
