using ECommerceApp.DtoLayer.CatologDtos.BrandDtos;

namespace ECommerce.WebUı.Services.CatalogServices.BrandService
{
    public interface IBrandService
    {
        Task<List<ResultBrandDto>> GetAllAsync();
        Task CreateBrandAsync(CreateBrandDto createBrandDto);
        Task UpdateBrandAsync(UpdateBrandDto updateBrandDto);
        Task DeleteBrandAsync(string id);
        Task<UpdateBrandDto> GetByIdBrandAsync(string id);
    }
}
