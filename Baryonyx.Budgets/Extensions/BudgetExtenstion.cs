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

        public static string TotalPosted(this Budget budget)
        {
            string total;
            var amount = budget.Categories.Sum(r => r.Posts.Sum(post => post.Amount));

            if (amount > 9999)
                total = (amount / 1000) + "K";
            else
                total = amount.ToString(CultureInfo.CurrentCulture);
            
            return total;
        }
    }
}