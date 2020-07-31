using Budgets;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Security;
using Users;

namespace BaryonyxBudgeting
{
    public static class ServiceExtensions
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            
        }

        public static void ConfigureDataConnections(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BaryonyxBudgetContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("BaryonyxBudgeting"), b => b.MigrationsAssembly("BaryonyxBudgeting")));
            services.AddDbContext<BaryonyxSecurityContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("BaryonyxSecurity"), b => b.MigrationsAssembly("BaryonyxBudgeting")));
            services.AddDbContext<BaryonyxUserContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("BaryonyxUsers"), b => b.MigrationsAssembly("BaryonyxBudgeting")));
            
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                // Password requirements
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 7;

                // User requirements
                options.User.RequireUniqueEmail = true;
            }).AddRoles<IdentityRole>().AddEntityFrameworkStores<BaryonyxSecurityContext>();
        }
        
    }
}