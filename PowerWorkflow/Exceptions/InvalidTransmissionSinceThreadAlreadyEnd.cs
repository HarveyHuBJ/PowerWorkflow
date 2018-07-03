using System;
using System.Runtime.Serialization;

namespace PowerWorkflow.Workflow.Exceptions
{
    [Serializable]
    internal class InvalidTransmissionSinceThreadAlreadyEnd : PowerThreadException
    {
        public InvalidTransmissionSinceThreadAlreadyEnd()
        {
        }

        public InvalidTransmissionSinceThreadAlreadyEnd(string message) : base(message)
        {
        }

        public InvalidTransmissionSinceThreadAlreadyEnd(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidTransmissionSinceThreadAlreadyEnd(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}