using Microsoft.AspNetCore.DataProtection.Repositories;
using Nencer.Modules.Patient.Repository;
using Nencer.Modules.Users.Repository;

namespace Nencer.Modules.Users
{
    public static class PatientServiceRegistration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IPatientTypeRepository, PatientTypeRepository>();
            services.AddScoped<IEthnicRepository, EthnicRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
        }
    }
}
