using ByCalc.Operators;

namespace ByCalc.Expressions;

/// <summary>
/// base class for all expression nodes in AST
/// every expression must be able to evaluate itself to a numeric constant
/// </summary>
public abstract class Expression
{
    public abstract decimal Evaluate();
}

/// <summary>
/// leaf node, a numeric constant
/// </summary>
public class NumberExpression : Expression
{
    public decimal Value { get; }
    public NumberExpression(decimal value) => Value = value;

    public override decimal Evaluate() => Value;
}

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
/// <summary>
/// unary operation with a single operand
/// </summary>
public class UnaryExpression : Expression
{
    public Expression Operand { get; }
    public IUnaryOperator Operator { get; }
    public UnaryExpression(Expression operand, IUnaryOperator op)
    {
        Operand = operand;
        Operator = op;
    }
    public override decimal Evaluate() => Operator.Calculate(Operand.Evaluate());
}