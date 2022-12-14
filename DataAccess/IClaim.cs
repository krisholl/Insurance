using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess
{
    public interface IClaim
    {
        Claim CreateClaim(Claim claim);
        Claim UpdateClaim(Claim claim);
        void DeleteClaim(int id);
        List<Claim> GetAllClaims();
        List<Claim> GetPatientClaims(int id);
        List<Claim> GetDoctorClaims(int id);
        Claim GetClaim(int id);
    }
}
