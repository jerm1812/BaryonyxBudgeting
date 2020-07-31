using System;

namespace Budgets.Models
{
    public class Post
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Notes { get; set; }
        public decimal Amount { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}