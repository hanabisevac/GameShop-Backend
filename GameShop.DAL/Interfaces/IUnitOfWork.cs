using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICartRepository CartRepository { get; }
        IConsoleRepository ConsoleRepository { get; }
        IPurchaseHistoryRepository PurchaseHistoryRepository { get; }
        ITypeRepository TypeRepository { get; }
        IUserRepository UserRepository { get; }
        Task CompleteAsync();
    }
}
