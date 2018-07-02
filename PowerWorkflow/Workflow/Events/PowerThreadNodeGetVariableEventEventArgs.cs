namespace PowerWorkflow.Workflow.Events
{
    public class PowerThreadNodeGetVariableEventEventArgs : System.EventArgs
    {
        public string VariableName { get; internal set; }
        public System.Type VariableType { get; internal set; }
        public object Value { get; internal set; }
    }
}