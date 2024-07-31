using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUı.ViewComponents.ProductListViewComponents
{
    public class _ProductListColorFilterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke () 
        { 
            return View();
        }    
    }
}
