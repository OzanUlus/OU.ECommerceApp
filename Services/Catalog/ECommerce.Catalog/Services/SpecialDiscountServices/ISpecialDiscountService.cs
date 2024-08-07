using ECommerce.Catalog.Dtos.SpecialDiscountDtos;

namespace ECommerce.Catalog.Services.SpecialDiscountServices
{
    public interface ISpecialDiscountService
    {
        Task<List<ResultSpecialDiscountDto>> GetAllAsync();
        Task CreateSpecialDiscountAsync(CreateSpecialDiscountDto createSpecialDiscountDto);
        Task UpdateSpecialDiscountAsync(UpdateSpecialDiscountDto updateSpecialDiscountDto);
        Task DeleteSpecialDiscountAsync(string id);
        Task<GetByIdSpecialDiscountDto> GetByIdSpecialDiscountAsync(string id);
    }
}
