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