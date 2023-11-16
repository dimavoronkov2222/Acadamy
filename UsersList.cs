using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Acadamy
{
    public class UsersList
    {
        public List<Users> users { get; set; }
        public UsersList()
        {
            users = new List<Users>();
        }
        public void AddUser(Users user)
        {
            users.Add(user);
        }
        public Users GetUser(string username, string password)
        {
            foreach (var user in users)
            {
                if (user.Username == username && user.Password == password)
                    return user;
            }
            return null;
        }
    }
}