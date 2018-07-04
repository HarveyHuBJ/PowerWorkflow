using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerWorkflow.Workflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerWorkflow.Workflow.Tests
{
    [TestClass()]
    public class PowerThreadBuilderTests
    {
        [TestMethod()]
        public void Builder_01ThreadNextNode_Test()
        {
            PowerThreadDescription description = new PowerThreadDescription();
            PowerThreadBuilderForTest builder = new PowerThreadBuilderForTest(description, Guid.NewGuid(), "test thread");
            var thread = builder.Build();

            PrintThreadCurrentNode(thread);


            RoleSettings roleSettings = new RoleSettings();
            Dictionary<string, string> varialbes = new Dictionary<string, string>();
            thread.StartWith(roleSettings, varialbes);

            PrintThreadCurrentNode(thread);


            thread.GoNextNode(thread.CurrentNode);
            PrintThreadCurrentNode(thread);


            thread.GoNextNode(thread.CurrentNode);
            PrintThreadCurrentNode(thread);

            thread.GoNextNode(thread.CurrentNode);
            PrintThreadCurrentNode(thread);

            thread.GoNextNode(thread.CurrentNode);
            PrintThreadCurrentNode(thread);
            //  thread.TerminateThreadAtNode(thread.CurrentNode);

        }

        [TestMethod()]
        public void Builder_02FormNextNode_Test()
        {
            PowerThreadDescription description = new PowerThreadDescription();
            PowerThreadBuilderForTest builder = new PowerThreadBuilderForTest(description, Guid.NewGuid(), "test thread");
            var thread = builder.Build();

            PrintThreadCurrentNode(thread);


            RoleSettings roleSettings = new RoleSettings();
            Dictionary<string, string> varialbes = new Dictionary<string, string>();
            thread.StartWith(roleSettings, varialbes);
            PrintThreadCurrentNode(thread);

            thread.CurrentNode.DefaultForm.Go();
            PrintThreadCurrentNode(thread);
            thread.CurrentNode.DefaultForm.Go();
            PrintThreadCurrentNode(thread);
            thread.CurrentNode.DefaultForm.Go();
            PrintThreadCurrentNode(thread);

        }

        [TestMethod()]
        public void Builder_03RenderForm_Test()
        {
            PowerThreadDescription description = new PowerThreadDescription();
            PowerThreadBuilderForTest builder = new PowerThreadBuilderForTest(description, Guid.NewGuid(), "test thread");
            var thread = builder.Build();

            PrintThreadCurrentNode(thread);


            RoleSettings roleSettings = new RoleSettings();
            Dictionary<string, string> varialbes = new Dictionary<string, string>();
            thread.StartWith(roleSettings, varialbes);
            PrintThreadCurrentNode(thread);

            var html = thread.CurrentNode.DefaultForm.RenderHtml();
            var html2 = thread.CurrentNode.RenderPage();


        }


            private void PrintThreadCurrentNode(PowerThread thread)
        {
            Console.WriteLine(thread.CurrentNode?.Name + " " + thread.State);
        }
    }
}