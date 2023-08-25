using CareerPlatform.Business.Implementations;
using CareerPlatform.Business.Interfaces;
using CareerPlatform.Business.Profiles;
using CareerPlatform.DataAccess.EF.Repositories;
using CareerPlatform.DataAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CareerPlatform.Business
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ApplicationProfile));

            services.AddScoped<IApplicationBs, ApplicationBs>();
            services.AddScoped<IApplicationRepository, ApplicationRepository>();

            services.AddScoped<ICompanyBs, CompanyBs>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();

            services.AddScoped<IEducationBs, EducationBs>();
            services.AddScoped<IEducationRepository, EducationRepository>();

            services.AddScoped<IJobBs, JobBs>();
            services.AddScoped<IJobRepository, JobRepository>();

            services.AddScoped<IMessageBs, MessageBs>();
            services.AddScoped<IMessageRepository, MessageRepository>();

            services.AddScoped<INotificationBs, NotificationBs>();
            services.AddScoped<INotificationRepository, NotificationRepositorty>();

            services.AddScoped<ISkillBs, SkillBs>();
            services.AddScoped<ISkillRepository, SkillRepository>();

            services.AddScoped<IUserBs, UserBs>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
