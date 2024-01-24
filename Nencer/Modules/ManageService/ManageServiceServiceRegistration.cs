using Nencer.Modules.ManageService.Repository;

namespace Nencer.Modules.ManageService
{
    public class ManageServiceServiceRegistration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IServiceTypeRepository, ServiceTypeRepository>();
            services.AddScoped<IServiceGroupRepository, ServiceGroupRepository>();
        }
    }
}
