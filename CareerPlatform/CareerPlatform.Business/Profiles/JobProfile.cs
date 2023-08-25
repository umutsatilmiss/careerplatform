using AutoMapper;
using CareerPlatform.Model.Dtos.Job;
using CareerPlatform.Model.Entities;

namespace CareerPlatform.Business.Profiles
{
    public class JobProfile:Profile
    {
        public JobProfile()
        {
            CreateMap<Job, JobGetDto>();
                //.ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.Company.CompanyId));

            CreateMap<JobPostDto, Job>();
            CreateMap<JobPutDto, Job>();
        }
    }
}
