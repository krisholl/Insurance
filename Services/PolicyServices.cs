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
    public class PolicyServices
    {
        private readonly IPolicy _policy;
        private readonly IUser _user;
        public PolicyServices(IPolicy policy, IUser user)
        {
            _policy = policy;
            _user = user;
        }
        /// <summary>
        /// Will search for all policies in the database
        /// </summary>
        /// <returns>List of all policies</returns>
        /// <exception cref="PolicyNotAvailableException">There are no policies in the database</exception>
        public List<Policy> GetPolicies()
        {
            try
            {
                return _policy.GetAllPolicies();
            }
            catch (ArgumentNullException)
            {
                throw new PolicyNotAvailableException();
            }
            catch (PolicyNotAvailableException)
            {
                throw;
            }
        }
        /// <summary>
        /// Will search for a particular policy in the database
        /// </summary>
        /// <param name="id">ID of policy to search for</param>
        /// <returns>Requested record of policy</returns>
        /// <exception cref="PolicyNotAvailableException">There is no policy with that Id</exception>
        public Policy GetPolicy(int id)
        {
            try
            {
                return _policy.GetPolicy(id);
            }
            catch (ArgumentNullException)
            {
                throw new PolicyNotAvailableException();
            }
            catch (PolicyNotAvailableException)
            {
                throw;
            }
        }
        /// <summary>
        /// Will attempt to create a new policy with provided information
        /// </summary>
        /// <param name="newPolicy">A valid Policy</param>
        /// <returns>Created Policy</returns>
        /// <exception cref="UserNotAvailableException">There is no insurance company with that id</exception>
        /// <exception cref="PolicyNotAvailableException">There is not enough information for your clients</exception>
        public Policy CreatePolicy(Policy newPolicy)
        {
            try
            {
                User insurance = _user.GetUser(newPolicy.Insurance);
                if (insurance.Id != newPolicy.Insurance)
                {
                    throw new UserNotAvailableException();
                }else if (string.IsNullOrWhiteSpace(newPolicy.Coverage))
                {
                    throw new PolicyNotAvailableException();
                }
                else
                {
                    return _policy.CreatePolicy(newPolicy);
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
            catch (ArgumentNullException)
            {
                throw new PolicyNotAvailableException();
            }
        }
        /// <summary>
        /// Will attempt to create a new policy with provided information
        /// </summary>
        /// <param name="policy">A valid Policy</param>
        /// <returns>Created Policy</returns>
        /// <exception cref="UserNotAvailableException">There is no insurance company with that id</exception>
        /// <exception cref="PolicyNotAvailableException">There is not enough information for your clients</exception>
        public Policy UpdatePolicy(Policy policy)
        {
            try
            {
                User insurance = _user.GetUser(policy.Insurance);
                if (insurance.Id != policy.Insurance)
                {
                    throw new UserNotAvailableException();
                } 
                else
                {
                    return _policy.CreatePolicy(policy);
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
            catch (ArgumentNullException)
            {
                throw new PolicyNotAvailableException();
            }
        }

        /// <summary>
        /// Will attempt to remove a policy from the database
        /// </summary>
        /// <param name="id">ID of policy to remove</param>
        /// <exception cref="PolicyNotAvailableException">There is no policy with that ID</exception>
        public void DeletePolicy(int id)
        {
            try
            {
                _policy.DeletePolicy(id);
            }
            catch (ArgumentNullException)
            {
                throw new PolicyNotAvailableException();
            }
            catch (PolicyNotAvailableException)
            {
                throw;
            }
        }
    }
}
