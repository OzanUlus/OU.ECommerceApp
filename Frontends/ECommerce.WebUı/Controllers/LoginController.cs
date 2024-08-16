using ECommerce.WebUı.Models;
using ECommerce.WebUı.Services.Interfaces;
using ECommerceApp.DtoLayer.IdentityDtos.LoginDtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace ECommerce.WebUı.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;
        private readonly IIdentityService _identityService;

        public LoginController(IHttpClientFactory httpClientFactory, ILoginService loginService, IIdentityService identityService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
            _identityService = identityService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginDto loginDto)
        {
            return View();
           
        }

      

        //[HttpPost]
        public async Task<IActionResult> SignIn(SignInDto signInDto)
        {
            signInDto.Username = "ozzy";
            signInDto.Password = "Password12*";
            await _identityService.SignIn(signInDto);

            return RedirectToAction("Index","Test");
        }
    }
}
