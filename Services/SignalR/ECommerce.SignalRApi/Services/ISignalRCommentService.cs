namespace ECommerce.SignalRApi.Services
{
    public interface ISignalRCommentService
    {
        Task<int> GetTotalCommentCount();
    }
}
