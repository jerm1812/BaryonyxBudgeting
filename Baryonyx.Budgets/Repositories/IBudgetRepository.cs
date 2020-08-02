using System.Linq;
using System.Threading.Tasks;
using Budgets.Models;
using Budgets.Models.ViewModels;

namespace Budgets
{
    public interface IBudgetRepository
    {
        // Gets a list of different budget items
        IQueryable<Budget> Budgets { get; }
        IQueryable<Category> Categories { get; }
        IQueryable<Post> Posts { get; }
        
        // Baryonyx.Budgets
        IQueryable<Budget> GetUserBudgets(string id);
        Budget CreateBudget(BudgetViewModel budget);
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