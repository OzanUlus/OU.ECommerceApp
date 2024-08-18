using ECommerce.WebUı.Services.CatalogServices.CategoryServices;
using ECommerceApp.DtoLayer.CatologDtos.CategoryDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ECommerce.WebUı.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Category")]
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ICategoryService _categoryService;

        public CategoryController(IHttpClientFactory httpClientFactory, ICategoryService categoryService)
        {
            _httpClientFactory = httpClientFactory;
            _categoryService = categoryService;
        }

        
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
           CategoryViewbagList();

            var values = await _categoryService.GetAllAsync();
            return View(values);
            
        }

        [HttpGet]
        [Route("CreateCategory")]
        public IActionResult CreateCategory()
        {
            CategoryViewbagList();
            return View();
        }

        [HttpPost]
        [Route("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            
            await _categoryService.CreateCategoryAsync(createCategoryDto);
             return RedirectToAction("Index","Category",new {area = "Admin"});

           
        }

        [Route("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            
            await _categoryService.DeleteCategoryAsync(id);
             return RedirectToAction("Index", "Category", new { area = "Admin" });

            
        }

        [HttpGet]
        [Route("UpdateCategory/{id}")]
        public async Task<IActionResult> UpdateCategory(string id)
        {
            CategoryViewbagList();

            var value = await _categoryService.GetByIdCategoryAsync(id);
            return View(value);
        }

        [HttpPost]
        [Route("UpdateCategory/{id}")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto )
        {
            await _categoryService.UpdateCategoryAsync(updateCategoryDto);
            return RedirectToAction("Index", "Category", new { area = "Admin" });

            
        }

        void CategoryViewbagList()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Kategoriler";
            ViewBag.v3 = "Kategori Listesi";
            ViewBag.v0 = "Kategori İşlemleri";

        }
    }
}
