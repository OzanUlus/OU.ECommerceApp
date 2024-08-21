using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUı.ViewComponents.OrderViewComponents
{
    public class _OrderDetailComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();
        }
    }
}
