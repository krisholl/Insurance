using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IPolicy
    {
        Policy CreatePolicy(Policy newPolicy);
        Policy UpdatePolicy(Policy newPolicy);
        void DeletePolicy(int id);
        Policy GetPolicy(int id);
        List<Policy> GetAllPolicies();
    }
}
