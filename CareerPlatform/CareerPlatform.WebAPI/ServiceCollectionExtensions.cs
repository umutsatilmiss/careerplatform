using System.Text.Json.Serialization;

namespace CareerPlatform.WebAPI
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApiService(this IServiceCollection services)
        {
            services.AddControllers().
                AddJsonOptions(opt => opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
    }
}
