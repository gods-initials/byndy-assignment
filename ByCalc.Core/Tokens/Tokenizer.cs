using System.Text;
using ByCalc.Operators;

namespace ByCalc.Tokens;

/// <summary>
/// a tokenizer, loops through a string and returns a list of Tokens
/// </summary>
/// <param name="expr">expression to be tokenized</param>
/// <returns></returns>
/// <exception cref="Exception"></exception>
public class Tokenizer
{  
    public HashSet<string> operators;
    List<Token> tokens = new();     /// list of tokens
    StringBuilder number = new();   /// buffer for number assembly
    Token previousToken = new Token(TokenType.Newline, "");
    HashSet<TokenType> unaryPrecedingOperators;
    public Tokenizer()
    {
        var binaryOperators = BinaryOperatorRegistry.Operators.Keys;
        var unaryOperators = UnaryOperatorRegistry.Operators.Keys;
        operators = new HashSet<string>(binaryOperators.Concat(unaryOperators));
        unaryPrecedingOperators = new HashSet<TokenType>
        {
            TokenType.Newline,
            TokenType.BinaryOperator,
            TokenType.UnaryOperator,
            TokenType.LeftParen
        };
    }
    public void AddNumberIfExists()
    {
        if (number.Length > 0)
        {
            var numberNew = new Token(TokenType.Number, number.ToString());
            tokens.Add(numberNew);
            number.Clear();
            previousToken = numberNew;
        }
    }
    public List<Token> Tokenize(string expr)
    {
        tokens.Clear();
        number.Clear();
        previousToken = new Token(TokenType.Newline, "");
        foreach (char e in expr)
        {
            if (char.IsDigit(e) || e == '.')
            {
                number.Append(e);
            }
            else if (char.IsWhiteSpace(e))
            {
                AddNumberIfExists();
                continue;
            }
            else if (operators.Contains(e.ToString()))
            {
                AddNumberIfExists();
                if (unaryPrecedingOperators.Contains(previousToken.Type))
                {
                    var tokenNew = new Token(TokenType.UnaryOperator, e.ToString());
                    tokens.Add(tokenNew);
                    previousToken = tokenNew;
                }
                else
                {
                    var tokenNew = new Token(TokenType.BinaryOperator, e.ToString());
                    tokens.Add(tokenNew);
                    previousToken = tokenNew;
                }
            }
            else if (e == '(')
            {
                AddNumberIfExists();
                var tokenNew = new Token(TokenType.LeftParen, e.ToString());
                tokens.Add(tokenNew);
                previousToken = tokenNew;
            }
            else if (e == ')')
            {
                AddNumberIfExists();
                var tokenNew = new Token(TokenType.RightParen, e.ToString());
                tokens.Add(tokenNew);
                previousToken = tokenNew;
            }
            else
            {
                throw new Exception($"invalid character {e}");
            }
        }
        /// in case input has a number as its last character
        AddNumberIfExists();
        return tokens;
    }
}
