using PowerWorkflow.Workflow.Events;
using System;
using RazorEngine;
using PowerWorkflow.Common;
using System.IO;

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

        public event PowerThreadNodeLoadEvent LoadForm;

        #endregion

        public PowerThreadForm(Guid objectId, string name, string formPath) : base(objectId, name)
        {

            this.FormPath = formPath;
            this.BindingViewModel = new PowerThreadEntity(Guid.NewGuid(), name + "-Entity");
        }

        #region actions of form


        public void Go()
        {
            GoNext?.Invoke(this, new PowerThreadNodeGoNextEventArgs());
        }

        public void Save()
        {

            SaveForm?.Invoke(this, new PowerThreadNodeSaveFormEventArgs() { Entity = BindingViewModel });
        }

        public void Load()
        {
            LoadForm?.Invoke(this, new PowerThreadNodeLoadEventArgs());
        }
        #endregion

        public string RenderHtml()
        {
            var cshtml = File.ReadAllText(this.FormPath);
            var result = RazorHelper.Parse(cshtml, BindingViewModel.Data, this.FormPath);
            return result;
        }
    }
}