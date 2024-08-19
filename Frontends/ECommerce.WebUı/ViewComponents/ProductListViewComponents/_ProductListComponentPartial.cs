using ECommerce.WebUı.Services.CatalogServices.CategoryServices;
using ECommerce.WebUı.Services.CatalogServices.ProductServices;
using ECommerceApp.DtoLayer.CatologDtos.CategoryDtos;
using ECommerceApp.DtoLayer.CatologDtos.PrdouctDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerce.WebUı.ViewComponents.ProductListViewComponents
{
    public class _ProductListComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _ProductListComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _productService.GetProductsWithCategoryByCategoryIdAsync(id);         
                return View(values);
    
        }
    }
}

