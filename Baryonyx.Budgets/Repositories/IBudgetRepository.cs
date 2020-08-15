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
        Budget GetUserBudget(string id);
        bool IsUsersBudget(string userId, int budgetId);
        Budget CreateBudget(Budget budget);
        Budget UpdateBudget(Budget budget);
        void DeleteBudget(int id);
        
        // Budget Categories
        bool IsUsersCategory(string userId, int categoryId);
        IQueryable<Category> GetBudgetCategory(int id);
        Category UpdateCategory(Category category);
        void DeleteCategory(int id);
        
        // Budget posts
        IQueryable<Post> GetCategoryPosts(int id);
        Post UpdatePost(Post post);
        void DeletePost(int id);
    }
}