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
            var nodes = context.PowerThread.Nodes;

            PowerThreadStateMachine result = new PowerThreadStateMachine();
            result.Transmissions = new List<Transmission> {
                   new Transmission( PowerThreadDefaultNodes.DefaultStartNode, nodes[0]),
                   new Transmission( nodes[0],nodes[1]),
                   new Transmission( nodes[1],nodes[2]),
                   new Transmission(nodes[2],  PowerThreadDefaultNodes.DefaultEndNode )
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
            var items = new List<PowerThreadForm>() {
                new PowerThreadForm(Guid.NewGuid(), "form1", "/forms/form1.cshtml")
               , new PowerThreadForm(Guid.NewGuid(), "form2", "/forms/form2.cshtml")
               , new PowerThreadForm(Guid.NewGuid(), "form3", "/forms/form3.cshtml")
            };

            return items;
        }

        protected override IList<PowerThreadRole> BuildRoles(
          PowerThreadContext context)
        {
            return new List<PowerThreadRole>();
        }

        protected override IList<PowerThreadNode> BuildNodes(
          PowerThreadContext context)
        {
            var forms = context.PowerThread.Forms;
            var views = context.PowerThread.Views;

            var items = new List<PowerThreadNode>() {
                new PowerThreadNode(Guid.NewGuid(), "node1", context) 
               ,new PowerThreadNode(Guid.NewGuid(), "node2", context) 
               ,new PowerThreadNode(Guid.NewGuid(), "node3", context) 
            };

            items[0].RegisterDefaultForm(forms[0]);
            items[1].RegisterDefaultForm(forms[1]);
            items[2].RegisterDefaultForm(forms[2]);


            items[0].RegisterDefaultView(views[0]);
            items[1].RegisterDefaultView(views[1]);
            items[2].RegisterDefaultView(views[2]);

            return items;
        }

        protected override IList<PowerThreadView> BuildViews(PowerThreadContext context)
        {
            var items = new List<PowerThreadView>() {
                new PowerThreadView(Guid.NewGuid(),  "view1", "/views/view1.cshtml")
               , new PowerThreadView(Guid.NewGuid(), "view2", "/views/view2.cshtml")
               , new PowerThreadView(Guid.NewGuid(), "view3", "/views/view3.cshtml")
            };

            return items;
        }
    }
}