using ECommerce.WebUı.Services.CatalogServices.SpecialOfferService;
using ECommerceApp.DtoLayer.CatologDtos.SpecialOfferDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ECommerce.WebUı.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/SpecialOffer")]
    public class SpecialOfferController : Controller
    {
        private readonly ISpecialOfferService _specialOfferService;

        public SpecialOfferController(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Özel Teklifler";
            ViewBag.v3 = "Özel Teklifler Listesi";
            ViewBag.v0 = "Özel Teklifler İşlemleri";

            var values = await _specialOfferService.GetAllAsync();

            return View(values);

        }

        [HttpGet]
        [Route("CreateSpecialOffer")]
        public IActionResult CreateSpecialOffer()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Özel Teklifler";
            ViewBag.v3 = "Yeni Özel Teklifler Girişi";
            ViewBag.v0 = "Özel Teklifler İşlemleri";
            return View();
        }

        [HttpPost]
        [Route("CreateSpecialOffer")]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Özel Teklifler";
            ViewBag.v3 = "Yeni Özel Teklifler Girişi";
            ViewBag.v0 = "Özel Teklifler İşlemleri";

            await _specialOfferService.CreateSpecialOfferAsync(createSpecialOfferDto);

             return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });

            
        }

        [Route("DeleteSpecialOffer/{id}")]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            await _specialOfferService.DeleteSpecialOfferAsync(id);
             return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });

           
        }

        [HttpGet]
        [Route("UpdateSpecialOffer/{id}")]
        public async Task<IActionResult> UpdateSpecialOffer(string id)
        {


            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Özel Teklifler";
            ViewBag.v3 = "Özel Teklifler Güncelleme";
            ViewBag.v0 = "Özel Teklifler İşlemleri";

            var value = await _specialOfferService.GetByIdSpecialOfferAsync(id);
          
                return View(value);
            
            
        }

        [HttpPost]
        [Route("UpdateSpecialOffer/{id}")]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _specialOfferService.UpdateSpecialOfferAsync(updateSpecialOfferDto);
             return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });

            
        }
    }
}
