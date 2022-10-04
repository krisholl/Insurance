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
    public class PolicyRepo : IPolicy
    {
        private readonly masterContext _context;
        public PolicyRepo(masterContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Will create a new policy in the database
        /// </summary>
        /// <param name="newPolicy">Policy to add to the database</param>
        /// <returns>The new policy record</returns>
        public Policy CreatePolicy(Policy newPolicy)
        {
            _context.Policies.Add(newPolicy);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            return newPolicy;
        }
        /// <summary>
        /// Will remove a requested policy
        /// </summary>
        /// <param name="id">Id of policy to remove</param>
        /// <exception cref="PolicyNotAvailableException">There is no policy with that id</exception>
        public void DeletePolicy(int id)
        {
            try
            {
                Policy thisOne = _context.Policies.FirstOrDefault(c=>c.Id == id)!;
                _context.Policies.Remove(thisOne);
                _context.SaveChanges();
                _context.ChangeTracker.Clear();                
            }
            catch (ArgumentNullException)
            {
                throw new PolicyNotAvailableException();
            }
        }
        /// <summary>
        /// Will retreive all records in the policy table
        /// </summary>
        /// <returns>All records of policies in the database</returns>
        /// <exception cref="PolicyNotAvailableException">There is no policies in the database</exception>
        public List<Policy> GetAllPolicies()
        {
            try
            {
                return _context.Policies.ToList();
            }
            catch (ArgumentNullException)
            {
                throw new PolicyNotAvailableException();
            }
        }
        /// <summary>
        /// This will get a specific policy
        /// </summary>
        /// <param name="id">ID of policy to search for</param>
        /// <returns>Requested record</returns>
        /// <exception cref="PolicyNotAvailableException">There is no policy with that ID</exception>
        public Policy GetPolicy(int id)
        {
            try
            {
                return _context.Policies.AsNoTracking().FirstOrDefault(s => s.Id == id)!;
            }
            catch (ArgumentNullException)
            {
                throw new PolicyNotAvailableException();
            }
        }
        /// <summary>
        /// Will update a policy's information
        /// </summary>
        /// <param name="newPolicy">Policy information to update</param>
        /// <returns>The updated record</returns>
        /// <exception cref="PolicyNotAvailableException">There is no policy with that ID</exception>
        public Policy UpdatePolicy(Policy newPolicy)
        {
            try
            {
                Policy In = _context.Policies.FirstOrDefault(s => s.Id == newPolicy.Id)!;
                In.Insurance = newPolicy.Insurance == 0 ? In.Insurance : newPolicy.Insurance;
                In.Coverage = newPolicy.Coverage == "" ? In.Coverage : newPolicy.Coverage;
                _context.SaveChanges();
                _context.ChangeTracker.Clear();
                return In;
            }
            catch (ArgumentNullException)
            {
                throw new PolicyNotAvailableException();
            }
        }
    }
}
