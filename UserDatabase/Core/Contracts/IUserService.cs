using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDatabase.Core.Models;

namespace UserDatabase.Core.Contracts
{
    public interface IUserService
    {
        void RegisterUser(User user);
        User GetUser(int id);
        List<User> GetAllUsers();
        void RemoveUser(int id);
        void UpdatePassword(int id, string newPassword);
        void ActivateUser(int id);
        void DeactivateUser(int id);
        List<User> ListUsersByRole(string role);
        void UpdateUser(User user);
    }
}
