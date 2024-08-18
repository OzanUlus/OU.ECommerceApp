using ECommerceApp.DtoLayer.CatologDtos.SpecialDiscountDtos;
using Newtonsoft.Json;

namespace ECommerce.WebUı.Services.CatalogServices.SpecialDiscountService
{
    public class SpecialDiscountService : ISpecialDiscountService
    {
        private readonly HttpClient _httpClient;

        public SpecialDiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateSpecialDiscountAsync(CreateSpecialDiscountDto createSpecialDiscountDto)
        {
            await _httpClient.PostAsJsonAsync<CreateSpecialDiscountDto>("specialdiscounts", createSpecialDiscountDto);

        }

        public async Task DeleteSpecialDiscountAsync(string id)
        {
            await _httpClient.DeleteAsync("specialdiscounts?id=" + id);
        }

        public async Task<List<ResultSpecialDiscountDto>> GetAllAsync()
        {
            var responseMessage = await _httpClient.GetAsync("specialdiscounts");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultSpecialDiscountDto>>(jsonData);
            return values;
        }

        public async Task<UpdateSpecialDiscountDto> GetByIdSpecialDiscountAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("specialdiscounts/" + id);
            var value = await responseMessage.Content.ReadFromJsonAsync<UpdateSpecialDiscountDto>();
            return value;
        }

        public async Task UpdateSpecialDiscountAsync(UpdateSpecialDiscountDto updateSpecialDiscountDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateSpecialDiscountDto>("specialdiscounts", updateSpecialDiscountDto);
        }
    }
}
