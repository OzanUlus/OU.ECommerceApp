using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUı.ViewComponents.ShopingCardViewComponents
{
    public class _ShopingCardCouponComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() 
        { 
            return View();
        }
    }
}
