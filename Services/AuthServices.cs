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
        

        public User Login(string username, string password)
        {
            try
            {
                User found = _user.GetUser(username);
                if(found == null) 
                {
                    throw new UserNotAvailableException(); 
                }
                else if(found.Password == password)
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
    }
}