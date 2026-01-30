using System;

class Program
{
    static double CircleArea(double radius)
    {
        double area;
        area = Math.PI * radius * radius;
        area = Math.Round(area, 2, MidpointRounding.AwayFromZero);
        return area;
    }
    static void Main()
    {
        double radius = 5; 
        double result = CircleArea(radius);
        Console.WriteLine(result);
    }
}
