using ECommerce.WebUı.Services.CatalogServices.AboutService;
using ECommerceApp.DtoLayer.CatologDtos.AboutDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace ECommerce.WebUı.ViewComponents.UILayoutViewComponents
{
    public class _FooterUILayoutComponentPartial : ViewComponent
    {
        private readonly IAboutService _aboutService;

        public _FooterUILayoutComponentPartial(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [Route("Index")]
      
        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var values = await _aboutService.GetAllAsync();
            return View(values);
           
        }    
    }
}
