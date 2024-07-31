using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUı.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailFeatureComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() 
        {  
            return View();
        }
    }
}
