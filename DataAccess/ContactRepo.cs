using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ContactRepo : IContact
    {
        private readonly masterContext _context;
        public ContactRepo(masterContext context)
        {
            _context = context;
        }

        public Contact CreateContact(Contact contact)
        {
            throw new NotImplementedException();
        }

        public void DeleteContact(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Will retreive a list of all contacts
        /// </summary>
        /// <returns>List of all contacts</returns>
        public List<Contact> GetAllContacts()
        {
            try
            {
                return _context.Contacts.ToList();
            }
            catch (ArgumentNullException)
            {
                return new List<Contact>();
            }
        }

        public Contact GetContact(int id)
        {
            throw new NotImplementedException();
        }

        public Contact GetUserContact(int id)
        {
            throw new NotImplementedException();
        }

        public Contact UpdateContact(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
