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

        public async Task<IActionResult> Index(string code,decimal discountPrice)
        {
            ViewBag.Code = code;
            var values = await _basketService.GetBasket();
            ViewBag.total = values.TotalPrice;
            var tax = values.TotalPrice / 100 * 10;
            var totalPriceWithTax = values.TotalPrice + tax;
            ViewBag.totalPriceWithTax = totalPriceWithTax;
            ViewBag.tax = tax;
            ViewBag.discountPrice = discountPrice;
            var lastTotal = totalPriceWithTax - discountPrice;
            ViewBag.lastTotal = lastTotal;
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
