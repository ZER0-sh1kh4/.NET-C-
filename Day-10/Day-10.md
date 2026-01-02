# Day 10 – .NET (C#)

### Problem Statements

```csharp
class Program
{
    static void Main()
    {
        Console.WriteLine("creating obj");       
        for(int i = 0; i < 5; i++)
        {
            Myclass obj=new Myclass();
        }
        Console.WriteLine("forcing GC");
        GC.Collect();
        GC.WaitForPendingFinalizers();
        Console.WriteLine("GC COMPLETED");
    }
}
class Myclass
{
    ~Myclass()
    {
        Console.WriteLine("finalizer");
    }
}
```

### Problem Statements

```csharp
class Program
{
    static void Main()
    {
        List<Myclass> list = new List<Myclass>();

        for (int i = 0; i < 5; i++)
        {
            list.Add(new Myclass());
        }

        Console.WriteLine("Forcing GC");
        GC.Collect();
        GC.WaitForPendingFinalizers();
        Console.WriteLine("GC completed");
    }
}
class Myclass
{
    ~Myclass()
    {
        Console.WriteLine("finalizer");
    }
}
```

### Problem Statements

```csharp
var student=(ID: 101,NAME: "amit");  //tuple
Console.WriteLine(student.GetType());
(int,string)student1=(101,"amit"); //tuple
Console.WriteLine(student1.GetType());
var obj = new { id = 101, name = "amit" };  //anonymous
Console.WriteLine(obj.GetType());
```

### Problem Statements

```csharp
class Program
{
static (int Sum,int avg,int subt) Calculate(int a,int b)
{
    return (a+b, (a+b)/2, a-b);
}
    static void Main()
    { 
        Console.WriteLine(Calculate(5,4));
        
    }
}
```

### Problem Statements

```csharp
static (bool IsValid, string msg) Validate(string username)
{
    if(string.IsNullOrEmpty(username)) return (false,"username is required");
    return (true,"valid user");
}
var response=Validate("admin");
Console.WriteLine(response.msg);
var person=(Id: 1,Name: "neha");
Console.WriteLine(person.Id);
var(id,name)=person;
Console.WriteLine(id);
Console.WriteLine(id.GetType());
Console.WriteLine(person.GetType());
var(_,name1)=person;  //discard if you want to skip
Console.WriteLine();
```

### Problem Statements

```csharp
class Student
{
    public int Id { get; set; }
    public string Name { get; set; }

    public void Deconstruct(out int id, out string name)
    {
        id = Id;
        name = Name;
    }
    static void Main()
    {
        var s = new Student { Id = 1, Name = "Amit" };
        Console.WriteLine(s.GetType());
        var (sid, sname) = s;
        Console.WriteLine(sid);
        Console.WriteLine(sname);
    }
}
```

### Problem Statements
LINQ

```csharp
class Program
{
    static void Main()
    {
        int[] numbers={1,2,3,4,5,6,7,8,9};
        var evennumber=numbers.Where(n=>n>3).Select(n=>n*2);
        var res=from n in numbers where n>3 select n*2;

        Console.WriteLine(res.GetType());
        Console.Write("even no. are: ");
        foreach(var n in evennumber)
        {
            Console.Write(n+" ");
        }
    }
}
```

### Problem Statements

```csharp
class Student
{
    public string Name { get; set; }
    public string Grade { get; set;}
    public int Marks { get; set;}
}
class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>()
        {
            new Student{Name = "Amit", Marks = 75},
            new Student{Name = "shi", Marks = 55 },
            new Student{Name = "me", Marks = 90 }
        };
        var result = students.OrderBy(s=>s.Name).Select(s => new
        {
            s.Name,
            Grade = s.Marks > 60 ? "Pass" : "Fail"
        }).ToList();
        Console.WriteLine(result.GetType());
        foreach (var r in result)
        {
            Console.WriteLine("name: "+r.Name+" grade: "+r.Grade);
        }
    }
}
```

### Problem Statements

```csharp
class Resource : IDisposable
{
    public Resource()
    {
        Console.WriteLine("acquired");
    }
    public void Dispose()
    {
        Console.WriteLine("released");
    }
}
class Program
{
    static void Main()
    {
        using (Resource handler=new Resource())
        {
            Console.WriteLine("using resource");
        }
        Console.WriteLine("endd");
    }
}
```

### Problem Statements

```csharp
class Program
{
    static void Main()
    {
        Console.WriteLine($"Total Memory Before GC: {GC.GetTotalMemory(false)} bytes");

        for (int i = 0; i < 10000; i++)
        {
            object obj = new object(); // Gen 0 allocation
        }

        Console.WriteLine($"Total Memory After Object Creation: {GC.GetTotalMemory(false)} bytes");

        GC.Collect(); 
        GC.WaitForPendingFinalizers();

        Console.WriteLine($"Total Memory After GC: {GC.GetTotalMemory(false)} bytes");
        Console.WriteLine($"Generation of a new object: {GC.GetGeneration(new object())}");
    }
   
}
```




