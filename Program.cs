using System.Diagnostics.Contracts;
using System.IO;
using System.Reflection;
using ByCalc.Calculator;

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
            /// криво написано, но для начала пойдёт
            string expr = line.Split('=')[0];
            string ans = line.Split('=')[1];
            parsed_tests.Add(new Test(expr, ans));
        }
        return parsed_tests;
    }
    public static void Main(string[] args)
    {
        Calculator calc = new();
        string path = @"C:\Users\galah\Desktop\byndy-assignment\test.txt";
        List<Test> tests = ReadTestsFromTxt(path);
        foreach (Test test in tests.Take(4))
        {
            ///Console.WriteLine($"{test} : {calc.Calculate(test.Expression) == test.Answer}");
        }
        Console.WriteLine(char.IsDigit('3'));
    }
}