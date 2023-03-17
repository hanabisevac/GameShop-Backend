using System;
using GameShop.BLL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameShop.DAL.Interfaces;

namespace GameShop.BLL.Services
{
    public class PurchaseHistoryService : IPurchaseHistoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PurchaseHistoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
