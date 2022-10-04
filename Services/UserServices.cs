using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomExceptions;
using DataAccess;
using DataAccess.Entities;
namespace Services
{
    public class UserServices
    {
        private readonly IUser _user;
        public UserServices(IUser user)
        {
            _user = user;
        }
        /// <summary>
        /// Will retreive a list of all users
        /// </summary>
        /// <returns>List of all users</returns>
        /// <exception cref="UserNotAvailableException">There are no users</exception>
        public List<User> GetUsers()
        {
            try
            {
                return _user.GetUsers();
            }
            catch (UserNotAvailableException)
            {
                throw;
            }
            catch (ArgumentNullException)
            {
                throw new UserNotAvailableException();
            }
        }
        /// <summary>
        /// Will search the database for a user id
        /// </summary>
        /// <param name="id">Id to search for</param>
        /// <returns>User whose id is requested</returns>
        /// <exception cref="UserNotAvailableException">There is no user with that id</exception>
        public User GetUser(int id)
        {
            try
            {
                return _user.GetUser(id);
            }
            catch (UserNotAvailableException)
            {
                throw;
            }
            catch (ArgumentNullException)
            {
                throw new UserNotAvailableException();
            }
        }

        /// <summary>
        /// Will search the database for a username
        /// </summary>
        /// <param name="username">Username to search for</param>
        /// <returns>User whose username is requested</returns>
        /// <exception cref="UserNotAvailableException">There is no user with that username</exception>
        public User GetUser(string username)
        {
            try
            {
                return _user.GetUser(username);
            }
            catch (UserNotAvailableException)
            {
                throw;
            }
            catch (ArgumentNullException)
            {
                throw new UserNotAvailableException();
            }
        }
    }
}
