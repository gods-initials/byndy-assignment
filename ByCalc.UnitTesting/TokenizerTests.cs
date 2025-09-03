using Xunit;
using ByCalc.Tokens;

namespace ByCalc.Testing.TokenTesting;

public class TokenizerTests
{
    [Fact]
    public void Tokenizer_SimpleAddition_ReturnsCorrectTokens()
    {
        var tokenizer = new Tokenizer();
        var tokens = tokenizer.Tokenize("1+2");

        Assert.Equal(TokenType.Number, tokens[0].Type);
        Assert.Equal(TokenType.BinaryOperator, tokens[1].Type);
        Assert.Equal(TokenType.Number, tokens[2].Type);
    }

    [Fact]
    public void Tokenizer_WithSpaces_IgnoresWhitespace()
    {
        var tokenizer = new Tokenizer();
        var tokens = tokenizer.Tokenize("  3   *   4 ");

        Assert.Equal(TokenType.Number, tokens[0].Type);
        Assert.Equal(TokenType.BinaryOperator, tokens[1].Type);
        Assert.Equal(TokenType.Number, tokens[2].Type);
    }

    [Fact]
    public void Tokenizer_Parentheses_ReturnsCorrectTokens()
    {
        var tokenizer = new Tokenizer();
        var tokens = tokenizer.Tokenize("(5-2)");

        Assert.Equal(TokenType.LeftParen, tokens[0].Type);
        Assert.Equal(TokenType.Number, tokens[1].Type);
        Assert.Equal(TokenType.BinaryOperator, tokens[2].Type);
        Assert.Equal(TokenType.Number, tokens[3].Type);
        Assert.Equal(TokenType.RightParen, tokens[4].Type);
    }

    [Fact]
    public void Tokenizer_MultipleDigitsNumber_ReturnsSingleNumberToken()
    {
        var tokenizer = new Tokenizer();
        var tokens = tokenizer.Tokenize("123+456");

        Assert.Equal(TokenType.Number, tokens[0].Type);
        Assert.Equal("123", tokens[0].Value);
        Assert.Equal(TokenType.BinaryOperator, tokens[1].Type);
        Assert.Equal(TokenType.Number, tokens[2].Type);
        Assert.Equal("456", tokens[2].Value);
    }

    [Fact]
    public void Tokenizer_InvalidCharacter_ThrowsException()
    {
        var tokenizer = new Tokenizer();

        Assert.Throws<System.Exception>(() => tokenizer.Tokenize("2 & 3"));
    }

    [Fact]
    public void Tokenizer_EmptyInput_ReturnsEmptyList()
    {
        var tokenizer = new Tokenizer();
        var tokens = tokenizer.Tokenize("");

        Assert.Empty(tokens);
    }
}

