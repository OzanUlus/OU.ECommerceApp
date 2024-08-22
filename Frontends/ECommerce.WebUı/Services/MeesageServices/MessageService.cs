using ECommerceApp.DtoLayer.MessageDtos;

namespace ECommerce.WebUı.Services.MeesageServices
{
    public class MessageService : IMessageService
    {
        private readonly HttpClient _httpClient;

        public MessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:5000/services/message/usermessages/GetInboxMessage?id=" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultInboxMessageDto>>();
            return values;
        }

        public async Task<List<ResultSendboxDto>> GetSendboxMessageAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:5000/services/message/usermessages/GetSendboxMessage?id=" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultSendboxDto>>();
            return values;
        }
        //http://localhost:7078/api/UserMessages/GetSendboxMessage?id=q
    }
}
