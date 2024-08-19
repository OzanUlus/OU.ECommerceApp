using ECommerce.WebUı.Services.CatalogServices.FeatureSliderService;
using ECommerceApp.DtoLayer.CatologDtos.FeatureSliderDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerce.WebUı.ViewComponents.DefaultViewComponents
{
    public class _CarouselDefaultComponentPartial : ViewComponent
    {
        private readonly IFeatureSliderService _featureSliderService;

        public _CarouselDefaultComponentPartial(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var values = await _featureSliderService.GetAllAsync();
            return View(values);
        }
    }
}
