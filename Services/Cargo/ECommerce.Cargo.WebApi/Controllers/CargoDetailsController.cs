using ECommerce.Cargo.BusinessLayer.Abstract;
using ECommerce.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using ECommerce.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailsController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }

        [HttpGet]
        public IActionResult CargoDetailList()
        {
            var values = _cargoDetailService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
        {
            CargoDetail cargoDetail = new()
            {
                Barcode = createCargoDetailDto.Barcode,
                RecieverCustomer = createCargoDetailDto.RecieverCustomer,
                CargoCamponyId = createCargoDetailDto.CargoCamponyId,
                SenderCustomer = createCargoDetailDto.SenderCustomer,
            };
            _cargoDetailService.TInsert(cargoDetail);
            return Ok("Kargo detay başırıyla oluşturuldu.");
        }

        [HttpDelete]
        public IActionResult DeleteCargoDetail(int id)
        {
            _cargoDetailService.TDelete(id);
            return Ok("Kargo detay başırıyla silindi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoDetailById(int id)
        {
            var value = _cargoDetailService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
        {
            CargoDetail CargoDetail = new()
            {
                 CargoDetailId = updateCargoDetailDto.CargoDetailId,
                Barcode = updateCargoDetailDto.Barcode,
                RecieverCustomer = updateCargoDetailDto.RecieverCustomer,
                CargoCamponyId = updateCargoDetailDto.CargoCamponyId,
                SenderCustomer = updateCargoDetailDto.SenderCustomer,

            };
            _cargoDetailService.TUpdate(CargoDetail);
            return Ok("Kargo detay başırıyla güncellendi.");
        }
    }
}
