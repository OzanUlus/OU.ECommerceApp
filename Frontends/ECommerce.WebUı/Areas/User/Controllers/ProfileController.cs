using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUı.Areas.User.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
