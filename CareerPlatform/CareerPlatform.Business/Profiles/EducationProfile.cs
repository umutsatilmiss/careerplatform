using AutoMapper;
using CareerPlatform.Model.Dtos.Education;
using CareerPlatform.Model.Entities;
using Infrastructure.Utilities.ApiResponses;

namespace CareerPlatform.Business.Profiles
{
    public class EducationProfile:Profile
    {
        public EducationProfile()
        {
            CreateMap<Education, EducationGetDto>();
                //.ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User));

            CreateMap<EducationPostDto, Education>();
            CreateMap<EducationPutDto, Education>();
        }
    }
}
