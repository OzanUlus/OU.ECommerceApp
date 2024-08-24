using ECommerce.WebUı.Services.CommentServices;
using ECommerce.WebUı.Services.StatisticsServices.CatalogStatisticServices;
using ECommerce.WebUı.Services.StatisticsServices.DiscountStatisticServices;
using ECommerce.WebUı.Services.StatisticsServices.UserStatisticServices;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUı.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StatisticController : Controller
    {
        private readonly ICatalogStatisticService _catalogStatisticService;
        private readonly IUserStatisticService _userStatisticService;
        private readonly ICommentService _commentService;
        private readonly IDiscountStatisticService _discountStatisticService;

        public StatisticController(ICatalogStatisticService catalogStatisticService, IUserStatisticService userStatisticService, ICommentService commentService, IDiscountStatisticService discountStatisticService)
        {
            _catalogStatisticService = catalogStatisticService;
            _userStatisticService = userStatisticService;
            _commentService = commentService;
            _discountStatisticService = discountStatisticService;
        }

        public async Task<IActionResult> Index()
        {
            var brandCount = await _catalogStatisticService.GetBrandCount();
            ViewBag.BrandCount = brandCount;

            var categoryCount = await _catalogStatisticService.GetCategoryCount();
            ViewBag.categoryCount = categoryCount;

            var getMaxPriceProductName = await _catalogStatisticService.GetMaxPriceProductName();
            ViewBag.GetMaxPriceProductName = getMaxPriceProductName;

            var getMinPriceProductName = await _catalogStatisticService.GetMinPriceProductName();
            ViewBag.GetMinPriceProductName = getMinPriceProductName;

            var getProductCount = await _catalogStatisticService.GetProductCount();
            ViewBag.GetProductCount = getProductCount;

            //var getProductAvgPrice = await _catalogStatisticService.GetProductAvgPrice();
            //ViewBag.GetProductAvgPrice = getProductAvgPrice;

            var getUserCount = await _userStatisticService.GetUserCountAsync();
            ViewBag.GetUserCount = getUserCount;

            var getTotalCommentCount = await _commentService.GetTotalCommentCount();
            ViewBag.GetTotalCommentCount = getTotalCommentCount;

            var getActiveCommentCount = await _commentService.GetActiveCommentCount();
            ViewBag.GetActiveCommentCount = getActiveCommentCount;

            var getPassiveCommentCount = await _commentService.GetPassiveCommentCount();
            ViewBag.GetPassiveCommentCount = getPassiveCommentCount;

            var getDiscountCouponCount = await _discountStatisticService.GetDiscountCouponAsync();
            ViewBag.GetDiscountCouponCount = getDiscountCouponCount;


            return View();
        }
    }
}
