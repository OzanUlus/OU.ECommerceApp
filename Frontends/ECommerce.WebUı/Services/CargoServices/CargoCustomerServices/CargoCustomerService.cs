using ECommerceApp.DtoLayer.CargoDtos.CargoCustomerDtos;

namespace ECommerce.WebUı.Services.CargoServices.CargoCustomerServices
{
    public class CargoCustomerService : ICargoCustomerService
    {
        private readonly HttpClient _httpClient;

        public CargoCustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetCargoCustomerByCustomerId> GetCargoCustomerAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("CargoCustomers/GetCargoCustomerById?id="+id);
            var  value = await responseMessage.Content.ReadFromJsonAsync<GetCargoCustomerByCustomerId>();
            return value;
        }
    }
}
