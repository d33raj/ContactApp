using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Models
{
    internal class Contact
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; } = true;
        public List<ContactDetails> ContactDetails { get; set; } = new List<ContactDetails>();

        public Contact(int contactId, string firstName, string lastName)
        {
            ContactId = contactId;
            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString()
        {
            return $"Contact ID: {ContactId}\nContact Full Name: {FirstName + " " + LastName}\nContact Is Active: {IsActive}";
        }
    }
}
