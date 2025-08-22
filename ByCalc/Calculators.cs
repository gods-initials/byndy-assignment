using ByCalc.Tokens;
using ByCalc.Expressions;

namespace ByCalc.Calculators;
public class Calculator
{
    private Tokenizer tokenizer = new();
    private Parser parser = new();
    public double Calculate(string expr)
    {
        ///хз про decimal, надеюсь не будет косяков с округлением
        List<Token> tokens = tokenizer.Tokenize(expr);
        double result = parser.Parse(tokens);
        return result;
    }
}