using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUı.Controllers
{
    public class ShopingCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
