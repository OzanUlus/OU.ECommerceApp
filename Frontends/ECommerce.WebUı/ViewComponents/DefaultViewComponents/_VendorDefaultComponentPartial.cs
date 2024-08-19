using ECommerce.WebUı.Services.CatalogServices.BrandService;
using ECommerceApp.DtoLayer.CatologDtos.BrandDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerce.WebUı.ViewComponents.DefaultViewComponents
{
    public class _VendorDefaultComponentPartial : ViewComponent
    {
        private readonly IBrandService _brandService;

        public _VendorDefaultComponentPartial(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var values = await _brandService.GetAllAsync();
            return View(values);
        }    
    }
}
