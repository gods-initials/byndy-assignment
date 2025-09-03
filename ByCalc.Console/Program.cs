using System.Diagnostics.Contracts;
using System.IO;
using System.Reflection;
using ByCalc.Calculators;

public class CalcTesting
{
    public static void Main(string[] args)
    {
        var calc = new Calculator();
        Console.WriteLine("Type \"end\" to exit.");
        string? expr = "";
        while (expr != "end")
        {
            Console.Write("Input the expression: ");
            expr = Console.ReadLine();
            Console.Write("Result: ");
            try
            {
                Console.WriteLine(calc.Calculate(expr));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}