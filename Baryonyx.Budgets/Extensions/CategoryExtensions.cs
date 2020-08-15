using System.Globalization;
using System.Linq;
using Budgets.Models;

namespace Budgets.Extensions
{
    public static class CategoryExtensions
    {
        public static string AbbreviateTotal(this Category category)
        {
            return category.Total > 9999 ? $"{category.Total/1000:C}K" : $"{category.Total:C}";
        }

        public static string TotalPosted(this Category category)
        {
            var amount = category.Posts.Sum(x => x.Amount);

            return amount > 9999 ? $"{amount/1000:C}K" : $"{amount:C}";
        }
    }
}
