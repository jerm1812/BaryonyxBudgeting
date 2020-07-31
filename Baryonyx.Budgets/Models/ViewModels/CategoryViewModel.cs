using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Budgets.Models.ViewModels
{
    public class CategoryViewModel
    {
        [Required(ErrorMessage = "Category needs a title")]
        [Display(Name = "Category Title")]
        public string CategoryTitle { get; set; }
        
        [Required(ErrorMessage = "Category needs a total")]
        [Display(Name = "Category Total")]
        public decimal CategoryTotal { get; set; }

        [Required(ErrorMessage = "Category needs a type")]
        [Display(Name = "Category Type")]
        public CategoryType CategoryType { get; set; }
        
        public List<CategoryType> CategoryTypes = new List<CategoryType>() { CategoryType.Amount, CategoryType.Percent };
    }
}