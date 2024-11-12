using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDatabase.Core.Contracts;
using UserDatabase.Core.Models;

namespace UserDatabase.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void ActivateUser(int id)
        {
            _userRepository.SetUserStatus(id, true);
        }

        public void DeactivateUser(int id)
        {
            _userRepository.SetUserStatus(id, false);
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public User GetUser(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public List<User> ListUsersByRole(string role)
        {
            return _userRepository.GetAllUsersByRole(role);
            
        }

        public void RegisterUser(User user)
        {
            _userRepository.AddUser(user);
        }

        public void RemoveUser(int id)
        {
            _userRepository.DeleteUser(id);
        }

        public void UpdatePassword(int id, string newPassword)
        {
            _userRepository.ChangePassword(id, newPassword);
        }
        public void UpdateUser(User user)
        {
            _userRepository.UpdateUser(user);
        }
    }
}
