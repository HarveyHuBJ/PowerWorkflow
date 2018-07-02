using System;

namespace PowerWorkflow.Workflow
{
    public class PowerVariable : PowerThreadBaseObject
    {

        public PowerVariable(string name) : base(Guid.NewGuid(), name)
        {

        }

        public string VariableName { get { return this.Name; } }

        public object Value { get; set; }
    }
}