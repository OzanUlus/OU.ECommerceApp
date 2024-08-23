using ECommerceApp.DtoLayer.CargoDtos.CargoCompanyDtos;

namespace ECommerce.WebUı.Services.CargoServices.CargoCompanyServices
{
    public interface ICargoCompanyService
    {
        Task<List<ResultCargoCompantDto>> GetAllAsync();
        Task CreateCargoCompanyAsync(CreateCargoCompantDto createCargoCompanyDto);
        Task UpdateCargoCompanyAsync(UpdateCargoCompantDto updateCargoCompanyDto);
        Task DeleteCargoCompanyAsync(string id);
        Task<UpdateCargoCompantDto> GetByIdCargoCompanyAsync(string id);
    }
}
