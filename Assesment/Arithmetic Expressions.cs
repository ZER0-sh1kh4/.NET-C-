using System;
using System.Data;
class Program
{
    public static void Main()
    {
        Console.WriteLine("Take inpt in format a op b : ");
        string input = Console.ReadLine();
        string[] section = input.Split(' ');
        //int a = int.Parse(section[0]);
        char op = section[1][0];
        //int b = int.Parse(section[2]);
          if(section.Length != 3)
        {
            Console.WriteLine("Error:InvalidExpression");
            return;
        }
       
        if(!int.TryParse(section[0],out int a)||!int.TryParse(section[2],out int b))
        {
            Console.WriteLine("Error:InvalidNumber");
            return;
        }
       
        int result = 0;
       
            switch (op)
            {
                case '+' :
                    result=a+b;
                    result.ToString();
                    Console.WriteLine(result);
                    
                break;
                case '-':
                    result=a-b;
                    result.ToString();

                    Console.WriteLine(result);

                break;
                case '*':
                    result=a*b;
                    result.ToString();

                    Console.WriteLine(result);

                break;
                case '/':
                    if (b == 0)
                    {
                        Console.WriteLine("Error:DivideByZero");
                        return;
                    }
                    result=a/b;
                    result.ToString();

                    Console.WriteLine(result);
                break;
                default :
                Console.WriteLine("Error:UnknownOperator");
                break;
            }
        
    }
}
