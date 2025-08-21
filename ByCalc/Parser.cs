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
        public Expression Parse(List<Token> tokens)
        {
            var output = new Stack<Expression>();
            var ops = new Stack<Token>();

            foreach (Token token in tokens)
            {
                switch (token.Type)
                {
                    case TokenType.Number:
                        output.Push(new NumberExpression(double.Parse(token.Value, System.Globalization.CultureInfo.InvariantCulture)));
                        break;
                }                
            }
            return expr;
        }
    }
}