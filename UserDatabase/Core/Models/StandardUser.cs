using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDatabase.Core.Models
{
    public class StandardUser : User
    {
        public string Role { get; set; } = "StandardUser";
        public StandardUser()
        {

        }
        public override string ToString()
        {
            return $"{UserId} | {Username} | {Password} | {IsActive} | {Role}";
        }
    }
}
