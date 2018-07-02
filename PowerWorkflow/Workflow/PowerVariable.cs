namespace PowerWorkflow.Workflow
{
    public class PowerVariable : PowerThreadBaseObject
    {

        public PowerVariable(string name) : base(name)
        {

        }

        public string VariableName { get { return this.Name; }  }

        public object Value { get; set; }
    }
}