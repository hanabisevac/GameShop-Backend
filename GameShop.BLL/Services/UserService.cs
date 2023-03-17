using GameShop.BLL.DTOS;
using GameShop.BLL.Interfaces;
using GameShop.DAL.Entities;
using GameShop.DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public UserService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task<string> LogIn(UserDto userDto)
        {
            var userExist = await _unitOfWork.UserRepository.GetByEmail(userDto.Email);
            if(userExist == null)
            {
                return "User with this e-mail does not exist!";
            }
            if (!VerifyPasswordHash(userDto.Password, userExist.PasswordHash, userExist.PasswordSalt))
            {
                return "Wrong password";
            }
            string token = CreateToken(userExist);

            return token;
        }

        public async Task<bool> Register(UserRegister userRegister)
        {
            CreatePasswordHash(userRegister.Password, out byte[] passwordHash, out byte[] passwordSalt);
            //check if the email is already in the database
            User user = new User()
            {
                Email = userRegister.Email,
                Surname = userRegister.Surname,
                Name = userRegister.Name,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Address = userRegister.Address,
                RoleId = 1
            };

            await _unitOfWork.UserRepository.Add(user);
            await _unitOfWork.CompleteAsync();

            return true;
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.RoleId.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
