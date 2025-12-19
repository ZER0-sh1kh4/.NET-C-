# Day 02 – .NET (C#)

### Problem Statement
1- First 5 numbers

### Code
```csharp
class Program
{
    static void Main()
    {
        int count=0;
        while (count <= 5)
        {
            Console.WriteLine(count);
            count++;
        }
    }
}
```
2-reverse 5 numbers

### Code
```csharp
class Program
{
    static void Main()
    {
        int count=5;
        while (count >=0)
        {
            Console.WriteLine(count);
            count--;
        } 
    }
}
```
3- 5 numbers using do while loop

### Code
```csharp
class Program
{
    static void Main()
    {
        int count=0;
        do
        {
            Console.WriteLine(count);
            count++;
        }
        while(count<=5);
    }
}
```
4-Table 20-30

### Code
```csharp
class Program
{
    static void Main()
    {
       for(int i = 20; i <= 30; i++)
        {
            Console.WriteLine("tabel of : " + i);
            for(int j = 1; j <= 10; j++)
            {
                Console.WriteLine(i +"X" + j+ "=" +i*j);
            }
        }
    }
}
```
5- game that skip one enemy at place 4

### Code
```csharp
class Program
{
    static void Main()
    {
        Console.WriteLine("GAME BEGINS...");
        for(int i = 1; i <= 10; i++)
        {
            if (i == 4)
            {
                Console.WriteLine("Enemy "+i+" is invisible ....\n" +"djfhdf");
                Console.WriteLine("Skipping enermy "+i);

                continue;
            }
            Console.WriteLine("Player Killed Enemy "+ i);

        }
    }
}
```
