using System;
using System.Collections.Generic;

namespace PowerWorkflow.Workflow
{
    public class PowerThreadBuilderForTest : BasePowerThreadBuilder
    {
        private Guid[] FormIds = new Guid[] {
             Guid.Parse("29bcfe3b-2025-4ef7-92cb-a910ec475bc7")
           , Guid.Parse("c6cffcf1-da81-4146-9930-2d8560e8d873")
           , Guid.Parse("aad13fb2-4e75-4690-850c-c6f58224b48b")
        };

        private Guid[] ViewIds = new Guid[] {
             Guid.Parse("a77756e2-a25b-4f01-b100-65c16e0d3894")
           , Guid.Parse("804906f4-b5bc-4250-a448-1f366f1b6e36")
           , Guid.Parse("0ccdf5f5-814d-4707-ba0b-1ffd123b9cc0")
        };

        private Guid[] NodeIds = new Guid[] {
             Guid.Parse("d8c01f83-7b74-41a9-af80-91aa99a7a40d")
           , Guid.Parse("1cec5700-154e-4e80-a724-72815742622a")
           , Guid.Parse("3696c77c-ec4d-4c16-b329-70c5e7672a41")
        };

        public PowerThreadBuilderForTest(Guid objectId, string name, PowerThreadDescription powerThreadDescription)
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
                new PowerThreadForm(FormIds[0], "form1", "_testdata/forms/form1.cshtml")
               , new PowerThreadForm(FormIds[1], "form2", "_testdata/forms/form2.cshtml")
               , new PowerThreadForm(FormIds[2], "form3", "_testdata/forms/form3.cshtml")
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

            var items = new List<PowerThreadNode>() {
                new PowerThreadNode(NodeIds[0], "node1")
               ,new PowerThreadNode(NodeIds[1], "node2")
               ,new PowerThreadNode(NodeIds[2], "node3")
            };
            
            return items;
        }

        public override void PatchNodes(PowerThreadContext context )
        {

            var forms = context.PowerThread.Forms;
            var views = context.PowerThread.Views;
            var nodes = context.PowerThread.Nodes;

            foreach (var node in nodes)
            {
                node.SetContext(context);
            }

            nodes[0].RegisterDefaultForm(forms[0]);
            nodes[1].RegisterDefaultForm(forms[1]);
            nodes[2].RegisterDefaultForm(forms[2]);

            nodes[0].RegisterDefaultView(views[0]);
            nodes[1].RegisterDefaultView(views[1]);
            nodes[2].RegisterDefaultView(views[2]);
        }

        protected override IList<PowerThreadView> BuildViews(PowerThreadContext context)
        {
            var items = new List<PowerThreadView>() {
                new PowerThreadView( ViewIds[0],  "view1", "/views/view1.cshtml")
               , new PowerThreadView(ViewIds[1], "view2", "/views/view2.cshtml")
               , new PowerThreadView(ViewIds[2], "view3", "/views/view3.cshtml")
            };

            return items;
        }
    }
}