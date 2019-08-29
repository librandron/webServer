using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace webServer.Controller
{
    class VoteController : BaseController
    {
        public override void Handle(HttpListenerContext httpContext)
        {
            var fileJson = File.ReadAllText(Program.dataBaseSpase);
            DataBase data = JsonConvert.DeserializeObject<DataBase>(foleJson);
            var userList = "";
            foreach (var user in collectidata.users)
            {
                userList += $@"<li>{user.name}</li>";

            }

        }
    }
}
