using AutoMapper;
using CareerPlatform.Model.Dtos.Application;
using CareerPlatform.Model.Dtos.Company;
using CareerPlatform.Model.Entities;
using Infrastructure.Utilities.ApiResponses;

namespace CareerPlatform.Business.Profiles
{
    public class ApplicationProfile:Profile
    {
        public ApplicationProfile() 
        {
            CreateMap<Application, ApplicationGetDto>();
                
            CreateMap<ApplicationPostDto, Application>();
            CreateMap<ApplicationPutDto, Application>();
            
        }
    }
}
