using ECommerce.WebUı.Services.CatalogServices.ProductDetailService;
using ECommerceApp.DtoLayer.CatologDtos.ProductDetailDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerce.WebUı.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailInformationComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IProductDetailService _productDetailService;

        public _ProductDetailInformationComponentPartial(IHttpClientFactory httpClientFactory, IProductDetailService productDetailService)
        {
            _httpClientFactory = httpClientFactory;
            _productDetailService = productDetailService;
        }
        [HttpGet]
        [Route("UpdateProductDetail/{id}")]

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _productDetailService.GetByProductIdDetailAsync(id);
            return View(values);
            
            
        }
    }
}
