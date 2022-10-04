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

        /// <summary>
        /// Will Create a new claim in the database
        /// </summary>
        /// <param name="claim">A valid claim</param>
        /// <returns>The Added Claim</returns> 
        public Claim CreateClaim(Claim claim)
        { 
            _context.Claims.Add(claim);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            return claim;
             
        }
        /// <summary>
        /// Will Remove a claim for the database
        /// </summary>
        /// <param name="id">Id of claim to remove</param>
        /// <exception cref="ClaimNotAvailableException">There is no claim with that ID</exception>
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
        /// <summary>
        /// Will retrieve all records from the claims table 
        /// </summary>
        /// <returns>All Records of claims in the database</returns>
        /// <exception cref="ClaimNotAvailableException">The Claims table does not exist</exception>
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
        /// <summary>
        /// Will Get a specific claim 
        /// </summary>
        /// <param name="id">Id of claim to retreive</param>
        /// <returns>Requested Claim</returns>
        /// <exception cref="ClaimNotAvailableException">There is no claim with that ID</exception>
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
        /// <summary>
        /// Will get all Claims Attributed to that doctor
        /// </summary>
        /// <param name="id">Id of doctor to search for</param>
        /// <returns>Requested Records</returns>
        /// <exception cref="ClaimNotAvailableException">That doctor is not attributed to any claims</exception>
        public List<Claim> GetDoctorClaims(int id)
        {
            try
            {
                return _context.Claims.Where(p=>p.Doctor==id).AsNoTracking().ToList()!;
            }
            catch (ArgumentNullException)
            {
                throw new ClaimNotAvailableException();
            }
        }
        /// <summary>
        /// Will get all claims attributted to that patient
        /// </summary>
        /// <param name="id">Id of patient to search for</param>
        /// <returns>Requested Records</returns>
        /// <exception cref="ClaimNotAvailableException">That patient is not attributed to any claims</exception>
        public List<Claim> GetPatientClaims(int id)
        {
            try
            {
                return _context.Claims.Where(p => p.Patient == id).AsNoTracking().ToList()!;
            }
            catch (ArgumentNullException)
            {
                throw new ClaimNotAvailableException();
            }
        }
        /// <summary>
        /// Will update a requested claim
        /// </summary>
        /// <param name="claim">Claim information to update</param>
        /// <returns>Updated Claim</returns>
        /// <exception cref="ClaimNotAvailableException">That claim does not exist in the database</exception>
        public Claim UpdateClaim(Claim claim)
        {
            try
            {
                Claim In = _context.Claims.FirstOrDefault(x => x.Id == claim.Id)!;
                In.Status = claim.Status == "" ? In.Status : claim.Status;
                In.Doctor = claim.Doctor == 0 ? In.Doctor : claim.Doctor;
                In.Policy=claim.Policy==0? In.Policy : claim.Policy;
                In.ReasonForVisit = claim.ReasonForVisit==""?In.ReasonForVisit:claim.ReasonForVisit;
                _context.SaveChanges();
                _context.ChangeTracker.Clear();
                return In;
            }
            catch (ArgumentNullException)
            {
                throw new ClaimNotAvailableException();
            }
        }
    }
}
