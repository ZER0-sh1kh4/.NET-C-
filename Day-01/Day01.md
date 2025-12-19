# Day 01 – Introduction to .NET and C#

### Problem Statements
1-Write a C# program to print **Hello World** on the console.

### Code
```csharp
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Hello World");
    }
}
```
2-Read Integer from User

### Code
```csharp
class Program
{
    static void Main()
    {
        int a;
        Console.WriteLine("Enter a number:");
        a = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"Number is: {a}");
    }
}
```
3- Read Float from User

### Code
```csharp
class Program
{
    static void Main()
    {
        float a=0.0f;
        Console.WriteLine("Enter a float:");
        a = Convert.ToSingle(Console.ReadLine());
        Console.WriteLine($"Float is: {a}");
    }
}
```
4- Read and Display String

### Code
```csharp
class Program
{
    static void Main()
    {
        string str=string.Empty;
        Console.WriteLine("enter a string :");
        str=Console.ReadLine();
        Console.WriteLine($"string is : {str}");
    }
}
```
5-Area of Circle

### Code
```csharp
class Program
{
    static void Main()
    {
        float area=0.0f;
        float radius=0;
        Console.WriteLine("Enter the radius: ");
        radius=Convert.ToSingle(Console.ReadLine());
        area=(22/7)*radius*radius;
        Console.WriteLine($"raisus id: {radius} and area is : {area}");
    }
}
```
6- Even or Odd

### Code
```csharp
class Program
{
    static void Main()
    {
        int a=0;
        Console.WriteLine("enter a no.: ");
        a=Convert.ToInt32(Console.ReadLine());
        if (a % 2 == 0)
        {
            Console.WriteLine($"number {a} is even");
        }
        else
        {
            Console.WriteLine($"Number {a} is odd");
        }
    }
}
```
7- Greatest of 2 numbers

### Code
```csharp
class Program
{
    static void Main()
    {
        int a=0;
        int b=0;
        Console.WriteLine("enter fisrst no : ");
        a=Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("enter second no : ");
        b=Convert.ToInt32(Console.ReadLine());
        if (a > b)
        {
            Console.WriteLine($"number {a} is greater");
        }
        else
        {
            Console.WriteLine($"number {b} is greater");
        }
    }
}
```
8- Positive , Negative or Zero

### Code
```csharp
class Program
{
    static void Main()
    {
        int a=0;
         Console.WriteLine("enter the no. :");
         a=Convert.ToInt32(Console.ReadLine());
        if (a > 0)
        {
            Console.WriteLine($"number {a} is positive");
        }
        else if (a < 0)
        {
            Console.WriteLine($"number {a} is negative");
        }
        else
        {
            Console.WriteLine($"number {a} is 0");
        }

    }
}
```
9- Greatest of 3 numbers

### Code
```csharp
class Program
{
    static void Main()
    {
       int a=0;
        int b=0;
        int c=0;
        Console.WriteLine("enter the first number: ");
        a=Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("enter the second number: ");
        b=Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("enter the third number: ");
        c=Convert.ToInt32(Console.ReadLine());
        if(a>b && a > c)
        {
            Console.WriteLine($"Number {a} is greatest");
        }
        else if( b>c && b > a)
        {
            Console.WriteLine($"Number {b} is greatest");
           
        }
        else
        {
            Console.WriteLine($"Number {c} is greatest");

        }
    }
}
```
10- Vowel or Consonant

### Code
```csharp
class Program
{
    static void Main()
    {
        char ch;
        Console.WriteLine("enter a char: ");
        ch=Convert.ToChar(Console.ReadLine());
        switch(ch){
        case 'a':
        Console.WriteLine($"char {ch} is vowel");
        break;
        case 'e':
        Console.WriteLine($"char {ch} is vowel");
        break;
        case 'i':
        Console.WriteLine($"char {ch} is vowel");
        break;
        case 'o':
        Console.WriteLine($"char {ch} is vowel");
        break;
        case 'u':
        Console.WriteLine($"char {ch} is vowel");
        break;
        case 'A':
        Console.WriteLine($"char {ch} is vowel");
        break;
        case 'E':
        Console.WriteLine($"char {ch} is vowel");
        break;
        case 'I':
        Console.WriteLine($"char {ch} is vowel");
        break;
        case 'O':
        Console.WriteLine($"char {ch} is vowel");
        break;
        case 'U':
        Console.WriteLine($"char {ch} is vowel");
        break;
        default:
        Console.WriteLine($"char {ch} is consonent");
        break;

        }
    }
}
```
11- Covert String into Uppercase and print Length

### Code
```csharp
class Program
{
    static void Main()
    {
        string str=string.Empty;
        int length=0;
        Console.WriteLine("enter the string: ");
        str=Console.ReadLine();
        str=str.ToUpper();
        length=str.Length;
        Console.WriteLine($"Uppercase string: {str}");
        Console.WriteLine($"string length: {length} ");
    }
}
```
12- Swap numbers without temporary variable

### Code
```csharp
class Program
{
    static void Main()
    {
        int a;
        int b;
        Console.WriteLine("enter a value: ");
        a=Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("enter b value: ");
        b=Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($" a={a} and b={b}");
        Console.WriteLine($" a={(a+b)-a} and b={(a+b)-b}");
    }
}
```

