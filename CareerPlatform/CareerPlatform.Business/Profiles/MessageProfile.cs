using AutoMapper;
using CareerPlatform.Model.Dtos.Message;
using CareerPlatform.Model.Entities;

namespace CareerPlatform.Business.Profiles
{
    public  class MessageProfile:Profile
    {
        public MessageProfile()
        {
            CreateMap<Message, MessageGetDto>();
                //.ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.UserId));
            CreateMap<MessagePostDto, Message>();
          
        }
    }
}
