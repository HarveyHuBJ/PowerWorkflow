using PowerWorkflow.Workflow.Events;

namespace PowerWorkflow.Workflow
{
    public class StandNodeActions
    {
        public event PowerThreadNodeGoNextEvent GoNext;

        public event PowerThreadNodeSaveFormEvent SaveForm;

        public event PowerThreadNodeTerminateEvent Terminate;

        public event PowerThreadNodeSetVariableEvent SetVariable;

        public event PowerThreadNodeGetVariableEvent GetVariable;
    }
}