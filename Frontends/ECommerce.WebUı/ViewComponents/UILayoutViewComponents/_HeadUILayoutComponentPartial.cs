using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUı.ViewComponents.UILayoutViewComponents
{
    public class _HeadUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() 
        { 
            return View();
        }
    }
}
