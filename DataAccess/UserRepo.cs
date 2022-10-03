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
    public class UserRepo : IUser
    {
        private readonly masterContext _context;
        public UserRepo(masterContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Will Add a user to the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            return user;
        }
        /// <summary>
        /// Will remove a user from the database
        /// </summary>
        /// <param name="id">A valid user id</param>
        /// <exception cref="UserNotAvailableException">There is no user with that ID</exception>
        public void DeleteUser(int id)
        {
            try
            {
                User you =_context.Users.FirstOrDefault(p=>p.Id == id)!;
                _context.Users.Remove(you);
                _context.SaveChanges();
                _context.ChangeTracker.Clear();
            }
            catch (ArgumentNullException)
            {
                throw new UserNotAvailableException();
            }
        }
        /// <summary>
        /// Will return a user based on the user id
        /// </summary>
        /// <param name="id">A valid user ID</param>
        /// <returns>The requested user</returns>
        /// <exception cref="UserNotAvailableException">There is no user with that ID</exception>
        public User GetUser(int id)
        {
            try
            {
                return _context.Users.AsNoTracking().FirstOrDefault(p => p.Id == id)!;
            }
            catch (ArgumentNullException)
            {
                throw new UserNotAvailableException();
            }
        }
        /// <summary>
        /// Will return a user based on the username
        /// </summary>
        /// <param name="username">A valid username</param>
        /// <returns>The requested User</returns>
        /// <exception cref="UserNotAvailableException">There is no user with that ID</exception>
        public User GetUser(string username)
        {
            try
            {
                return _context.Users.AsNoTracking().FirstOrDefault(p => p.Username == username)!;
            }
            catch (ArgumentNullException)
            {
                throw new UserNotAvailableException();
            }
        }
        /// <summary>
        /// Will return all users in the database
        /// </summary>
        /// <returns>All users in the database</returns>
        /// <exception cref="UserNotAvailableException">There are no users in the database</exception>
        public List<User> GetUsers()
        {
            try
            {
                return _context.Users.AsNoTracking().ToList();
            }
            catch (ArgumentNullException)
            {
                throw new UserNotAvailableException();
            }
        }
        /// <summary>
        /// Will update a user
        /// </summary>
        /// <param name="user">A Valid user</param>
        /// <returns>The updated user information</returns>
        /// <exception cref="UserNotAvailableException">There is no user with that user ID</exception>
        public User UpdateUser(User user)
        {
            try
            {
                User In = _context.Users.FirstOrDefault(p => p.Id == user.Id)!;
                In.FirstName = user.FirstName == "" ? In.FirstName : user.FirstName;
                In.LastName = user.LastName == "" ? In.LastName : user.LastName;
                In.MiddleInit = user.MiddleInit == "" ? In.MiddleInit : user.MiddleInit;
                In.ContactIdFk = user.ContactIdFk == 0 ? In.ContactIdFk : user.ContactIdFk;
                In.Username = user.Username == "" ? In.Username : user.Username;
                In.Password = user.Password == "" ? In.Password : user.Password;
                In.Role = user.Role == "" ? In.Role : user.Role;
                _context.SaveChanges();
                _context.ChangeTracker.Clear();
                return In;
            }
            catch (ArgumentNullException)
            {
                throw new UserNotAvailableException();
            }
        }
    }
}
