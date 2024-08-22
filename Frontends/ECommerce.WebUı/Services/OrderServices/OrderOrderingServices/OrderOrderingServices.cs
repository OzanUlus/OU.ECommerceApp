using ECommerceApp.DtoLayer.OrderDtos.OrderingDtos;
using Newtonsoft.Json;

namespace ECommerce.WebUı.Services.OrderServices.OrderOrderingServices
{
    public class OrderOrderingServices : IOrderOrderingService
    {
        private readonly HttpClient _httpClient;

        public OrderOrderingServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<ResultOrderingByUserIdDto>> GetOrderingByUserId(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"orderings/GetOrderingByUserId/{id}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultOrderingByUserIdDto>>(jsonData);
            return values;
        }
    }
}
