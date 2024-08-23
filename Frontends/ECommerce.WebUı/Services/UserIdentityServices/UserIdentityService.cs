using ECommerceApp.DtoLayer.IdentityDtos.UserDtos;
using Newtonsoft.Json;

namespace ECommerce.WebUı.Services.UserIdentityServices
{
    public class UserIdentityService : IUserIdentityService
    {
        private readonly HttpClient _httpClient;

        public UserIdentityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<ResultUserDto>> GetAllUserAsync()
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:5001/api/users/getalluserlist");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultUserDto>>(jsonData);
            return values; 
        }
    }
}
