using Xunit;
using ByCalc;
using ByCalc.Tokens;

namespace ByCalc.Testing.ParserTesting;

public class ParserTests
{
    [Fact]
    public void Parser_BinaryExpressionEvaluatedCorrectly()
    {
        var parser = new Parser();
        var binaryExpression = new List<Token>      // 1 + 2
        {
            new Token(TokenType.Number, "1"),
            new Token(TokenType.BinaryOperator, "+"),
            new Token(TokenType.Number, "2")
        };
        Assert.Equal(3, parser.Parse(binaryExpression));
    }

    [Fact]
    public void Parser_ExpressionWithParenthesisEvaluatedCorrectly()
    {
        var parser = new Parser();
        var binaryExpression = new List<Token>      // (1+2)*5
        {
            new Token(TokenType.LeftParen, "("),
            new Token(TokenType.Number, "1"),
            new Token(TokenType.BinaryOperator, "+"),
            new Token(TokenType.Number, "2"),
            new Token(TokenType.RightParen, ")"),
            new Token(TokenType.BinaryOperator, "*"),
            new Token(TokenType.Number, "5")
        };
        Assert.Equal(15, parser.Parse(binaryExpression));
    }

    [Fact]
    public void Parser_ExpressionWithUnaryOperatorEvaluatedCorrectly()
    {
        var parser = new Parser();
        var binaryExpression = new List<Token>      // (1+(-2))*5
        {
            new Token(TokenType.LeftParen, "("),
            new Token(TokenType.Number, "1"),
            new Token(TokenType.BinaryOperator, "+"),
            new Token(TokenType.LeftParen, "("),
            new Token(TokenType.UnaryOperator, "-"),
            new Token(TokenType.Number, "2"),
            new Token(TokenType.RightParen, ")"),
            new Token(TokenType.RightParen, ")"),
            new Token(TokenType.BinaryOperator, "*"),
            new Token(TokenType.Number, "5")
        };
        Assert.Equal(-5, parser.Parse(binaryExpression));
    }
}

