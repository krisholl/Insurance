using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomExceptions;
using DataAccess.Entities;
using DataAccess;
namespace Services
{
    public class ClaimServices
    {
        private readonly IClaim _claim;
        private readonly IUser _user;
        private readonly IPolicy _policy;
        public ClaimServices(IClaim claim, IUser user, IPolicy policy)
        {
            _claim = claim;
            _user = user;
            _policy = policy;
        }

        /// <summary>
        /// Will search the database for all claims
        /// </summary>
        /// <returns>All claims in the database</returns>
        /// <exception cref="ClaimNotAvailableException">There are no claims in the database</exception>
        public List<Claim> GetClaims()
        {
            try
            {
                return _claim.GetAllClaims();
            }
            catch (ArgumentNullException)
            {
                throw new ClaimNotAvailableException();
            }
            catch (ClaimNotAvailableException)
            {
                throw;
            }
        }
        /// <summary>
        /// Will search for all claims made by a patient
        /// </summary>
        /// <param name="id">ID of the patient to search for</param>
        /// <returns>List of all claims made by that patient</returns>
        /// <exception cref="ClaimNotAvailableException">That patient hasn't made any claims</exception>
        public List<Claim> GetPatientClaims(int id)
        {
            try
            {
                return _claim.GetPatientClaims(id);
            }
            catch (ArgumentNullException)
            {
                throw new ClaimNotAvailableException();
            }
            catch (ClaimNotAvailableException)
            {
                throw;
            }
        }
        /// <summary>
        /// Will search for all claims attributed to a doctor
        /// </summary>
        /// <param name="id">ID of the doctor to search for</param>
        /// <returns>List of all claims attributed to that doctor</returns>
        /// <exception cref="ClaimNotAvailableException">There are no claims attributed to that doctor</exception>
        public List<Claim> GetDoctorClaims(int id)
        {
            try
            {
                return _claim.GetDoctorClaims(id);
            }
            catch (ArgumentNullException)
            {
                throw new ClaimNotAvailableException();
            }
            catch (ClaimNotAvailableException)
            {
                throw;
            }
        }

        /// <summary>
        /// Will search for a claim
        /// </summary>
        /// <param name="id">ID of claim to search for</param>
        /// <returns>Requested record</returns>
        /// <exception cref="ClaimNotAvailableException">There is no claim with that id</exception>
        public Claim GetClaim(int id)
        {
            try
            {
                return _claim.GetClaim(id);
            }
            catch (ArgumentNullException)
            {
                throw new ClaimNotAvailableException();
            }
            catch (ClaimNotAvailableException)
            {
                throw;
            }
        }
        
        /// <summary>
        /// Will attempt to create a new claim in the database
        /// </summary>
        /// <param name="newClaim">Claim to add to database</param>
        /// <returns>Created Claim</returns>
        /// <exception cref="ClaimNotAvailableException">Not enough information provided</exception>
        /// <exception cref="PolicyNotAvailableException">There is no policy with that ID</exception>
        /// <exception cref="UserNotAvailableException">There is no Patient or Doctor with that ID</exception>
        public Claim CreateClaim(Claim newClaim)
        {
            try
            {
                User Patient = _user.GetUser(newClaim.Patient);
                User Doctor = _user.GetUser(newClaim.Doctor);
                Policy polcy = _policy.GetPolicy(newClaim.Policy);
                if(Patient.Id != newClaim.Patient)
                {
                    throw new UserNotAvailableException();
                }else if (Doctor.Id != newClaim.Doctor)
                {
                    throw new UserNotAvailableException();
                }else if(polcy.Id != newClaim.Policy)
                {
                    throw new PolicyNotAvailableException();
                }else if (string.IsNullOrWhiteSpace(newClaim.ReasonForVisit))
                {
                    throw new ClaimNotAvailableException();
                }
                else
                {
                    return _claim.CreateClaim(newClaim);
                }
            }
            catch (ArgumentNullException)
            {
                throw new ClaimNotAvailableException();
            }
            catch (ClaimNotAvailableException)
            {
                throw new ClaimNotAvailableException();
            }
            catch (PolicyNotAvailableException)
            {
                throw new PolicyNotAvailableException();
            }
            catch (UserNotAvailableException)
            {
                throw new UserNotAvailableException();
            }
        }

        /// <summary>
        /// Will attempt to update a claim in the database
        /// </summary>
        /// <param name="claim">Claim to update in database</param>
        /// <returns>Updated Claim</returns>
        /// <exception cref="ClaimNotAvailableException">Not enough information provided</exception>
        /// <exception cref="PolicyNotAvailableException">There is no policy with that ID</exception>
        /// <exception cref="UserNotAvailableException">There is no Patient or Doctor with that ID</exception>
        public Claim UpdateClaim(Claim claim)
        {
            try
            {
                User Patient = _user.GetUser(claim.Patient);
                User Doctor = _user.GetUser(claim.Doctor);
                Policy polcy = _policy.GetPolicy(claim.Policy);
                if (Patient.Id != claim.Patient)
                {
                    throw new UserNotAvailableException();
                }
                else if (Doctor.Id != claim.Doctor)
                {
                    throw new UserNotAvailableException();
                }
                else if (polcy.Id != claim.Policy)
                {
                    throw new PolicyNotAvailableException();
                } 
                else
                {
                    return _claim.CreateClaim(claim);
                }
            }
            catch (ArgumentNullException)
            {
                throw new ClaimNotAvailableException();
            }
            catch (ClaimNotAvailableException)
            {
                throw new ClaimNotAvailableException();
            }
            catch (PolicyNotAvailableException)
            {
                throw new PolicyNotAvailableException();
            }
            catch (UserNotAvailableException)
            {
                throw new UserNotAvailableException();
            }
        }

        /// <summary>
        /// Will attempt to remove a claim from the database
        /// </summary>
        /// <param name="id">ID of claim to remove</param>
        /// <exception cref="ClaimNotAvailableException">There is no claim with that ID</exception>
        public void DeleteClaim(int id)
        {
            try
            {
                _claim.DeleteClaim(id);
            }
            catch (ArgumentNullException)
            {
                throw new ClaimNotAvailableException();
            }
            catch (ClaimNotAvailableException)
            {
                throw new ClaimNotAvailableException();
            }
        }
    }
}
