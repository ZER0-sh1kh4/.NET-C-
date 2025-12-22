# Day 04 – .NET (C#)

### Problem Statement

```csharp
using System;

class Bank
{
    Bank()
    {
        Console.WriteLine("lol");
    }
    
    class FixedDeposit : Bank
    {
        int time;
        double amount;
        public FixedDeposit() : base()   
        {
            Console.WriteLine("constructor called");
        }
    }

    
    public static void Main()
    {
        FixedDeposit f=new FixedDeposit();
        Console.WriteLine(f);
    }
}
```

### Problem Statement

```csharp
using System;

class Parent
{
    int x;

    public Parent(int x)
    {
        this.x = x;
        Console.WriteLine("Parent");
    }
}

class Child : Parent
{
    int y;

    public Child(int x, int y) : base(x)
    {
        this.y = y;
        Console.WriteLine("Child");
    }
}

class Program
{
    public static void Main()
    {
        Child c = new Child(10, 20);
    }
}
```
-void not allowed<br>
-multiple  constructors are allowed<br>
-all access modifiers applied<br>
-inheritence of constructor is not allowed<br>
-you can call the constructor of parent class  keyword call as base<br>
-An instance constructor runs every time an object is created using new.<br>
-A static constructor runs only once, automatically, before the first object or static member is used.<br>


### Problem Statement

```csharp
using System;

class Bank
{
    public Bank()
    {
        Console.WriteLine("Bank constructor called");
    }

    static void Main()
    {
        Bank b = new Bank();
    }
}
```
-you can create multiple objects<br>
-that doesnt mean static will run again, cause static constryctor doesnt belong to the constructor only to class, it runs when class is laoded in the memory

### Problem Statement
Overloading Constructors

```csharp
using System;

class Product
{
    public string Name;
    public int Price;

   public Product() { }

    public Product(string name, int price)
    {
        Name = name;
        Price = price;
    }


public static void Main()
{
    Product p = new Product
{
    Name = "Laptop",
    Price = 50000
};
}
}
```
-it require default constructor<br>
-not private members, it should be public members

### Problem Statement
Properties of C# (getter, setter)

```csharp
using System;

class Student
{
        string name;
        int age;
        int marks;

        public string Name
    {
        get{return name;}
        set{
            if(value !=" "){
                name=value;
            }
        }
    }
    public int Age{
        get{return age;}
        set{
            if(value>0){
                age=value;
            }
        }
    }
    public int Marks
{
    get{return marks;}
    set{
        if(value>=0 && value<=100)
        {
            marks=value;
        }
    }
}
}
class P
{
    public static void Main()
    {
        Student s=new Student();
        s.Name="mufasa";
        s.Age=22;
        s.Marks=45;
        Console.WriteLine(s.Name);
        Console.WriteLine(s.Age);
        Console.WriteLine(s.Marks);

    }
}
```

### Problem Statement


```csharp
using System;

class Student
{
        string name;
        int age;
        int marks;
        int studentID;
        string password;

        public string Name
    {
        get{return name;}
        set{
            if(value !=" "){
                name=value;
            }
        }
    }
    public int Age{
        get{return age;}
        set{
            if(value>0){
                age=value;
            }
        }
    }
    public int Marks
{
    get{return marks;}
    set{
        if(value>=0 && value<=100)
        {
            marks=value;
        }
    }

}
    public int StudentID
    {
       get{return studentID;} 
       set{studentID=value;}
    } 
    public string Password//write-only
    {
        get{return password;}
        set
        {
            if (value.Length >= 6)
            {
                password=value;
            }
        }
    }
    public string Result//read only
    {
        get
        {
            if (marks >= 40)
            {
                return "Pass";
            }
            else
            {
                return "Fail";
            }
        }
    }
}
class P
{
    public static void Main()
    {
        Student s=new Student();
        s.Name="mufasa";
        s.Age=22;
        s.Marks=35;
        s.Password="7638";
        s.StudentID=56;
        Console.WriteLine(s.Name);
        Console.WriteLine(s.Age);
        Console.WriteLine(s.Marks);
        Console.WriteLine(s.Password);
        Console.WriteLine(s.Result);
        Console.WriteLine(s.StudentID);
    }
}
```
-get fun should be public<br>
-types readonly and writeonly<br>
-use init(instead of set)-> init cant be changed<br>
-expression-bodied property use "=>"<br>

### Problem Statement

```csharp
using System;

class Student
{
    int marks;
    public int regNo{get;private set;}
    public int year{get;init;}
    public int Marks
{
    get{return marks;}
    set{
        if(value>=0 && value<=100)
        {
            marks=value;
        }
    }
}
   public double Percentage => (marks/100.0)*100;

    public Student(int reNo)
{
    regNo=reNo;
}
}
class P{
public static void Main()
{
    Student s=new Student(5000)
    {
        year=2023
    };
    s.Marks=45;
    Console.WriteLine(s.Marks);
    Console.WriteLine(s.Percentage);
    Console.WriteLine(s.regNo);
    Console.WriteLine(s.year);
}
 }
```
-obj[index]=indexer<br>

### Problem Statement

```csharp
using System;

class Library
{
    private Dictionary<int,string> books=new Dictionary<int, string>();
    public string this[int id]
    {
        get{return books[id];}
        set{books[id]=value;}
    }
    public int this[string name]
    {
        get
        {
            foreach (var book in books)
            {
                if(book.Value==name) return book.Key;
            }
            return -1;
        }
    }
}
class P
{
    public static void Main()
    {
        Library l =new Library();
        l[1]="one";
        l[2]="two";
        l[3]="three";
        Console.WriteLine(l[1]);
        Console.WriteLine(l["two"]);
            }
}
```
### Problem Statement
Inheritance

```csharp
using System;
class Person
{
    public string Name;
    public Person(string name)
    {
        Name = name;
    }
}

class Student : Person
{
    public int RollNo;

    public Student(string name, int roll) : base(name)
    {
        RollNo = roll;
    }
}
class Program
{
    public static void Main()
    {
        Student s=new Student("mufasa",20);
        Console.WriteLine(s.Name);
        Console.WriteLine(s.RollNo);

    }
}
```
-types of inheritance<br>
-single (1 parent 1child)<br>
-multi-level(1 parnet then child then grandchild....)<br>
-no multiple inheritence but possible with help of instances<br>
-hierarchical inheritance(1 parent , multiple child)<br>
-Diamond problem (last child doesnt know whose function to inhert)->solution instances<br>

### Problem Statement
Instances

```csharp
using System;

interface IPrintable
{
    void Print();
}
interface IScannable
{
    void Scan();
}
class Machine : IPrintable, IScannable
{
    public void Print()
    {
        Console.WriteLine("Printing");
    }
    public void Scan()
    {
        Console.WriteLine("Scanning");
    }
}
class Program
{
    public static void Main(){
    Machine m=new Machine();
    m.Print();
    m.Scan();
    }

}
```
-method overridding provides runtime polymorphism<br>
-polymorphism (use virtual in parent and override in child class)<br>
-virtual tells child that it can be override ,override is the keyword that used by child class to override<br>

### Problem Statement
method overriding

```csharp
using System;

class Animal
{
    public virtual void Sound()
    {
        Console.WriteLine("Animal makes sound");
    }
}
class Dog : Animal
{
    public override void Sound()
    {
        base.Sound();//to call the parent sound() method 
        Console.WriteLine("Dog barks");
    }
}
class P
{
    public static void Main(){
    Dog d=new Dog();
    d.Sound();
    }
}
```
-parent constructor runs fast always<br>
-Inheritance IS-A relation  | Composition HAS-A relation<br>
-sealed class and methods prevents inheritence---it tells complier this function cant be changed further so cant be inherited<br>

### Problem Statement


```csharp
using System;

class Parent
{
    public virtual void Show()
    {
        Console.WriteLine("Parent Show");
    }
}

class Child : Parent
{
    public sealed override void Show()
    {
        Console.WriteLine("Child Show");
    }
}
class P
{
    public static void Main()
    {
        Child c=new Child();
        c.Show();
    }
}
```
### Problem Statement
Composition 

```csharp
using System;

class Engine
{
    public void Start()
    {
        Console.WriteLine("Engine started");
    }
}
class Car
{
    Engine engine = new Engine();   // composition
    public void Drive()
    {
        engine.Start();
        Console.WriteLine("Car is moving");
    }
}

class Program
{
    static void Main()
    {
        Car c = new Car();
        c.Drive();
    }
}
```
-method hiding vs method overloading  similarity ->same name method<br>
-method hiding used "new" keyword  instaed of virtual and ovreride you can use new<br>
-it creates a new separate method<br>
-when to use- you dont want to change base method<br>
-static methods cant be overriden but can be hidden<br>
-sealed methods be hidden not overriden<br>


