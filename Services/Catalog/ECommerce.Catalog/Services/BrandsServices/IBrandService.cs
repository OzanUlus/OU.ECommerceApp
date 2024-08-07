using ECommerce.Catalog.Dtos.BrandDtos;

namespace ECommerce.Catalog.Services.BrandsServices
{
    public interface IBrandService
    {
        Task<List<ResultBrandDto>> GetAllAsync();
        Task CreateBrandAsync(CreateBrandDto createBrandDto);
        Task UpdateBrandAsync(UpdateBrandDto updateBrandDto);
        Task DeleteBrandAsync(string id);
        Task<GetByIdBrandDto> GetByIdBrandAsync(string id);
    }
}
