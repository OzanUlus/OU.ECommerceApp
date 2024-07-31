using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUı.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
