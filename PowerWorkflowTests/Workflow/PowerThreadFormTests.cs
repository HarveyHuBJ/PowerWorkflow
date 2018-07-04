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
    public class PowerThreadFormTests
    {
        [TestMethod()]
        public void RenderHtmlTest()
        {
            PowerThreadForm form = new PowerThreadForm(Guid.Empty, null, null);

            var s = form.RenderHtml();

            Console.WriteLine(s);
        }
    }
}