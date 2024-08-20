using ECommerceApp.DtoLayer.DiscountDtos;

namespace ECommerce.WebUı.Services.DiscountServices
{
    public interface IDiscountService
    {
        Task<GetDiscountCodeDetailByCode> GetDiscountCode(string code);
    }
}
