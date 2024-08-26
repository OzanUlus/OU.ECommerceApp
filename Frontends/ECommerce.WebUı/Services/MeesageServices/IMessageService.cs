using ECommerceApp.DtoLayer.MessageDtos;
using System.Collections.Specialized;

namespace ECommerce.WebUı.Services.MeesageServices
{
    public interface IMessageService
    {
        //Task<List<ResultMessageDto>> GetAllMessageAsync();
        Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id);
        Task<List<ResultSendboxDto>> GetSendboxMessageAsync(string id);
        Task<int> GetTotalMessageCountByRecieverIdAsync(string id);
        //Task CreateMessageAsync(CreateMessageDto createMessageDto);
        //Task UpdateMessageAsync(UpdateMessageDto updateMessageDto);
        //Task DeleteMessageAsync(int id);
        //Task<GetByIdMessageDto> GetByIdMessageAsync(int id);
    }
}
