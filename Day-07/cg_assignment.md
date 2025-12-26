# Day 07 – .NET (C#)

### Problem Statement

```csharp
class Program
{
    public static void Main(){

    string s=Console.ReadLine();
    if(string.IsNullOrEmpty(s)||s.Length<6){
        return;

    }
    foreach(char c in s)
        {
            if (!char.IsLetter(c))
            {
                return;
            }

        }
        s=s.ToLower();

        char[] temp=new char[s.Length];
        int count=0;
        for(int i = 0; i < s.Length; i++)
        {
            if ((int)s[i] % 2 != 0)
            {
                temp[count]=s[i];
                count++;
            }
        }
        char[] res=new char[count];
        Array.Copy(temp,res,count);
        Array.Reverse(res);
        for(int i = 0; i < res.Length; i++)
        {
            if (i % 2 == 0)
            {
                res[i]=char.ToUpper(res[i]);
            }

        }
        Console.WriteLine(new string(res));
}
}
```
