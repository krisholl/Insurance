using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Entities;
using CustomExceptions;
namespace Services
{
    public class ContactServices
    {
        private readonly IContact _contact;
        public ContactServices(IContact contact)
        {
            _contact = contact;
        }

        /// <summary>
        /// Will search database for all contacts
        /// </summary>
        /// <returns>List of all contacts in the database</returns>
        /// <exception cref="ContactNotAvailableException">There are no contacts in the database</exception>
        public List<Contact> GetContacts()
        {
            try
            {
                return _contact.GetAllContacts();
            }
            catch (ArgumentNullException)
            {
                throw new ContactNotAvailableException();
            }
            catch (ContactNotAvailableException)
            {
                throw;
            }
        }

        /// <summary>
        /// Will search database for a specific contact
        /// </summary>
        /// <param name="id">ID of contact to search for</param>
        /// <returns>Particular contact</returns>
        /// <exception cref="ContactNotAvailableException">There is no contact with that ID</exception>
        public Contact GetContact(int id)
        {
            try
            {
                return _contact.GetContact(id);
            }
            catch (ArgumentNullException)
            {
                throw new ContactNotAvailableException();
            }
            catch (ContactNotAvailableException)
            {
                throw;
            }
        }

        /// <summary>
        /// Will attempt to create a new contact
        /// </summary>
        /// <param name="newContact">Valid Contact information</param>
        /// <returns>Created Contact</returns>
        public Contact CreateContact(Contact newContact)
        {
            return _contact.CreateContact(newContact);
        }

        /// <summary>
        /// Will attempt to update a contact
        /// </summary>
        /// <param name="contactToUpdate">Contact information</param>
        /// <returns>Updated Contact</returns>
        /// <exception cref="ContactNotAvailableException">There is no Contact with that ID</exception>
        public Contact UpdateContact(Contact contactToUpdate)
        {
            try
            {
                return _contact.UpdateContact(contactToUpdate);
            }
            catch (ArgumentNullException)
            {
                throw new ContactNotAvailableException();
            }
            catch (ContactNotAvailableException)
            {
                throw;
            }
        }
    }
}
