using ECommerce.WebUı.Services.CargoServices.CargoCustomerServices;
using ECommerce.WebUı.Services.UserIdentityServices;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUı.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserIdentityService _userIdentityService;
        private readonly ICargoCustomerService _cargoCustomerService;

        public UserController(IUserIdentityService userIdentityService, ICargoCustomerService cargoCustomerService)
        {
            _userIdentityService = userIdentityService;
            _cargoCustomerService = cargoCustomerService;
        }

        public async Task<IActionResult> UserList()
        {
            var values = await _userIdentityService.GetAllUserAsync();
            return View(values);
        }

        public async Task<IActionResult> UserAddressInfo(string id)
        {
            var value = await _cargoCustomerService.GetCargoCustomerAsync(id);
            return View(value);
        }
    }
}
