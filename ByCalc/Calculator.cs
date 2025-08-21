using System.IO.Pipelines;

namespace ByCalc;
public class Calculator
{
    private Tokenizer tokenizer = new();
    private Parser parser = new();
    public double Calculate(string expr)
    {
        ///хз про decimal, надеюсь не будет косяков с округлением
        List<string> tokens = tokenizer.Tokenize(expr);
        double result = parser.Evaluate(tokens);
        return result;
    }
}