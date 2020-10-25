using System;

namespace Fateblade.Alexandria.Logic.Domain.GearManagement.Contract.Exceptions
{
    [Serializable]
    public class GearManagementException : Exception
    {
        public GearManagementException() { }
        public GearManagementException(string message) : base(message) { }
        public GearManagementException(string message, Exception inner) : base(message, inner) { }
        protected GearManagementException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
