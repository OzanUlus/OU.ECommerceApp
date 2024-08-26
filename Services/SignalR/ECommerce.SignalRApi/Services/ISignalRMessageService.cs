namespace ECommerce.SignalRApi.Services
{
    public interface ISignalRMessageService
    {
        Task<int> GetTotalMessageCountByRecieverIdAsync(string id);
       
    }
}
