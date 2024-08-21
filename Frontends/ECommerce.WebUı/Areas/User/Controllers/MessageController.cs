using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUı.Areas.User.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
