using GameShop.BLL.Interfaces;
using GameShop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.BLL.Services
{
    public class ConsoleService : IConsoleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ConsoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
