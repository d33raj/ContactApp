using ContactApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Controller
{
    internal class ContactDetailsManager
    {
        public ContactDetails GetContactDetailById(Contact contact, int detailId)
        {
            return contact.ContactDetails.Find(cd => cd.ContactDetailId == detailId);
        }

        public void AddContactDetail(Contact contact, ContactDetails contactDetail)
        {
            contact.ContactDetails.Add(contactDetail);
        }

        public void ModifyContactDetail(Contact contact, ContactDetails contactDetail)
        {
            var existingDetail = GetContactDetailById(contact, contactDetail.ContactDetailId);
            if (existingDetail != null && existingDetail.IsActive)
            {
                existingDetail.Type = contactDetail.Type;
                existingDetail.Detail = contactDetail.Detail;
            }
        }

        public void SoftDeleteContactDetail(Contact contact, int detailId)
        {
            var detail = GetContactDetailById(contact, detailId);
            if (detail != null)
            {
                detail.IsActive = false;
            }
        }

        public List<ContactDetails> GetAllContactDetails(Contact contact)
        {
            return contact.ContactDetails;
        }

        public ContactDetails FindContactDetail(Contact contact, int detailId)
        {
            return GetContactDetailById(contact, detailId);
        }
    }
}
