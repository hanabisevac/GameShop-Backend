using GameShop.DAL.Entities;
using GameShop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.DAL.Repositories
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        private readonly AppDbContext _appDbContext;
        public CartRepository(AppDbContext context) : base(context)
        {
            _appDbContext = context;
        }
    }
}
