using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomExceptions;

namespace DataAccess
{
    public class TicketRepo : ITicket
    {
        private readonly masterContext _context;
        public TicketRepo(masterContext context)
        {
            _context = context;
        }

        public Ticket CreateTicket(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public void DeleteTicket(int id)
        {
            throw new NotImplementedException();
        }

        public List<Ticket> GetAllTickets()
        {
            throw new NotImplementedException();
        }

        public List<Ticket> GetPatientTickets(int id)
        {
            throw new NotImplementedException();
        }

        public Ticket GetTicket(int id)
        {
            throw new NotImplementedException();
        }

        public Ticket UpdateTicket(Ticket ticket)
        {
            throw new NotImplementedException();
        }
    }
}
