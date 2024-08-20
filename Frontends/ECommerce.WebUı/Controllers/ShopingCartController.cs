using ECommerce.WebUı.Services.BasketServices;
using ECommerce.WebUı.Services.CatalogServices.ProductServices;
using ECommerce.WebUı.Services.DiscountServices;
using ECommerceApp.DtoLayer.BasketDtos;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUı.Controllers
{
    public class ShopingCartController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;
       

        public ShopingCartController(IProductService productService, IBasketService basketService)
        {
            _productService = productService;
            _basketService = basketService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _basketService.GetBasket();
            ViewBag.total = values.TotalPrice;
            var totalPriceWithTax = values.TotalPrice + values.TotalPrice / 100 * 10;
            ViewBag.taxTotal = totalPriceWithTax;
            var tax = values.TotalPrice / 100 * 10;
            ViewBag.tax = tax;
            return View();
        }

        public async Task<IActionResult> AddBasketItem(string id)
        {
            var values = await _productService.GetByIdProductAsync(id);
            var items = new BasketItemDto
            {
                ProductId = values.ProductId,
                ProductName = values.ProductName,
                Price = values.ProductPrice,
                Quantity = 1,
                ProductImageUrl = values.ProductImageUrl,
            };
            await _basketService.AddBasketItem(items);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveBasketItem(string id)
        {
            await _basketService.RemoveBasketItem(id);
            return RedirectToAction("Index");
        }
    }
}
