using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface ITicket
    {
        Ticket CreateTicket(Ticket ticket);
        Ticket UpdateTicket(Ticket ticket);
        void DeleteTicket(int id);
        Ticket GetTicket(int id);
        List<Ticket> GetPatientTickets(int id);
        List<Ticket> GetAllTickets();
    }
}
