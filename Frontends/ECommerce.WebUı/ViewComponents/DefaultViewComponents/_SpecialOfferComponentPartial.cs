using ECommerce.WebUı.Services.CatalogServices.SpecialOfferService;
using ECommerceApp.DtoLayer.CatologDtos.SpecialOfferDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerce.WebUı.ViewComponents.DefaultViewComponents
{
    public class _SpecialOfferComponentPartial : ViewComponent
    {
       private readonly ISpecialOfferService _specialOfferService;

        public _SpecialOfferComponentPartial(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var values = await _specialOfferService.GetAllAsync();
            return View(values);
        }
        
       
    }
}
