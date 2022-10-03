using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomExceptions;
namespace DataAccess
{
    public class ContactRepo : IContact
    {
        private readonly masterContext _context;
        public ContactRepo(masterContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Will add a Contact to the database
        /// </summary>
        /// <param name="contact">A valid Contact</param>
        /// <returns>The contact information in the database</returns>
        public Contact CreateContact(Contact contact)
        { 
            _context.Add(contact);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            return contact;             
        }
        /// <summary>
        /// Will delete a requested Contact
        /// </summary>
        /// <param name="id">Valid Contact ID</param>
        /// <exception cref="UserNotAvailableException">There is no Contact with that ID</exception>
        public void DeleteContact(int id)
        {
            try
            {
                Contact you = _context.Contacts.FirstOrDefault(p => p.Id == id)!;
                _context.Contacts.Remove(you);
            }
            catch (ArgumentNullException)
            {
                throw new ContactNotAvailableException();
            }
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
        /// <summary>
        /// Gets a contact from the database based on the id
        /// </summary>
        /// <param name="id">Valid Contact ID</param>
        /// <returns>Record with that id attribute</returns>
        /// <exception cref="ContactNotAvailableException">There is no contact with that id</exception>
        public Contact GetContact(int id)
        {
            try
            {
                return _context.Contacts.FirstOrDefault(p => p.Id == id)!;
            } catch (ArgumentNullException)
            {
                throw new ContactNotAvailableException();
            }
        }  
        /// <summary>
        /// Checks all information of possible contact and changes anything different in new contactt.
        /// </summary>
        /// <param name="contact">Valid new contact</param>
        /// <returns>Updated record</returns>
        /// <exception cref="ContactNotAvailableException">There is no record with that id</exception>
        public Contact UpdateContact(Contact contact)
        {
            try
            {
                Contact In=_context.Contacts.FirstOrDefault(p => p.Id == contact.Id)!;
                In.PoOrStreet = contact.PoOrStreet;
                In.PoNumber = contact.PoNumber==0 ? In.PoNumber : contact.PoNumber;
                In.StreetNumber = contact.StreetNumber==0 ? In.StreetNumber : contact.StreetNumber;
                In.StreetName = contact.StreetName=="" ? In.StreetName : contact.StreetName;
                In.City =  contact.City=="" ? In.City : contact.City;
                In.State = contact.State=="" ? In.State : contact.State;
                In.Zipcode = contact.Zipcode == 0 ? In.Zipcode : contact.Zipcode;
                _context.SaveChanges();
                _context.ChangeTracker.Clear();
                return In;
            }
            catch (ArgumentNullException)
            {
                throw new ContactNotAvailableException();
            }
        }
    }
}
