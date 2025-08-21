using Expense_Tracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Tracker.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User> CreateAsync(User user);
        Task<bool> UpdateAsync(int id, User user);
        Task<bool> DeleteAsync(int id);

        Task<object> LoginAsync(LoginModel model);
        Task<object> RefreshTokenAsync(TokenModel tokenModel);
    }
}
