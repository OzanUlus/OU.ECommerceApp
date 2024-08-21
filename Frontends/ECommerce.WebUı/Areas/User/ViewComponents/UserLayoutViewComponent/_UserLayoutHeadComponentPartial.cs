using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUı.Areas.User.ViewComponents.UserLayoutViewComponent
{
    public class _UserLayoutHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        { 
          return View();
        }
    }
}
