namespace PowerWorkflow.Workflow.Events
{
    public class PowerThreadNodeSaveFormEventArgs : System.EventArgs
    {
        public PowerThreadEntity Entity { get; internal set; }
    }
}