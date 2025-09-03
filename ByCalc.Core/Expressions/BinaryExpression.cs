using ByCalc.Operators;

namespace ByCalc.Expressions;

/// <summary>
/// binary operation with left and right operands
/// </summary>
public class BinaryExpression : Expression
{
    public Expression Left { get; }
    public Expression Right { get; }
    public IBinaryOperator Operator { get; }

    public BinaryExpression(Expression left, Expression right, IBinaryOperator op)
    {
        Left = left;
        Right = right;
        Operator = op;
    }

    public override decimal Evaluate() => Operator.Calculate(Left.Evaluate(), Right.Evaluate());
}