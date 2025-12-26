
# Day 07 – .NET (C#)

### Problem Statement

```csharp
class Program
{
    public static void Main()
    {
        int[] arr={1,2,4,3,5};
        foreach(int i in arr)
        {
            Console.Write(i+" ");
        }

        Console.WriteLine();

        Console.Write("og array: ");

        for(int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i]+" ");
        }
        Console.WriteLine();

        Console.Write("sorted: ");
        Array.Sort(arr);
        for(int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i]+" ");
        }
        Console.WriteLine();

        Console.Write("reverse: ");


        Array.Reverse(arr,1,arr.Length-1);


        for(int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i]+" ");
        }
        Console.WriteLine();


        Console.Write("clear after 1: ");

        Array.Clear(arr,1,arr.Length-1);

        for(int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i]+" ");
        }
        Console.WriteLine();

        Console.Write("copy : ");
        int[] copy=new int[arr.Length];
        Array.Copy(arr, copy, arr.Length);
        for(int i = 0; i < copy.Length; i++)
        {
            Console.Write(copy[i]+" ");

        }
        Console.WriteLine();
        Console.Write("resize: ");
        int[] arr1={10,20,30,40};
        Array.Resize(ref arr1,1);
        foreach(int i in arr1)
        {
            Console.Write(i+" ");

        }
        Console.WriteLine();
        Array.Resize(ref arr1,2);
        foreach(int i in arr1)
        {
            Console.Write(i+" ");

        }
        Console.WriteLine();
        int[] arr2={10,20,30,40};

        bool found=Array.Exists(arr2,x=>x>25);
        Console.WriteLine(found);
    }
}
```

### Problem Statement

```csharp
class Program
{
    public static void Main()
    {
        int[,]arr={{1,2,3},{4,5,6}};
        Console.WriteLine(arr[1,0]);
        for(int i = 0; i < arr.GetLength(0);i++)                  //getlength for dimension
        {
            for(int j = 0; j < arr.GetLength(1); j++)
            {
                Console.Write(arr[i,j]+" ");
            }
            Console.WriteLine("");
        }
    }
}
```

### Problem Statement

```csharp
class Program
{
    public static void Main()
    {
        int [] [] jagged=new int[2][];
        jagged[0]=new int[]{1,2,3};
        jagged[1]=new int[]{4,5,6,7};
        Console.WriteLine(jagged[1][1]);
        Console.WriteLine(jagged.Length);   //2
        Console.WriteLine(jagged[1].Length);    //4

        for(int i = 0; i < jagged.Length;i++)
        {
            for(int j = 0; j < jagged[i].Length; j++)
            {
                Console.Write(jagged[i][j]+" ");
            }
            Console.WriteLine("");
        }
    }
}
```


```csharp
class PROgram
{
    public static void Main()
    {
        List<int> num=new List<int>();
        num.Add(10);
        num.Add(20);
        foreach(int i in num)
        {
            Console.Write(i);
        }
        Console.WriteLine();
        ArrayList list=new ArrayList();
        list.Add(10);
        list.Add(20);
        list.Add("Hello");
        foreach(object i in list)
        {
            Console.Write(i);
        }
        Console.WriteLine();
        Hashtable ht=new Hashtable();
        ht.Add(1,"me");
        ht.Add(2,"you");
        Console.WriteLine(ht[1]);
        Stack st=new Stack();
        st.Push(10);
        st.Push(20);
       // st.Pop();
        Console.WriteLine(st.Pop());
        Queue qu=new Queue();
        qu.Enqueue(10);
        qu.Enqueue(20);
        Console.WriteLine(qu.Dequeue());

        Dictionary<int,string> dict=new Dictionary<int, string>();
        dict.Add(1,"me");
        dict.Add(2,"you");
        dict.Add(3,"me");
        foreach(var i in dict)
        {
            Console.Write(i);
        }
        Console.WriteLine();
        foreach(int key in dict.Keys)
        {
            Console.Write(key);
        }
        Console.WriteLine();
        foreach(string value in dict.Values)
        {
            Console.Write(value);
        }
        Console.WriteLine();
        if(dict.TryGetValue(2,out string you))
        {
            Console.WriteLine(you);
        }
        else
        {
            Console.WriteLine("not found");
        }
        foreach(KeyValuePair<int,string> d in dict)
        {
            Console.Write(d.Key+"-"+d.Value+" ");
        }

        Console.WriteLine();
        HashSet<int> set=new HashSet<int>();
        set.Add(10);
        set.Add(11);
        foreach(int i in set)
        {
            Console.Write(i+" ");
        }
        Console.WriteLine();
        SortedList<string,string> l=new SortedList<string, string>();
        l.Add("b","B");
        l.Add("a","C");
        foreach(var i in l)
        {
            Console.Write(i+" ");
        }
        foreach(string i in l.Keys)
        {
            Console.Write(i+" ");
        }
        foreach(string i in l.Values)
        {
            Console.Write(i+" ");
        }
        foreach(var i in l.Reverse())
        {
            Console.Write(i.Key);
        }


    }
}
```

### Problem Statement

```csharp
class Program
{
    public static void Main()
    {
        Dictionary<int,int> dict=new Dictionary<int, int>();
        int[] arr={1,2,3,2,1,4,2};
        foreach(int i in arr)
        {
            if (dict.ContainsKey(i))
            {
                dict[i]++;
            }
            else
            {
                dict[i]=1;
            }
        }
        foreach (var i in dict)
        {
            Console.WriteLine(i);
        }
}
}
```
### Problem Statement

```csharp
class Program
{
    public static void Main()
    {
        int[] arr1={1,3,5,9};
        int[] arr2={4,8,10,11};
        int[] merged=new int[arr1.Length+arr2.Length];
        int i=0;
        int j=0;
        int k=0;
        while(i<arr1.Length && j < arr2.Length)
        {
            if (arr1[i] < arr2[j])
            {
                merged[k++]=arr1[i++];
            }
            else
            {
                merged[k++]=arr2[j++];
            }
        }
        while (i < arr1.Length)
        {
            merged[k++]=arr1[i++];
        }
        while (j < arr2.Length)
        {
            merged[k++]=arr2[j++];
        }
        foreach(int n in merged)
        {
            Console.Write(n+" ");
        }
    }  

}
```







