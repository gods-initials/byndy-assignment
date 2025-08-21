using ByCalc.Operator;

namespace ByCalc.Expressions;

public abstract class Expression
{
    public abstract double Evaluate();
}

public class NumberExpression : Expression
{
    public double Value { get; }
    public NumberExpression(double value) => Value = value;

    public override double Evaluate() => Value;
}

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