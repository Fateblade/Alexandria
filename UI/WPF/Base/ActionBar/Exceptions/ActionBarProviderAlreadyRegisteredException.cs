using System;
using System.Runtime.Serialization;

namespace Fateblade.Alexandria.UI.WPF.Base.ActionBar.Exceptions
{
    [Serializable]
    public class ActionBarProviderAlreadyRegisteredException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public ActionBarProviderAlreadyRegisteredException()
        {
        }

        public ActionBarProviderAlreadyRegisteredException(string message) : base(message)
        {
        }

        public ActionBarProviderAlreadyRegisteredException(string message, Exception inner) : base(message, inner)
        {
        }

        protected ActionBarProviderAlreadyRegisteredException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
