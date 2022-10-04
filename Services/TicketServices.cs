using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using CustomExceptions;

namespace Services
{
    public class TicketServices
    {
        private readonly IUser _user;
        private readonly IClaim _claim;
        private readonly ITicket _ticket;
        private readonly IPolicy _policy;
        public TicketServices(IUser user, IClaim claim, ITicket ticket, IPolicy policy)
        {
            _user = user;
            _claim = claim;
            _ticket = ticket;
            _policy = policy;
        }

        /// <summary>
        /// Will retreive all tickets in the database
        /// </summary>
        /// <returns>List of all tickets</returns>
        /// <exception cref="TicketNotAvailableException">There are no tickets.</exception>
        public List<Ticket> GetTickets()
        {
            try
            {
                return _ticket.GetAllTickets();
            }
            catch (ArgumentNullException)
            {
                throw new TicketNotAvailableException();
            }
            catch (TicketNotAvailableException)
            {
                throw;
            }
        } 

        /// <summary>
        /// Will retreive a list of tickets made by a patient
        /// </summary>
        /// <param name="id">ID of the Patient in question</param>
        /// <returns>List of tickets made by the patient</returns>
        /// <exception cref="TicketNotAvailableException">That patient hasn't made any tickets</exception>
        public List<Ticket> GetPatientTickets(int id)
        {
            try
            {
                return _ticket.GetPatientTickets(id);
            }
            catch (ArgumentNullException)
            {
                throw new TicketNotAvailableException();
            }
            catch (TicketNotAvailableException)
            {
                throw;
            }
        }

        /// <summary>
        /// Search for a particular ticket
        /// </summary>
        /// <param name="id">ID of ticket to find</param>
        /// <returns>Requested ticket</returns>
        /// <exception cref="TicketNotAvailableException">There is no ticket with that ID</exception>
        public Ticket GetTicket(int id)
        {
            try
            {
                return _ticket.GetTicket(id);
            }
            catch (ArgumentNullException)
            {
                throw new TicketNotAvailableException();
            }
            catch (TicketNotAvailableException)
            {
                throw;
            }
        }

        /// <summary>
        /// Will check all tables to ensure that a ticket can be made with the provided information
        /// </summary>
        /// <param name="newTicket">Ticket to create</param>
        /// <returns>Created Ticket</returns>
        /// <exception cref="UserNotAvailableException">There is no user with that ID</exception>
        /// <exception cref="PolicyNotAvailableException">There is no policy with that ID</exception>
        /// <exception cref="ClaimNotAvailableException">There is no claim with that ID</exception>
        /// <exception cref="TicketNotAvailableException">There is not enough provided information</exception>
        public Ticket CreateTicket(Ticket newTicket)
        {
            try
            {
                User Patient = _user.GetUser(newTicket.Patient);
                Policy policy = _policy.GetPolicy(newTicket.Policy);
                Claim claim = _claim.GetClaim(newTicket.Claim);
                if(Patient.Id != newTicket.Patient)
                {
                    throw new UserNotAvailableException();
                }else if(policy.Id != newTicket.Policy)
                {
                    throw new PolicyNotAvailableException();
                }else if (claim.Id != newTicket.Claim)
                {
                    throw new ClaimNotAvailableException();
                }else if (string.IsNullOrEmpty(newTicket.Notes))
                {
                    throw new TicketNotAvailableException();
                }
                else
                {
                    return _ticket.CreateTicket(newTicket);
                }
            }
            catch (UserNotAvailableException)
            {
                throw new UserNotAvailableException();
            }
            catch (PolicyNotAvailableException)
            {
                throw new PolicyNotAvailableException();
            }
            catch (ClaimNotAvailableException)
            {
                throw new ClaimNotAvailableException();
            }
            catch (TicketNotAvailableException)
            {
                throw new TicketNotAvailableException();
            }
            catch (ArgumentNullException)
            {
                throw new TicketNotAvailableException();
            }
        }

        /// <summary>
        /// Will check all tables to ensure that a ticket can be updated with the provided information
        /// </summary>
        /// <param name="ticket">Ticket to update</param>
        /// <returns>Updated Ticket</returns>
        /// <exception cref="UserNotAvailableException">There is no user with that ID</exception>
        /// <exception cref="PolicyNotAvailableException">There is no policy with that ID</exception>
        /// <exception cref="ClaimNotAvailableException">There is no claim with that ID</exception>
        /// <exception cref="TicketNotAvailableException">There is not enough provided information</exception>
        public Ticket UpdateTicket(Ticket ticket)
        {
            try
            {
                User Patient = _user.GetUser(ticket.Patient);
                Policy policy = _policy.GetPolicy(ticket.Policy);
                Claim claim = _claim.GetClaim(ticket.Claim);
                if (Patient.Id != ticket.Patient)
                {
                    throw new UserNotAvailableException();
                }
                else if (policy.Id != ticket.Policy)
                {
                    throw new PolicyNotAvailableException();
                }
                else if (claim.Id != ticket.Claim)
                {
                    throw new ClaimNotAvailableException();
                } 
                else
                {
                    return _ticket.UpdateTicket(ticket);
                }
            }
            catch (UserNotAvailableException)
            {
                throw new UserNotAvailableException();
            }
            catch (PolicyNotAvailableException)
            {
                throw new PolicyNotAvailableException();
            }
            catch (ClaimNotAvailableException)
            {
                throw new ClaimNotAvailableException();
            }
            catch (TicketNotAvailableException)
            {
                throw new TicketNotAvailableException();
            }
            catch (ArgumentNullException)
            {
                throw new TicketNotAvailableException();
            }
        }
        
        /// <summary>
        /// Will remove a ticket from the database
        /// </summary>
        /// <param name="id">Id of ticket to remove</param>
        /// <exception cref="TicketNotAvailableException">There is no ticket with that ID</exception>
        public void DeleteTicket(int id)
        {
            try
            {
                _ticket.DeleteTicket(id);
            }
            catch (ArgumentNullException)
            {
                throw new TicketNotAvailableException();
            }
            catch (TicketNotAvailableException)
            {
                throw;
            }
        }
    }
}
