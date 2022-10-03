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
    public class ClaimRepo : IClaim
    {
        private readonly masterContext _context;
        public ClaimRepo(masterContext context)
        {
            _context = context;
        }

        public Claim CreateClaim(Claim claim)
        {
            try
            {
                _context.Claims.Add(claim);
                _context.SaveChanges();
                _context.ChangeTracker.Clear();
                return claim;
            }
            catch (ArgumentNullException)
            {
                throw new ClaimNotAvailableException();
            }
        }

        public void DeleteClaim(int id)
        {
            try
            {
                Claim thisOne = _context.Claims.FirstOrDefault(x => x.Id == id)!;
                _context.Claims.Remove(thisOne);
                _context.SaveChanges();
                _context.ChangeTracker.Clear();
            }
            catch (ArgumentNullException)
            {
                throw new ClaimNotAvailableException();
            }
        }

        public List<Claim> GetAllClaims()
        {
            try
            {
                return _context.Claims.ToList();
            }
            catch (ArgumentNullException)
            {
                throw new ClaimNotAvailableException();
            }
        }

        public Claim GetClaim(int id)
        {
            try
            {
                return _context.Claims.AsNoTracking().FirstOrDefault(p => p.Id == id)!;
            }
            catch (ArgumentNullException)
            {
                throw new ClaimNotAvailableException();
            }
        }

        public Claim UpdateClaim(Claim claim)
        {
            try
            {
                Claim In = _context.Claims.FirstOrDefault(x => x.Id == claim.Id)!;
                In.Status = claim.Status == "" ? In.Status : claim.Status;
                In.Doctor = claim.Doctor == 0 ? In.Doctor : claim.Doctor;
                In.Policy=claim.Policy==0? In.Policy : claim.Policy;
                In.ReasonForVisit = claim.ReasonForVisit==""?In.ReasonForVisit:claim.ReasonForVisit;
            }
            catch (ArgumentNullException)
            {
                throw new ClaimNotAvailableException();
            }
        }
    }
}
