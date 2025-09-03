namespace ByCalc.Operators;

public interface IBinaryOperator : IOperator
{
    decimal Calculate(decimal left, decimal right);
}