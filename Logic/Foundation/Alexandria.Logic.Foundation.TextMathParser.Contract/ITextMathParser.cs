using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Aspects;
using Fateblade.Alexandria.Logic.Foundation.TextMathParser.Contract.Exceptions;

namespace Fateblade.Alexandria.Logic.Foundation.TextMathParser.Contract
{
    [MapException(typeof(TextMathParsingException))]
    public interface ITextMathParser
    {
        double Parse(string mathematicExpression);
    }
}
