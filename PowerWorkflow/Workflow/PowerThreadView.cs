using System;

namespace PowerWorkflow.Workflow
{
    public class PowerThreadView
        : PowerThreadBaseObject, IPowerThreadEntityBindable
    {
        public PowerThreadView(Guid objectId, string name) : base(objectId, name)
        {

        }

        /// <summary>
        ///  use razor engine to render the view (readonly) in the path
        /// </summary>
        public string ViewPath { get; set; }

        /// <summary>
        /// the binding view model, used for rendering
        /// </summary>
        public PowerThreadEntity BindingViewModel { get; set; }
    }
}