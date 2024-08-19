using ECommerce.WebUı.Services.CatalogServices.CategoryServices;
using ECommerceApp.DtoLayer.CatologDtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerce.WebUı.ViewComponents.DefaultViewComponents
{
    public class _CategoriesDefaultComponent : ViewComponent
    {

        private readonly ICategoryService _categoryService;

        public _CategoriesDefaultComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var values = await _categoryService.GetAllAsync();
            return View(values);
        }    
    }
}
