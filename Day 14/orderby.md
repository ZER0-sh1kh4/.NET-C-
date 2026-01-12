# Day 14 – .NET (C#)

### Problem Statement

### Code
```csharp
using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public string Name{get;set;}
    public string Grade{get;set;}
    public int Marks{get;set;}
}

class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>
        {
            new Student { Name = "Aman", Marks = 75 },
            new Student { Name = "Neha", Marks = 55 },
            new Student { Name = "Rohit", Marks = 62 }
        };
        var result = students.Select(s => new
        {
            s.Name,
            s.Marks,
            Grade = s.Marks > 60 ? "Pass" : "Fail"
        }).ToList();
        var orderByMarks = result.OrderBy(r => r.Marks);
        var orderByMarksDesc = result.OrderByDescending(r => r.Marks);
        var sorted=result.OrderBy(r=>r.Name).ThenBy(r=>r.Grade);

        foreach (var r in result)
        {
            Console.WriteLine($"{r.Name} - {r.Grade}");
        }
         foreach (var r in orderByMarks)
        {
            Console.WriteLine($"{r.Name} - {r.Marks} - {r.Grade}");
        }
        foreach (var r in orderByMarksDesc)
        {
            Console.WriteLine($"{r.Name} - {r.Marks} - {r.Grade}");
        }
        foreach (var r in sorted)
        {
            Console.WriteLine($"{r.Name} - {r.Grade}");
        }

        Console.WriteLine(result.GetType());
        Student firstStudent = students.First();
        Console.WriteLine(firstStudent.Name);
        Student res=students.Last(n=>n.Marks<70);
        Console.WriteLine(res.Marks);
        Student res1 = students.Single(s => s.Marks < 60);
        Console.WriteLine(res1.Marks);
    }
}
```
