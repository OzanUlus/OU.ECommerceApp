using AutoMapper;
using ECommerce.Message.DAL.Context;
using ECommerce.Message.DAL.Entities;
using ECommerce.Message.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Message.Services
{
    public class MessageService : IMessageService
    {
        private readonly MessageContext _messageContext;
        private readonly IMapper _mapper;

        public MessageService(MessageContext messageContext, IMapper mapper)
        {
            _messageContext = messageContext;
            _mapper = mapper;
        }

        public async Task CreateMessageAsync(CreateMessageDto createMessageDto)
        {
            var entity = _mapper.Map<UserMessage>(createMessageDto);
            await _messageContext.UserMessages.AddAsync(entity);
            await _messageContext.SaveChangesAsync();
        }

        public async Task DeleteMessageAsync(int id)
        {
            var value = await _messageContext.UserMessages.FindAsync(id);
            _messageContext.UserMessages.Remove(value);
            await _messageContext.SaveChangesAsync();
        }

        public async Task<List<ResultMessageDto>> GetAllMessageAsync()
        {
            var values = await _messageContext.UserMessages.ToListAsync();
            return _mapper.Map<List<ResultMessageDto>>(values);
        }

        public async Task<GetByIdMessageDto> GetByIdMessageAsync(int id)
        {
            var value = await _messageContext.UserMessages.FindAsync(id);
            return _mapper.Map<GetByIdMessageDto>(value);
        }

        public async Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id)
        {
            var values = await _messageContext.UserMessages.Where(x=> x.ReciecerId == id).ToListAsync();
            return _mapper.Map<List<ResultInboxMessageDto>>(values);
        }

        public async Task<List<ResultSendboxDto>> GetSendboxMessageAsync(string id)
        {
            var values = await _messageContext.UserMessages.Where(x => x.SendedId == id).ToListAsync();
            return _mapper.Map<List<ResultSendboxDto>>(values);
        }

        public async Task<int> GetTotalMessageCountByRecieverIdAsync(string id)
        {
            var value = await _messageContext.UserMessages.Where(m => m.ReciecerId ==id).CountAsync();
            return value;
        }

        public async Task<int> GetTotalMessageCountCountAsync()
        {
            var value = await _messageContext.UserMessages.CountAsync();
            return value;
        }

        public async Task UpdateMessageAsync(UpdateMessageDto updateMessageDto)
        {
            var entity = _mapper.Map<UserMessage>(updateMessageDto);
             _messageContext.UserMessages.Update(entity);
            await _messageContext.SaveChangesAsync();
        }
    }
}
