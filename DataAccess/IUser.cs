using DataAccess.Entities;
namespace DataAccess;
public interface IUser
{
    User GetUser(int id);
    User GetUser(string username);
    User CreateUser(User user);
    User UpdateUser(User user);
    void DeleteUser(int id);
    List<User> GetUsers();
}
