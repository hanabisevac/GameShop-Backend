using GameShop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.DAL.Repositories
{
    public class TypeRepository : GenericRepository<Entities.Type>, ITypeRepository
    {
        private AppDbContext _appDbContext;
        public TypeRepository(AppDbContext context) : base(context)
        {
            _appDbContext = context;
        }
    }
}
