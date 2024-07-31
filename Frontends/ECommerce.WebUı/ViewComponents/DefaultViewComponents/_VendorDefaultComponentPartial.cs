using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUı.ViewComponents.DefaultViewComponents
{
    public class _VendorDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();
        }    
    }
}
