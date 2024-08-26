using ECommerce.Message.Dtos;
using ECommerce.Message.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Message.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public UserMessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMessage()
        {
            var values = await _messageService.GetAllMessageAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessageAsync(CreateMessageDto createMessageDto)
        {
            await _messageService.CreateMessageAsync(createMessageDto);
            return Ok("Mesaj başarıyla oluşturuldu");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMessage(int id)
        {
             await _messageService.DeleteMessageAsync(id);
            return Ok("Mesaj başarıyla silindi");
        }

       

        [HttpPut]
        public async Task<IActionResult> UpdateMessage(UpdateMessageDto updateMessageDto)
        {
          await _messageService.UpdateMessageAsync(updateMessageDto);
            return Ok("Mesaj başarıyla güncellendi");
        }

        [HttpGet("GetSendboxMessage")]
        public async Task<IActionResult> GetSendboxMessage(string id)
        {
            var values = await _messageService.GetSendboxMessageAsync(id);
            return Ok(values);
        }
        
        [HttpGet("GetTotalMessageCountCountAsync")]
        public async Task<IActionResult> GetTotalMessageCountCountAsync()
        {
            var values = await _messageService.GetTotalMessageCountCountAsync();
            return Ok(values);
        }

        [HttpGet("GetInboxMessage")]
        public async Task<IActionResult> GetInboxMessage(string id)
        {
            var values = await _messageService.GetInboxMessageAsync(id);
            return Ok(values);
        }

        [HttpGet("GetMessageById")]
        public async Task<IActionResult> GetMessageById(int id)
        {
            var values = await _messageService.GetByIdMessageAsync(id);
            return Ok(values);
        }
        
        [HttpGet("GetTotalMessageCountByRecieverIdAsync")]
        public async Task<IActionResult> GetTotalMessageCountByRecieverIdAsync(string id)
        {
            var values = await _messageService.GetTotalMessageCountByRecieverIdAsync(id);
            return Ok(values);
        }

    }
}
