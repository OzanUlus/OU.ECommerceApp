using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUı.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutHeaderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {  
            return View();
        }
    }
}
