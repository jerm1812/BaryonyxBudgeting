using System;

namespace Budgets.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int BudgetId { get; set; }
        public int CommentId { get; set; }
        public DateTime SentDate { get; set; }
    }
}