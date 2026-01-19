using System;
using System.Runtime.Serialization;

namespace Fateblade.Alexandria.Logic.Foundation.Meta.Dice.Contract.Exceptions
{
    [Serializable]
    public class DiceParsingException : DiceException
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public DiceParsingException()
        {
        }

        public DiceParsingException(string message) : base(message)
        {
        }

        public DiceParsingException(string message, Exception inner) : base(message, inner)
        {
        }

        protected DiceParsingException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
