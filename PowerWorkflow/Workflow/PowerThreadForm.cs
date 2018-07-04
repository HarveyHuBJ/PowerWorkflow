using PowerWorkflow.Workflow.Events;
using System;
using RazorEngine;
using PowerWorkflow.Common;

namespace PowerWorkflow.Workflow
{
    public class PowerThreadForm : PowerThreadBaseObject, IPowerThreadEntityBindable

    {
        #region Properties
        /// <summary>
        ///  use razor engine to render the form in the path
        /// </summary>
        public string FormPath { get; }

        /// <summary>
        /// the binding view model, used for submit
        /// </summary>
        public PowerThreadEntity BindingViewModel { get; set; }
        #endregion

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

        #region actions of form


        public void Go()
        {
            GoNext(this, new PowerThreadNodeGoNextEventArgs());
        }

        public void Save()
        {
            SaveForm(this, new PowerThreadNodeSaveFormEventArgs() { Entity = BindingViewModel  });
        }

        #endregion

        public string RenderHtml()
        {
            var result = RazorHelper.Parse("<h1>@Model.Name</h1>", new { Name = "Jason" });
            return result;
        }
    }
}