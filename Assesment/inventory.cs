using System;

class Program
{
    static void Main()
    {
        string input = " llapppptop bag ";

        input = input.Trim();
        string temp = "";
        for (int i = 0; i < input.Length; i++)
        {
            if (i == 0 || input[i] != input[i - 1])
                temp += input[i];
        }
        string result = "";
        bool newWord = true;
        for (int i = 0; i < temp.Length; i++)
        {
            char ch = temp[i];

            if (ch == ' ')
            {
                result += ch;
                newWord = true;
            }
            else
            {
                if (newWord)
                    result += char.ToUpper(ch);
                else
                    result += char.ToLower(ch);

                newWord = false;
            }
        }
        Console.WriteLine(result);
    }
}
