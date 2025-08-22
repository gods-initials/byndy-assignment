using ByCalc.Tokens;
using ByCalc.Expressions;

namespace ByCalc.Calculators;
public class Calculator
{
    private Tokenizer tokenizer = new();
    private Parser parser = new();
    public double Calculate(string expr)
    {
        List<Token> tokens = tokenizer.Tokenize(expr);
        /// rewrite to decimal if precision is necessary
        double result = parser.Parse(tokens);
        return result;
    }
}