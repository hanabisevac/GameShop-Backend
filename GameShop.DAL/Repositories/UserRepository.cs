using GameShop.DAL.Entities;
using GameShop.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.DAL.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private AppDbContext _appDbContext;
        public UserRepository(AppDbContext context) : base(context)
        {
            _appDbContext = context;
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _appDbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<bool> RegisterUser(User user)
        {
            await _appDbContext.Users.AddAsync(user);
            return true;
        }
    }
}
