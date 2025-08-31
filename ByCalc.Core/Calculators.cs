using ByCalc.Tokens;
using ByCalc.Expressions;

namespace ByCalc.Calculators;
public class Calculator
{
    private Tokenizer tokenizer = new();
    private Parser parser = new();
    public decimal Calculate(string expr)
    {
        List<Token> tokens = tokenizer.Tokenize(expr);
        decimal result = parser.Parse(tokens);
        return result;
    }
}