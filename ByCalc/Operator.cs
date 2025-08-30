namespace ByCalc.Operator;

/// <summary>
/// mathematical operators representation
/// 
/// when adding a new one also add it to the tokenizer magic string (i didn't have time to fix it sadly)
/// </summary>
public interface IOperator
{
    string Symbol { get; }
    int Precedence { get; }     /// highter = evaluated first
    decimal Calculate(decimal left, decimal right);
}

public class AdditionOperator : IOperator
{
    public string Symbol => "+";
    public int Precedence => 1;
    public decimal Calculate(decimal left, decimal right) => left + right;
}

public class SubtractionOperator : IOperator
{
    public string Symbol => "-";
    public int Precedence => 1;
    public decimal Calculate(decimal left, decimal right) => left - right;
}

public class MultiplicationOperator : IOperator
{
    public string Symbol => "*";
    public int Precedence => 2;
    public decimal Calculate(decimal left, decimal right) => left * right;
}

public class DivisionOperator : IOperator
{
    public string Symbol => "/";
    public int Precedence => 2;
    public decimal Calculate(decimal left, decimal right) => left / right;
}