using System;

namespace Fateblade.Alexandria.Logic.Domain.Meta.MetaManagement.Contract.Exceptions
{
    [Serializable]
    public class MetaManagementException : Exception
    {
        public MetaManagementException() { }
        public MetaManagementException(string message) : base(message) { }
        public MetaManagementException(string message, Exception inner) : base(message, inner) { }
        protected MetaManagementException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
