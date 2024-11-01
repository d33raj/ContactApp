using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ContactApp.Models
{
    internal class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }=true;
        public bool IsActive { get; set; } = true;
        public List<Contact> Contacts { get; set; }= new List<Contact>();

        public User(int userId, string firstName, string lastName, bool isAdmin)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            IsAdmin = isAdmin;
        }

        public override string ToString()
        {
            return $"User ID: {UserId}\nUser Name: {FirstName+" "+LastName}\nUser Is Admin:{IsAdmin}\nUser Is Active: {IsActive}";
        }
    }

}
