using Microsoft.AspNetCore.DataProtection.Repositories;
using Nencer.Modules.Users.Repository;

namespace Nencer.Modules.Service
{
    public static class UserServiceRegistration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepotisoty>();
            services.AddScoped<IGroupRepository, GroupRepository>();
        }
    }
}
