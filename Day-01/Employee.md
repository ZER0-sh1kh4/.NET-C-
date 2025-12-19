# Day 01 – .NET (C#)

### Problem Statement
Employee Details

### Code
```csharp
namespace HelloWorld
{
class Employee
{
    int Id;
    string Name;
    string Department;
    float Salary;
    char Gender;
    public void AceeptDetails()
    {
        Console.WriteLine("Enter details");
        Console.WriteLine("Enter the employee id: ");
        Id=Convert.ToInt32(Console.ReadLine());
        //Id=int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Name: ");
        Name=Console.ReadLine();
        Console.WriteLine("Enter Department: ");
        Department=Console.ReadLine();
        Console.WriteLine("Enter Salary: ");
        Salary=Convert.ToSingle(Console.ReadLine());
        Console.WriteLine("Enter Gender: ");
        Gender=Convert.ToChar(Console.ReadLine());
    }
    public void Display()
    {
        Console.WriteLine("Employee detials are");
        Console.WriteLine($"Employee I d is {Id}");
        Console.WriteLine($"Employee Name is {Name}");
        Console.WriteLine($"Employee Department is {Department}");
        Console.WriteLine($"Employee Slary is {Salary}");
        Console.WriteLine($"Employee Gneder is {Gender}");
    }
}
}
```
Main Function

### Code
```csharp
using System;

namespace HelloWorld
{
    class Program
    {
        static void Main()
        {
            Employee emp = new Employee();

            emp.AceeptDetails();
            emp.Display();
        }
    }
}
```

