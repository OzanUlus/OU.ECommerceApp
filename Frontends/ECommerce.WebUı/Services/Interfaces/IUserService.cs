using ECommerce.WebUı.Models;

namespace ECommerce.WebUı.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDetailViewModel> GetUserInfo();
    }
}
