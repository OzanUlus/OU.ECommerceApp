using ECommerce.Cargo.BusinessLayer.Abstract;
using ECommerce.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using ECommerce.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _customerService;

        public CargoCustomersController(ICargoCustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult CargoCustomerList()
        {
            var values = _customerService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
        {
            CargoCustomer CargoCustomer = new()
            {
                Address = createCargoCustomerDto.Address,
                City = createCargoCustomerDto.City,
                District = createCargoCustomerDto.District,
                Email = createCargoCustomerDto.Email,
                Name = createCargoCustomerDto.Name,
                PhoneNumber = createCargoCustomerDto.PhoneNumber,
                Surname = createCargoCustomerDto.Surname
            };
            _customerService.TInsert(CargoCustomer);
            return Ok("Kargo müşterisi başırıyla oluşturuldu.");
        }

        [HttpDelete]
        public IActionResult DeleteCargoCustomer(int id)
        {
            _customerService.TDelete(id);
            return Ok("Kargo müşterisi başırıyla silindi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCustomerById(int id)
        {
            var value = _customerService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            CargoCustomer CargoCustomer = new()
            {
                CargoCustomerId = updateCargoCustomerDto.CargoCustomerId,
                City = updateCargoCustomerDto.City,
                District = updateCargoCustomerDto.District,
                Address = updateCargoCustomerDto.Address,
                Email = updateCargoCustomerDto.Email,
                Name = updateCargoCustomerDto.Name,
                PhoneNumber = updateCargoCustomerDto.PhoneNumber,
                Surname = updateCargoCustomerDto.Surname

            };
            _customerService.TUpdate(CargoCustomer);
            return Ok("Kargo müşterisi başırıyla güncellendi.");
        }
    }
}
