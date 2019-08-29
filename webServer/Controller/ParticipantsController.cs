using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace webServer.Controller
{
    class ParticipantsController : BaseController
    {
        public override void Handle(HttpListenerContext httpContext)
        {
            var fileJson = File.ReadAllText(Program.dataBaseSpase);
            DataBase data = JsonConvert.DeserializeObject<DataBase>(fileJson);
            var userList = "";
            foreach (var user in data.users)
            {
                userList += $@"<li>{user.name}</li>";
            }

            var html = GetView();
        }
    }
}
