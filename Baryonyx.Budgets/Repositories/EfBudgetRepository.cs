using System;
using System.Dynamic;
using System.Linq;
using Budgets.Models;

namespace Budgets.Repositories
{
    public class EfBudgetRepository : IBudgetRepository
    {
        private readonly BaryonyxBudgetContext _context;

        public EfBudgetRepository(BaryonyxBudgetContext context)
        {
            _context = context;
        }

        public IQueryable<Budget> Budgets => _context.Budgets;
        public IQueryable<Category> Categories => _context.Categories;
        public IQueryable<Post> Posts => _context.Posts;

        // Budget methods //
        public Budget GetUserBudget(string id)
        {
            var budget = Budgets.FirstOrDefault(b => b.UserId == id);

            if (budget == null) return null;
            
            budget.Categories = _context.Categories.Where(r => r.BudgetId == budget.Id).ToList();

            foreach (var category in budget.Categories)
            {
                category.Posts = _context.Posts.Where(p => p.CategoryId == category.Id).ToList();
            }

            return budget;
        }

        public bool IsUsersBudget(string userId, int budgetId)
        {
            return _context.Budgets.FirstOrDefault(b => b.UserId == userId && b.Id == budgetId) != null;
        }

        public Budget CreateBudget(Budget budget)
        {
            _context.Budgets.Add(budget);
            _context.SaveChanges();

            foreach (var category in budget.Categories)
            {
                category.Id = 0;
                _context.Categories.Add(category);
            }

            _context.SaveChanges();

            return budget;
        }

        public Budget UpdateBudget(Budget budget)
        {
            if (budget.Id == 0)
            {
                _context.Budgets.Add(budget);
            }
            else
            {
                var currentBudget = Budgets.FirstOrDefault(b => b.Id == budget.Id);

                if (currentBudget != null)
                {
                    currentBudget.Title = budget.Title;
                    currentBudget.Total = budget.Total;
                    currentBudget.Categories = budget.Categories;
                    currentBudget.UpdateDate = DateTime.UtcNow;
                }
            }

            _context.SaveChanges();
            return budget;
        }

        public void DeleteBudget(int id)
        {
            var budget = _context.Budgets.FirstOrDefault(b => b.Id == id);

            if (budget != null)
            {
                _context.Budgets.Remove(budget);
            }

            _context.SaveChanges();
        }

        public bool IsUsersCategory(string userId, int categoryId)
        {

            var budget = _context.Budgets.FirstOrDefault(b => b.UserId == userId);

            return _context.Categories.FirstOrDefault(c => c.Id == categoryId && c.BudgetId == budget.Id) != null;
        }

        public IQueryable<Category> GetBudgetCategory(int id)
        {
            return _context.Categories.Where(r => r.BudgetId == id);
        }

        // Category methods //
        public Category UpdateCategory(Category category)
        {
            if (category.Id == 0)
            {
                _context.Categories.Add(category);
            }
            else
            {
                var currentRow = _context.Categories.FirstOrDefault(r => r.Id == category.Id);

                if (currentRow != null)
                {
                    currentRow.Title = category.Title;
                    currentRow.Total = category.Total;
                    currentRow.Type = category.Type;
                    currentRow.UpdateDate = DateTime.UtcNow;
                }
            }

            _context.SaveChanges();

            return category;
        }

        public void DeleteCategory(int id)
        {
            var row = _context.Categories.FirstOrDefault(r => r.Id == id);

            if (row != null)
            {
                _context.Categories.Remove(row);
            }

            _context.SaveChanges();
        }

        public IQueryable<Post> GetCategoryPosts(int id)
        {
            return _context.Posts.Where(p => p.CategoryId == id);
        }

        // Post methods //
        public Post UpdatePost(Post post)
        {
            if (post.Id == 0)
            {
                _context.Posts.Add(post);
            }
            else
            {
                var currentPost = _context.Posts.FirstOrDefault(p => p.Id == post.Id);

                if (currentPost != null)
                {
                    currentPost.Amount = post.Amount;
                    currentPost.Title = post.Title;
                    currentPost.Notes = post.Notes;
                    currentPost.UpdateDate = DateTime.UtcNow;
                }
            }

            _context.SaveChanges();

            return post;
        }

        public void DeletePost(int id)
        {
            var post = _context.Posts.FirstOrDefault(p => p.Id == id);

            if (post != null)
            {
                _context.Posts.Remove(post);
            }

            _context.SaveChanges();
        }
    }
}