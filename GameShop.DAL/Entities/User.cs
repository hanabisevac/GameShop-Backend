using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.DAL.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string? Name { get; set; } = null;
        public string? Surname { get; set; } = null;
        public string? Email { get; set; } = null;
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public string? Address { get; set; } = null;
        public int RoleId { get; set; } 
        public Role? Role { get; set; } = null;
    }
}
