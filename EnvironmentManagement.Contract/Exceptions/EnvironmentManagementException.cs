using System;

namespace Fateblade.Alexandria.Logic.Domain.EnvironmentManagement.Contract.Exceptions
{
    [Serializable]
    public class EnvironmentManagementException : Exception
    {
        public EnvironmentManagementException() { }
        public EnvironmentManagementException(string message) : base(message) { }
        public EnvironmentManagementException(string message, Exception inner) : base(message, inner) { }
        protected EnvironmentManagementException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
