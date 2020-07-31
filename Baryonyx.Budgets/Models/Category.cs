using System;
using System.Collections.Generic;
using System.Linq;

namespace Budgets.Models
{
    public class Category
    {
        public int Id { get; set; }
        public int BudgetId { get; set; }
        public string Title { get; set; }
        public string Total { get; set; }
        public CategoryType Type { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        
        public IQueryable<Post> Posts { get; set; }
    }
}