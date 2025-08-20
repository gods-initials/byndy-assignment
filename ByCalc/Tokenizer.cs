using System.Reflection.Metadata;
using System.Security;
using System.Text;

namespace ByCalc
{
    public class Tokenizer
    {
        public List<string> Tokenize(string expr)
        {
            var tokens = new List<string>();
            var number = new StringBuilder();

            foreach (char e in expr)
            {
                if (char.IsDigit(e) || e == '.')
                {
                    number.Append(e);
                }
                /// переделать нормально чтобы смотрело доступные операторы
                else if ("()+-/*".Contains(e))
                {
                    if (number.Length > 0)
                    {
                        tokens.Add(number.ToString());
                        number.Clear();
                    }

                    tokens.Add(e.ToString());
                }
                else if (char.IsWhiteSpace(e))
                { 
                    continue;
                }
                else
                {
                    throw new Exception($"invalid character {e}");
                }
            }

            return tokens;
        }
    }
}
