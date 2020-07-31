using System;
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
        public IQueryable<Category> Rows => _context.Rows;
        public IQueryable<Post> Posts => _context.Posts;
        
        // Budget methods //
        public IQueryable<Budget> GetUserBudgets(string id)
        {
            var budgets = Budgets.Where(b => b.UserId == id);

            foreach (var budget in budgets)
            {
                budget.Rows = _context.Rows.Where(r => r.BudgetId == budget.Id);

                foreach (var row in budget.Rows)
                {
                    row.Posts = _context.Posts.Where(p => p.CategoryId == row.Id);
                }
            }

            return budgets;
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
                    currentBudget.Rows = budget.Rows;
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

        public IQueryable<Category> GetBudgetRows(int id)
        {
            return _context.Rows.Where(r => r.BudgetId == id);
        }

        // Row methods //
        public Category UpdateRow(Category category)
        {
            if (category.Id == 0)
            {
                _context.Rows.Add(category);
            }
            else
            {
                var currentRow = _context.Rows.FirstOrDefault(r => r.Id == category.Id);
                
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

        public void DeleteRow(int id)
        {
            var row = _context.Rows.FirstOrDefault(r => r.Id == id);

            if (row != null)
            {
                _context.Rows.Remove(row);
            }

            _context.SaveChanges();
        }

        public IQueryable<Post> GetRowPosts(int id)
        {
            return _context.Posts.Where(p => p.CategoryId == id);
        }

        // Post methods //
        public Post UpdatePost(Post post)
        {
            if (post.Id == 0)
            {
                _context.Add(post);
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