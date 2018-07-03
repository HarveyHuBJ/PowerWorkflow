using PowerWorkflow.Workflow.Events;
using System;

namespace PowerWorkflow.Workflow
{
    public class PowerThreadForm : PowerThreadBaseObject, IPowerThreadEntityBindable

    {
        #region events

        public event PowerThreadNodeGoNextEvent GoNext;

        public event PowerThreadNodeSaveFormEvent SaveForm;

        public event PowerThreadNodeTerminateEvent Terminate;

        public event PowerThreadNodeSetVariableEvent SetVariable;

        public event PowerThreadNodeGetVariableEvent GetVariable;
        #endregion

        public PowerThreadForm(Guid objectId, string name, string formPath) : base(objectId, name)
        {

            FormPath = FormPath;
            BindingViewModel = new PowerThreadEntity(Guid.NewGuid(), name + "-Entity");
        }


        /// <summary>
        ///  use razor engine to render the form in the path
        /// </summary>
        public string FormPath { get; }

        /// <summary>
        /// the binding view model, used for submit
        /// </summary>
        public PowerThreadEntity BindingViewModel { get; set; }

        public void Go()
        {
            GoNext(this, new PowerThreadNodeGoNextEventArgs());
        }

    }
}