using visiotech.application.Application;
using visiotech.application.Interfaces;
using visiotech.domain.Interfaces;
using visiotech.infrastructure.Repositories;

namespace visiotech.api.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddInjectiionRepositories(this IServiceCollection services)
        {
            services.AddScoped<IGrapeRepository, GrapeRepository>();
            services.AddScoped<IGrapeApp, GrapeApp>();
           
        }
    }
}
