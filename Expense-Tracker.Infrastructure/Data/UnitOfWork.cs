using Expense_Tracker.Domain.Entities;
using Expense_Tracker.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Tracker.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IRepository<User> Users { get; }
        public IRepository<Category> Categories { get; }

        public UnitOfWork(AppDbContext context, IRepository<User> userRepository, IRepository<Category> categoryRepository)
        {
            _context = context;
            Users = userRepository;
            Categories = categoryRepository;
        }

        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
