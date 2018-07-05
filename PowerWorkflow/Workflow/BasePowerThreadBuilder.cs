using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

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

            PatchNodes(result.Context);

            result.SetCurrentNode(PowerThreadDefaultNodes.DefaultStartNode);
            result.SetState(Enums.PowerThreadState.Initial);
            return result;
        }

        public abstract void PatchNodes(PowerThreadContext context);

        public PowerThread BuildFromSink(Guid threadId, string sinkJson)
        {
            if (sinkJson != null)
            {
                PowerThread result = JsonConvert.DeserializeObject<PowerThread>(sinkJson);

                /**/
                result.Context = new PowerThreadContext(result);
                result.CurrentNode =
                    result.Nodes.First(p => p.ObjectId == result.CurrentNode.ObjectId);

                PatchNodes(result.Context);

                return result;
            }

            return null;
        }

        protected abstract IList<PowerThreadForm> BuildForms(PowerThreadContext context);

        protected abstract IList<PowerThreadView> BuildViews(PowerThreadContext context);

        protected abstract IList<PowerThreadNode> BuildNodes(PowerThreadContext context);

        protected abstract IList<PowerThreadRole> BuildRoles(PowerThreadContext context);

        protected abstract PowerThreadStateMachine BuildStateMachine(PowerThreadContext context);

        protected abstract IList<PowerVariable> BuildVariables(PowerThreadContext context);
    }
}