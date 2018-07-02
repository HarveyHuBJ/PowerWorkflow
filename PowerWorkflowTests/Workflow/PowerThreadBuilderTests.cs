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
            PowerThreadBuilder builder = new PowerThreadBuilder();
            PowerThreadDescription description = new PowerThreadDescription();
            var thread = builder.Build(description, Guid.NewGuid(), "test thread");

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