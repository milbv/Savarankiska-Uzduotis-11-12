using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDatabase.Core.Contracts;
using UserDatabase.Core.Models;

namespace UserDatabase.Core.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;
        public UserRepository (string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddUser(User user)
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute("INSERT INTO Users (Username, Password, IsActive, Role) VALUES (@Username, @Password, 1, @Role", user);
            }
        }

        public void ChangePassword(int id, string newPassword)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute("UPDATE Users Password = @newPassword WHERE Id = @id", new { id, newPassword });
            }
        }

        public void DeleteUser(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute("DELETE FROM Users WHERE Id = @id", new { id });
            }
        }

        public List<User> GetAllUsers()
        {
            List<User> result = new List<User>();
            using(var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                result = connection.Query<User>("SELECT * FROM Users").ToList();
            }
            return result;
        }

        public List<User> GetAllUsersByRole(string role)
        {
            List<User> result = new List<User>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                result = connection.Query<User>("SELECT * FROM Users WHERE Role = @role", new { role }).ToList();
            }
            return result;
        }

        public User GetUserById(int id)
        {
            User result = new User();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                result = connection.QueryFirst<User>("SELECT * FROM Users WHERE Id = @id", new { userId = id });
            }
            return result;
        }

        public void SetUserStatus(int id, bool isActive)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                if(isActive)
                {
                    connection.Execute("REPLACE Users IsActive = 1 WHERE Id = @id", new { id });
                } else
                {
                    connection.Execute("REPLACE Users IsActive = 0 WHERE Id = @id", new { id });
                }
                
            }
        }

        public void UpdateUser(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute("UPDATE User(Username,Password,IsActive,Role) VALUES (@Username,@Password,@IsActive,@Role) WHERE Id = id", user);
            }
        }
    }
}
