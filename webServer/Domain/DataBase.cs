using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webServer.Domain
{
    class Database
    {
        private List<Users> users { get; set;}

        public List<Users> GetAll()
        {
            if(users == null)
            {
                var fileJson = File.ReadAllText(Program.dataBaseSpase);
                Database data = JsonConvert.DeserializeObject<DataBase>(fileJson);

                users = data.users;

            }
            return users;
        }

        public void AddUser(string name)
        {
            users.Add(new Users() { name = name });
            File.WriteAllText(Program.dataBaseSpace, JsonConvert.DeserializeObject(data));
        }

    }

    class Users
    {
        public string name { get; set; };

    }



}
