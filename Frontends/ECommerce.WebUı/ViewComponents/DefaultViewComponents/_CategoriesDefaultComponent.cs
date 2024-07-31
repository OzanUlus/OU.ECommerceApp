using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUı.ViewComponents.DefaultViewComponents
{
    public class _CategoriesDefaultComponent : ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();
        }    
    }
}
