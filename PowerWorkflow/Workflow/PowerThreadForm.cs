using System;

namespace PowerWorkflow.Workflow
{
    public class PowerThreadForm : PowerThreadBaseObject, IPowerThreadEntityBindable

    {
        public PowerThreadForm(Guid objectId, string name) : base(objectId, name)
        {

        }
        public StandNodeActions Actions { get; set; }

        /// <summary>
        ///  use razor engine to render the form in the path
        /// </summary>
        public string FormPath { get; set; }

        /// <summary>
        /// the binding view model, used for submit
        /// </summary>
        public PowerThreadEntity BindingViewModel { get; set; }
    }
}