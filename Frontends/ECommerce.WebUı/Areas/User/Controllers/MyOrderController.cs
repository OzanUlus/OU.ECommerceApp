using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUı.Areas.User.Controllers
{
    [Area("User")]
    public class MyOrderController : Controller
    {
        public IActionResult MyOrderList()
        {
            return View();
        }
    }
}
