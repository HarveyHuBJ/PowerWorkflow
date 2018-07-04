using RazorEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using RazorEngine.Templating;

namespace PowerWorkflow.Common
{
    public class RazorHelper
    {
        //public static string Parse<T>(HttpContext context, string virtualPath, T Model)
        //{
        //    string path = context.Server.MapPath(virtualPath);
        //    string templateSource = File.ReadAllText(path);
        //    //设置cacheName缓存。
        //    string cacheName = path + File.GetLastWriteTime(path);



        //    //string result = Razor.Parse<T>(rawhtml, Model, cacheName);

        //    var result = RazorEngine.Engine.Razor.RunCompile(templateSource, cacheName, null, Model);

        //    return result;
        //}



        public static string Parse<T>(string templateContent, T Model, string templateKey = "defaultTemplate")
        {


            //string result = Razor.Parse<T>(rawhtml, Model, cacheName);

            var result = RazorEngine.Engine.Razor.RunCompile(templateContent, templateKey, null, Model);

            return result;
        }
    }
}
