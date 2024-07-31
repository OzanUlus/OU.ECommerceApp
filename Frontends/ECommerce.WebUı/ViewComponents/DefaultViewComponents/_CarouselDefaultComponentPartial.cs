using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUı.ViewComponents.DefaultViewComponents
{
    public class _CarouselDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
         return View();
        }
    }
}
