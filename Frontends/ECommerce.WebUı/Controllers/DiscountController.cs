using ECommerce.WebUı.Services.BasketServices;
using ECommerce.WebUı.Services.DiscountServices;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUı.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;
        private readonly IBasketService _basketService;

        public DiscountController(IDiscountService discountService, IBasketService basketService)
        {
            _discountService = discountService;
            _basketService = basketService;
        }

        [HttpGet]
        public PartialViewResult ConfirmDiscountCoupon()
        {

            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDiscountCoupon(string code)
        {
            
            var values = await _discountService.GetDiscountCode(code);
            return View(values);
        }
    }
}
