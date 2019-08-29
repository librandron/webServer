using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace webServer.Controller
{
    class IndexController : BaseController
    {
        public override void Handle(HttpListenerContext httpContext)
        {
            var html = GetView("index.html");
            Render(httpContext, html);
        }
    }
}
