using ECommerceApp.DtoLayer.CatologDtos.SpecialDiscountDtos;

namespace ECommerce.WebUı.Services.CatalogServices.SpecialDiscountService
{
    public interface ISpecialDiscountService
    {
        Task<List<ResultSpecialDiscountDto>> GetAllAsync();
        Task CreateSpecialDiscountAsync(CreateSpecialDiscountDto createSpecialDiscountDto);
        Task UpdateSpecialDiscountAsync(UpdateSpecialDiscountDto updateSpecialDiscountDto);
        Task DeleteSpecialDiscountAsync(string id);
        Task<UpdateSpecialDiscountDto> GetByIdSpecialDiscountAsync(string id);
    }
}
