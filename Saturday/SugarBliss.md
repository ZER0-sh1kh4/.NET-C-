# DAY-14(Saturday) .NET(C#)

### Problem Statement

```csharp
using System;
using System.Reflection;

class Chocolate
{
    public string Flavour{get; set;}
    public int Quantity{get; set;}
    public int PricePerUnit{get; set;}
    public double TotalPrice{get; set;}
    public double DiscountedPrice{get;set;}

    public bool ValidateChocolateFlavour()
    {
        if(Flavour=="Dark" || Flavour=="Milk" || Flavour=="White") return true;
        else return false;
    }
  
}
class Program
{
    public static Chocolate CalculateDiscountedPrice(Chocolate chocolate)
    {
        double DiscountedPercentage=0;
        
        if (chocolate.Flavour == "Dark")
        {
            DiscountedPercentage=18;
        }
        else if (chocolate.Flavour == "Milk")
        {
            DiscountedPercentage=12;
        }
        else
        {
            DiscountedPercentage=6;
        }  
        chocolate.TotalPrice=chocolate.Quantity*chocolate.PricePerUnit;
        chocolate.DiscountedPrice=chocolate.TotalPrice-(chocolate.TotalPrice*DiscountedPercentage/100); 
        return chocolate;
    }
    public static void Main()
    {
        Chocolate c=new Chocolate();
        Console.Write("Enter the flavour: ");
        c.Flavour=Console.ReadLine();
        if (!c.ValidateChocolateFlavour()){
        Console.WriteLine("Invalid flavour");
        return;
        }
        Console.Write("Enter the quantity: ");
        c.Quantity=Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter the price per unit: ");
        c.PricePerUnit=Convert.ToInt32(Console.ReadLine());
        c=CalculateDiscountedPrice(c);
        Console.WriteLine("Flavour : " +c.Flavour);
        Console.WriteLine("Quantity : " +c.Quantity);
        Console.WriteLine("Price Per Unit : " +c.PricePerUnit);
        Console.WriteLine("Total Price : " + c.TotalPrice);
        Console.WriteLine("Discounted Price : " + c.DiscountedPrice);
    }
}
```
