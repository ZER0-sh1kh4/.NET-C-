# Day 13 – .NET (C#)

### Problem Statement

### Code
```csharp
class Program
{
    static void Main()
    {
        FileInfo file=new FileInfo("sample.txt");
        if (!file.Exists)
        {
            using(StreamWriter writer = file.CreateText())  //creates file and add writer along withit 
            {
                writer.WriteLine("data");
            }
        }
        Console.WriteLine("file name: "+file.Name);
        Console.WriteLine("file size: "+file.Length+" bytes");
        Console.WriteLine("Created on: "+file.CreationTime);

        Directory.CreateDirectory("logs");
        if (Directory.Exists("logs"))
        {
            Console.WriteLine("logs are");
        }


    }
}
```

### Problem Statement

### Code
```csharp
class Program()
{
    static void Main()
    {
        DirectoryInfo d=new DirectoryInfo("loaf");
        if (!d.Exists)
        {
            d.Create();
        }
        Console.WriteLine("file name: "+d.Name);
        Console.WriteLine("Created on: "+d.CreationTime);
        Console.WriteLine("full path: "+d.FullName);
    }
}
```

### Problem Statement

### Code
```csharp
[Serializable]
public class User
{
    public int ID{get; set;}
    public string Name{get; set;}
}
class Program
{
    static void Main()
    {
        User u=new User{ID=2, Name ="alice"};

        // string json=JsonSerializer.Serialize(u);
        // File.WriteAllText("u.json",json);
        // Console.WriteLine("suceess");
        XmlSerializer serializer=new XmlSerializer(typeof(User));
        using(FileStream fs=new FileStream("user.xml", FileMode.Create))
        {
            serializer.Serialize(fs,u);
        }
        Console.WriteLine("xml");
        Console.WriteLine(typeof(User));
    }
}
```

### Problem Statement

### Code
```csharp
[Serializable]
public class User
{
    public int ID{get; set;}
    public string Name{get; set;}
}


class Program
{
    static void Main()
    {
        string json=File.ReadAllText("u.json");
        User u=JsonSerializer.Deserialize<User>(json);
        Console.WriteLine($"User Loaded: {u.ID},{u.Name}");      
    }
}
```
