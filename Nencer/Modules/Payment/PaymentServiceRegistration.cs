using Microsoft.AspNetCore.DataProtection.Repositories;
using Nencer.Modules.Payment.Repository;
using Nencer.Modules.Users.Repository;

namespace Nencer.Modules.Users
{
    public static class PaymentServiceRegistration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IPaymentRepository, PaymentRepository>();
        }
    }
}
