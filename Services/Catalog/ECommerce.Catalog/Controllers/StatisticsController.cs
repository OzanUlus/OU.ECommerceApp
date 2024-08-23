using ECommerce.Catalog.Services.StatisticServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticService _statisticService;

        public StatisticsController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        [HttpGet("GetBrandCount")]
        public IActionResult GetBrandCount() 
        {
           var value =  _statisticService.GetBrandCount();
            return Ok(value);
        }

        [HttpGet("GetCategoryCount")]
        public IActionResult GetCategoryCount()
        {
            var value = _statisticService.GetCategoryCount();
            return Ok(value);
        }

        [HttpGet("GetProductCount")]
        public IActionResult GetProductCount()
        {
            var value = _statisticService.GetProductCount();
            return Ok(value);
        }

        [HttpGet("GetProductAvgPrice")]
        public IActionResult GetProductAvgPrice()
        {
            var value = _statisticService.GetProductAvgPrice();
            return Ok(value);
        }
    }
}
