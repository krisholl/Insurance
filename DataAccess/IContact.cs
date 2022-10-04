using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IContact
    {
        Contact GetContact(int id); 
        List<Contact> GetAllContacts();
        Contact CreateContact(Contact contact);
        Contact UpdateContact(Contact contact);
        void DeleteContact(int id);
    }
}
