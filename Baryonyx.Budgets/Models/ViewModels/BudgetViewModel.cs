using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Budgets.Models.ViewModels
{
    public class BudgetViewModel
    {
        [Required]
        [Display(Name = "Budget Title")]
        public string BudgetTitle { get; set; }
        
        [Required]
        [Display(Name = "Budget Total")]
        public decimal? BudgetTotal { get; set; }
        
        public List<CategoryViewModel> Categories { get; set; }
    }
}