using ECommerce.WebUı.Services.CatalogServices.ProductImageServices;
using ECommerceApp.DtoLayer.CatologDtos.PrdouctDtos;
using ECommerceApp.DtoLayer.CatologDtos.ProductImageDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerce.WebUı.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailİmageSliderComponentPartial : ViewComponent
    {
        private readonly IProductImageService _productImageService;

        public _ProductDetailİmageSliderComponentPartial(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
             var values = await _productImageService.GetByProductIdProductImageAsync(id);

                return View(values);
          
        }
    }
}
