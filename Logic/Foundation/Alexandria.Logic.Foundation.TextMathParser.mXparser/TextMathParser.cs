using Fateblade.Alexandria.Logic.Foundation.TextMathParser.Contract;

namespace Fateblade.Alexandria.Logic.Foundation.TextMathParser.mXparser
{
    internal class TextMathParser : ITextMathParser
    {
        public double Parse(string mathematicExpression)
        {
            return new org.mariuszgromada.math.mxparser.Expression(mathematicExpression).calculate();
        }
    }
}
