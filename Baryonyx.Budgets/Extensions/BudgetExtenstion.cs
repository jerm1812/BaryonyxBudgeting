using System.Globalization;
using System.Linq;
using Budgets.Models;

namespace Budgets.Extensions
{
    public static class BudgetExtenstion
    {
        public static string AbbreviateTotal(this Budget budget)
        {
            string total;
            
            if (budget.Total > 9999)
                total = (budget.Total / 1000) + "K";
            else
                total = budget.Total.ToString(CultureInfo.CurrentCulture);

            return total;
        }

        public static decimal TotalPosted(this Budget budget)
        {
            return budget.Categories.Sum(r => r.Posts.Sum(post => post.Amount));
        }
    }
}