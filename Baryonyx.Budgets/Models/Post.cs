using System;
using System.ComponentModel.DataAnnotations;

namespace Budgets.Models
{
    public class Post
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
       
        [MinLength(2), MaxLength(50)]
        public string Title { get; set; }
        
        [MinLength(2), MaxLength(200)]
        public string Notes { get; set; }
        public decimal Total { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}