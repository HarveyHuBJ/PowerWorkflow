namespace PowerWorkflow.Workflow
{
    public interface IPowerThreadEntityBindable
    {
        PowerThreadEntity BindingViewModel { get; set; }

        string RenderHtml();
    }
}