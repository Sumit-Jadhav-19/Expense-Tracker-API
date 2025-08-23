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
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _uow;
        public AdminService(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        public async Task<IEnumerable<Category>> GetAllAsync() => await _uow.Categories.GetAllAsync();

        public async Task<Category?> GetByIdAsync(int CategoryId) => await _uow.Categories.GetByIdAsync(CategoryId);

        public async Task<Category> CategoryAsync(Category category)
        {
            await _uow.Categories.AddAsync(category);
            await _uow.CompleteAsync();
            return category;
        }
        //public async Task<Category> UpdateAsync()
        //{

        //}
    }
}
