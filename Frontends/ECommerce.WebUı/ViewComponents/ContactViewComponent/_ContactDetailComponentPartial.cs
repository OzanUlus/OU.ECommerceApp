using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUı.ViewComponents.ContactViewComponent
{
    public class _ContactDetailComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() 
        { 
            return View();
        }
    }
}
