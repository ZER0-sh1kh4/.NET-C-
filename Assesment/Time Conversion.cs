using System;

class Program
{
    static string ConvertTime(int totalSeconds)
    {
        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;
        if (seconds < 10)
            return minutes + ":0" + seconds;
        else
            return minutes + ":" + seconds;
    }
    static void Main()
    {
        Console.WriteLine(ConvertTime(125));
        Console.WriteLine(ConvertTime(60));
    }
}
