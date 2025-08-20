using Expense_Tracker.Application.Interfaces;
using Expense_Tracker.Domain.Entities;
using Expense_Tracker.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Tracker.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        public UserService(IUnitOfWork uow) => _uow = uow;

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
    }
}
