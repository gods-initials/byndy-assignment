using ByCalc.Operators;
using ByCalc.Expressions;
using ByCalc.Tokens;

namespace ByCalc;
/// <summary>
///  parser based on dijkstra shunting yard
/// converts a Token sequence to an expression tree (AST)
/// </summary>
public class Parser
{
    public Stack<Expression> output;       // expression nodes (AST parts)
    public Stack<Token> ops;               // operator and parenthesis stack
    public Dictionary<string, IBinaryOperator> binaryOperators;
    public Dictionary<string, IUnaryOperator> unaryOperators;
    public Parser()
    {
        binaryOperators = BinaryOperatorRegistry.Operators;
        unaryOperators = UnaryOperatorRegistry.Operators;
        output = new();
        ops = new();
    }
    public void PushExpression()
    {
        if (ops.Peek().Type == TokenType.BinaryOperator)
        {
            var right = output.Pop();
            var left = output.Pop();
            var op = binaryOperators[ops.Pop().Value];
            output.Push(new BinaryExpression(left, right, op));
        }
        else if (ops.Peek().Type == TokenType.UnaryOperator)
        {
            var operand = output.Pop();
            var op = unaryOperators[ops.Pop().Value];
            output.Push(new UnaryExpression(operand, op));
        }
    }
    public IOperator GetOperator(Token token)
    {
        switch (token.Type)
        {
            case TokenType.BinaryOperator:
                return binaryOperators[token.Value];
            case TokenType.UnaryOperator:
                return unaryOperators[token.Value];
            default:
                throw new Exception($"Token is not an operator: {token.Value}");
        }
    }
    public decimal Parse(List<Token> tokens)
    {
        foreach (Token token in tokens)
        {
            switch (token.Type)
            {
                case TokenType.Number:
                    output.Push(new NumberExpression(decimal.Parse(token.Value)));
                    break;
                case TokenType.BinaryOperator:
                case TokenType.UnaryOperator:
                    while (ops.Count > 0 && (ops.Peek().Type == TokenType.BinaryOperator || ops.Peek().Type == TokenType.UnaryOperator) &&
                        GetOperator(ops.Peek()).Precedence >= GetOperator(token).Precedence)
                    {
                        PushExpression();
                    }
                    ops.Push(token);
                    break;
                case TokenType.LeftParen:
                    ops.Push(token);
                    break;
                case TokenType.RightParen:
                    while (ops.Count > 0 && ops.Peek().Type != TokenType.LeftParen)
                    {
                        PushExpression();
                    }
                    if (ops.Count == 0 || ops.Peek().Type != TokenType.LeftParen)
                        throw new Exception("parenthesis do not match");
                    ops.Pop();
                    break;
            }
        }
        while (ops.Count > 0)
        {
            PushExpression();
        }
        decimal result = output.Pop().Evaluate();
        output.Clear();
        ops.Clear();
        return result;
    }
}