using ECommerce.WebUı.Services.CatalogServices.CategoryServices;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUı.ViewComponents.UILayoutViewComponents
{
    public class _NavbarUILayoutComponentPartial : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _NavbarUILayoutComponentPartial(ICategoryService categoryService)
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
