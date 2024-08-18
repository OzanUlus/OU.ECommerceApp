using ECommerce.WebUı.Services.CatalogServices.CategoryServices;
using ECommerce.WebUı.Services.CatalogServices.ProductServices;
using ECommerceApp.DtoLayer.CatologDtos.CategoryDtos;
using ECommerceApp.DtoLayer.CatologDtos.PrdouctDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace ECommerce.WebUı.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Product")]
    public class ProductController : Controller
    {

        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {

            _productService = productService;
            _categoryService = categoryService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürünler Listesi";
            ViewBag.v0 = "Ürün İşlemleri";

            var values = await _productService.GetAllAsync();

            return View(values);


        }

        [HttpGet]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct()
        {

            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürünle Ekle";
            ViewBag.v0 = "Ürün İşlemleri";

            var values = await _categoryService.GetAllAsync();


            List<SelectListItem> categoryValues = (from c in values
                                                   select new SelectListItem
                                                   {
                                                       Text = c.CategoryName,
                                                       Value = c.CategoryId
                                                   }).ToList();
            ViewBag.CategoryValues = categoryValues;
            return View();
        }


        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {

            await _productService.CreateProductAsync(createProductDto);
            return RedirectToAction("Index", "Product", new { area = "Admin" });


        }

        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction("Index", "Product", new { area = "Admin" });


        }

        [HttpGet]
        [Route("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(string id)
        {


            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Güncelleme";
            ViewBag.v0 = "Ürün İşlemleri";

            var values = await _categoryService.GetAllAsync();


            List<SelectListItem> categoryValues = (from c in values
                                                   select new SelectListItem
                                                   {
                                                       Text = c.CategoryName,
                                                       Value = c.CategoryId
                                                   }).ToList();
            ViewBag.CategoryValues = categoryValues;


            var productValues = await _productService.GetByIdProductAsync(id);

            return View(productValues);
        }


        [HttpPost]
        [Route("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {

            await _productService.UpdateProductAsync(updateProductDto);
            return RedirectToAction("Index", "Product", new { area = "Admin" });


        }

        //[Route("ProductListWithCategory")]
        //public async Task<IActionResult> ProductListWithCategory()
        //{
        //    ViewBag.v1 = "Anasayfa";
        //    ViewBag.v2 = "Ürünler";
        //    ViewBag.v3 = "Ürünler Listesi";
        //    ViewBag.v0 = "Ürün İşlemleri";

        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = await client.GetAsync("https://localhost:7070/api/Products/ProductListWithCategory");
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //        var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
        //        return View(values);
        //    }
        //    return View();
        //}

    }

}

