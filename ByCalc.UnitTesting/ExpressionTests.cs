using Xunit;
using ByCalc.Expressions;
using ByCalc.Operators;

namespace ByCalc.Testing.ExpressionTesting;

public class ExpressionTests
{
    [Fact]
    public void Expression_NumberEvaluatesCorrectly()
    {
        var numberExpression = new NumberExpression(5);
        Assert.Equal(5, numberExpression.Evaluate());
    }

    [Fact]
    public void Expression_UnaryEvaluatesCorrectly()
    {
        var numberExpression = new NumberExpression(5);
        var unaryExpression = new UnaryExpression(numberExpression, new NegativeOperator());
        Assert.Equal(-5, unaryExpression.Evaluate());
    }

    [Fact]
    public void Expression_BinaryEvaluatesCorrectly()
    {
        var numberExpression1 = new NumberExpression(5);
        var numberExpression2 = new NumberExpression(4);
        var binaryExpression = new BinaryExpression(numberExpression1, numberExpression2, new SubtractionOperator());
        Assert.Equal(1, binaryExpression.Evaluate());
    }
}