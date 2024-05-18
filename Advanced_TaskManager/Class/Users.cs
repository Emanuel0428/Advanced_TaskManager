using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_TaskManager.Class
{
    internal class User
    {
        public string Username { get; }
        public string Password { get; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
