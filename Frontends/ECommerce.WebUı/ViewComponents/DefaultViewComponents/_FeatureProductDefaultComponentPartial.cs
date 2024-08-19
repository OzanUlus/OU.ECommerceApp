using ECommerce.WebUı.Services.CatalogServices.ProductServices;
using ECommerceApp.DtoLayer.CatologDtos.PrdouctDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerce.WebUı.ViewComponents.DefaultViewComponents
{
    public class _FeatureProductDefaultComponentPartial : ViewComponent
    {

       private readonly IProductService _productService;

        public _FeatureProductDefaultComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {

          var values = await _productService.GetAllAsync();
            return View(values);
        }
    }
}
