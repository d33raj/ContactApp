using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Models
{
    internal class ContactDetails
    {
        public int ContactDetailId { get; set; } 
        public string Type { get; set; }
        public string Detail { get; set; }
        public bool IsActive { get; set; } = true;

        public ContactDetails(int contactDetailId, string type, string detail)
        {
            ContactDetailId = contactDetailId;
            Type = type;
            Detail = detail;
        }

        public override string ToString()
        {
            return $"Contact Details ID: {ContactDetailId}\nContact Detail Type: {Type}\nContact Details: {Detail}\nContact Is Active: {IsActive}";
        }
    }
}
