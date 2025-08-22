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
    public List<Token> Tokenize(string expr)
    {
        var tokens = new List<Token>();
        var number = new StringBuilder();

        foreach (char e in expr)
        {
            if (char.IsDigit(e) || e == '.')
            {
                number.Append(e);
            }
            else if (char.IsWhiteSpace(e))
            {
                continue;
            }
            /// вот тут по красоте надо посмотреть объявленные операторы и строку из них составлять а не делать magic stringи, но в целом пока пойдёт
            else if ("+-/*".Contains(e))
            {
                if (number.Length > 0)
                {
                    var number_new = new Token(TokenType.Number, number.ToString());
                    tokens.Add(number_new);
                    number.Clear();
                }
                /// бога ради не надо кастить символ, просто перепиши токены под чар
                var token_new = new Token(TokenType.Operator, e.ToString());
                tokens.Add(token_new);
            }
            else if (e == '(')
            {
                var token_new = new Token(TokenType.LeftParen, e.ToString());
            }
            else if (e == ')')
            {
                var token_new = new Token(TokenType.RightParen, e.ToString());
            }
            else
            {
                throw new Exception($"invalid character {e}");
            }
        }
        /// на случай если ввод заканчивается числом а не скобкой
        if (number.Length > 0)
        {
            var number_new = new Token(TokenType.Number, number.ToString());
            tokens.Add(number_new);
            number.Clear();
        }
        return tokens;
    }
}
