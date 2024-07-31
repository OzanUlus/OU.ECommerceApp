using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUı.Controllers
{
    public class ProductListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
