﻿using ECommerce.Basket.Dtos;
using ECommerce.Basket.LoginServices;
using ECommerce.Basket.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace ECommerce.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ILoginService _loginService;

        public BasketsController(IBasketService basketService, ILoginService loginService)
        {
            _basketService = basketService;
            _loginService = loginService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMyBasketDetail() 
        {
            var user = User.Claims;
            var values = await _basketService.GetBasket(_loginService.GetUSerId);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> SaveMyBasket(BasketTotalDto basketTotalDto)
        {
            basketTotalDto.UserId = _loginService.GetUSerId;
            await _basketService.SaveBasket(basketTotalDto);
            return Ok("Sepetteki değişiklikler başarıyla değiştirildi");    
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMyBasket()
        {
            await _basketService.DeleteBasket(_loginService.GetUSerId);
            return Ok("Sepet başarıyla silindi");
        }
    }
}
