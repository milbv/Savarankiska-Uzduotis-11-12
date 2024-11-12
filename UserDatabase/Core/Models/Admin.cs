using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDatabase.Core.Models
{
    public class Admin : User
    {
        public string Role { get; set; } = "Administrator";
        public Admin()
        {
        }
        public override string ToString()
        {
            return $"{UserId} | {Username} | {Password} | {IsActive} | {Role}";
        }
    }
}
