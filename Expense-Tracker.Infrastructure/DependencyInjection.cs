using Expense_Tracker.Domain.Interfaces;
using Expense_Tracker.Infrastructure.Data;
using Expense_Tracker.Infrastructure.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
 
namespace Expense_Tracker.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection")!;


            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString,
            b => b.MigrationsAssembly("Expense-Tracker.Api")));
            // For SQLite instead: options.UseSqlite(connectionString)


            // Open generic registration for IRepository<>
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));


            // Unit of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            return services;
        }
    }
}
