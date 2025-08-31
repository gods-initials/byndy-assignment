namespace ByCalc.Operators;
/// <summary>
/// registry (list) of operators that are used in tokenizer and parser
/// unless added here, implemented operators won't be recognized!!
/// </summary>
public static class BinaryOperatorRegistry
{
    public static readonly Dictionary<string, IBinaryOperator> Operators = new()
    {
        {"+", new AdditionOperator()},
        {"-", new SubtractionOperator()},
        {"*", new MultiplicationOperator()},
        {"/", new DivisionOperator()}
    };
}

public static class UnaryOperatorRegistry
{
    public static readonly Dictionary<string, IUnaryOperator> Operators = new()
    {
        {"-", new NegativeOperator()}
    };
}