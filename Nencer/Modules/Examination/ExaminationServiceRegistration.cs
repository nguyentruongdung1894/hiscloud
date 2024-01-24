using Nencer.Modules.Examination.Repository;
using Nencer.Modules.Patient.Repository;
using Microsoft.AspNetCore.DataProtection.Repositories;

namespace Nencer.Modules.Examination;

public static class ExaminationServiceRegistration
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IExaminationRepository, ExaminationRepository>();
        services.AddScoped<IExaminationOrderRepository, ExaminationOrderRepository>();
        services.AddScoped<IExaminationTicketRepository, ExaminationTicketRepository>();
        services.AddScoped<IExaminationBarcodeRepository, ExaminationBarcodeRepository>();
        services.AddScoped<IExaminationOrdinalRepository, ExaminationOrdinalRepository>();
        services.AddScoped<IDiagnosticRepository, DiagnosticRepository>();
    }
}
