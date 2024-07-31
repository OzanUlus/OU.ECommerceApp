using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUı.ViewComponents.UILayoutViewComponents
{
    public class _ScriptUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();
        }    
    }
}
