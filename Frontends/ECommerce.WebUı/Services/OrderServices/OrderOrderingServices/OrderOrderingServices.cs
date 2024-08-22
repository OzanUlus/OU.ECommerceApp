using ECommerceApp.DtoLayer.OrderDtos.OrderingDtos;

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
            var responseMessage = await _httpClient.GetAsync("orders/GetOrderingByUserId?id="+id);
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultOrderingByUserIdDto>>();
            return values;
        }
    }
}
