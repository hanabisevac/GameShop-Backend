using GameShop.BLL.DTOS;
using GameShop.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<bool>> Register(UserRegister request)
        {
            return Ok(await _userService.Register(request));
        }

        [HttpPost("LogIn")]
        public async Task<ActionResult<string>> LogIn(UserDto request)
        {
            return Ok(await _userService.LogIn(request));
        }
    }
}
