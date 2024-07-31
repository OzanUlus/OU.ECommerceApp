using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUı.ViewComponents.ProductListViewComponents
{
    public class _ProductListComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
          return View();
        }
    }
}
