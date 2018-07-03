using System;
using System.Collections.Generic;

namespace PowerWorkflow.Workflow
{
    public abstract class BasePowerThreadBuilder
    {
        protected PowerThreadDescription PowerThreadDescription { get; }
        protected Guid ObjectId { get; }
        protected string Name { get; }

        public BasePowerThreadBuilder(PowerThreadDescription powerThreadDescription, Guid objectId, string name)
        {
            this.PowerThreadDescription = powerThreadDescription;
            this.ObjectId = objectId;
            this.Name = name;
        }

        public PowerThread Build()
        {
            PowerThread result = new PowerThread(ObjectId, Name);
            result.Roles = BuildRoles(result.Context);
            result.Views = BuildViews(result.Context);
            result.Forms = BuildForms(result.Context);
            result.Variables = BuildVariables(result.Context);
            result.Nodes = BuildNodes(result.Context);
            result.StateMachine = BuildStateMachine(result.Context);

            result.SetCurrentNode(PowerThreadDefaultNodes.DefaultStartNode);
            result.SetState(Enums.PowerThreadState.Initial);
            return result;
        }
         

        protected abstract IList<PowerThreadForm> BuildForms(PowerThreadContext context);

        protected abstract IList<PowerThreadView> BuildViews(PowerThreadContext context);

        protected abstract IList<PowerThreadNode> BuildNodes(PowerThreadContext context);

        protected abstract IList<PowerThreadRole> BuildRoles(PowerThreadContext context);

        protected abstract PowerThreadStateMachine BuildStateMachine(PowerThreadContext context);

        protected abstract IList<PowerVariable> BuildVariables(PowerThreadContext context);
    }
}