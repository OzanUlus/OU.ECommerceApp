using ECommerce.WebUı.Services.CatalogServices.BrandService;
using ECommerceApp.DtoLayer.CatologDtos.BrandDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ECommerce.WebUı.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Brand")]
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Markalar";
            ViewBag.v3 = "Markalar Listesi";
            ViewBag.v0 = "Markalar İşlemleri";


            var values = await _brandService.GetAllAsync();
            return View(values);


        }

        [HttpGet]
        [Route("CreateBrand")]
        public IActionResult CreateBrand()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Markalar";
            ViewBag.v3 = "Yeni Marka Girişi";
            ViewBag.v0 = "Markalar İşlemleri";
            return View();
        }

        [HttpPost]
        [Route("CreateBrand")]
        public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Markalar";
            ViewBag.v3 = "Yeni Marka Girişi";
            ViewBag.v0 = "Markalar İşlemleri";

            await _brandService.CreateBrandAsync(createBrandDto);
            return RedirectToAction("Index", "Brand", new { area = "Admin" });


        }

        [Route("DeleteBrand/{id}")]
        public async Task<IActionResult> DeleteBrand(string id)
        {

            await _brandService.DeleteBrandAsync(id);
            return RedirectToAction("Index", "Brand", new { area = "Admin" });


        }

        [HttpGet]
        [Route("UpdateBrand/{id}")]
        public async Task<IActionResult> UpdateBrand(string id)
        {


            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Markalar";
            ViewBag.v3 = "Marka Güncelleme";
            ViewBag.v0 = "Markalar İşlemleri";


            var value = await _brandService.GetByIdBrandAsync(id);
            return View(value);

        }

        [HttpPost]
        [Route("UpdateBrand/{id}")]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
        {
            await _brandService.UpdateBrandAsync(updateBrandDto);
            return RedirectToAction("Index", "Brand", new { area = "Admin" });


        }
    }
}
