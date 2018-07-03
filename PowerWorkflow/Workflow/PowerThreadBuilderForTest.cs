using System;
using System.Collections.Generic;

namespace PowerWorkflow.Workflow
{
    public class PowerThreadBuilderForTest : BasePowerThreadBuilder
    {
        public PowerThreadBuilderForTest(PowerThreadDescription powerThreadDescription, Guid objectId, string name)
            : base(powerThreadDescription, objectId, name)
        {
        }

        protected override PowerThreadStateMachine BuildStateMachine(PowerThreadContext context)
        {
            Guid[] ids = new Guid[] {
                Guid.NewGuid(),Guid.NewGuid(),Guid.NewGuid(),Guid.NewGuid(),Guid.NewGuid()
            };

            PowerThreadStateMachine result = new PowerThreadStateMachine();
            result.Transmissions = new List<Transmission> {
                   new Transmission(
                       PowerThreadDefaultNodes.DefaultStartNode,
                    new PowerThreadNode(ids[0], "node1",context )
                    ),

                  new Transmission(
                    new PowerThreadNode(ids[0], "node1",context )
                    ,new PowerThreadNode(ids[1], "node2",context )
                    ),

                   new Transmission(
                    new PowerThreadNode(ids[1], "node2",context )
                    ,new PowerThreadNode(ids[2], "node3",context )
                    ),

                    new Transmission(
                    new PowerThreadNode(ids[2], "node3",context )
                    ,  PowerThreadDefaultNodes.DefaultEndNode
                    )
        };

            return result;
        }

        protected override IList<PowerVariable> BuildVariables(
          PowerThreadContext context)
        {
            return new List<PowerVariable>();
        }

        protected override IList<PowerThreadForm> BuildForms(
          PowerThreadContext context)
        {
            return new List<PowerThreadForm>();
        }

        protected override IList<PowerThreadRole> BuildRoles(
          PowerThreadContext context)
        {
            return new List<PowerThreadRole>();
        }

        protected override IList<PowerThreadNode> BuildNodes(
          PowerThreadContext context)
        {
            return new List<PowerThreadNode>();
        }


    }
}