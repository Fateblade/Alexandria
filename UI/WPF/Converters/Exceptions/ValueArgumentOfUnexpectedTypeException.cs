using System;
using System.Runtime.Serialization;

namespace Fateblade.Alexandria.UI.WPF.ConvertersConverters.Exceptions
{
    [Serializable]
    public class ValueArgumentOfUnexpectedTypeException : ArgumentException
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public ValueArgumentOfUnexpectedTypeException(object value) :
            base($"Value is of unexpected type '{value?.GetType().FullName}'")
        {
        }

        public ValueArgumentOfUnexpectedTypeException(object value, Type expectedType) :
            base($"Value is of unexpected type '{value?.GetType().FullName}'. Expected '{expectedType.FullName}'")
        {
        }

        protected ValueArgumentOfUnexpectedTypeException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
