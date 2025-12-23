# Day 04– .NET (C#)

### Abstract Class & Abstract Methods
Abstract Methods-> methods without implementation<br>
-Instances are abstract class<br>
-Object creation not allowed<br>
-Abstract can't be private<br>
-can have constructors<br>
Concrete Methods-> methods with implementation<br>

### Interfaces
Interface reduce loose coupling<br>
supports multiple inheritence<br>
runtime ploymorphism<br>
If interface has 2 methods, both need to be used<br>
interfaces could not contain fields or instance variables<br>
Types-> Explicit interface(behaviour can be different of common methods of interface) and Implicit Interface(behaviour is same of common methods)<br>

### Problem Statement
Implementing Explicit Interface

```csharp

using System;
interface Print
{
    void Prinnt();
    void Scan();
}
interface Me
{
    void Prinnt();
}
class Lol : Print, Me
{
    void Print.Prinnt()//explicit 
    {
        Console.WriteLine("mufasa");
    }
   void Me.Prinnt()
    {
        Console.WriteLine("lion");//explicit
    }
    public void Scan()
    {
        Console.WriteLine("scanning...");
    }
    public static void Main()
    {
        Lol l=new Lol();
        Print p=new Lol();//1
        p.Prinnt();
        p.Scan();
        Me m=l;   //2
        m.Prinnt();

    }

}
```
-cant call directly , call it by reference<br>

### NameSpace

```csharp
namespace.class object=new namespace.class();
```
-nested Namespace

### Alias
nickname for namespace

```csharp
using Alias=Namespace
```

### Partial class
split single class across multiple files, while complier treat it as one "partial"

### Static Class
-not allow object creation<br>
-impilicitely sealed<br>

### Enumeration
-keyword "enum"<br>
-special value type<br>
-mapping fixed sets of value clearly<br>

```csharp
enum Priority{
      Low=1,
      Medium=2,
      High=3
};
```








