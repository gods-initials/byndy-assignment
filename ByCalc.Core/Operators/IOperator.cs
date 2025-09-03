namespace ByCalc.Operators;

/// <summary>
/// mathematical operators representation
/// </summary>
public interface IOperator
{
    int Precedence { get; }     /// highter precedence = evaluated first
    string Symbol { get; }
}