using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Budgets;
using Budgets.Models;
using Budgets.Repositories;
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

        public BudgetController(IBudgetRepository repository, UserManager<IdentityUser> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        [Route("/Budget")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/API/RetrieveBudget")]
        [HttpGet]
        public ViewComponentResult BudgetPartialView()
        {
            return ViewComponent("Budget");
        }

        [Route("/API/GetCreateBudgetPartialView")]
        [HttpGet]
        public PartialViewResult CreateBudget()
        {
            return PartialView("CreateBudgetPartialView", new Budget());
        }

        [Route("/API/DeleteBudget")]
        [HttpPost]
        public async Task<JsonResult> DeleteBudget(string id)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (_repository.IsUsersBudget(user.Id, int.Parse(id)))
            {
                _repository.DeleteBudget(int.Parse(id));
                return Json($"Budget with the id: {id} was deleted successfully");
            }
            else
            {
                return Json($"There was an error deleting the budget with the id: {id}");
            }
        }

        [Route("/API/UpdateBudget")]
        [HttpPost]
        public async Task<JsonResult> UpdateBudget(Budget model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                model.UserId = user.Id;
                var budget = _repository.UpdateBudget(model);
                return Json(budget);
            }
            else
            {
                return Json(model);
            }
        }

        [Route("/API/PostToBudget")]
        [HttpGet]
        public PartialViewResult PostToBudget()
        {
            return PartialView();
        }

        [Route("/API/PostToBudget")]
        [HttpPost]
        public async Task<IActionResult> PostToBudget(Post model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                var post = _repository.UpdatePost(model);
                return Json(post);
            }

            return Json(model);
        }
    }
}