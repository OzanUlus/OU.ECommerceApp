using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUı.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CargoController : Controller
    {
        public IActionResult CargoList()
        {
            return View();
        }
    }
}
