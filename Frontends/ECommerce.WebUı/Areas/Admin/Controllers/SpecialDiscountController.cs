using ECommerceApp.DtoLayer.CatologDtos.SpecialDiscountDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ECommerce.WebUı.Areas.Admin.Controllers
{

    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/SpecialDiscount")]
    public class SpecialDiscountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SpecialDiscountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Özel Fırsatlar";
            ViewBag.v3 = "Özel Fırsatlar Listesi";
            ViewBag.v0 = "Özel Fırsatlar İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/SpecialDiscounts");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSpecialDiscountDto>>(jsonData);
                return View(values);
            }
            return View();
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

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSpecialDiscountDto);
            StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7070/api/SpecialDiscounts", stringContent);

            if (responseMessage.IsSuccessStatusCode) return RedirectToAction("Index", "SpecialDiscount", new { area = "Admin" });

            return View();
        }

        [Route("DeleteSpecialDiscount/{id}")]
        public async Task<IActionResult> DeleteSpecialDiscount(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7070/api/SpecialDiscounts?id=" + id);

            if (responseMessage.IsSuccessStatusCode) return RedirectToAction("Index", "SpecialDiscount", new { area = "Admin" });

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

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/SpecialDiscounts/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateSpecialDiscountDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        [Route("UpdateSpecialDiscount/{id}")]
        public async Task<IActionResult> UpdateSpecialDiscount(UpdateSpecialDiscountDto updateSpecialDiscountDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateSpecialDiscountDto);
            StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7070/api/SpecialDiscounts", stringContent);

            if (responseMessage.IsSuccessStatusCode) return RedirectToAction("Index", "SpecialDiscount", new { area = "Admin" });

            return View();
        }
    }
}
