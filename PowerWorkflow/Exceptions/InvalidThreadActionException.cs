using System;
using System.Runtime.Serialization;

namespace PowerWorkflow.Workflow.Exceptions
{
    [Serializable]
    internal class InvalidThreadActionException : PowerThreadException
    {
        public InvalidThreadActionException()
        {
        }

        public InvalidThreadActionException(string message) : base(message)
        {
        }

        public InvalidThreadActionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidThreadActionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}