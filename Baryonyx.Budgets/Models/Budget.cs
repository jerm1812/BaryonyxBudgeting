using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Budgets.Models
{
    public class Budget
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        
        [Required(ErrorMessage = "Budget title is required")]
        [Display(Name = "Budget Title")]
        public string Title { get; set; }
        
        [Display(Name = "Budget Total")]
        public decimal Total { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdateDate { get; set; } = DateTime.UtcNow;

        public ICollection<Category> Categories { get; set; }
    }
}