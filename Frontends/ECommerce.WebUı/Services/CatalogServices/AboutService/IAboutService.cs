using ECommerceApp.DtoLayer.CatologDtos.AboutDtos;

namespace ECommerce.WebUı.Services.CatalogServices.AboutService
{
    public interface IAboutService
    {
        Task<List<ResultAboutDto>> GetAllAsync();
        Task CreateAboutAsync(CreateAboutDto createAboutDto);
        Task UpdateAboutAsync(UpdateAboutDto updateAboutDto);
        Task DeleteAboutAsync(string id);
        Task<UpdateAboutDto> GetByIdAboutAsync(string id);
    }
}
