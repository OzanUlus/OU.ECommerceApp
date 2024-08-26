using ECommerce.WebUı.Services.CommentServices;
using ECommerce.WebUı.Services.Interfaces;
using ECommerce.WebUı.Services.MeesageServices;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUı.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutHeaderComponentPartial : ViewComponent
    {
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;
        private readonly ICommentService _commentService;

        public _AdminLayoutHeaderComponentPartial(IMessageService messageService, IUserService userService, ICommentService commentService)
        {
            _messageService = messageService;
            _userService = userService;
            _commentService = commentService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userService.GetUserInfo();
            int messageCount = await _messageService.GetTotalMessageCountByRecieverIdAsync(user.Id);
            ViewBag.MessageCount = messageCount;

            int totalComment = await _commentService.GetTotalCommentCount();
            ViewBag.TotalComment = totalComment;
            return View();
        }
    }
}
