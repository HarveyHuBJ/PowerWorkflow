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
        public void BuildTest()
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

        private void PrintThreadCurrentNode(PowerThread thread)
        {
            Console.WriteLine(thread.CurrentNode?.Name + " " + thread.State);
        }
    }
}