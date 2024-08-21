using ECommerce.WebUı.Services.BasketServices;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUı.ViewComponents.OrderViewComponents
{
    public class _OrderSummaryComponentPartia : ViewComponent
    {
        private readonly IBasketService _basketService;

        public _OrderSummaryComponentPartia(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var basketTotal = await _basketService.GetBasket();
            var basketItems = basketTotal.BasketItems;
            return View(basketItems);
        }
    }
}
