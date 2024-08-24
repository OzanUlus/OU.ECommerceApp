﻿using ECommerce.Discount.Dtos;

namespace ECommerce.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultCouponDto>> GetAllCouponAsync();
        Task CreateCouponAsync(CreateCouponDto createCouponDto);
        Task UpdateCouponAsync(UpdateCouponDto updateCouponDto);
        Task DeleteCouponAsync(int id);
        Task<GetByIdCouponDto> GetByIdCouponAsync(int id);
        Task<ResultCouponDto> GetCodeDetailByCodeAsync(string code);
        Task<int> GetDiscountCouponCount();
    }
}
