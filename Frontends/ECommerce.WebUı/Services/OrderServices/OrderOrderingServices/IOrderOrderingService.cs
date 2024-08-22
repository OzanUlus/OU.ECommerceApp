using ECommerceApp.DtoLayer.OrderDtos.OrderingDtos;

namespace ECommerce.WebUı.Services.OrderServices.OrderOrderingServices
{
    public interface IOrderOrderingService
    {
        Task<List<ResultOrderingByUserIdDto>> GetOrderingByUserId(string id);
    }
}
