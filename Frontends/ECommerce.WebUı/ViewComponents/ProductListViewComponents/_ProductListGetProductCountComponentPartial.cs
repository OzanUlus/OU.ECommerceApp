using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUı.ViewComponents.ProductListViewComponents
{
    public class _ProductListGetProductCountComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();
        } 
    }
}
