using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomExceptions;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class TicketRepo : ITicket
    {
        private readonly masterContext _context;
        public TicketRepo(masterContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Will Create a new record in the Ticket table
        /// </summary>
        /// <param name="ticket">Ticket to add in database</param>
        /// <returns>New record in table</returns>
        public Ticket CreateTicket(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            return ticket;
        }
        /// <summary>
        /// Will remove a record from the ticket table in the database
        /// </summary>
        /// <param name="id">ID of ticket ot remove</param>
        /// <exception cref="TicketNotAvailableException">There is no ticket with that ID</exception>
        public void DeleteTicket(int id)
        {
            try
            {
                Ticket thisOne = _context.Tickets.FirstOrDefault(s=>s.Id == id)!;
                _context.Tickets.Remove(thisOne);
                _context.SaveChanges();
                _context.ChangeTracker.Clear();
            }
            catch (ArgumentNullException)
            {
                throw new TicketNotAvailableException();
            }
        }
        /// <summary>
        /// Will retreive all records from the database
        /// </summary>
        /// <returns>All records from the Ticket table</returns>
        /// <exception cref="TicketNotAvailableException">There are no tickets in the database</exception>
        public List<Ticket> GetAllTickets()
        {
            try
            {
                return _context.Tickets.AsNoTracking().ToList();
            }
            catch (ArgumentNullException)
            {
                throw new TicketNotAvailableException();
            }
        }

        /// <summary>
        /// Will retreive all tickets created by a patient
        /// </summary>
        /// <param name="id">ID of patient to search for</param>
        /// <returns>All records of tickets made by a patient</returns>
        /// <exception cref="TicketNotAvailableException">That patient has not created any tickets</exception>
        public List<Ticket> GetPatientTickets(int id)
        {
            try
            {
                return _context.Tickets.Where(p=>p.Id == id).AsNoTracking().ToList();
            }
            catch (ArgumentNullException)
            {
                throw new TicketNotAvailableException();
            }
        }
        /// <summary>
        /// Will retreive a specific record
        /// </summary>
        /// <param name="id">ID of ticket to search for</param>
        /// <returns>Requested record</returns>
        /// <exception cref="TicketNotAvailableException">There is no ticket with that ID</exception>
        public Ticket GetTicket(int id)
        {
            try
            {
                return _context.Tickets.AsNoTracking().FirstOrDefault(p => p.Id == id)!;
            }
            catch (ArgumentNullException)
            {
                throw new TicketNotAvailableException();
            }
        }
        /// <summary>
        /// Will update a record in the Tickets table
        /// </summary>
        /// <param name="ticket">Ticket information to update</param>
        /// <returns>Updated record</returns>
        /// <exception cref="TicketNotAvailableException">There is no ticket with that ID</exception>
        public Ticket UpdateTicket(Ticket ticket)
        {
            try
            {
                Ticket In = _context.Tickets.FirstOrDefault(p => p.Id == ticket.Id)!;
                In.Policy = ticket.Policy == 0 ? In.Policy : ticket.Policy;
                In.Claim = ticket.Claim==0 ? In.Policy : ticket.Claim;
                In.Notes = ticket.Notes=="" ? In.Notes : ticket.Notes;
                _context.SaveChanges();
                _context.ChangeTracker.Clear();
                return In;
            }
            catch (ArgumentNullException)
            {
                throw new TicketNotAvailableException();
            }
        }
    }
}
