using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDatabase.Core.Models;

namespace UserDatabase.Core.Contracts
{
    public interface IUserRepository
    {
        void AddUser(User user);
        User GetUserById(int id);
        List<User> GetAllUsers();
        void UpdateUser(User user);
        void DeleteUser(int id);
        void ChangePassword(int id, string newPassword);
        void SetUserStatus(int id, bool isActive);
        List<User> GetAllUsersByRole(string role);
    }
}
