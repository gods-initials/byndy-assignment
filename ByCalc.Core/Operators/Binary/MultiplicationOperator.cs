namespace ByCalc.Operators;

public class MultiplicationOperator : IBinaryOperator
{
    public string Symbol => "*";
    public int Precedence => 2;
    public decimal Calculate(decimal left, decimal right) => left * right;
}