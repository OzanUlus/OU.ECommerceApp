using ECommerce.Basket.LoginServices;

namespace ECommerce.Basket.LoginServices
{
    
    public class LoginService : ILoginService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUSerId => _httpContextAccessor.HttpContext.User.FindFirst("sub").Value;
    }
}
