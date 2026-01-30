using System;

class Program
{
    static double FeetToCm(int feet)
    {
        double cm;
        cm = feet * 30.48;
        cm = Math.Round(cm, 2, MidpointRounding.AwayFromZero);
        return cm;
    }
    static void Main()
    {
        int feet = 5; 
        double result = FeetToCm(feet);
        Console.WriteLine(result);
    }
}
