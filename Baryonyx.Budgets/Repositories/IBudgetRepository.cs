using System.Linq;
using System.Threading.Tasks;
using Budgets.Models;

namespace Budgets
{
    public interface IBudgetRepository
    {
        // Gets a list of different budget items
        IQueryable<Budget> Budgets { get; }
        IQueryable<Category> Rows { get; }
        IQueryable<Post> Posts { get; }
        
        // Baryonyx.Budgets
        IQueryable<Budget> GetUserBudgets(string id);
        Budget UpdateBudget(Budget budget);
        void DeleteBudget(int id);
        
        // Budget lines
        IQueryable<Category> GetBudgetRows(int id);
        Category UpdateRow(Category category);
        void DeleteRow(int id);
        
        // Budget posts
        IQueryable<Post> GetRowPosts(int id);
        Post UpdatePost(Post post);
        void DeletePost(int id);
    }
}