using AutoMapper;
using CareerPlatform.Model.Dtos.User;
using CareerPlatform.Model.Entities;

namespace CareerPlatform.Business.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserGetDto>();
                //.ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message));

            CreateMap<UserPostDto, User>();
            CreateMap<UserPutDto, User>();
        }
    }
}
