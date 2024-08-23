using ECommerce.WebUı.Services.CargoServices.CargoCompanyServices;
using ECommerceApp.DtoLayer.CargoDtos.CargoCompanyDtos;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUı.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Cargo")]
    public class CargoController : Controller
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        [HttpGet]

        public async Task<IActionResult> CargoCompanyList()
        {
            var values = await _cargoCompanyService.GetAllAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreateCargoCompany")]
        public IActionResult CreateCargoCompany()
        {
            
            return View();
        }

        [HttpPost]
        [Route("CreateCargoCompany")]
        public async Task<IActionResult> CreateCargoCompany(CreateCargoCompantDto createCargoCompantDto)
        {
            

            await _cargoCompanyService.CreateCargoCompanyAsync(createCargoCompantDto);
            return RedirectToAction("CargoCompanyList", "Cargo", new { area = "Admin" });


        }

        [Route("DeleteCargoCompany/{id}")]
        public async Task<IActionResult> DeleteCargoCompany(string id)
        {

            await _cargoCompanyService.DeleteCargoCompanyAsync(id);
            return RedirectToAction("CargoCompanyList", "Cargo", new { area = "Admin" });


        }

        [HttpGet]
        [Route("UpdateCargoCompany/{id}")]
        public async Task<IActionResult> UpdateCargoCompany(string id)
        {

            var value = await _cargoCompanyService.GetByIdCargoCompanyAsync(id);
            return View(value);

        }

        [HttpPost]
        [Route("UpdateCargoCompany/{id}")]
        public async Task<IActionResult> UpdateCargoCompany(UpdateCargoCompantDto updateCargoCompantDto )
        {
            await _cargoCompanyService.UpdateCargoCompanyAsync(updateCargoCompantDto);
            return RedirectToAction("CargoCompanyList", "Cargo", new { area = "Admin" });


        }
    }
}
