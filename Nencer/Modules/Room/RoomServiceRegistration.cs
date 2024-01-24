using Nencer.Modules.Patient.Repository;
using Nencer.Modules.Room.Repository;
using Nencer.Modules.Service.Repository;

namespace Nencer.Modules.Room
{
    public static class RoomServiceRegistration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IRoomNumberRepository, RoomNumberRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IRoomStaffRepository, RoomStaffRepository>();
            services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        }
    }
}
