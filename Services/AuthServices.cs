using CustomExceptions;
using DataAccess;
using DataAccess.Entities;
namespace Services
{
    public class AuthServices
    {
        private readonly IUser _user;
        private readonly IContact _contact;
        public AuthServices(IUser user, IContact contact)
        {
            _user = user;
            _contact = contact;
        }

        /// <summary>
        /// Will allow a user to login to the system
        /// </summary>
        /// <param name="username">A valid username</param>
        /// <param name="password">A valid password</param>
        /// <returns>The logged in user</returns>
        /// <exception cref="UserNotAvailableException">No user has that username</exception>
        /// <exception cref="InvalidCredentialsException">That password does not match the username</exception>
        public User Login(string username, string password)
        {
            try
            {
                User found = _user.GetUser(username);
                if (found == null)
                {
                    throw new UserNotAvailableException();
                }
                else if (found.Password == password)
                {
                    return found;
                }
                else
                {
                    throw new InvalidCredentialsException();
                }
            }
            catch (UserNotAvailableException)
            {
                throw new UserNotAvailableException();
            }
            catch (InvalidCredentialsException)
            {
                throw new InvalidCredentialsException();
            }
        }
        /// <summary>
        /// Will create a new user in the database if the provided username is not in use.
        /// </summary>
        /// <param name="newUser">Valid User object</param>
        /// <returns>Registered User</returns>
        /// <exception cref="UserNotAvailableException">There is a user with that username already</exception>
        public User Register(User newUser)
        {
            try
            {
                User found = _user.GetUser(newUser.Username)!;
                if(found.Username == newUser.Username)
                {
                    throw new UserNotAvailableException();
                }
                else
                {
                    Contact newContact = _contact.CreateContact(new()
                    {
                        City = "-",
                        State = "-",
                        Zipcode = 0,
                        PoOrStreet =true,
                        PoNumber =0,
                        StreetName = "-",
                        StreetNumber =0
                    });
                    newUser.ContactIdFk = newContact.Id;
                    return _user.CreateUser(newUser);
                }
            }
            catch (ArgumentNullException)
            {
                throw new UserNotAvailableException();
            }
            catch (UserNotAvailableException)
            {
                throw;
            }
            
        }
        
        /// <summary>
        /// Will update a user's information
        /// </summary>
        /// <param name="userToUpdate">User information to update</param>
        /// <returns>Updated User</returns>
        /// <exception cref="UserNotAvailableException">There is no user with that ID</exception>
        public User UpdateInformation(User userToUpdate)
        {
            try
            {
                return _user.UpdateUser(userToUpdate);
            }
            catch (UserNotAvailableException)
            {
                throw;
            }
        }
    }
}