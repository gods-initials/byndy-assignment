using ByCalc.Operator;

namespace ByCalc.Expressions;

/// <summary>
/// base class for all expression nodes in AST
/// every expression must be able to evaluate itself to a numeric constant
/// </summary>
public abstract class Expression
{
    public abstract double Evaluate();
}

/// <summary>
/// leaf node, a numeric constant
/// </summary>
public class NumberExpression : Expression
{
    public double Value { get; }
    public NumberExpression(double value) => Value = value;

    public override double Evaluate() => Value;
}

/// <summary>
/// binary operation with left and right operands
/// </summary>
public class BinaryExpression : Expression
{
    public Expression Left { get; }
    public Expression Right { get; }
    public IOperator Operator { get; }

    public BinaryExpression(Expression left, Expression right, IOperator op)
    {
        Left = left;
        Right = right;
        Operator = op;
    }

    public override double Evaluate() => Operator.Calculate(Left.Evaluate(), Right.Evaluate());
}