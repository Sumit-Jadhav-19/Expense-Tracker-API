using Expense_Tracker.Application.Interfaces;
using Expense_Tracker.Domain.Entities;
using Expense_Tracker.Domain.Interfaces;
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

namespace Expense_Tracker.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IConfiguration _configuration;

        public UserService(IUnitOfWork uow, IConfiguration configuration)
        {
            _uow = uow;
            _configuration = configuration;
        }

        public async Task<IEnumerable<User>> GetAllAsync() => await _uow.Users.GetAllAsync();


        public async Task<User?> GetByIdAsync(int id) => await _uow.Users.GetByIdAsync(id);


        public async Task<User> CreateAsync(User user)
        {
            await _uow.Users.AddAsync(user);
            await _uow.CompleteAsync();
            return user;
        }


        public async Task<bool> UpdateAsync(int id, User product)
        {
            //var existing = await _uow.Users.GetByIdAsync(id);
            //if (existing == null) return false;
            //existing.Name = product.Name;
            //existing.Price = product.Price;
            //_uow.Products.Update(existing);
            //await _uow.CompleteAsync();
            return true;
        }


        public async Task<bool> DeleteAsync(int id)
        {
            //var existing = await _uow.Products.GetByIdAsync(id);
            //if (existing == null) return false;
            //_uow.Products.Remove(existing);
            //await _uow.CompleteAsync();
            return true;
        }


        public async Task<object> LoginAsync(LoginModel model)
        {
            var users = await _uow.Users.GetAllAsync();
            var user = users.FirstOrDefault(x => x.UserName == model.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
                return "Invalid credentials";

            user.RefreshToken = GenerateRefreshToken();
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            _uow.Users.Update(user);
            await _uow.CompleteAsync();

            return new { Token = GenerateToken(user), RefreshToken = user.RefreshToken };
        }
        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
        private string GenerateToken(User user)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Role, user.Role)
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public async Task<object> RefreshTokenAsync(TokenModel tokenModel)
        {
            var users = await _uow.Users.GetAllAsync();
            var user = users.FirstOrDefault(u => u.RefreshToken == tokenModel.RefreshToken);

            if (user == null || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
                return "Invalid credentials";

            var newAccessToken = GenerateToken(user);
            var newRefreshToken = GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            _uow.Users.Update(user);
            await _uow.CompleteAsync();

            return new
            {
                Token = newAccessToken,
                RefreshToken = newRefreshToken
            };
        }
    }
}
