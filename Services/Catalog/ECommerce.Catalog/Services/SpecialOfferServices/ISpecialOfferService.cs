using ECommerce.Catalog.Dtos.SpecailOfferDtos;

namespace ECommerce.Catalog.Services.SpecialOfferServices
{
    public interface ISpecialOfferService
    {
        Task<List<ResultSpecialOfferDto>> GetAllAsync();
        Task CreateCategoryAsync(CreateSpecialOfferDto createSpecialOfferDto );
        Task UpdateCategoryAsync(UpdateSpecialOfferDto updateSpecialOfferDto);
        Task DeleteCategoryAsync(string id);
        Task<GetByIdSpecialOfferDto> GetByIdCategoryAsync(string id);
    }
}
