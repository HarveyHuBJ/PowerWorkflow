using System;

namespace PowerWorkflow.Workflow
{
    public class PowerThreadView
        : PowerThreadBaseObject, IPowerThreadEntityBindable
    {
        public PowerThreadView(Guid objectId, string name, string viewPath) : base(objectId, name)
        {
            this.ViewPath = viewPath;
        }

        /// <summary>
        ///  use razor engine to render the view (readonly) in the path
        /// </summary>
        public string ViewPath { get;   }

        /// <summary>
        /// the binding view model, used for rendering
        /// </summary>
        public PowerThreadEntity BindingViewModel { get; set; }

        public string RenderHtml()
        {
            throw new NotImplementedException();
        }
    }
}