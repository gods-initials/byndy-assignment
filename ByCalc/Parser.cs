using ByCalc.Operator;
using ByCalc.Expressions;

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
        public Expression Parse(List<string> tokens)
        {
            /// я наверное ещё успею пожалеть что не сделал класс для токенов
            foreach (string token in tokens)
            {
                if (char.IsDigit(token))
                if (this.operators.Keys.Contains(token))
                {

                }
            }
            return expr;
        }
    }
}