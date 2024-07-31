using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUı.ViewComponents.ProductListViewComponents
{
    public class _ProductListPagenationComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();
        }
    }
}
