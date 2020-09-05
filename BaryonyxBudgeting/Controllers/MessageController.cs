using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BaryonyxBudgeting.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult UpdateMessages()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult SendMessage()
        {
            return View();
        }
    }
}