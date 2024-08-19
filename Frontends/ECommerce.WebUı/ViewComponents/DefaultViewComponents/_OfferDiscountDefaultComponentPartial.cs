using ECommerce.WebUı.Services.CatalogServices.SpecialDiscountService;
using ECommerceApp.DtoLayer.CatologDtos.SpecialDiscountDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerce.WebUı.ViewComponents.DefaultViewComponents
{
    public class _OfferDiscountDefaultComponentPartial : ViewComponent
    {
        private readonly ISpecialDiscountService _specialDiscountService;

        public _OfferDiscountDefaultComponentPartial(ISpecialDiscountService specialDiscountService)
        {
            _specialDiscountService = specialDiscountService;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var values = await _specialDiscountService.GetAllAsync();
            return View(values);
        }
    }
}
