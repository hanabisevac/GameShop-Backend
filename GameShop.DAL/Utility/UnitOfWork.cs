using GameShop.DAL.Interfaces;
using GameShop.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.DAL.Utility
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;

        public ICartRepository CartRepository { get; private set; }

        public IConsoleRepository ConsoleRepository { get; private set; }

        public IPurchaseHistoryRepository PurchaseHistoryRepository {get; private set; }

        public ITypeRepository TypeRepository {get ; private set; }

        public IUserRepository UserRepository { get; private set; }

        public UnitOfWork(AppDbContext dbContext)
        {
            _appDbContext = dbContext;
            CartRepository = new CartRepository(dbContext);
            ConsoleRepository = new ConsoleRepository(dbContext);
            PurchaseHistoryRepository = new PurchaseHistoryRepository(dbContext);
            TypeRepository = new TypeRepository(dbContext);
            UserRepository = new UserRepository(dbContext);
        }

        public async Task CompleteAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _appDbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
