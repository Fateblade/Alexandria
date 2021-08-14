using System;
using System.Runtime.Serialization;

namespace Fateblade.Alexandria.Logic.Foundation.Meta.Dice.Contract.Exceptions
{
    [Serializable]
    public class DiceException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public DiceException()
        {
        }

        public DiceException(string message) : base(message)
        {
        }

        public DiceException(string message, Exception inner) : base(message, inner)
        {
        }

        protected DiceException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
