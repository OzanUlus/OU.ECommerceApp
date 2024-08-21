using ECommerce.WebUı.Services.Interfaces;
using ECommerce.WebUı.Services.OrderServices.AddressesService;
using ECommerceApp.DtoLayer.OrderDtos.OrderAddressDtos;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUı.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderAddressService _orderAddressService;
        private readonly IUserService _userService;

        public OrderController(IOrderAddressService orderAddressService, IUserService userService)
        {
            _orderAddressService = orderAddressService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateOrderAddressDto createOrderAddressDto)
        {
            var userInfo = await _userService.GetUserInfo();
            createOrderAddressDto.UserId = userInfo.Id;
            createOrderAddressDto.Description = "aaa";
            await _orderAddressService.CreateOrderAddressAsync(createOrderAddressDto);
            return RedirectToAction("Index","Payment");
        }
    }
}
