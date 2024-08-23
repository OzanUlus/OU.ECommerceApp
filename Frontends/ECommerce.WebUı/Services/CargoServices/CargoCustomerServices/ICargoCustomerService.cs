using ECommerceApp.DtoLayer.CargoDtos.CargoCustomerDtos;

namespace ECommerce.WebUı.Services.CargoServices.CargoCustomerServices
{
    public interface ICargoCustomerService
    {
        Task<GetCargoCustomerByCustomerId> GetCargoCustomerAsync(string id);
    }
}
