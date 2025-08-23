using Expense_Tracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Tracker.Application.Interfaces
{
    public interface IAdminService
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int CategoryId);
        Task<Category> CategoryAsync(Category category);
    }
}
