using ByCalc.Operator;
using ByCalc.Expressions;
using ByCalc.Tokens;

namespace ByCalc
{
    public class Parser
    {
        private Dictionary<string, IOperator> operators;
        public Parser()
        {
            operators = new Dictionary<string, IOperator>
            {
                {"+", new AdditionOperator()},
                {"-", new SubtractionOperator()},
                {"*", new MultiplicationOperator()},
                {"/", new DivisionOperator()}
            };
        }
        public double Parse(List<Token> tokens)
        {
            var output = new Stack<Expression>();
            var ops = new Stack<Token>();

            foreach (Token token in tokens)
            {
                switch (token.Type)
                {
                    case TokenType.Number:
                        output.Push(new NumberExpression(double.Parse(token.Value)));
                        break;
                    case TokenType.Operator:
                        while (ops.Count > 0 && ops.Peek().Type == TokenType.Operator &&
                            operators[ops.Peek().Value].Precedence >= operators[token.Value].Precedence)
                        {
                            var right = output.Pop();
                            var left = output.Pop();
                            var op = operators[ops.Pop().Value];
                            output.Push(new BinaryExpression(left, right, op));
                        }
                        ;
                        ops.Push(token);
                        break;
                    case TokenType.LeftParen:
                        ops.Push(token);
                        break;
                    case TokenType.RightParen:
                        while (ops.Count > 0 && ops.Peek().Type != TokenType.LeftParen)
                        {
                            var right = output.Pop();
                            var left = output.Pop();
                            var op = operators[ops.Pop().Value];
                            output.Push(new BinaryExpression(left, right, op));
                        }
                        if (ops.Count == 0 || ops.Peek().Type != TokenType.LeftParen)
                            throw new Exception("parenthesis do not match");
                        ops.Pop();
                        break;
                }                
            }
            while (ops.Count > 0)
            {
                var right = output.Pop();
                var left = output.Pop();
                var op = operators[ops.Pop().Value];
                output.Push(new BinaryExpression(left, right, op));
            }
            double result = output.Pop().Evaluate();
            return result;
        }
    }
}