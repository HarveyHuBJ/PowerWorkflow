using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PowerWorkflow.Common;
using PowerWorkflow.Workflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerWorkflowTests.Json
{
    [TestClass()]
    public class TestJsonTests
    {
        [TestMethod()]
        public void JObjectTest()
        {

            var s = Newtonsoft.Json.JsonConvert.SerializeObject(new Foo { Name = "abc", age = 10 });

            // var o = "{name:'ada'}";
             var o = JsonConvert.DeserializeObject< Foo>(s);


            //var m = RazorHelper.Parse<Foo>("<h1>say @Model.Name</h1>", new Foo { Name = "abc", age = 10 } );

            var m =
              //RazorHelper.Parse("<h1>@Model.Name</h1>", new { Name = "Jason" });
              RazorHelper.Parse("<h1>@Model.Name</h1>", new   { Name = "abc", age = 10 });
            Console.WriteLine(m);

        }


    }

    internal class Foo
    {
        public string Name;
        public int age { get; set; }
    }
}
