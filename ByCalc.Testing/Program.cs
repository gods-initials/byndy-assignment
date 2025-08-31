using System.Diagnostics.Contracts;
using System.IO;
using System.Reflection;
using ByCalc.Calculators;

public class Test
{
    public string Expression { get; }
    public string Answer { get; }
    public Test(string expr, string ans)
    {
        this.Expression = expr;
        this.Answer = ans;
    }
    public override string ToString()
    {
        return $"{this.Expression}={this.Answer}";
    }
}
public class CalcTesting
{
    public static List<Test> ReadTestsFromTxt(string path)
    {
        string[] text = File.ReadAllLines(path);
        List<Test> parsed_tests = new();
        foreach (string line in text)
        {
            /// input shouldn't have a '=' anyway
            string expr = line.Split('=')[0];
            string ans = line.Split('=')[1];
            parsed_tests.Add(new Test(expr, ans));
        }
        return parsed_tests;
    }
    public static void Main(string[] args)
    {
        Calculator calc = new();
        /// uncomment to run tests from txt
        /// format is <expression>=<right answer>
        /*
        string path = @"C:\Users\galah\Desktop\byndy-assignment\ByCalc.Testing\test.txt";
        List<Test> tests = ReadTestsFromTxt(path);
        foreach (Test test in tests)
        {
            Console.WriteLine($"{test} : {calc.Calculate(test.Expression) == Convert.ToDecimal(test.Answer)}");
        }
        */
        
        Console.WriteLine("Type \"END\" to exit.");
        string expr = "";
        while (expr != "END")
        {
            Console.Write("Input the expression: ");
            expr = Console.ReadLine();
            Console.Write("Result: ");
            Console.WriteLine(calc.Calculate(expr));
        }
        
    }
}