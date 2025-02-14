using visiotech.application.Application;
using visiotech.application.Interfaces;
using visiotech.domain.Interfaces;
using visiotech.infrastructure.Repositories;

namespace visiotech.api.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddInjectionRepositories(this IServiceCollection services)
        {
            services.AddScoped<IGrapeRepository, GrapeRepository>();
            services.AddScoped<IGrapeApp, GrapeApp>();
            services.AddScoped<IManagerRepository, ManagerRepository>();
            services.AddScoped<IManagerApp, ManagerApp>();
            services.AddScoped<IParcelRepository, ParcelRepository>();
            services.AddScoped<IParcelApp, ParcelApp>();
            services.AddScoped<IVineyardRepository, VineyardRepository>();

        }
    }
}
