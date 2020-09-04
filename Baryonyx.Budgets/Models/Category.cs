using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Budgets.Models
{
    public class Category
    {
        public int Id { get; set; }
        public int BudgetId { get; set; }
        
        [Required(ErrorMessage = "Category needs a title")]
        [Display(Name = "Category Title")]
        [MinLength(2), MaxLength(50)]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "Category needs a total")]
        [Display(Name = "Category Total")]
        public decimal Total { get; set; }
        
        [Required(ErrorMessage = "Category needs a type")]
        [Display(Name = "Category Type")]
        public CategoryType Type { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdateDate { get; set; }  = DateTime.UtcNow;
        
        public ICollection<Post> Posts { get; set; }
    }
}