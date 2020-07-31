using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Budgets;
using Budgets.Models;
using Budgets.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BaryonyxBudgeting.Controllers
{
    [Authorize]
    public class BudgetController : Controller
    {
        private readonly IBudgetRepository _repository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;

        public BudgetController(IBudgetRepository repository, UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _repository = repository;
            _userManager = userManager;
            _configuration = configuration;
        }

        [Route("/Budgets")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var budgets = _repository.GetUserBudgets(user.Id);
            
            return View(budgets);
        }

        [Route("/CreateBudget")]
        [HttpGet]
        public PartialViewResult CreateBudget()
        {
            return PartialView("CreateBudget");
        }

        [HttpGet("CheckBudgetLimit")]
        public async Task<IActionResult> CheckBudgetLimit()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var budgets = _repository.GetUserBudgets(user.Id);

            return budgets.Count() < _configuration.GetValue<int>("BudgetLimit") ? Ok("can create budget") : Problem("budget limit reached");
        }

        [Route("/UpdateBudget")]
        [HttpPost]
        public IActionResult UpdateBudget(BudgetViewModel model)
        {
            try
            {
                var valid = ModelState.IsValid;
                return Json(new {success = valid, model = model});

            }
            catch (Exception ex)
            {
                return Problem("unable to update budget" + ex);
            }
        }
    }
}