using Nencer.Modules.Local.Repository;
using Nencer.Modules.Users.Repository;

namespace Nencer.Modules.Local
{
    public class LocalServiceRegistration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IDistrictRepository, DistrictRepository>();
            services.AddScoped<IWardRepository, WardRepository>();
        }
    }
}
