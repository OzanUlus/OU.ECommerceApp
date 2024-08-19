using ECommerce.WebUı.Services.CatalogServices.FeatureService;
using ECommerceApp.DtoLayer.CatologDtos.FeatureDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerce.WebUı.ViewComponents.DefaultViewComponents
{
    public class _FeatureDefaultComponentPartial : ViewComponent
    {

        private readonly IFeatureService _featureService;

        public _FeatureDefaultComponentPartial(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
          var values = await _featureService.GetAllAsync();
            return View(values);
        }
    }
}
