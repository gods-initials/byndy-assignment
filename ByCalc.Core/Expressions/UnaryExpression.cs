using ByCalc.Operators;

namespace ByCalc.Expressions;

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