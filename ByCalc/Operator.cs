namespace ByCalc.Operator;

public interface IOperator
{
    string Symbol { get; }
    int Precedence { get; }
    double Calculate(double left, double right);
}

public class AdditionOperator : IOperator
{
    public string Symbol => "+";
    public int Precedence => 1;
    public double Calculate(double left, double right) => left + right;
}

public class SubtractionOperator : IOperator
{
    public string Symbol => "-";
    public int Precedence => 1;
    public double Calculate(double left, double right) => left - right;
}

public class MultiplicationOperator : IOperator
{
    public string Symbol => "*";
    public int Precedence => 2;
    public double Calculate(double left, double right) => left * right;
}

public class DivisionOperator : IOperator
{
    public string Symbol => "/";
    public int Precedence => 2;
    public double Calculate(double left, double right) => left / right;
}