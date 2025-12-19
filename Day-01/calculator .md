# Day 01 – .NET (C#)

### Problem Statement
Simple Calculator

### Code
```csharp
namespace Cal
{
    class Calculator
    {
        int a;
        int b;
        int res;
        public void ADD()
        {
            Console.WriteLine("Enter first value: ");
            a=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter second value: ");
            b=Convert.ToInt32(Console.ReadLine());
            res=a+b;
            Console.WriteLine($"Sum is: {res}");        
        }
        public void SUB()
        {
            Console.WriteLine("Enter first value: ");
            a=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter second value: ");
            b=Convert.ToInt32(Console.ReadLine());
            res=a-b;
            Console.WriteLine($"Subtraction is: {res}");           
        }
        public void MUL()
        {
            Console.WriteLine("Enter first value: ");
            a=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter second value: ");
            b=Convert.ToInt32(Console.ReadLine());
            res=a*b;
            Console.WriteLine($"Multipliacation is: {res}");            
        }
        public void DIV()
        {
            Console.WriteLine("Enter first value: ");
            a=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter second value: ");
            b=Convert.ToInt32(Console.ReadLine());
            res=a/b;
            Console.WriteLine($"Division is: {res}");
        }
        public void Remainder()
        {
            Console.WriteLine("Enter first value: ");
            a=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter second value: ");
            b=Convert.ToInt32(Console.ReadLine());
            res=a%b;
            Console.WriteLine($"Division is: {res}");         
        }
    }
}
```
Main function

### Code
```csharp
using System;

namespace Cal
{
    class Program
    {
        static void Main()
        {
            Calculator cal = new Calculator();

            cal.ADD();
            cal.SUB();
            cal.MUL();
            cal.DIV();
            cal.Remainder();
        }
    }
}
```
