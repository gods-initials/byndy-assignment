namespace ByCalc.Operators;
/// registry (list) of operators that are used in tokenizer and parser
/// unless added here, implemented operators won't be recognized!!
/// idk if i should split into two files 

/// <summary>
/// registry for binary (w/ left and right operands) operators
/// </summary>
public static class BinaryOperatorRegistry
{
    /// <summary>
    /// a Dictionary containing pairs of symbols and corresponding operators from Operators.cs
    /// </summary>
    public static readonly Dictionary<string, IBinaryOperator> Operators = new()
    {
        {"+", new AdditionOperator()},
        {"-", new SubtractionOperator()},
        {"*", new MultiplicationOperator()},
        {"/", new DivisionOperator()}
    };
}

/// <summary>
/// registry for unary (w/ a single operand) operators
/// </summary>
public static class UnaryOperatorRegistry
{    
    /// <summary>
    /// a Dictionary containing pairs of symbols and corresponding operators from Operators.cs
    /// </summary>
    public static readonly Dictionary<string, IUnaryOperator> Operators = new()
    {
        {"-", new NegativeOperator()}
    };
}