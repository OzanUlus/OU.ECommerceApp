using ECommerce.SignalRApi.Services;
using Microsoft.AspNetCore.SignalR;

namespace ECommerce.SignalRApi.Hubs
{
    
    public class SignalRHub : Hub
    {
        //private readonly ISignalRMessageService _signalRMessageService;
        private readonly ISignalRCommentService _signalRCommentService;

        public SignalRHub(/*ISignalRMessageService signalRMessageService,*/ ISignalRCommentService signalRCommentService)
        {
            //_signalRMessageService = signalRMessageService;
            _signalRCommentService = signalRCommentService;
        }

        public async Task SendStatisticCount()
        {
            var getTotalComment = await _signalRCommentService.GetTotalCommentCount();
            await Clients.All.SendAsync("RecieveCommentCount",getTotalComment);

            //var getTotalMessageCount = await _signalRMessageService.GetTotalMessageCountByRecieverIdAsync(id);
            //await Clients.All.SendAsync("RecieveMessageCount",getTotalMessageCount);
        }
    }
}
