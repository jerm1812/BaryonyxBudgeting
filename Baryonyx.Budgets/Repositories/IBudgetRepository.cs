using System.Linq;
using Budgets.Models;

namespace Budgets.Repositories
{
    public interface IBudgetRepository
    {
        // Gets a list of different budget items
        IQueryable<Budget> Budgets { get; }
        IQueryable<Category> Categories { get; }
        IQueryable<Post> Posts { get; }
        
        // Baryonyx.Budgets
        IQueryable<Budget> GetUserBudgets(string id);
        bool IsUsersBudget(string userId, int budgetId);
        Budget CreateBudget(Budget budget);
        Budget UpdateBudget(Budget budget);
        void DeleteBudget(int id);
        
        // Budget Categories
        IQueryable<Category> GetBudgetRows(int id);
        Category UpdateRow(Category category);
        void DeleteRow(int id);
        
        // Budget posts
        IQueryable<Post> GetRowPosts(int id);
        Post UpdatePost(Post post);
        void DeletePost(int id);
    }
}