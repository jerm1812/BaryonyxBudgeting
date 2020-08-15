using Budgets.Models;
using Microsoft.EntityFrameworkCore;

namespace Budgets
{
    public class BaryonyxBudgetContext : DbContext
    {
        public BaryonyxBudgetContext(DbContextOptions<BaryonyxBudgetContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var budget = modelBuilder.Entity<Budget>();
            budget.Property(m => m.CreatedDate).HasColumnType("smalldatetime");
            budget.Property(m => m.UpdateDate).HasColumnType("smalldatetime");
            budget.Property(m => m.Total).HasColumnType("decimal(11,2)");

            var category = modelBuilder.Entity<Category>();
            category.Property(m => m.CreatedDate).HasColumnType("smalldatetime");
            category.Property(m => m.UpdateDate).HasColumnType("smalldatetime");
            category.Property(m => m.Total).HasColumnType("decimal(11,2)");
            

            var post = modelBuilder.Entity<Post>();
            post.Property(m => m.PostedDate).HasColumnType("smalldatetime");
            post.Property(m => m.UpdateDate).HasColumnType("smalldatetime");
            post.Property(m => m.Amount).HasColumnType("decimal(11,2)");
            
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}