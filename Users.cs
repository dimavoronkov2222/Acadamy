using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Acadamy
{
    public class Users
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public Users(string username, string password, int role)
        {
            Username = username;
            Password = password;
            Role = role;
        }
    }
}