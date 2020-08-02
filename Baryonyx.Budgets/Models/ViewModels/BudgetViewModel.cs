using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Budgets.Models.ViewModels
{
    public class BudgetViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdateDate { get; set; } = DateTime.UtcNow;
        
        [Required(ErrorMessage = "Budget title is required")]
        [Display(Name = "Budget Title")]
        public string BudgetTitle { get; set; }
        
        [Display(Name = "Budget Total")]
        public decimal BudgetTotal { get; set; }
        
        public List<CategoryViewModel> Categories { get; set; }
    }
}