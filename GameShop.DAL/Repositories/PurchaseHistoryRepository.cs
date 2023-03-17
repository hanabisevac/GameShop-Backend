using GameShop.DAL.Entities;
using GameShop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.DAL.Repositories
{
    public class PurchaseHistoryRepository : GenericRepository<PurchaseHistory>, IPurchaseHistoryRepository
    {
        private AppDbContext _appDbContext;
        public PurchaseHistoryRepository(AppDbContext context) : base(context)
        {
            _appDbContext = context;
        }
    }
}
