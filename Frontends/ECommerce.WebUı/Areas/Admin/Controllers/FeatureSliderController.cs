using ECommerce.WebUı.Services.CatalogServices.FeatureSliderService;
using ECommerceApp.DtoLayer.CatologDtos.FeatureSliderDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ECommerce.WebUı.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/FeatureSlider")]
    public class FeatureSliderController : Controller
    {
        private readonly IFeatureSliderService _featureSliderService;

        public FeatureSliderController(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Öne Çıkan Görsel";
            ViewBag.v3 = "Öne Çıkan Görsel Listesi";
            ViewBag.v0 = "Öne Çıkan Görsel İşlemleri";

            var values = await _featureSliderService.GetAllAsync();
            return View(values);

        }

        [HttpGet]
        [Route("CreateFeatureSlider")]
        public IActionResult CreateFeatureSlider()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Öne Çıkan Görsel";
            ViewBag.v3 = "Yeni Öne Çıkan Görsel Girişi";
            ViewBag.v0 = "Öne Çıkan Görsel İşlemleri";
            return View();
        }

        [HttpPost]
        [Route("CreateFeatureSlider")]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Öne Çıkan Görsel";
            ViewBag.v3 = "Yeni Öne Çıkan Görsel Girişi";
            ViewBag.v0 = "Öne Çıkan Görsel İşlemleri";
            createFeatureSliderDto.Status = false;
            await _featureSliderService.CreateFeatureSliderAsync(createFeatureSliderDto);
            return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });

            
        }

        [Route("DeleteFeatureSlider/{id}")]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            await _featureSliderService.DeleteFeatureSliderAsync(id);
            return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });

            
        }

        [HttpGet]
        [Route("UpdateFeatureSlider/{id}")]
        public async Task<IActionResult> UpdateFeatureSlider(string id)
        {


            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Öne Çıkan Görsel";
            ViewBag.v3 = "Öne Çıkan Görsel Güncelleme";
            ViewBag.v0 = "Öne Çıkan Görsel İşlemleri";

            var value = await _featureSliderService.GetByIdFeatureSliderAsync(id);
           
                return View(value);
          
        }

        [HttpPost]
        [Route("UpdateFeatureSlider/{id}")]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
             await _featureSliderService.UpdateFeatureSliderAsync(updateFeatureSliderDto);
             return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });

            
        }
    }
}
