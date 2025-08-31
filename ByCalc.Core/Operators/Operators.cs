namespace ByCalc.Operators;

/// <summary>
/// mathematical operators representation
/// </summary>
public interface IOperator
{
    int Precedence { get; }     /// highter precedence = evaluated first
    string Symbol { get; }
}
public interface IBinaryOperator : IOperator
{    
    decimal Calculate(decimal left, decimal right);
}

public interface IUnaryOperator : IOperator
{
    decimal Calculate(decimal operand);
}

public class AdditionOperator : IBinaryOperator
{
    public string Symbol => "+";
    public int Precedence => 1;
    public decimal Calculate(decimal left, decimal right) => left + right;
}

public class SubtractionOperator : IBinaryOperator
{
    public string Symbol => "-";
    public int Precedence => 1;
    public decimal Calculate(decimal left, decimal right) => left - right;
}

public class MultiplicationOperator : IBinaryOperator
{
    public string Symbol => "*";
    public int Precedence => 2;
    public decimal Calculate(decimal left, decimal right) => left * right;
}

public class DivisionOperator : IBinaryOperator
{
    public string Symbol => "/";
    public int Precedence => 2;
    public decimal Calculate(decimal left, decimal right) => left / right;
}

public class NegativeOperator : IUnaryOperator
{
    // MIGHT make all classes static and take SubtractionOperator.Symbol instead?
    public string Symbol => "-";
    public int Precedence => 3;
    // might also just make a descendant of SubtractionOperator and take left=0, afaik that"s even mathematically correct
    public decimal Calculate(decimal operand) => -operand;
}