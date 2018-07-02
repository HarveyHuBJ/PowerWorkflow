using PowerWorkflow.Description;
using System;
using System.Collections.Generic;

namespace PowerWorkflow.Workflow
{
    public class PowerThreadBuilder
    {
        //public PowerThreadDescription CreateThreadDefinition(Root root)
        //{
        //    PowerThreadDescription result = new PowerThreadDescription();
        //    return result;
        //}

        public PowerThread Build(PowerThreadDescription powerThreadDescription, Guid objectId, string name)
        {
            PowerThread result = new PowerThread(objectId, name);
            result.Nodes = BuildNodes(powerThreadDescription, result.Context);
            result.Roles = BuildRoles(powerThreadDescription, result.Context);
            result.Forms = BuildForms(powerThreadDescription, result.Context);
            result.Variables = BuildVariables(powerThreadDescription, result.Context);
            result.StateMachine = BuildStateMachine(powerThreadDescription, result.Context);

            result.SetCurrentNode(PowerThreadDefaultNodes.DefaultStartNode);
            result.SetState(Enums.PowerThreadState.Initial);
            return result;
        }


        private PowerThreadStateMachine BuildStateMachine(
            PowerThreadDescription powerThreadDescription,
            PowerThreadContext context
            )
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

        private IList<PowerVariable> BuildVariables(
            PowerThreadDescription powerThreadDescription,
            PowerThreadContext context)
        {
            return new List<PowerVariable>();
        }

        private IList<PowerThreadForm> BuildForms(
            PowerThreadDescription powerThreadDescription,
            PowerThreadContext context)
        {
            return new List<PowerThreadForm>();

        }

        private IList<PowerThreadRole> BuildRoles(
            PowerThreadDescription powerThreadDescription,
            PowerThreadContext context)
        {
            return new List<PowerThreadRole>();

        }

        private IList<PowerThreadNode> BuildNodes(
            PowerThreadDescription powerThreadDescription,
            PowerThreadContext context)
        {
            return new List<PowerThreadNode>();
        }
    }
}