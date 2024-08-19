using ECommerce.WebUı.Services.CatalogServices.ProductDetailService;
using ECommerceApp.DtoLayer.CatologDtos.ProductDetailDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerce.WebUı.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailDescriptionComponentPartial : ViewComponent
    {
       private readonly IProductDetailService _productDetailService;

        public _ProductDetailDescriptionComponentPartial(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        [HttpGet]
        [Route("UpdateProductDetail/{id}")]
        
        public async Task<IViewComponentResult> InvokeAsync(string id) 
        {
           
            var values = await _productDetailService.GetByIdProductDetailAsync(id);
            return View(values);
        }
    }
}
