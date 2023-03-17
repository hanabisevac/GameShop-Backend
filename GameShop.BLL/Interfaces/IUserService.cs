using GameShop.BLL.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.BLL.Interfaces
{
    public interface IUserService
    {
        Task<bool> Register(UserRegister userRegister);

        Task<string> LogIn(UserDto userDto);
    }
}
