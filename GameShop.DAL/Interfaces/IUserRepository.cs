using GameShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.DAL.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<bool> RegisterUser(User user);
        Task<User> GetByEmail(string email);
    }
}
