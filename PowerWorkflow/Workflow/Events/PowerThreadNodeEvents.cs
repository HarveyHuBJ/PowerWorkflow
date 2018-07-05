namespace PowerWorkflow.Workflow.Events
{
    public delegate void PowerThreadNodeGoNextEvent(object sender, PowerThreadNodeGoNextEventArgs args);

    public delegate void PowerThreadNodeSaveFormEvent(object sender, PowerThreadNodeSaveFormEventArgs args);

    public delegate void PowerThreadNodeTerminateEvent(object sender, PowerThreadNodeTerminateEventArgs args);

    public delegate void PowerThreadNodeSetVariableEvent(object sender, PowerThreadNodeSetVariableEventArgs args);

    public delegate void PowerThreadNodeGetVariableEvent(object sender, PowerThreadNodeGetVariableEventArgs args);

    public delegate void PowerThreadNodeLoadEvent(object sender, PowerThreadNodeLoadEventArgs args);
}