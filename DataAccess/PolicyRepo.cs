using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomExceptions;
namespace DataAccess
{
    public class PolicyRepo : IPolicy
    {
        private readonly masterContext _context;
        public PolicyRepo(masterContext context)
        {
            _context = context;
        }

        public Policy CreatePolicy(Policy newPolicy)
        {
            throw new NotImplementedException();
        }

        public void DeletePolicy(int id)
        {
            throw new NotImplementedException();
        }

        public List<Policy> GetAllPolicies()
        {
            throw new NotImplementedException();
        }

        public Policy GetPolicy(int id)
        {
            throw new NotImplementedException();
        }

        public Policy UpdatePolicy(Policy newPolicy)
        {
            throw new NotImplementedException();
        }
    }
}
