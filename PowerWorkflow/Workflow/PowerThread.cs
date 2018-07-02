using PowerWorkflow.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PowerWorkflow.Workflow
{
    public class PowerThread : PowerThreadBaseObject
    {
        public PowerThread(string name):base(name)
        {
            this.Context = new PowerThreadContext(this);
        }

        public PowerThreadContext Context { get; set; }

        public IList<PowerThreadNode> Nodes
        {
            get; set;
        }

        public IList<PowerThreadRole> Roles
        {
            get; set;
        }

        internal void SetCurrentNode(object toNode)
        {
            throw new NotImplementedException();
        }

        internal void SetState(PowerThreadState state)
        {
            this.State = state;
        }

        public IList<PowerThreadForm> Forms
        {
            get; set;
        }

        public IList<PowerThreadView> Views
        {
            get; set;
        }

        public IList<PowerVariable> Variables
        {
            get; set;
        }

        public PowerThreadStateMachine StateMachine { get; set; }
        public PowerThreadState State { get; private set; }

        public void GoNextNode(PowerThreadNode fromNode)
        {
            // todo
            StateMachine.Next(Context, fromNode);
        }

        internal void TerminateThreadAtNode(PowerThreadNode fromNode)
        {
            StateMachine.TerminateThread(Context, fromNode);
        }

        internal object GetVariable(string variableName, Type variableType)
        {
            var variable = this.Variables.FirstOrDefault(p => p.VariableName == variableName);
            if (variable != null)
            {
                return variable.Value;
            }

            return Activator.CreateInstance(variableType, null);
        }

        internal void SetVariable(string variableName, object value)
        {
            var variable = this.Variables.FirstOrDefault(p => p.VariableName == variableName);
            if (variable != null)
            {
                variable.Value = value;
            }
            else
            {
                variable = new PowerVariable(variableName) {   Value = value };
                this.Variables.Add(variable);
            }
        }
    }
}