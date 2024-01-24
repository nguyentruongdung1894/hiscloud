using Microsoft.AspNetCore.DataProtection.Repositories;
using Nencer.Modules.Users.Repository;

namespace Nencer.Modules.Users
{
    public static class CategoryServiceRegistration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
