using AutoMapper;
using CareerPlatform.Model.Dtos.Notification;
using CareerPlatform.Model.Entities;

namespace CareerPlatform.Business.Profiles
{
    public class NotificationProfile:Profile
    {
        public NotificationProfile()
        {
            CreateMap<Notification, NotificationGetDto>();
                //.ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.UserId));

            CreateMap<NotificationGetDto, Notification>();
        }
    }
}
