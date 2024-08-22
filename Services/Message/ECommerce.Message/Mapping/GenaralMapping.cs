using AutoMapper;
using ECommerce.Message.DAL.Entities;
using ECommerce.Message.Dtos;

namespace ECommerce.Message.Mapping
{
    public class GenaralMapping : Profile
    {
        public GenaralMapping()
        {
            CreateMap<UserMessage,ResultMessageDto>().ReverseMap();
            CreateMap<UserMessage,ResultInboxMessageDto>().ReverseMap();
            CreateMap<UserMessage,ResultSendboxDto>().ReverseMap();
            CreateMap<UserMessage,UpdateMessageDto>().ReverseMap();
            CreateMap<UserMessage,CreateMessageDto>().ReverseMap();
            CreateMap<UserMessage,GetByIdMessageDto>().ReverseMap();
        }
    }
}
