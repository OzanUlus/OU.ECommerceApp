using ECommerce.WebUı.Services.CatalogServices.SpecialDiscountService;
using ECommerceApp.DtoLayer.CatologDtos.SpecialDiscountDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ECommerce.WebUı.Areas.Admin.Controllers
{

    [Area("Admin")]

    [Route("Admin/SpecialDiscount")]
    public class SpecialDiscountController : Controller
    {
        private readonly ISpecialDiscountService _specialDiscountService;

        public SpecialDiscountController(ISpecialDiscountService specialDiscountService)
        {
            _specialDiscountService = specialDiscountService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Özel Fırsatlar";
            ViewBag.v3 = "Özel Fırsatlar Listesi";
            ViewBag.v0 = "Özel Fırsatlar İşlemleri";

           
                var values = await _specialDiscountService.GetAllAsync();
                return View(values);
           
        }

        [HttpGet]
        [Route("CreateSpecialDiscount")]
        public IActionResult CreateSpecialDiscount()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Özel Fırsatlar";
            ViewBag.v3 = "Yeni Özel Fırsat Girişi";
            ViewBag.v0 = "Özel Fırsatlar İşlemleri";
            return View();
        }

        [HttpPost]
        [Route("CreateSpecialDiscount")]
        public async Task<IActionResult> CreateSpecialDiscount(CreateSpecialDiscountDto createSpecialDiscountDto)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Özel Fırsatlar";
            ViewBag.v3 = "Yeni Özel Fırsat Girişi";
            ViewBag.v0 = "Özel Fırsatlar İşlemleri";
            await _specialDiscountService.CreateSpecialDiscountAsync(createSpecialDiscountDto);
            return RedirectToAction("Index", "SpecialDiscount", new { area = "Admin" });

           
        }

        [Route("DeleteSpecialDiscount/{id}")]
        public async Task<IActionResult> DeleteSpecialDiscount(string id)
        {
            await _specialDiscountService.DeleteSpecialDiscountAsync(id);
             return RedirectToAction("Index", "SpecialDiscount", new { area = "Admin" });

            return View();
        }

        [HttpGet]
        [Route("UpdateSpecialDiscount/{id}")]
        public async Task<IActionResult> UpdateSpecialDiscount(string id)
        {


            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Özel Fırsatlar";
            ViewBag.v3 = "Özel Fırsatlar Güncelleme";
            ViewBag.v0 = "Özel Fırsatlar İşlemleri";

           
                var value = await _specialDiscountService.GetByIdSpecialDiscountAsync(id);
                return View(value);
            
            
        }

        [HttpPost]
        [Route("UpdateSpecialDiscount/{id}")]
        public async Task<IActionResult> UpdateSpecialDiscount(UpdateSpecialDiscountDto updateSpecialDiscountDto)
        {
            await _specialDiscountService.UpdateSpecialDiscountAsync(updateSpecialDiscountDto);
             return RedirectToAction("Index", "SpecialDiscount", new { area = "Admin" });

           
        }
    }
}
