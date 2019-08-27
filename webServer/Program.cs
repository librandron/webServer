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

namespace webServer
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpListener listener = new HttpListener();

            listener.Prefixes.Add("http://*:8881/");
            listener.Start();
            while(listener.IsListening)
                {
                var pathIndex = @"D:\";
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;



                var requestPathFile = pathIndex + request.Url.LocalPath;

                if(File.Exists(requestPathFile))
                {
                    string file;
                    byte[] fileAsByte;
                    Stream output;

                    if (request.Url.LocalPath.Contains("part.html"))
                        HandleParticipantsRoute(response, requestPathFile, out file, out fileAsByte, out output);

                }


                    file = File.ReadAllText(requestPathFile);

                    fileAsByte = System.Text.Encoding.UTF8.GetBytes(file);
                    response.ContentLength64 = fileAsByte.Length;
                    var output = response.OutputStream;
                    var output.Write(fileAsByte, 0, fileAsByte.Length);
                    var output.Close();
                }


            }

        private static void HandleParticipantsRoute(HttpListenerResponse response, string requestPathFile, out string file, out byte[] fileAsByte, out Stream output)
        {
            file = File.ReadAllText(requestPathFile);
            var fileJson = File.ReadAllLines(@"D:\");
            //Database data = JsonConvert.DeserializeObject<Database>(fileJson);


            fileAsByte = System.Text.Encoding.UTF8.GetBytes(file);
            response.ContentLength64 = fileAsByte.Length;
            output = response.OutputStream;
            output.Write(fileAsByte, 0, fileAsByte.Length);
            output.Close();
        }


        public static void HandleVoteRouter(string queryString)
        {
            var params2 = HttpUtility.ParseQueryString(queryString);
            if(params2["attend"]=="true")
            {
                var name = params2["name"];
                var fileJson = File.ReadAllText();
                Database data = JsonConvert.DeserializeObject<Database>(fileJson);
                data.users.Add(new Users() { name = name});//add to JSON

                File.WriteAllText(JsonConvert.SerializeObject(data));

            }
        }
    }



    }
}
