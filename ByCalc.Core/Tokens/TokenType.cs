using System.Text;
using ByCalc.Operators;

namespace ByCalc.Tokens;

public enum TokenType
{
    Newline,
    Number,
    BinaryOperator,
    UnaryOperator,
    LeftParen,
    RightParen
}