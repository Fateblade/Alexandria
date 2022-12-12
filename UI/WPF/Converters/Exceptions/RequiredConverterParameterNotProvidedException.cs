using System;
using System.Runtime.Serialization;

namespace Fateblade.Alexandria.UI.WPF.ConvertersConverters.Exceptions
{
    [Serializable]
    public class RequiredConverterParameterNotProvidedException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public RequiredConverterParameterNotProvidedException() : this("Required converter parameter was not provided")
        {
        }

        public RequiredConverterParameterNotProvidedException(string message) : base(message)
        {
        }

        public RequiredConverterParameterNotProvidedException(string message, Exception inner) : base(message, inner)
        {
        }

        protected RequiredConverterParameterNotProvidedException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
