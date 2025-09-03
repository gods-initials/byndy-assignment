namespace ByCalc.Operators;

public class NegativeOperator : IUnaryOperator
{
    // MIGHT make all classes static and take SubtractionOperator.Symbol instead?
    public string Symbol => "-";
    public int Precedence => 3;
    // might also just make a descendant of SubtractionOperator and take left=0, afaik that's even mathematically correct
    public decimal Calculate(decimal operand) => -operand;
}