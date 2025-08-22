using System.Reflection.Metadata;
using System.Security;
using System.Text;

namespace ByCalc.Tokens;
public enum TokenType
{
    Number,
    Operator,
    LeftParen,
    RightParen
}

public class Token
{
    /// <summary>
    /// needed this class to track token type
    /// </summary>
    public TokenType Type { get; }
    public string Value { get; }
    public Token(TokenType type, string value)
    {
        this.Type = type;
        this.Value = value;
    }
}
public class Tokenizer
{
    /// <summary>
    /// tokenizer, loops through a string and returns a list of Tokens
    /// </summary>
    /// <param name="expr">expression to be tokenized </param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public List<Token> Tokenize(string expr)
    {
        var tokens = new List<Token>();     /// list of tokens
        var number = new StringBuilder();   /// buffer for number assembly

        foreach (char e in expr)
        {
            /// TODO: fix the ifs
            if (char.IsDigit(e) || e == '.')
            {
                number.Append(e);
            }
            else if (char.IsWhiteSpace(e))
            {
                /// current character is not a number -> append the constructed number (if it exists) and append the current character
                if (number.Length > 0)
                {
                    var number_new = new Token(TokenType.Number, number.ToString());
                    tokens.Add(number_new);
                    number.Clear();
                }
                continue;
            }
            /// TODO: remove magic string
            else if ("+-/*".Contains(e))
            {
                if (number.Length > 0)
                {
                    var number_new = new Token(TokenType.Number, number.ToString());
                    tokens.Add(number_new);
                    number.Clear();
                }
                var token_new = new Token(TokenType.Operator, e.ToString());
                tokens.Add(token_new);
            }
            else if (e == '(')
            {
                if (number.Length > 0)
                {
                    var number_new = new Token(TokenType.Number, number.ToString());
                    tokens.Add(number_new);
                    number.Clear();
                }
                var token_new = new Token(TokenType.LeftParen, e.ToString());
                tokens.Add(token_new);
            }
            else if (e == ')')
            {
                if (number.Length > 0)
                {
                    var number_new = new Token(TokenType.Number, number.ToString());
                    tokens.Add(number_new);
                    number.Clear();
                }
                var token_new = new Token(TokenType.RightParen, e.ToString());
                tokens.Add(token_new);
            }
            else
            {
                throw new Exception($"invalid character {e}");
            }
        }
        /// in case input has a number as its last character
        if (number.Length > 0)
        {
            var number_new = new Token(TokenType.Number, number.ToString());
            tokens.Add(number_new);
            number.Clear();
        }
        return tokens;
    }
}
