using RickAndMortyIntegration.Business.Services;
using RickAndMortyIntegration.Business.Services.Interfaces;

namespace RickAndMortyIntegration.WebAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IHttpRequestService, HttpRequestService>();
            services.AddScoped<IRickAndMortyService, RickAndMortyService>();
        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
        }
    }
}
