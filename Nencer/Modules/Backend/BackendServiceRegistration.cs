using Microsoft.CodeAnalysis.Host;
using Nencer.Modules.Backend.Repository;
using Nencer.Modules.Backend.Repository.CurrencyRepository;
using Nencer.Modules.Backend.Repository.LanguageRepository;
using Nencer.Modules.Backend.Repository.LanguagesTransRepository;
using Nencer.Modules.Backend.Repository.SettingRepository;

namespace Nencer.Modules.Backend;

public static class BackendServiceRegistration
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<ISettingRepository, SettingRepository>();
        services.AddScoped<ILanguageRepository, LanguageRepository>();
        services.AddScoped<ILanguagesTransRepository, LanguagesTransRepository>();
        services.AddScoped<ICurrencyRepository, CurrencyRepository>();
        services.AddScoped<PaygateInterface, PaygateRepository>();
    }
}