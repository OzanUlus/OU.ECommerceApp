using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUı.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        public async Task<IActionResult> UserList()
        {
            return View();
        }
    }
}
