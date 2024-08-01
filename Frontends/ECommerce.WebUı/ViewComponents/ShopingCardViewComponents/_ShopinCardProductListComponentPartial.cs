using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUı.ViewComponents.ShopingCardViewComponents
{
    public class _ShopinCardProductListComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();
        }
    }
}
