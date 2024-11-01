using ContactApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Controller
{
    internal class UserManager
    {
        public List<User> users;
        public UserManager() 
        {
            users = new List<User>
            {
            new User(1, "Dheeraj", "kumar", true),
            new User(2,"Murali","Krishna",false),
            new User(3, "Arvind", "Sharma", false)
            };
        }

        public User GetUserById(int id)
        {
            return users.Find(u => u.UserId == id);
        }

        public void Add(User user)
        {
            users.Add(user);
        }

        public void Modify(User user) 
        {
            var existingUser = GetUserById(user.UserId);
            if (existingUser != null && existingUser.IsActive) 
            {
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.IsAdmin = user.IsAdmin;
            }
        }

        public void Delete(int id)
        {
            var user=GetUserById(id);
            if (user != null) 
                user.IsActive = false;

        }

        public List<User> AllUsers()
        {
            return users;
        }
    }
}
