# Day 13 – .NET (C#)

### Problem Statement
1- First 5 numbers

### Code
```csharp
class User
{
    public int Id;
    public string Name;

}
class Program
{
    static void Main()
    {
        User user =new User{ Id =1, Name="Alice"};

       using (StreamWriter writer=new StreamWriter("user.txt"))
        {
            writer.WriteLine(user.Id);
            writer.WriteLine(user.Name);
            user.Id=2;
            user.Name="Bob";
            writer.WriteLine(user.Id);
            writer.WriteLine(user.Name);

        }
        using (StreamReader reader =new StreamReader("user.txt"))
        {
            string content;
            // while((content=reader.ReadLine())!=null){
            // Console.WriteLine(content);}
            user.Id=int.Parse(reader.ReadLine());
            user.Name=reader.ReadLine();
        }
        Console.WriteLine($"User Loaded: {user.Id} , {user.Name}");
    }
}
```
### Problem Statement

### Code
```csharp
class Program
{
    static void Main()
    {
        string path ="data.txt";
        string p1 ="data2.txt";
        string p2 ="data3.txt";

        File.WriteAllText(path, "File I/O Example in C#");
        File.WriteAllText(p1, "File I/O Example in C#");
        File.WriteAllText(p2, "File I/O Example in C#");
        File.WriteAllText(p2, "Append or changed");
        //overwritten 
        Console.WriteLine("Data written");
    }
}
```

### Problem Statement

### Code
```csharp
class User
{
    public int Id;
    public string Name;

}
class Program
{
    static void Main()
    {
        User user =new User{ Id =1, Name="Alice"};

       using (StreamWriter writer=new StreamWriter("user.txt"))
        {
            writer.WriteLine(user.Id);
            writer.WriteLine(user.Name);
            user.Id=2;
            user.Name="Bob";
            writer.WriteLine(user.Id);
            writer.WriteLine(user.Name);

        }
        using (StreamReader reader =new StreamReader("user.txt"))
        {
            string content;
            // while((content=reader.ReadLine())!=null){
            // Console.WriteLine(content);}
            user.Id=int.Parse(reader.ReadLine());
            user.Name=reader.ReadLine();
        }
        Console.WriteLine($"User Loaded: {user.Id} , {user.Name}");
    }
}
```

### Problem Statement

### Code
```csharp
class Program
{
    static void Main()
    {
        string ct=File.ReadAllText("data.txt");
        Console.WriteLine("File Content:"+ct);
        Console.WriteLine("File Readed");
        
    }
}
```

### Problem Statement

### Code
```csharp

class Program
{
    static void Main()
    {
        using(StreamWriter writer=new StreamWriter("log.txt"))
        {
            writer.WriteLine("Application Started");
            writer.WriteLine("Processing Data");
            writer.WriteLine("Application ENded");
        }
        using (StreamReader reader=new StreamReader("log.txt"))
        {
            string content;
            while((content=reader.ReadLine())!=null)
            {
                Console.WriteLine(content);
            }
        }
    }
}
```

### Problem Statement

### Code
```csharp
class User
{
    public int Id;
    public string Name;

}
class Program
{
    static void Main()
    {
        User user = new User{Id=1,Name="Bob"};

        using(BinaryWriter writer=new BinaryWriter(File.Open("user.bin", FileMode.Create)))
        {
            writer.Write(user.Id);
            writer.Write(user.Name);
            user.Id=2;
            user.Name="Alice";
            writer.Write(user.Id);
            writer.Write(user.Name);
        }
        Console.WriteLine("Binary Data Saved");

        using (BinaryReader reader=new BinaryReader(File.Open("user.bin",FileMode.Open)))
        {
            Console.WriteLine(reader.ReadInt32());
            Console.WriteLine(reader.ReadString());
        }
    }
}
```
