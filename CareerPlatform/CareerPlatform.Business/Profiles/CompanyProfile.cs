using AutoMapper;
using CareerPlatform.Model.Dtos.Company;
using CareerPlatform.Model.Entities;

namespace CareerPlatform.Business.Profiles
{
    public class CompanyProfile:Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyGetDto>();
                //.ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.CompanyAddress));
            CreateMap<CompanyPostDto, Company>();
            CreateMap<CompanyPutDto, Company>();
        }
    }
}
