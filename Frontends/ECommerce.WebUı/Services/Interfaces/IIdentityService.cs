﻿using ECommerceApp.DtoLayer.IdentityDtos.LoginDtos;

namespace ECommerce.WebUı.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<bool> SignIn(SignInDto signInDto);
        Task<bool> GetRefreshToken();
    }
}
