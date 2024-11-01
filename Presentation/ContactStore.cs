using ContactApp.Controller;
using ContactApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Presentation
{
    internal class ContactStore
    {
        public UserManager manager=new UserManager();
        public ContactManager contactmanager = new ContactManager();
        public ContactDetailsManager contactDetailsManager = new ContactDetailsManager();
        public void Start()
        {
            while (true) 
            {
                Console.Write("Enter UserId: ");
                int userId = int.Parse(Console.ReadLine());

                var user = manager.GetUserById(userId);
                if (user == null || !user.IsActive)
                    Console.WriteLine("No such User Exists or is Inactive");

                if (user.IsAdmin)
                    AdminMenu(user);
                else
                    StaffMenu(user);
            }
        }

        public void AdminMenu(User user)
        {
            while (true)
            {
                Console.WriteLine($"Welcome to Admin Menu. What do you wish to do?" +
                    $"\n1. Add New User \n2. Modify User \n3. Soft Delete User \n4. Display All Users \n5. Find User \n6. Logout \n7.Exit Application");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddUser();
                        break;
                    case 2:
                        EditUser();
                        break;
                    case 3:
                        SoftDeleteUser();
                        break;
                    case 4:
                        DisplayUsers();
                        break;
                    case 5:
                        FindUsers();
                        break;
                    case 6: return;
                    case 7: Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Enter Correct Option :) ");
                        break;
                }
            }

        }

        public void StaffMenu(User user)
        {
            while (true)
            {
                Console.WriteLine($"Welcome to Staff Menu. What do you wish to do?" +
                    $"\n1. Work on Contacts.\n2. Work on Contact Details.\n3. Logout.\n4. Exit Application");
                int choice = int.Parse(Console.ReadLine());
                switch(choice)
                {
                    case 1: ContactMenu(user);
                        break;

                    case 2: ContactDetailsMenu(user);
                        break;

                    case 3: return;

                    case 4:
                        Environment.Exit(0);
                        break;

                    default: 
                        Console.WriteLine("Invalid Choice! Enter Correct Option :)");
                        break;
                }
            } 
        }

        public void ContactMenu(User user)
        {
            while (true)
            {
                Console.WriteLine($"Welcome to Contact Menu." +
                $"\n1. Add New Contact \n2. Modify Contact \n3. Soft Delete Contact " +
                $"\n4. Display All Contacts \n5. Find Contact \n6. Logout");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddContact(user);
                        break;
                    case 2:
                        EditContact(user);
                        break;
                    case 3:
                        SoftDeleteContact(user);
                        break;
                    case 4:
                        DisplayContacts(user);
                        break;
                    case 5:
                        FindContacts(user);
                        break;
                    case 6: return;
                    default:
                        Console.WriteLine("Invalid Choice! Enter Correct Option :)");
                        break;
                }
            }
        }
        public void ContactDetailsMenu(User user) 
        {
            while (true)
            {
                Console.WriteLine($"Welcome to Contact Details Menu." +
                $"\n1. Add New Contact Details \n2. Modify Contact Details \n3. Soft Delete Contact Details " +
                $"\n4. Display All ContactDetails \n5. Find Contact Details \n6. Logout");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddContactDetails(user);
                        break;
                    case 2:
                        EditContactDetails(user);
                        break;
                    case 3:
                        SoftDeleteContactDetails(user);
                        break;
                    case 4:
                        DisplayContactDetails(user);
                        break;
                    case 5:
                        FindContactDetails(user);
                        break;
                    case 6: return;
                    default:
                        Console.WriteLine("Invalid Choice! Enter Correct Option :)");
                        break;
                }
            }
        }

        //******************************************USER MENU METHODS******************************************

        public void AddUser() 
        {
            Console.WriteLine("Enter User ID:");
            int id=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter First Name:");
            string fname=Console.ReadLine();
            Console.WriteLine("Enter Last Name:");
            string lname=Console.ReadLine();
            Console.WriteLine("Select if User IsAdmin or Not ?");
            bool admin=bool.Parse(Console.ReadLine());
            manager.Add(new User(id, fname, lname,admin));
            Console.WriteLine("User Added Succesfully");
        }
        public void EditUser() 
        {

            Console.Write("Enter UserId: ");
            int userId = int.Parse(Console.ReadLine());
            var user = manager.GetUserById(userId);
            if (user != null && user.IsActive)
            {
                Console.WriteLine("Enter New User Id:");
                user.UserId= int.Parse(Console.ReadLine());
                Console.WriteLine("Enter New First Name");
                user.FirstName= Console.ReadLine();
                Console.WriteLine("Enter New Last Name");
                user.LastName= Console.ReadLine();
                Console.WriteLine("Enter if User IsAdmin or Not");
                user.IsAdmin= bool.Parse(Console.ReadLine());
                manager.Modify(user);
                Console.WriteLine("User Modified Succesfully");
            }
            else
                Console.WriteLine("No User Found or User is Inactive\n");
        }
        public void SoftDeleteUser() 
        {
            Console.Write("Enter UserId to Soft Delete: ");
            int userId = int.Parse(Console.ReadLine());
            manager.Delete(userId);
            Console.WriteLine("User is Currently In-Active");

        }
        public void DisplayUsers() 
        {
            var users = manager.AllUsers();
            Console.WriteLine("+++++++++++++++++++++++++++++++++");
            foreach (var user in users)
            { Console.WriteLine(user);
                Console.WriteLine("+++++++++++++++++++++++++++++++++");
            }
        }
        public void FindUsers()
        {
            Console.Write("Enter UserId: ");
            int userId = int.Parse(Console.ReadLine());

            var user = manager.GetUserById(userId);
            Console.WriteLine("+++++++++++++++++++++++++++++++++");
            if (user == null || !user.IsActive)
                Console.WriteLine("No User Exists or User Is Inactive");
            else
                Console.WriteLine(user);
            Console.WriteLine("+++++++++++++++++++++++++++++++++");
        }

        //******************************************CONTACT MENU METHODS******************************************

        public void AddContact(User user) 
        {
            Console.WriteLine("Enter Contact ID:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter First Name:");
            string fname = Console.ReadLine();
            Console.WriteLine("Enter Last Name:");
            string lname = Console.ReadLine();
            contactmanager.Add(user,new Contact(id, fname, lname));
            Console.WriteLine("Contact added Successfully");
        }
        public  void EditContact(User user) 
        {
            Console.WriteLine("Enter Contact ID to Edit:");
            int id=int.Parse(Console.ReadLine());
            var contact = contactmanager.GetContactById(user, id);
            if (contact != null && contact.IsActive)
            {
                Console.WriteLine("Enter First Name:");
                contact.FirstName = Console.ReadLine();
                Console.WriteLine("Enter Last Name:");
                contact.LastName = Console.ReadLine();
                contactmanager.ModifyContact(user, contact);
                Console.WriteLine("Contact Modified :)");
            }
            else
                Console.WriteLine("Contact Not Found or Inactive");
        }
        public void SoftDeleteContact(User user) 
        {
            Console.WriteLine("Enter Contact Id to Soft Delete:");
            int id= int.Parse(Console.ReadLine());
            contactmanager.SoftDeleteContact(user,id);
            Console.WriteLine("Contact Made Inactive");
        }
        public void DisplayContacts(User user) 
        {
           var contacts = contactmanager.AllContacts(user);
           Console.WriteLine("+++++++++++++++++++++++++++++++++");
           foreach (var contact in contacts)
            {   
                Console.WriteLine(contact);
                Console.WriteLine("+++++++++++++++++++++++++++++++++");
            }
        }
        public void FindContacts(User user) 
        {
            Console.WriteLine("Enter Contact ID to Search:");
            int id=int.Parse(Console.ReadLine());
            var contact= contactmanager.FindContact(user, id);
            Console.WriteLine("+++++++++++++++++++++++++++++++++");
            if (contact != null && contact.IsActive)
                Console.WriteLine(contact);
            else
                Console.WriteLine("Contact Not Found or Inactive");
            Console.WriteLine("+++++++++++++++++++++++++++++++++");
        }

        //******************************************CONTACT DETAILS MENU METHODS******************************************

        public void AddContactDetails(User user) 
        {
            Console.WriteLine("Enter Contact Id to Add");
            int id= int.Parse (Console.ReadLine());
            var contact = contactmanager.GetContactById(user, id);
            if (contact != null && contact.IsActive)
            {
                Console.WriteLine("Enter Contact Details ID:");
                int detilsId= int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Contact Details Type Email or Number");
                string detailType= Console.ReadLine();
                Console.WriteLine("Enter Details:");
                string details= Console.ReadLine();

                contactDetailsManager.AddContactDetail(contact, new ContactDetails(detilsId, detailType, details));
                Console.WriteLine("Details Added Successfully");
            }
            else
                Console.WriteLine("No Contact Exists or Inactive");


        }
        public void EditContactDetails(User user) 
        {
            Console.WriteLine("Enter Contact Id to Display Details");
            int id = int.Parse(Console.ReadLine());
            var contact = contactmanager.GetContactById(user, id);
            if (contact != null && contact.IsActive)
            {
                Console.WriteLine("Enter Detail Id to modify: ");
                int detailId = int.Parse(Console.ReadLine());
                var contactDetail = contactDetailsManager.GetContactDetailById(contact, detailId);
                if (contactDetail != null && contactDetail.IsActive)
                {
                    Console.WriteLine("Enter new Type (number/email): ");
                    contactDetail.Type = Console.ReadLine();
                    Console.WriteLine("Enter new Detail: ");
                    contactDetail.Detail = Console.ReadLine();
                    contactDetailsManager.ModifyContactDetail(contact, contactDetail);
                    Console.WriteLine("Contact detail modified successfully!");
                }
                else
                    Console.WriteLine("Contact detail not found or inactive.");
            }
            else
                Console.WriteLine("Contact Not Found or Inactive");
        }
        public void SoftDeleteContactDetails(User user) 
        {
            Console.WriteLine("Enter Contact Id to Display Details");
            int id = int.Parse(Console.ReadLine());
            var contact = contactmanager.GetContactById(user, id);
            if (contact != null && contact.IsActive)
            {
                Console.WriteLine("Enter Contact Detail ID to Delete:");
                int contactId=int.Parse(Console.ReadLine());
                contactDetailsManager.SoftDeleteContactDetail(contact, contactId);
                Console.WriteLine("Contact Details Made Inactive");
            }
            else
                Console.WriteLine("Contact Not Found or Inactive");
        }
        public void DisplayContactDetails(User user) 
        {
            Console.WriteLine("Enter Contact Id to Display Details");
            int id=int.Parse (Console.ReadLine());
            var contact = contactmanager.GetContactById(user, id);
            if (contact != null && contact.IsActive)
            {
                var contactDetails = contactDetailsManager.GetAllContactDetails(contact);
                Console.WriteLine("+++++++++++++++++++++++++++++++++");
                foreach (var contactDetail in contactDetails)
                {
                    Console.WriteLine(contactDetail);
                    Console.WriteLine("+++++++++++++++++++++++++++++++++");
                }
            }
            else
                Console.WriteLine("Conatct Not Found or Inactive");

        }
        public void FindContactDetails(User user) 
        {
            Console.WriteLine("Enter Contact Id to Display Details");
            int id = int.Parse(Console.ReadLine());
            var contact = contactmanager.GetContactById(user, id);
            if (contact != null && contact.IsActive)
            {
                Console.WriteLine("Enter Detail Id to find: ");
                int detailId = int.Parse(Console.ReadLine());
                var contactDetail = contactDetailsManager.FindContactDetail(contact, detailId);

                if (contactDetail != null && contactDetail.IsActive)
                    Console.WriteLine(contactDetail);
                else
                    Console.WriteLine("Contact detail not found or inactive.");
            }
            else
                Console.WriteLine("Contact Not found or Inactive");
        }


    }
}
