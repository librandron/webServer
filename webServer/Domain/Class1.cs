using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webServer.Domain
{
    class Database
    {
        public List<Users> users { get; set;}

    }

    class Users
    {
        public string name { get; set; };

    }


}
