using Microsoft.AspNetCore.DataProtection.Repositories;
using Nencer.Modules.Checkin.Repository;
using Nencer.Modules.Patient.Repository;
using Nencer.Modules.Users.Repository;

namespace Nencer.Modules.Users
{
    public static class CheckinServiceRegistration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ICheckinRepository, CheckinRepository>();
            services.AddScoped<ICheckinOrdinalRepository, CheckinOrdinalRepository>();
            services.AddScoped<ICheckinDoorRepository, CheckinDoorRepository>();
        }
    }
}
