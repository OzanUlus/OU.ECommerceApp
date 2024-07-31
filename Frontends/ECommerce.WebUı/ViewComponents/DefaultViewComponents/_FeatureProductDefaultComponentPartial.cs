using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUı.ViewComponents.DefaultViewComponents
{
    public class _FeatureProductDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();
        }
    }
}
