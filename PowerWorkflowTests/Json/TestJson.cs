using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PowerWorkflow.Common;
using PowerWorkflow.Workflow;
using System;
using System.Collections.Generic;
using System.Dynamic;
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

            var s = Newtonsoft.Json.JsonConvert.SerializeObject(new Foo{ Name = "abc", age = 10 });

            // var o = "{name:'ada'}";
            var o = JsonConvert.DeserializeObject<ExpandoObject>(s);
            var o2 = JsonConvert.DeserializeObject<Foo>(s);

            Console.WriteLine(o.GetType().ToString());
            Console.WriteLine(o2.GetType().ToString());

           

           

            Console.WriteLine(JsonConvert.SerializeObject(o));

            //var m = RazorHelper.Parse<Foo>("<h1>say @Model.Name</h1>", new Foo { Name = "abc", age = 10 } );

            var m =
              //RazorHelper.Parse("<h1>@Model.Name</h1>", new { Name = "Jason" });
             // RazorHelper.Parse("<h1>@Model.Name</h1>", new { Name = "abc", age = 10 });
              RazorHelper.Parse("<h1>@Model.Name</h1>", o);
            Console.WriteLine(m);

        }


    }
}
