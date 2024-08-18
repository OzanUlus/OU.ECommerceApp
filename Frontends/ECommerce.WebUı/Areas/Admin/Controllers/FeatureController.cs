using ECommerce.WebUı.Services.CatalogServices.FeatureService;
using ECommerceApp.DtoLayer.CatologDtos.FeatureDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ECommerce.WebUı.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Feature")]
    public class FeatureController : Controller
    {
        private readonly IFeatureService _featureService;

        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Özellikler";
            ViewBag.v3 = "Özellikler Listesi";
            ViewBag.v0 = "Özellikler İşlemleri";

            var values = await _featureService.GetAllAsync();
            return View(values);


        }

        [HttpGet]
        [Route("CreateFeature")]
        public IActionResult CreateFeature()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Özellikler";
            ViewBag.v3 = "Yeni Özellikler Girişi";
            ViewBag.v0 = "Özellikler İşlemleri";
            return View();
        }

        [HttpPost]
        [Route("CreateFeature")]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Özellikler";
            ViewBag.v3 = "Yeni Özellikler Girişi";
            ViewBag.v0 = "Özellikler İşlemleri";

            await _featureService.CreateFeatureAsync(createFeatureDto);
            return RedirectToAction("Index", "Feature", new { area = "Admin" });


        }

        [Route("DeleteFeature/{id}")]
        public async Task<IActionResult> DeleteFeature(string id)
        {
            await _featureService.DeleteFeatureAsync(id);
            return RedirectToAction("Index", "Feature", new { area = "Admin" });


        }

        [HttpGet]
        [Route("UpdateFeature/{id}")]
        public async Task<IActionResult> UpdateFeature(string id)
        {


            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Özellikler";
            ViewBag.v3 = "Özellikler Güncelleme";
            ViewBag.v0 = "Özellikler İşlemleri";

            var value = await _featureService.GetByIdFeatureAsync(id);
            return View(value);

        }

        [HttpPost]
        [Route("UpdateFeature/{id}")]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            await _featureService.UpdateFeatureAsync(updateFeatureDto);
            return RedirectToAction("Index", "Feature", new { area = "Admin" });


        }
    }
}
