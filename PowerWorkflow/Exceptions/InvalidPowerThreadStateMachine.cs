using System;
using System.Runtime.Serialization;

namespace PowerWorkflow.Workflow.Exceptions
{
    [Serializable]
    internal class InvalidPowerThreadStateMachine : PowerThreadException
    {
        public InvalidPowerThreadStateMachine()
        {
        }

        public InvalidPowerThreadStateMachine(string message) : base(message)
        {
        }

        public InvalidPowerThreadStateMachine(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidPowerThreadStateMachine(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}