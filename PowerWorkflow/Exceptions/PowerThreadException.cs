using System;
using System.Runtime.Serialization;

namespace PowerWorkflow.Workflow.Exceptions
{
    internal class PowerThreadException : Exception
    {
        public PowerThreadException()
        {
        }

        public PowerThreadException(string message) : base(message)
        {
        }

        public PowerThreadException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PowerThreadException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}