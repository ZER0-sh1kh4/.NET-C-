# Day 07 – .NET (C#)

### Problem Statement

```csharp
class Program
{
    public static void Main()
    {
        Console.WriteLine("enter no.: ");
        int n=Convert.ToInt32(Console.ReadLine());
        int[] arr=new int[n];
        Console.WriteLine("enter values: ");
        for(int i = 0; i < n; i++)
        {
            int a=Convert.ToInt32(Console.ReadLine());
            if (a > 0)
            {
                arr[i]=a;
            }
            else
            {
                i--;
            }
        }
        int len=arr.Length;
        int avg=arr.Sum()/len;
        Array.Sort(arr);
        for(int i = 0; i < arr.Length; i++)
        {
            if (arr[i] < avg)
            {
                arr[i]=0;
            }
        }
        int oldlen=arr.Length;
        for(int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i]+" ");
        }
        Console.WriteLine();
        Array.Resize(ref arr, oldlen+5 );
        for(int i = oldlen; i < arr.Length; i++)
        {   
                arr[i]=avg;   
        }
        for(int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine("index "+i+" is "+arr[i]);
        }
    
    }
}
```
