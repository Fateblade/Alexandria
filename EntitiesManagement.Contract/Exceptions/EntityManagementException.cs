using System;

namespace Fateblade.Alexandria.Logic.Domain.EntitiesManagement.Contract.Exceptions
{

    [Serializable]
    public class EntityManagementExceptionException : Exception
    {
        public EntityManagementExceptionException() { }
        public EntityManagementExceptionException(string message) : base(message) { }
        public EntityManagementExceptionException(string message, Exception inner) : base(message, inner) { }
        protected EntityManagementExceptionException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
