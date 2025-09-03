namespace ByCalc.Operators;

public class SubtractionOperator : IBinaryOperator
{
    public string Symbol => "-";
    public int Precedence => 1;
    public decimal Calculate(decimal left, decimal right) => left - right;
}