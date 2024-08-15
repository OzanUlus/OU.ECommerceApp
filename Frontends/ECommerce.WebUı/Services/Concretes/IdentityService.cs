using ECommerce.WebUı.Services.Interfaces;
using ECommerce.WebUı.Settings;
using ECommerceApp.DtoLayer.IdentityDtos.LoginDtos;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Security.Claims;

namespace ECommerce.WebUı.Services.Concretes
{
    public class IdentityService : IIdentityService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ClientSetting _clientSetting;

        public IdentityService(HttpClient httpClient, IHttpContextAccessor contextAccessor, IOptions<ClientSetting> clientSetting)
        {
            _httpClient = httpClient;
            _contextAccessor = contextAccessor;
            _clientSetting = clientSetting.Value;
        }

        public async Task<bool> SignIn(SignUpDto signUpDto)
        {
            var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest 
            {
             Address="http://localhost:5001",
             Policy = new DiscoveryPolicy 
             {
               RequireHttps = false,
             }
            });

            var passwordTokenRequest = new PasswordTokenRequest
            {
                ClientId = _clientSetting.ECommerceManagerClient.ClientId,
                ClientSecret = _clientSetting.ECommerceManagerClient.ClientSecret,
                UserName = signUpDto.Username,
                Password = signUpDto.Password,
                Address = discoveryEndPoint.TokenEndpoint

            };

            var token = await _httpClient.RequestPasswordTokenAsync(passwordTokenRequest);

            var userInfoRequest = new UserInfoRequest 
            {
                Token = token.AccessToken,
               Address = discoveryEndPoint.UserInfoEndpoint,

            };

            var userValues = await _httpClient.GetUserInfoAsync(userInfoRequest);

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(userValues.Claims,CookieAuthenticationDefaults.AuthenticationScheme, "name","role");

            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            var authenticationProperties = new AuthenticationProperties();
            authenticationProperties.StoreTokens(new List<AuthenticationToken>() 
            {
               new AuthenticationToken 
               {
                 Name = OpenIdConnectParameterNames.AccessToken ,
                 Value = token.AccessToken, 
               },
               new AuthenticationToken 
               {
                 Name= OpenIdConnectParameterNames.RefreshToken ,
                 Value = token.RefreshToken,
               },
               new AuthenticationToken 
               {
                 Name = OpenIdConnectParameterNames.ExpiresIn ,
                 Value = DateTime.Now.AddSeconds(token.ExpiresIn).ToString(),
               }
            });

            authenticationProperties.IsPersistent = false;
        }
    }
}
