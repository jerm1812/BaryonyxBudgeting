using Microsoft.AspNetCore.Mvc;

namespace BaryonyxBudgeting.Controllers
{
    public class UserController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}