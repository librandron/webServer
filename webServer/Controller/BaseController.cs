using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace webServer.Controller
{
    abstract class BaseController
    {
        public abstract void Handle(HttpListenerContext httpContext);

        public string GetView(string viewName)
        {
            var pathIndex = @"d:\";
            if (File.Exists(pathIndex + viewName))
            {
                return  File.ReadAllText(pathIndex + viewName);
            }

            return string.Empty;
                
        }

        public void Render(HttpListenerContext httpContext, string html)
        {
            var fileAsByte = System.Text.Encoding.UTF8.GetBytes(html);
            httpContext.Response.ContentLength64 = fileAsByte.Length;
            var output = httpContext.Response.OutputStream;
            output.Write(fileAsByte, 0, fileAsByte.Length);
            output.Close();
        }
    }
}
