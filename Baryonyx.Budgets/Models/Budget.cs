using System;
using System.Collections.Generic;
using System.Linq;

namespace Budgets.Models
{
    public class Budget
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public decimal Total { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public IQueryable<Category> Rows { get; set; }
    }
}