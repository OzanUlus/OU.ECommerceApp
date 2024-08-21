using ECommerceApp.DtoLayer.OrderDtos.OrderAddressDtos;

namespace ECommerce.WebUı.Services.OrderServices.AddressesService
{
    public interface IOrderAddressService
    {
        //Task<List<ResultAboutDto>> GetAllAsync();
        Task CreateOrderAddressAsync(CreateOrderAddressDto createOrderAddressDto );
        //Task UpdateAboutAsync(UpdateAboutDto updateAboutDto);
        //Task DeleteAboutAsync(string id);
        //Task<UpdateAboutDto> GetByIdAboutAsync(string id);
    }
}
