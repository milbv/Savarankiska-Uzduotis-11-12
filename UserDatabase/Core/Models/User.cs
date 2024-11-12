using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDatabase.Core.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public User()
        {

        }
        public override string ToString()
        {
            return $"{UserId} | {Username} | {Password} | {IsActive}";
        }
    }
}
