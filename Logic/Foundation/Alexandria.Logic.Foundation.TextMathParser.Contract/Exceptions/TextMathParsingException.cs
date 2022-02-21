using System;
using System.Runtime.Serialization;

namespace Fateblade.Alexandria.Logic.Foundation.TextMathParser.Contract.Exceptions
{
    [Serializable]
    public class TextMathParsingException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public TextMathParsingException()
        {
        }

        public TextMathParsingException(string message) : base(message)
        {
        }

        public TextMathParsingException(string message, Exception inner) : base(message, inner)
        {
        }

        protected TextMathParsingException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
