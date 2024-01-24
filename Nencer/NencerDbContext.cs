using Microsoft.EntityFrameworkCore;
using Nencer.Modules.Backend.Model;
using Nencer.Modules.Backend.Model.Currency;
using Nencer.Modules.Backend.Model.Language;
using Nencer.Modules.Backend.Model.LanguagesTrans;
using Nencer.Modules.Backend.Model.Menu;
using Nencer.Modules.Backend.Model.Setting;
using Nencer.Modules.Backend.Model.Slider;
using Nencer.Modules.Checkin.Model;
using Nencer.Modules.Examination.Model;
using Nencer.Modules.Local.Model;

using Nencer.Modules.ManageService;
using Nencer.Modules.ManageService.Model.Dto;
using Nencer.Modules.Patient.Model;
using Nencer.Modules.Product.Model;
using Nencer.Modules.Room.Model;
using Nencer.Modules.Users.Model;

namespace Nencer
{
    public class NencerDbContext : DbContext
    {
        public NencerDbContext(DbContextOptions options) : base(options)
        {
        }

        public NencerDbContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString("Default");
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .EnableSensitiveDataLogging();
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<Group> Groups { get; set; }

        // patient
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientType> PatientTypes { get; set; }
        public DbSet<PatientDetail> PatientDetails { get; set; }
        public DbSet<PatientInsuranceCard> PatientInsuranceCards { get; set; }
        public DbSet<PatientPrehistoric> PatientPrehistorics { get; set; }
        public DbSet<PatientRelation> PatientRelations { get; set; }
        public DbSet<Ethnic> Ethnics { get; set; }


        // local
        public DbSet<LocalAdminUnit> LocalAdminUnits { get; set; }
        public DbSet<LocalCity> LocalCities { get; set; }
        public DbSet<LocalCountry> LocalCountries { get; set; }
        public DbSet<LocalDistrict> LocalDistricts { get; set; }
        public DbSet<LocalRegion> LocalRegions { get; set; }
        public DbSet<LocalWard> LocalWards { get; set; }

        // service
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<ServiceGroup> ServiceGroups { get; set; }
        public DbSet<ServiceItem> ServiceItems { get; set; }

        // room
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Department> Departments { get; set; }
        //public DbSet<RoomStaff> RoomStaff { get; set; }
        //public DbSet<RoomNumber> RoomNumbers { get; set; }

        // checkin
        public DbSet<Checkin> Checkins { get; set; }
        public DbSet<CheckinOrdinal> CheckinOrdinals { get; set; }
        public DbSet<CheckinDoor> CheckinDoors { get; set; }

        // exam
        public DbSet<Examination> Examinations { get; set; }
        public DbSet<ExaminationOrder> ExaminationOrders { get; set; }
        public DbSet<ExaminationOrdinal> ExaminationOrdinals { get; set; }
        public DbSet<ExaminationBarcode> ExaminationBarcodes { get; set; }
        public DbSet<ExaminationTicket> ExaminationTickets { get; set; }
        public DbSet<ExaminationOrder> ExaminationOrder { get; set; }
        public DbSet<ExaminationTicket> ExaminationTicket { get; set; }
        public DbSet<ExaminationResult> ExaminationResults { get; set; }
        public DbSet<ExaminationDiagnostic> ExaminationDiagnostics { get; set; }
        // Diagnostic
        public DbSet<CatelogDiagnostic> CatelogDiagnostics { get; set; }
        // Product
        public DbSet<ProductCate> ProductCates { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<ProductSupplier> ProductSuppliers { get; set; }
        public DbSet<ProductUnit> ProductUnits { get; set; }
        public DbSet<ProductOptionUnit> ProductOptionUnits { get; set; }
        public DbSet<StockOrder> StockOrders { get; set; }
        public DbSet<StockOrderItem> StockOrderItems { get; set; }
        public DbSet<ProductBid> ProductBids { get; set; }
        public DbSet<ProductBidsItem> ProductBidsItems { get; set; }
        // Backend
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<LanguagesTrans> LanguagesTrans { get; set; }
        public DbSet<Paygate> Paygates { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<RolePermission>()
            //    .HasKey(p => new { p.PermissionId, p.TroleId });

            //modelBuilder.Entity<LocalCity>(entity =>
            //{
            //    entity.HasNoKey().ToTable("local_countries");
            //});
        }


    }
}
