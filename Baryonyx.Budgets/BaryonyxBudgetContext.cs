using Budgets.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Budgets
{
    public class BaryonyxBudgetContext : DbContext
    {
        public BaryonyxBudgetContext(DbContextOptions<BaryonyxBudgetContext> options) : base(options) {}
        
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}