using ECommerceApp.DtoLayer.IdentityDtos.UserDtos;

namespace ECommerce.WebUı.Services.UserIdentityServices
{
    public interface IUserIdentityService
    {
        Task<List<ResultUserDto>> GetAllUserAsync();
    }
}
