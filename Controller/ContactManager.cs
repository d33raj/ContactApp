using ContactApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Controller
{
    internal class ContactManager
    {
        public Contact GetContactById(User user, int contactId)
        { 
            return user.Contacts.Find(c => c.ContactId == contactId); 
        }

        public void Add(User user, Contact contact)
        {
            user.Contacts.Add(contact);
        }

        public void ModifyContact(User user, Contact contact)
        {
            var existingContact = GetContactById(user, contact.ContactId);
            if (existingContact != null && existingContact.IsActive)
            {
                existingContact.FirstName = contact.FirstName;
                existingContact.LastName = contact.LastName;
            }
        }

        public void SoftDeleteContact(User user, int contactId)
        {
            var contact = GetContactById(user, contactId);
            if (contact != null)
            {
                contact.IsActive = false;
            }
        }

        public List<Contact> AllContacts(User user)
        {
            return user.Contacts;
        }

        public Contact FindContact(User user, int contactId)
        {
            return GetContactById(user, contactId);
        }
    }
}
