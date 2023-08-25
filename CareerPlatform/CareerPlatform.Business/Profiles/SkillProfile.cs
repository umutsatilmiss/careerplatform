using AutoMapper;
using CareerPlatform.Model.Dtos.Skill;
using CareerPlatform.Model.Entities;

namespace CareerPlatform.Business.Profiles
{
    public class SkillProfile:Profile
    {
        public SkillProfile()
        {
            CreateMap<Skill, SkillGetDto>();
                //.ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.UserId));
            CreateMap<SkillPostDto, Skill>();
            CreateMap<SkillPutDto, Skill>();
        }
    }
}
