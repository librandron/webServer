using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using webServer.Domain;
using System.Web;
using webServer.Controller;

namespace webServer
{
    class Program
    {
        static void Main(string[] args)
        {

            string file;
            byte[] fileAsByte;
            Stream output;
            HttpListener listener = new HttpListener();

            listener.Prefixes.Add("http://*:8881/");
            listener.Start();
            while (listener.IsListening)
            {
                var pathIndex = @"D:\";
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;
                BaseController targetController;

                if (request.Url.LocalPath.Contains("vote"))
                {
                    targetController = new VoteController();
                }
                else if (request.Url.LocalPath.Contains("part"))
                {
                    targetController = new ParticipantsController();
                }
                else
                {
                    targetController = new IndexController();
                }
                targetController.Handle(context);
            }
        }

    }
}
