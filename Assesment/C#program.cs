using System;
using System.Text;
class Program
{
    static bool Vowel(char ch)
    {
        ch = char.ToLower(ch);
        return ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u';
    }
    static void Main()
    {
        string first = Console.ReadLine();
        string second = Console.ReadLine().ToLower();
        StringBuilder temp = new StringBuilder();
        foreach (char ch in first)
        {
            char lower = char.ToLower(ch);

            if (!Vowel(lower) && second.Contains(lower))
            {
                continue; 
            }
            temp.Append(ch);
        }
        StringBuilder res = new StringBuilder();
        for (int i = 0; i < temp.Length; i++)
        {
            if (i == 0 || temp[i] != temp[i - 1])
            {
                res.Append(temp[i]);
            }
        }
        Console.WriteLine(res.ToString());
    }
}
