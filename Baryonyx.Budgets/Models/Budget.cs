using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Budgets.Models
{
    public class Budget
    {
        public int Id { get; set; }
        
        [MaxLength(450)]
        public string UserId { get; set; }
        
        [Required(ErrorMessage = "Budget title is required")]
        [Display(Name = "Budget Title")]
        [MinLength(2), MaxLength(50)]
        public string Title { get; set; }
        
        [Display(Name = "Budget Total")]
        public decimal Total { get; set; }

        [Range(typeof(DateTime), "1/1/1900", "6/6/2079")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        
        [Range(typeof(DateTime), "1/1/1900", "6/6/2079")]
        public DateTime UpdateDate { get; set; } = DateTime.UtcNow;

        public ICollection<Category> Categories { get; set; }
    }
}