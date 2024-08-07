using ECommerce.Catalog.Dtos.SpecialDiscountDtos;
using ECommerce.Catalog.Services.SpecialDiscountServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialDiscountsController : ControllerBase
    {
        private readonly ISpecialDiscountService _specialDiscountService;

        public SpecialDiscountsController(ISpecialDiscountService specialDiscountService)
        {
            _specialDiscountService = specialDiscountService;
        }

        [HttpGet]
        public async Task<IActionResult> SpecialDiscountList()
        {
            var response = await _specialDiscountService.GetAllAsync();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecialDiscountById(string id)
        {
            var response = await _specialDiscountService.GetByIdSpecialDiscountAsync(id);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSpecialDiscount(CreateSpecialDiscountDto createSpecialDiscountDto)
        {
            await _specialDiscountService.CreateSpecialDiscountAsync(createSpecialDiscountDto);
            return Ok("Özel indirim başarı ile eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteSpecialDiscount(string id)
        {
            await _specialDiscountService.DeleteSpecialDiscountAsync(id);
            return Ok("Özel indirim başarı ile silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSpecialDiscount(UpdateSpecialDiscountDto updateSpecialDiscountDto)
        {
            await _specialDiscountService.UpdateSpecialDiscountAsync(updateSpecialDiscountDto);
            return Ok("Özel indirim başarı ile güncellendi");
        }
    }
}
