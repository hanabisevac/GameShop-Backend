using GameShop.DAL.Entities;
using GameShop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.DAL.Repositories
{
    public class GameRepository : GenericRepository<Game>, IGameRepository
    {
        private AppDbContext _appDbContext;
        public GameRepository(AppDbContext context) : base(context)
        {
            _appDbContext = context;
        }
    }
}
