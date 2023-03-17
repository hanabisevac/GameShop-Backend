using GameShop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.DAL.Repositories
{
    public class ConsoleRepository : GenericRepository<Entities.Console>, IConsoleRepository
    {
        private AppDbContext _appDbContext;
        public ConsoleRepository(AppDbContext context) : base(context)
        {
            _appDbContext = context;
        }
    }
}
