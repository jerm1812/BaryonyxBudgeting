using System.Threading.Tasks;
using Budgets;
using Budgets.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BaryonyxBudgeting.Components
{
    public class BudgetViewComponent : ViewComponent
    {
        private readonly IBudgetRepository _repository;
        private readonly UserManager<IdentityUser> _userManager;

        public BudgetViewComponent(IBudgetRepository repository, UserManager<IdentityUser> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var budgets = _repository.GetUserBudgets(user.Id);
            return View("BudgetViewComponent", budgets);
        }
    }
}