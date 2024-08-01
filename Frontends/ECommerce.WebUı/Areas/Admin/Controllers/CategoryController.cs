using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUı.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
