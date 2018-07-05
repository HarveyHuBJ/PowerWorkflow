using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
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
            PowerThreadBuilderForTest builder = new PowerThreadBuilderForTest(Guid.NewGuid(), "test thread", description);
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
            PowerThreadBuilderForTest builder = new PowerThreadBuilderForTest(Guid.NewGuid(), "test thread", description);
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
            PowerThreadBuilderForTest builder = new PowerThreadBuilderForTest(Guid.NewGuid(), "test thread", description);
            var thread = builder.Build();

            PrintThreadCurrentNode(thread);


            RoleSettings roleSettings = new RoleSettings();
            Dictionary<string, string> varialbes = new Dictionary<string, string>();
            thread.StartWith(roleSettings, varialbes);
            PrintThreadCurrentNode(thread);

            var html = thread.CurrentNode.DefaultForm.RenderHtml();
            //  var html2 = thread.CurrentNode.RenderPage();


        }

        [TestMethod()]
        public void Builder_04RenderNodePage_Test()
        {
            PowerThreadDescription description = new PowerThreadDescription();
            PowerThreadBuilderForTest builder =
                new PowerThreadBuilderForTest(Guid.NewGuid(), "test thread", description);
            var thread = builder.Build();

            PrintThreadCurrentNode(thread);


            RoleSettings roleSettings = new RoleSettings();
            Dictionary<string, string> varialbes = new Dictionary<string, string>();
            thread.StartWith(roleSettings, varialbes);
            PrintThreadCurrentNodePage(thread);

            thread.CurrentNode.DefaultForm.Go();
            PrintThreadCurrentNodePage(thread);
            thread.CurrentNode.DefaultForm.Go();
            PrintThreadCurrentNodePage(thread);
            thread.CurrentNode.DefaultForm.Go();
            PrintThreadCurrentNodePage(thread);

        }

        [TestMethod()]
        public void Builder_05SinkAndEmerge_Test()
        {

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
              
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            };


            Guid ThreadObjectId = Guid.Parse("a44dacf8-ffc4-485d-9eb9-d9693304e276");

            PowerThreadDescription description = new PowerThreadDescription();
            PowerThreadBuilderForTest builder =
                new PowerThreadBuilderForTest(ThreadObjectId, "test thread", description);
            var thread = builder.Build();


            PrintThreadCurrentNode(thread);

          

            RoleSettings roleSettings = new RoleSettings();
            Dictionary<string, string> varialbes = new Dictionary<string, string>();
            thread.StartWith(roleSettings, varialbes);

            var t = JsonConvert.SerializeObject(thread.CurrentNode.DefaultForm.BindingViewModel);
            var tt = JsonConvert.DeserializeObject<PowerThreadEntity>(t);

            var s = thread.Sink();



            var threadRevived = builder.BuildFromSink(thread.Id, s);

            PrintThreadCurrentNodePage(threadRevived);

            threadRevived.CurrentNode.DefaultForm.Go();
            PrintThreadCurrentNodePage(threadRevived);

            thread.CurrentNode.DefaultForm.Go();
            PrintThreadCurrentNodePage(thread);

            thread.CurrentNode.DefaultForm.Go();
            PrintThreadCurrentNodePage(thread);
        }



        private void PrintThreadCurrentNode(PowerThread thread)
        {
            Console.WriteLine(thread.CurrentNode?.Name + " " + thread.State);
        }
        private void PrintThreadCurrentNodePage(PowerThread thread)
        {
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine(thread.CurrentNode?.Name + " " + thread.State);
            Console.WriteLine(thread.CurrentNode?.DefaultForm?.RenderHtml());
            //Console.WriteLine(thread.CurrentNode.DefaultView.RenderHtml());
            Console.WriteLine();
        }
    }
}