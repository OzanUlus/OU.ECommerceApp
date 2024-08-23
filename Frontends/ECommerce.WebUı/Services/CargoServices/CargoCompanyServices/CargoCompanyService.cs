using ECommerceApp.DtoLayer.CargoDtos.CargoCompanyDtos;
using Newtonsoft.Json;

namespace ECommerce.WebUı.Services.CargoServices.CargoCompanyServices
{
    public class CargoCompanyService : ICargoCompanyService
    {
        private readonly HttpClient _httpClient;

        public CargoCompanyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCargoCompanyAsync(CreateCargoCompantDto createCargoCompanyDto)
        {
            await _httpClient.PostAsJsonAsync<CreateCargoCompantDto>("cargoCompanies", createCargoCompanyDto);
        }

        public async Task DeleteCargoCompanyAsync(string id)
        {
            await _httpClient.DeleteAsync("cargoCompanies?id=" + id);
        }

        public async Task<List<ResultCargoCompantDto>> GetAllAsync()
        {
            var responseMessage = await _httpClient.GetAsync("cargoCompanies");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCargoCompantDto>>(jsonData);
            return values;
        }

        public async Task<UpdateCargoCompantDto> GetByIdCargoCompanyAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("cargoCompanies/" + id);
            var value = await responseMessage.Content.ReadFromJsonAsync<UpdateCargoCompantDto>();
            return value;
        }

        public async Task UpdateCargoCompanyAsync(UpdateCargoCompantDto updateCargoCompanyDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateCargoCompantDto>("cargoCompanies", updateCargoCompanyDto);
        }
    }
}
