using CareerPlatform.Business;
using WS.WebAPI;
using WS.WebAPI.Middlewares;

namespace CareerPlatform.WebAPI
{
    public class Program
    {


        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddApiService();
            builder.Services.AddBusinessServices();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.UseCustomException();

            app.Run();
        }
    }
}