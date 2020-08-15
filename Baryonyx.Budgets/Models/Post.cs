using System;
using System.ComponentModel.DataAnnotations;

namespace Budgets.Models
{
    public class Post
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
       
        [MaxLength(50)]
        public string Title { get; set; }
        
        [MaxLength(200)]
        public string Notes { get; set; }
        
        [Required]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        public DateTime PostedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdateDate { get; set; } = DateTime.UtcNow;
    }
}