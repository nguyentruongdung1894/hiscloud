using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Nencer.Models;

public partial class HisContext : DbContext
{
    public HisContext()
    {
    }

    public HisContext(DbContextOptions<HisContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AnalysisImage> AnalysisImages { get; set; }

    public virtual DbSet<AnalysisResult> AnalysisResults { get; set; }

    public virtual DbSet<AuthLog> AuthLogs { get; set; }

    public virtual DbSet<Bed> Beds { get; set; }

    public virtual DbSet<CatalogDiagnostic> CatalogDiagnostics { get; set; }

    public virtual DbSet<Chamber> Chambers { get; set; }

    public virtual DbSet<Checkin> Checkins { get; set; }

    public virtual DbSet<CheckinDoor> CheckinDoors { get; set; }

    public virtual DbSet<CheckinGroup> CheckinGroups { get; set; }

    public virtual DbSet<CheckinOrdinal> CheckinOrdinals { get; set; }

    public virtual DbSet<Currency> Currencies { get; set; }

    public virtual DbSet<CurrencyCode> CurrencyCodes { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Drug> Drugs { get; set; }

    public virtual DbSet<DrugIngredient> DrugIngredients { get; set; }

    public virtual DbSet<DrugIngredientInteraction> DrugIngredientInteractions { get; set; }

    public virtual DbSet<DrugReceipt> DrugReceipts { get; set; }

    public virtual DbSet<DrugVendor> DrugVendors { get; set; }

    public virtual DbSet<DynamicReport> DynamicReports { get; set; }

    public virtual DbSet<Ethnic> Ethnics { get; set; }

    public virtual DbSet<Examination> Examinations { get; set; }

    public virtual DbSet<Examination2023> Examination2023s { get; set; }

    public virtual DbSet<ExaminationAction> ExaminationActions { get; set; }

    public virtual DbSet<ExaminationDiagnostic> ExaminationDiagnostics { get; set; }

    public virtual DbSet<ExaminationOrder> ExaminationOrders { get; set; }

    public virtual DbSet<ExaminationOrdinal> ExaminationOrdinals { get; set; }

    public virtual DbSet<ExaminationResult> ExaminationResults { get; set; }

    public virtual DbSet<ExaminationTicket> ExaminationTickets { get; set; }

    public virtual DbSet<Fund> Funds { get; set; }

    public virtual DbSet<FundLog> FundLogs { get; set; }

    public virtual DbSet<FundsMode> FundsModes { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Hospital> Hospitals { get; set; }

    public virtual DbSet<Information> Informations { get; set; }

    public virtual DbSet<InformationInsurance> InformationInsurances { get; set; }

    public virtual DbSet<InsuranceCard> InsuranceCards { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<InventoryLog> InventoryLogs { get; set; }

    public virtual DbSet<InventoryPo> InventoryPos { get; set; }

    public virtual DbSet<InventoryStock> InventoryStocks { get; set; }

    public virtual DbSet<InventoryUnitConvert> InventoryUnitConverts { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<LocalAdminUnit> LocalAdminUnits { get; set; }

    public virtual DbSet<LocalCity> LocalCities { get; set; }

    public virtual DbSet<LocalCountry> LocalCountries { get; set; }

    public virtual DbSet<LocalDistrict> LocalDistricts { get; set; }

    public virtual DbSet<LocalRegion> LocalRegions { get; set; }

    public virtual DbSet<LocalWard> LocalWards { get; set; }

    public virtual DbSet<Machine> Machines { get; set; }

    public virtual DbSet<MachineDevice> MachineDevices { get; set; }

    public virtual DbSet<MachineTestcode> MachineTestcodes { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<NewsCat> NewsCats { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<PatientDetail> PatientDetails { get; set; }

    public virtual DbSet<PatientInsuranceCard> PatientInsuranceCards { get; set; }

    public virtual DbSet<PatientPrehistoric> PatientPrehistorics { get; set; }

    public virtual DbSet<PatientRelation> PatientRelations { get; set; }

    public virtual DbSet<PatientType> PatientTypes { get; set; }

    public virtual DbSet<Paygate> Paygates { get; set; }

    public virtual DbSet<PaygatesLog> PaygatesLogs { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<PrescriptionCeiling> PrescriptionCeilings { get; set; }

    public virtual DbSet<PrescriptionOrder> PrescriptionOrders { get; set; }

    public virtual DbSet<PrescriptionOrderItem> PrescriptionOrderItems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductBid> ProductBids { get; set; }

    public virtual DbSet<ProductBidItem> ProductBidItems { get; set; }

    public virtual DbSet<ProductCat> ProductCats { get; set; }

    public virtual DbSet<ProductInventory> ProductInventories { get; set; }

    public virtual DbSet<ProductStock> ProductStocks { get; set; }

    public virtual DbSet<ProductStockOrder> ProductStockOrders { get; set; }

    public virtual DbSet<ProductStockOrderItem> ProductStockOrderItems { get; set; }

    public virtual DbSet<ProductSupplier> ProductSuppliers { get; set; }

    public virtual DbSet<ProductUnit> ProductUnits { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<RocheDatum> RocheData { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RolePermission> RolePermissions { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomNumber> RoomNumbers { get; set; }

    public virtual DbSet<RoomStaff> RoomStaffs { get; set; }

    public virtual DbSet<RoomType> RoomTypes { get; set; }

    public virtual DbSet<Route> Routes { get; set; }

    public virtual DbSet<SampleDevice> SampleDevices { get; set; }

    public virtual DbSet<SendmailDriver> SendmailDrivers { get; set; }

    public virtual DbSet<SendmailSetting> SendmailSettings { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<ServiceCodeMapping> ServiceCodeMappings { get; set; }

    public virtual DbSet<ServiceGroup> ServiceGroups { get; set; }

    public virtual DbSet<ServiceType> ServiceTypes { get; set; }

    public virtual DbSet<ServicesItem> ServicesItems { get; set; }

    public virtual DbSet<Setting> Settings { get; set; }

    public virtual DbSet<SmsLog> SmsLogs { get; set; }

    public virtual DbSet<SmsProvider> SmsProviders { get; set; }

    public virtual DbSet<StorehouseInven> StorehouseInvens { get; set; }

    public virtual DbSet<TemplateService> TemplateServices { get; set; }

    public virtual DbSet<TestCode> TestCodes { get; set; }

    public virtual DbSet<Treatment> Treatments { get; set; }

    public virtual DbSet<TreatmentRegiman> TreatmentRegimen { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserCertificate> UserCertificates { get; set; }

    public virtual DbSet<UserDetail> UserDetails { get; set; }

    public virtual DbSet<UserDevice> UserDevices { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=103.179.189.88;port=3306;database=his;uid=his;pwd=cmiaChyFYddKjTLy", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.24-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<AnalysisImage>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("analysis_images")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.AnalysisResultId).HasColumnName("analysis_result_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .HasColumnName("image");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<AnalysisResult>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("analysis_results")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActionTime)
                .HasMaxLength(100)
                .HasColumnName("action_time");
            entity.Property(e => e.Comment)
                .HasColumnType("text")
                .HasColumnName("comment");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.DoctorId).HasColumnName("doctor_id");
            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.ServiceOrderId).HasColumnName("service_order_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<AuthLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("auth_logs")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cookie)
                .HasMaxLength(250)
                .HasColumnName("cookie")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Ip)
                .HasMaxLength(255)
                .HasColumnName("ip")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Twofactor)
                .HasMaxLength(250)
                .HasColumnName("twofactor")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserAgent)
                .HasColumnType("text")
                .HasColumnName("user_agent");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<Bed>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("bed", tb => tb.HasComment("Giường bệnh"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ChamberId).HasColumnName("chamber_id");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("code");
            entity.Property(e => e.CodeBhyt)
                .HasMaxLength(50)
                .HasColumnName("code_bhyt");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<CatalogDiagnostic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("catalog_diagnostic", tb => tb.HasComment("ICD10(Chuẩn đoán)"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.Code, "code").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasMaxLength(6)
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.NameEn)
                .HasMaxLength(255)
                .HasComment("Tên thường gọi")
                .HasColumnName("name_en");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasMaxLength(6)
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Chamber>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("chamber", tb => tb.HasComment("Buồng bệnh"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.RoomId, "room_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("code");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.RoomName)
                .HasMaxLength(50)
                .HasColumnName("room_name");
        });

        modelBuilder.Entity<Checkin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("checkin", tb => tb.HasComment("đón tiếp"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.PatientId, "FK_checkin_patients");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BedId).HasColumnName("bed_id");
            entity.Property(e => e.ChamberId).HasColumnName("chamber_id");
            entity.Property(e => e.CheckinNumber)
                .HasComment("stt tiep don")
                .HasColumnName("checkin_number");
            entity.Property(e => e.CheckinTime)
                .HasComment("Giờ checkin")
                .HasColumnType("timestamp")
                .HasColumnName("checkin_time");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DepartmentId)
                .HasComment("khoa")
                .HasColumnName("department_id");
            entity.Property(e => e.DoctorId)
                .HasComment("Bac si phu trach")
                .HasColumnName("doctor_id");
            entity.Property(e => e.DoctorName)
                .HasMaxLength(50)
                .HasComment("BS dieu trị")
                .HasColumnName("doctor_name");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.PatientNumber)
                .HasMaxLength(50)
                .HasComment("mã bệnh nhân")
                .HasColumnName("patient_number");
            entity.Property(e => e.PatientType)
                .HasComment("Đối tượng khách hàng : fee , bhyt..")
                .HasColumnName("patient_type");
            entity.Property(e => e.Priority)
                .HasDefaultValueSql("'0'")
                .HasColumnName("priority");
            entity.Property(e => e.Reason)
                .HasComment("Lý do khám")
                .HasColumnType("text")
                .HasColumnName("reason");
            entity.Property(e => e.RoomId)
                .HasComment("Phong")
                .HasColumnName("room_id");
            entity.Property(e => e.ServiceId)
                .HasComment("Dịch vụ ban đầu ")
                .HasColumnName("service_Id");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasDefaultValueSql("'PENDING'")
                .HasColumnName("status");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasComment("Loại khám : cấp cứu hay khám bệnh")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Patient).WithMany(p => p.Checkins)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_examination_patients");
        });

        modelBuilder.Entity<CheckinDoor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("checkin_door")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Group)
                .HasDefaultValueSql("'1'")
                .HasComment("Cùng nhóm sẽ chung số gọi")
                .HasColumnName("group");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .HasColumnName("name_en");
        });

        modelBuilder.Entity<CheckinGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("checkin_group")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.MaxNumber).HasColumnName("max_number");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<CheckinOrdinal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("checkin_ordinal");

            entity.HasIndex(e => new { e.Number, e.DoorCode, e.DoorId, e.Group }, "number_door_code_door_id_group").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DoorCode)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("door_code");
            entity.Property(e => e.DoorId).HasColumnName("door_id");
            entity.Property(e => e.Group).HasColumnName("group");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'0'")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Currency>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("currencies")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.Status, "currencies_status_index");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasComment("Mã tiền tệ")
                .HasColumnName("code")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Decimal).HasColumnName("decimal");
            entity.Property(e => e.Default).HasColumnName("default");
            entity.Property(e => e.Name)
                .HasMaxLength(191)
                .HasColumnName("name")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Seperator)
                .HasMaxLength(255)
                .HasColumnName("seperator")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Sort).HasColumnName("sort");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");
            entity.Property(e => e.SymbolLeft)
                .HasMaxLength(50)
                .HasColumnName("symbol_left")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.SymbolRight)
                .HasMaxLength(50)
                .HasColumnName("symbol_right")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.Value)
                .HasComment("1 USD bằng bao nhiêu tiền này")
                .HasColumnName("value");
        });

        modelBuilder.Entity<CurrencyCode>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("currency_code", tb => tb.HasComment("Các mã code của tiền tệ trên thế giới"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("code")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("departments", tb => tb.HasComment("Khoa"));

            entity.HasIndex(e => e.Code, "code").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .HasColumnName("image");
            entity.Property(e => e.Manager)
                .HasMaxLength(255)
                .HasColumnName("manager");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.NameByt)
                .HasMaxLength(255)
                .HasColumnName("name_byt");
            entity.Property(e => e.NameEng)
                .HasMaxLength(255)
                .HasColumnName("name_eng");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .HasColumnName("phone");
            entity.Property(e => e.Sort)
                .HasDefaultValueSql("'1'")
                .HasColumnName("sort");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Drug>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("drugs")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.BarCode, "bar_code").IsUnique();

            entity.HasIndex(e => e.Code, "code").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Antibiotic)
                .HasDefaultValueSql("'0'")
                .HasColumnName("antibiotic");
            entity.Property(e => e.AtcCode)
                .HasMaxLength(255)
                .HasColumnName("atc_code");
            entity.Property(e => e.BarCode).HasColumnName("bar_code");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.Concentration)
                .HasMaxLength(255)
                .HasComment("Nồng độ")
                .HasColumnName("concentration");
            entity.Property(e => e.CountryCode)
                .HasMaxLength(255)
                .HasColumnName("country_code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DrugContent)
                .HasMaxLength(255)
                .HasColumnName("drug_content");
            entity.Property(e => e.DrugGroupId).HasColumnName("drug_group_id");
            entity.Property(e => e.DrugReceipt)
                .HasDefaultValueSql("'0'")
                .HasComment("Thuốc kê đơn")
                .HasColumnName("drug_receipt");
            entity.Property(e => e.DrugTypeId).HasColumnName("drug_type_id");
            entity.Property(e => e.Featured)
                .HasDefaultValueSql("'0'")
                .HasColumnName("featured");
            entity.Property(e => e.FunctionalFood)
                .HasDefaultValueSql("'0'")
                .HasComment("Thực phẩm chức năng")
                .HasColumnName("functional_food");
            entity.Property(e => e.IngredientIds)
                .HasMaxLength(255)
                .HasComment("array")
                .HasColumnName("ingredient_ids");
            entity.Property(e => e.InputPrice)
                .HasMaxLength(255)
                .HasColumnName("input_price");
            entity.Property(e => e.InsuranceGroupId)
                .HasMaxLength(255)
                .HasColumnName("insurance_group_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.NewDrug)
                .HasDefaultValueSql("'1'")
                .HasColumnName("new_drug");
            entity.Property(e => e.Packing)
                .HasMaxLength(255)
                .HasComment("Quy cách")
                .HasColumnName("packing");
            entity.Property(e => e.Price)
                .HasMaxLength(255)
                .HasColumnName("price");
            entity.Property(e => e.PriceIns)
                .HasMaxLength(255)
                .HasColumnName("price_ins");
            entity.Property(e => e.RegisterNumber)
                .HasMaxLength(255)
                .HasColumnName("register_number");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");
            entity.Property(e => e.TraditionalMedicineProduct)
                .HasDefaultValueSql("'0'")
                .HasComment("Chế phẩm y học cổ truyền")
                .HasColumnName("traditional_medicine_product");
            entity.Property(e => e.TraditionalMedicineTaste)
                .HasDefaultValueSql("'0'")
                .HasComment("Vị y học cổ truyền")
                .HasColumnName("traditional_medicine_taste");
            entity.Property(e => e.UnitId).HasColumnName("unit_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.Vendor).HasColumnName("vendor");
            entity.Property(e => e.Volume)
                .HasMaxLength(255)
                .HasComment("Thể tích, khối lượng")
                .HasColumnName("volume");
        });

        modelBuilder.Entity<DrugIngredient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("drug_ingredients", tb => tb.HasComment("Hoạt chất"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.Code, "code");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<DrugIngredientInteraction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("drug_ingredient_interaction", tb => tb.HasComment("Tương tác thuốc theo hoạt chất"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Bibliography)
                .HasMaxLength(255)
                .HasColumnName("bibliography");
            entity.Property(e => e.CodeIngredient)
                .HasMaxLength(255)
                .HasComment("Mã hoạt chất")
                .HasColumnName("code_ingredient");
            entity.Property(e => e.Consequence)
                .HasMaxLength(255)
                .HasComment("hậu quả")
                .HasColumnName("consequence");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Degree)
                .HasMaxLength(255)
                .HasComment("Mức độ")
                .HasColumnName("degree");
            entity.Property(e => e.Handle)
                .HasMaxLength(255)
                .HasComment("cách xử lý")
                .HasColumnName("handle");
            entity.Property(e => e.NameIngredient)
                .HasMaxLength(255)
                .HasComment("Tên hoạt chất")
                .HasColumnName("name_ingredient");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .HasColumnName("note");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<DrugReceipt>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("drug_receipts", tb => tb.HasComment("Toa thuốc"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CheckinId).HasColumnName("checkin_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatorId)
                .HasMaxLength(50)
                .HasColumnName("creator_id");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(50)
                .HasColumnName("currency_code");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.DrugCode)
                .HasMaxLength(50)
                .HasColumnName("drug_code");
            entity.Property(e => e.DrugId).HasColumnName("drug_id");
            entity.Property(e => e.DrugName)
                .HasMaxLength(255)
                .HasColumnName("drug_name");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .HasColumnName("note");
            entity.Property(e => e.OrderCode)
                .HasMaxLength(255)
                .HasColumnName("order_code");
            entity.Property(e => e.PayAmount).HasColumnName("pay_amount");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Qty).HasColumnName("qty");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.StockId).HasColumnName("stock_id");
            entity.Property(e => e.TotalDay).HasColumnName("total_day");
            entity.Property(e => e.Unit)
                .HasMaxLength(50)
                .HasColumnName("unit");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<DrugVendor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("drug_vendors", tb => tb.HasComment("Nhà sản xuất, nhà cung cấp"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.Code, "code").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.Certificate)
                .HasMaxLength(255)
                .HasColumnName("certificate");
            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.Code)
                .HasMaxLength(25)
                .HasColumnName("code");
            entity.Property(e => e.CompanyAddress)
                .HasMaxLength(255)
                .HasColumnName("company_address");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(50)
                .HasColumnName("company_name");
            entity.Property(e => e.CountryCode)
                .HasMaxLength(255)
                .HasColumnName("country_code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Director)
                .HasMaxLength(255)
                .HasColumnName("director");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Featured)
                .HasDefaultValueSql("'0'")
                .HasColumnName("featured");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .HasColumnName("image");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");
            entity.Property(e => e.TaxNumber)
                .HasMaxLength(50)
                .HasColumnName("tax_number");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<DynamicReport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("dynamic_report")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ReportCode)
                .HasMaxLength(255)
                .HasComment("Mẫu báo cáo")
                .HasColumnName("report_code");
            entity.Property(e => e.ReportColumn)
                .HasMaxLength(255)
                .HasComment("Tên cột")
                .HasColumnName("report_column");
            entity.Property(e => e.ReportDataField)
                .HasMaxLength(255)
                .HasComment("Giá trị cột")
                .HasColumnName("report_data_field");
            entity.Property(e => e.ReportName)
                .HasMaxLength(255)
                .HasColumnName("report_name");
            entity.Property(e => e.ReportSql)
                .HasComment("Định nghĩa sql")
                .HasColumnName("report_sql");
        });

        modelBuilder.Entity<Ethnic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("ethnic", tb => tb.HasComment("dân tộc"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.Code, "Code");

            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Examination>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("examination", tb => tb.HasComment("khám bệnh"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.CheckinId, "checkin_id");

            entity.HasIndex(e => e.PatientId, "patient_id");

            entity.Property(e => e.Id)
                .HasComment("--medicalrecordID ( benh an id, ban ghi lai lich su dieu tri )")
                .HasColumnName("id");
            entity.Property(e => e.BedId).HasColumnName("bed_id");
            entity.Property(e => e.ChamberId).HasColumnName("chamber_id");
            entity.Property(e => e.CheckinId)
                .HasComment("mã đón tiếp")
                .HasColumnName("checkin_id");
            entity.Property(e => e.CheckinTime)
                .HasComment("Giờ checkin")
                .HasColumnType("timestamp")
                .HasColumnName("checkin_time");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DepartmentId)
                .HasComment("khoa")
                .HasColumnName("department_id");
            entity.Property(e => e.DoctorId)
                .HasComment("Bac si phu trach")
                .HasColumnName("doctor_id");
            entity.Property(e => e.DoctorName)
                .HasMaxLength(50)
                .HasComment("BS dieu trị")
                .HasColumnName("doctor_name");
            entity.Property(e => e.ExamIdBefore)
                .HasComment("id exam ngay trước nó")
                .HasColumnName("exam_id_before");
            entity.Property(e => e.ExaminationDate)
                .HasComment("Ngày khám")
                .HasColumnType("datetime")
                .HasColumnName("examination_date");
            entity.Property(e => e.ExaminationNumber)
                .HasComment("stt khám")
                .HasColumnName("examination_number");
            entity.Property(e => e.ExaminationStartAt)
                .HasComment("Giờ bắt đầu khám")
                .HasColumnType("timestamp")
                .HasColumnName("examination_start_at");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.PatientRelationId).HasColumnName("patient_relation_id");
            entity.Property(e => e.PatientType)
                .HasComment("Đối tượng khách hàng : fee , bhyt..")
                .HasColumnName("patient_type");
            entity.Property(e => e.Priority)
                .HasDefaultValueSql("'0'")
                .HasColumnName("priority");
            entity.Property(e => e.Reason)
                .HasComment("Lý do khám")
                .HasColumnType("text")
                .HasColumnName("reason");
            entity.Property(e => e.RoomId)
                .HasComment("Phong")
                .HasColumnName("room_id");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasDefaultValueSql("'PENDING'")
                .HasColumnName("status");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasComment("Loại khám")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Checkin).WithMany(p => p.Examinations)
                .HasForeignKey(d => d.CheckinId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_exam_checkin");
        });

        modelBuilder.Entity<Examination2023>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("examination_2023", tb => tb.HasComment("khám bệnh"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.CheckinId, "checkin_id");

            entity.HasIndex(e => e.PatientId, "patient_id");

            entity.Property(e => e.Id)
                .HasComment("--medicalrecordID ( benh an id, ban ghi lai lich su dieu tri )")
                .HasColumnName("id");
            entity.Property(e => e.BedId).HasColumnName("bed_id");
            entity.Property(e => e.ChamberId).HasColumnName("chamber_id");
            entity.Property(e => e.CheckinId)
                .HasComment("mã đón tiếp")
                .HasColumnName("checkin_id");
            entity.Property(e => e.CheckinTime)
                .HasComment("Giờ checkin")
                .HasColumnType("timestamp")
                .HasColumnName("checkin_time");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DepartmentId)
                .HasComment("khoa")
                .HasColumnName("department_id");
            entity.Property(e => e.DoctorId)
                .HasComment("Bac si phu trach")
                .HasColumnName("doctor_id");
            entity.Property(e => e.DoctorName)
                .HasMaxLength(50)
                .HasComment("BS dieu trị")
                .HasColumnName("doctor_name");
            entity.Property(e => e.ExamIdBefore)
                .HasComment("id exam ngay trước nó")
                .HasColumnName("exam_id_before");
            entity.Property(e => e.ExaminationDate)
                .HasComment("Ngày khám")
                .HasColumnType("datetime")
                .HasColumnName("examination_date");
            entity.Property(e => e.ExaminationNumber)
                .HasComment("stt khám")
                .HasColumnName("examination_number");
            entity.Property(e => e.ExaminationStartAt)
                .HasComment("Giờ bắt đầu khám")
                .HasColumnType("timestamp")
                .HasColumnName("examination_start_at");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.PatientRelationId).HasColumnName("patient_relation_id");
            entity.Property(e => e.PatientType)
                .HasComment("Đối tượng khách hàng : fee , bhyt..")
                .HasColumnName("patient_type");
            entity.Property(e => e.Priority)
                .HasDefaultValueSql("'0'")
                .HasColumnName("priority");
            entity.Property(e => e.Reason)
                .HasComment("Lý do khám")
                .HasColumnType("text")
                .HasColumnName("reason");
            entity.Property(e => e.RoomId)
                .HasComment("Phong")
                .HasColumnName("room_id");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasDefaultValueSql("'PENDING'")
                .HasColumnName("status");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasComment("Loại khám")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Checkin).WithMany(p => p.Examination2023s)
                .HasForeignKey(d => d.CheckinId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("examination_2023_ibfk_1");
        });

        modelBuilder.Entity<ExaminationAction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("examination_action", tb => tb.HasComment("Xử trí khám bệnh"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.ExaminationId, "FK_examination_results_examination");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActionAt)
                .HasComment("Thời gian xử trí")
                .HasColumnType("datetime")
                .HasColumnName("action_at");
            entity.Property(e => e.Advice)
                .HasComment("Loi dan bac sy")
                .HasColumnType("text")
                .HasColumnName("advice");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatorId).HasColumnName("creator_id");
            entity.Property(e => e.Death)
                .HasComment("Tu vong")
                .HasColumnType("text")
                .HasColumnName("death");
            entity.Property(e => e.DeliveryOfPrescription)
                .HasComment("Cap toa cho ve")
                .HasColumnType("text")
                .HasColumnName("delivery_of_prescription");
            entity.Property(e => e.DoctorId).HasColumnName("doctor_id");
            entity.Property(e => e.ExamResult)
                .HasMaxLength(255)
                .HasComment("Ket qua dieu tri")
                .HasColumnName("exam_result");
            entity.Property(e => e.ExaminationDetermination)
                .HasComment("Chuẩn đoán xác định")
                .HasColumnType("text")
                .HasColumnName("examination_determination");
            entity.Property(e => e.ExaminationId).HasColumnName("examination_id");
            entity.Property(e => e.Hospitalization)
                .HasComment("Nhap vien")
                .HasColumnType("text")
                .HasColumnName("hospitalization");
            entity.Property(e => e.OfflineTreatmentEnds)
                .HasComment("het dot dieu tri")
                .HasColumnType("text")
                .HasColumnName("offline_treatment_ends");
            entity.Property(e => e.OutpatientTreatment)
                .HasComment("Điều trị ngoại trú")
                .HasColumnType("text")
                .HasColumnName("outpatient_treatment");
            entity.Property(e => e.ReasonEdit)
                .HasComment("Ly do sua")
                .HasColumnType("text")
                .HasColumnName("reason_edit");
            entity.Property(e => e.SwitchClinic)
                .HasComment("chuyen phong kham")
                .HasColumnType("text")
                .HasColumnName("switch_clinic");
            entity.Property(e => e.Transition)
                .HasComment("Chuyen tuyen")
                .HasColumnType("text")
                .HasColumnName("transition");
            entity.Property(e => e.TreatmentMethod)
                .HasMaxLength(255)
                .HasComment("Hinh thuc xt")
                .HasColumnName("treatment_method");
            entity.Property(e => e.Uncheck)
                .HasComment("Bo kham")
                .HasColumnType("text")
                .HasColumnName("uncheck");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Examination).WithMany(p => p.ExaminationActions)
                .HasForeignKey(d => d.ExaminationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("examination_action_ibfk_1");
        });

        modelBuilder.Entity<ExaminationDiagnostic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("examination_diagnostic");

            entity.HasIndex(e => e.DiagnosticId, "FK_examination_diagnostic_catalog_diagnostic");

            entity.HasIndex(e => e.ObjectId, "FK_examination_diagnostic_examination");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DiagnosticId).HasColumnName("diagnostic_id");
            entity.Property(e => e.IsPrimary)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_primary");
            entity.Property(e => e.ObjectId).HasColumnName("object_id");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");

            entity.HasOne(d => d.Diagnostic).WithMany(p => p.ExaminationDiagnostics)
                .HasForeignKey(d => d.DiagnosticId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_examination_diagnostic_catalog_diagnostic");
        });

        modelBuilder.Entity<ExaminationOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("examination_orders", tb => tb.HasComment("Chỉ định dịch vụ"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.ExaminationId, "FK_examination_appointments_examination");

            entity.HasIndex(e => e.TicketId, "FK_examination_service_orders_examination_service_orders");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BenefitRate)
                .HasComment("mức hưởng bhyt")
                .HasColumnName("benefit_rate");
            entity.Property(e => e.CopayPatient)
                .HasComment("bệnh nhân cùng chi trả")
                .HasColumnName("copay_patient");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.ExaminationId).HasColumnName("examination_id");
            entity.Property(e => e.InsurancePay)
                .HasDefaultValueSql("'0'")
                .HasComment("bảo hiểm chi trả")
                .HasColumnName("insurance_pay");
            entity.Property(e => e.InvoiceId)
                .HasComment("thuộc invoice nào")
                .HasColumnName("invoice_id");
            entity.Property(e => e.IsDeleteHandle)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_delete_handle");
            entity.Property(e => e.IsDeleteSample)
                .HasDefaultValueSql("'0'")
                .HasComment("Cho phep xoa lay mau")
                .HasColumnName("is_delete_sample");
            entity.Property(e => e.IsShowHandle)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_show_handle");
            entity.Property(e => e.IsShowSample)
                .HasDefaultValueSql("'0'")
                .HasComment("Cho phep hien thi lay mau")
                .HasColumnName("is_show_sample");
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(50)
                .HasComment("người updated cuối cùng")
                .HasColumnName("last_updated_by");
            entity.Property(e => e.ParentId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("parent_id");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.PatientInDebt)
                .HasComment("bệnh nhân còn nợ")
                .HasColumnName("patient_in_debt");
            entity.Property(e => e.PatientPaid)
                .HasDefaultValueSql("'0'")
                .HasComment("bệnh nhân đã trả")
                .HasColumnName("patient_paid");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(50)
                .HasDefaultValueSql("'UNPAID'")
                .HasColumnName("payment_status");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Qty)
                .HasDefaultValueSql("'1'")
                .HasColumnName("qty");
            entity.Property(e => e.Result)
                .HasComment("Kết quả nhập tay và dùng làm kq trả về")
                .HasColumnType("text")
                .HasColumnName("result");
            entity.Property(e => e.ResultByMachine)
                .HasComment("kết quả update từ máy xét nghiệm")
                .HasColumnType("text")
                .HasColumnName("result_by_machine");
            entity.Property(e => e.ResultByMachineAt)
                .HasComment("thời gian nhận được kq từ máy")
                .HasColumnType("timestamp")
                .HasColumnName("result_by_machine_at");
            entity.Property(e => e.ResultNote)
                .HasMaxLength(255)
                .HasColumnName("result_note");
            entity.Property(e => e.ResultUnit)
                .HasMaxLength(50)
                .HasColumnName("result_unit");
            entity.Property(e => e.RisDevice)
                .HasMaxLength(255)
                .HasComment("thiết bị thực hiện ris")
                .HasColumnName("ris_device");
            entity.Property(e => e.RisFinish)
                .HasComment("kết luận")
                .HasColumnName("ris_finish");
            entity.Property(e => e.RisResult)
                .HasComment("nội dung ris")
                .HasColumnName("ris_result");
            entity.Property(e => e.RoomHandleBy)
                .HasMaxLength(50)
                .HasComment("Nguoi xn")
                .HasColumnName("room_handle_by");
            entity.Property(e => e.RoomHandleDate)
                .HasComment("Thoi gian xn")
                .HasColumnType("timestamp")
                .HasColumnName("room_handle_date");
            entity.Property(e => e.RoomHandleId)
                .HasComment("phòng xét nghiệm / thực hiện")
                .HasColumnName("room_handle_id");
            entity.Property(e => e.RoomHandleResultBy)
                .HasMaxLength(50)
                .HasComment("Nguoi trả kết quả xn")
                .HasColumnName("room_handle_result_by");
            entity.Property(e => e.RoomHandleResultDate)
                .HasComment("Thoi gian trả kq xn")
                .HasColumnType("timestamp")
                .HasColumnName("room_handle_result_date");
            entity.Property(e => e.RoomHandleStatus)
                .HasMaxLength(100)
                .HasComment("Trang thai xn")
                .HasColumnName("room_handle_status");
            entity.Property(e => e.RoomId)
                .HasComment("Phòng chỉ định")
                .HasColumnName("room_id");
            entity.Property(e => e.RoomSampleId)
                .HasComment("phòng lấy mẫu")
                .HasColumnName("room_sample_id");
            entity.Property(e => e.ServiceCode)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("service_code");
            entity.Property(e => e.ServiceDate)
                .HasComment("Ngày làm dịch vụ")
                .HasColumnType("timestamp")
                .HasColumnName("service_date");
            entity.Property(e => e.ServiceGroupId)
                .HasComment("Tách theo nhóm")
                .HasColumnName("service_group_id");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.ServiceName)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("service_name");
            entity.Property(e => e.ServiceObject)
                .HasMaxLength(50)
                .HasComment("đối tượng thanh toán")
                .HasColumnName("service_object");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValueSql("'PENDING'")
                .HasColumnName("status");
            entity.Property(e => e.TestCode)
                .HasMaxLength(50)
                .HasColumnName("test_code");
            entity.Property(e => e.TicketId)
                .HasComment("thuộc ticket nào")
                .HasColumnName("ticket_id");
            entity.Property(e => e.TotalAmount)
                .HasComment("tổng số phải trả : giá * sl")
                .HasColumnName("total_amount");
            entity.Property(e => e.Unit)
                .HasMaxLength(50)
                .HasComment("đơn vị")
                .HasColumnName("unit");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Examination).WithMany(p => p.ExaminationOrders)
                .HasForeignKey(d => d.ExaminationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_examination_appointments_examination");
        });

        modelBuilder.Entity<ExaminationOrdinal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("examination_ordinal", tb => tb.HasComment("Số thứ tự chờ tiếp đón"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.ExaminationId, "FK_examination_ordinal_examination");

            entity.HasIndex(e => new { e.Number, e.RoomCode }, "number_room_code").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CallingNumber).HasColumnName("calling_number");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DateTime).HasColumnName("date_time");
            entity.Property(e => e.ExaminationId).HasColumnName("examination_id");
            entity.Property(e => e.Number)
                .HasComment("So tt")
                .HasColumnName("number");
            entity.Property(e => e.RoomCode)
                .HasMaxLength(50)
                .HasColumnName("room_code");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<ExaminationResult>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("examination_results", tb => tb.HasComment("Xử trí khám bệnh"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.ExaminationId, "FK_examination_results_examination");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Allergy)
                .HasDefaultValueSql("'0'")
                .HasComment("Dị ứng")
                .HasColumnName("allergy");
            entity.Property(e => e.AllergyNote)
                .HasComment("Dị ứng note")
                .HasColumnType("tinytext")
                .HasColumnName("allergy_note");
            entity.Property(e => e.Bmi)
                .HasMaxLength(50)
                .HasComment("Tỉ lệ cân nặng/chiều cao")
                .HasColumnName("bmi");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DoctorId).HasColumnName("doctor_id");
            entity.Property(e => e.Emergency)
                .HasDefaultValueSql("'0'")
                .HasComment("Cấp cứu?")
                .HasColumnName("emergency");
            entity.Property(e => e.ExamNote)
                .HasComment("Khám bệnh")
                .HasColumnType("tinytext")
                .HasColumnName("exam_note");
            entity.Property(e => e.ExamPart)
                .HasComment("Khám bộ phận")
                .HasColumnType("tinytext")
                .HasColumnName("exam_part");
            entity.Property(e => e.ExaminationId).HasColumnName("examination_id");
            entity.Property(e => e.FamilyMedicalHistory)
                .HasComment("Tiền sử gia đình")
                .HasColumnType("tinytext")
                .HasColumnName("family_medical_history");
            entity.Property(e => e.Height)
                .HasMaxLength(50)
                .HasComment("Chiều cao")
                .HasColumnName("height");
            entity.Property(e => e.InitiallyResult)
                .HasComment("Kết luận tóm tắt")
                .HasColumnType("tinytext")
                .HasColumnName("initially_result");
            entity.Property(e => e.PathologicalProcess)
                .HasComment("Quá trình bệnh lý")
                .HasColumnType("tinytext")
                .HasColumnName("pathological_process");
            entity.Property(e => e.PressureMax)
                .HasMaxLength(50)
                .HasColumnName("pressure_max");
            entity.Property(e => e.PressureMin)
                .HasMaxLength(50)
                .HasComment("Huyết áp")
                .HasColumnName("pressure_min");
            entity.Property(e => e.Pulse)
                .HasMaxLength(50)
                .HasComment("Mạch")
                .HasColumnName("pulse");
            entity.Property(e => e.Reason)
                .HasComment("Lý do khám")
                .HasColumnType("tinytext")
                .HasColumnName("reason");
            entity.Property(e => e.ReasonEdit)
                .HasComment("Ly do sua")
                .HasColumnType("text")
                .HasColumnName("reason_edit");
            entity.Property(e => e.ResolveMethod)
                .HasComment("Hướng xử lý")
                .HasColumnType("tinytext")
                .HasColumnName("resolve_method");
            entity.Property(e => e.Respiration)
                .HasMaxLength(50)
                .HasComment("Nhịp thở")
                .HasColumnName("respiration");
            entity.Property(e => e.SelfMedicalHistory)
                .HasComment("Tiền sử bản thân")
                .HasColumnType("tinytext")
                .HasColumnName("self_medical_history");
            entity.Property(e => e.SpO2)
                .HasMaxLength(50)
                .HasComment("SpO2")
                .HasColumnName("spO2");
            entity.Property(e => e.Symptom)
                .HasComment("Triệu chứng")
                .HasColumnType("tinytext")
                .HasColumnName("symptom");
            entity.Property(e => e.Temperature)
                .HasMaxLength(50)
                .HasComment("Nhiệt độ")
                .HasColumnName("temperature");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.Weight)
                .HasMaxLength(50)
                .HasComment("Cân nặng")
                .HasColumnName("weight");

            entity.HasOne(d => d.Examination).WithMany(p => p.ExaminationResults)
                .HasForeignKey(d => d.ExaminationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_examination_results_examination");
        });

        modelBuilder.Entity<ExaminationTicket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("examination_tickets", tb => tb.HasComment("Quản lý các phiếu chỉ định"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.ExaminationId, "FK_examination_appointments_examination");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Barcode)
                .HasMaxLength(50)
                .HasColumnName("barcode");
            entity.Property(e => e.CreatedAt)
                .HasComment("ngày tạo phiếu")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.DoctorId).HasColumnName("doctor_id");
            entity.Property(e => e.ExaminationId).HasColumnName("examination_id");
            entity.Property(e => e.HandleAt)
                .HasComment("thực hiện lúc")
                .HasColumnType("timestamp")
                .HasColumnName("handle_at");
            entity.Property(e => e.HandleBy)
                .HasMaxLength(50)
                .HasComment("người thực hiện")
                .HasColumnName("handle_by");
            entity.Property(e => e.HandleReturnResultAt)
                .HasComment("trả kết quả lúc")
                .HasColumnType("timestamp")
                .HasColumnName("handle_return_result_at");
            entity.Property(e => e.HandleReturnResultBy)
                .HasMaxLength(50)
                .HasComment("người trả kết quả ")
                .HasColumnName("handle_return_result_by");
            entity.Property(e => e.HandleStatus)
                .HasMaxLength(50)
                .HasComment("trạng thái thực hiện")
                .HasColumnName("handle_status");
            entity.Property(e => e.IsEmergency)
                .HasComment("Có phải là cấp cứu ?")
                .HasColumnName("is_emergency");
            entity.Property(e => e.OrderAt)
                .HasComment("ngày y lệnh (thực hiện)")
                .HasColumnType("timestamp")
                .HasColumnName("order_at");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(50)
                .HasComment("trạng thái thanh toán")
                .HasColumnName("payment_status");
            entity.Property(e => e.ProductOrderId)
                .HasComment("order ticket id")
                .HasColumnName("product_order_id");
            entity.Property(e => e.Room)
                .HasComment("ID phong")
                .HasColumnName("room");
            entity.Property(e => e.RoomHandle)
                .HasComment("Id cua phong thuc hien")
                .HasColumnName("room_handle");
            entity.Property(e => e.RoomSample)
                .HasComment("ID cua phong lay mau")
                .HasColumnName("room_sample");
            entity.Property(e => e.SampleAt)
                .HasComment("thời gian lấy mẫu")
                .HasColumnType("timestamp")
                .HasColumnName("sample_at");
            entity.Property(e => e.SampleBy)
                .HasMaxLength(50)
                .HasComment("người lấy mẫu")
                .HasColumnName("sample_by");
            entity.Property(e => e.SampleStatus)
                .HasMaxLength(50)
                .HasComment("trạng thái lấy mẫu")
                .HasColumnName("sample_status");
            entity.Property(e => e.ServiceGroupId)
                .HasComment("id nhóm dịch vụ")
                .HasColumnName("service_group_id");
            entity.Property(e => e.Status)
                .HasComment("active , inactive , delete ...")
                .HasColumnName("status");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasComment("phiếu từ nguồn nào : exam hay kho ..")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Fund>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("funds")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccBranch)
                .HasMaxLength(255)
                .HasColumnName("acc_branch");
            entity.Property(e => e.AccName)
                .HasMaxLength(255)
                .HasColumnName("acc_name");
            entity.Property(e => e.AccNumber)
                .HasMaxLength(255)
                .HasColumnName("acc_number");
            entity.Property(e => e.Balance)
                .HasDefaultValueSql("'0'")
                .HasColumnType("double(22,0)")
                .HasColumnName("balance");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(50)
                .HasColumnName("currency_code");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");
            entity.Property(e => e.TaxAcc)
                .HasMaxLength(255)
                .HasComment("113")
                .HasColumnName("tax_acc");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasComment("Loại")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<FundLog>(entity =>
        {
            entity.HasKey(e => e.FundLogId).HasName("PRIMARY");

            entity
                .ToTable("fund_logs", tb => tb.HasComment("Phiếu thu tiền"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.CheckinId, "checkin_id");

            entity.HasIndex(e => e.Code, "code").IsUnique();

            entity.Property(e => e.FundLogId).HasColumnName("fund_log_id");
            entity.Property(e => e.BenefitRate)
                .HasComment("Mức hưởng bhyt")
                .HasColumnName("benefit_rate");
            entity.Property(e => e.BookNumber)
                .HasMaxLength(45)
                .HasComment("Số quyển")
                .HasColumnName("book_number");
            entity.Property(e => e.CheckinId).HasColumnName("checkin_id");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.CopayPatient)
                .HasComment("Bệnh nhân cùng chi trả")
                .HasColumnType("double(22,0)")
                .HasColumnName("copay_patient");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Creator)
                .HasDefaultValueSql("'1'")
                .HasColumnName("creator");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(255)
                .HasColumnName("currency_code");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Discount).HasColumnName("discount");
            entity.Property(e => e.Fees).HasColumnName("fees");
            entity.Property(e => e.FundLogChannel)
                .HasMaxLength(255)
                .HasColumnName("fund_log_channel");
            entity.Property(e => e.NetAmount).HasColumnName("net_amount");
            entity.Property(e => e.Note)
                .HasColumnType("text")
                .HasColumnName("note");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.OrderType)
                .HasMaxLength(45)
                .HasColumnName("order_type");
            entity.Property(e => e.PatientsInDebt)
                .HasComment("Bệnh nhân còn nợ")
                .HasColumnType("double(22,0)")
                .HasColumnName("patients_in_debt");
            entity.Property(e => e.PatientsPaid)
                .HasComment("Bệnh nhân đã trả")
                .HasColumnType("double(22,0)")
                .HasColumnName("patients_paid");
            entity.Property(e => e.PayAmount).HasColumnName("pay_amount");
            entity.Property(e => e.Paygate)
                .HasMaxLength(45)
                .HasColumnName("paygate");
            entity.Property(e => e.ServiceObject)
                .HasMaxLength(255)
                .HasComment("Đối tượng thanh toán")
                .HasColumnName("service_object");
            entity.Property(e => e.Status)
                .HasMaxLength(45)
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<FundsMode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("funds_mode", tb => tb.HasComment("Các hình thức thanh toán quỹ"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Sort)
                .HasDefaultValueSql("'1'")
                .HasColumnName("sort");
            entity.Property(e => e.TaxAcc)
                .HasMaxLength(255)
                .HasComment("113")
                .HasColumnName("tax_acc");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasComment("Loại thu, chi")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("groups")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(191)
                .HasColumnName("description")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Hideit).HasColumnName("hideit");
            entity.Property(e => e.Name)
                .HasMaxLength(191)
                .HasColumnName("name")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Sort)
                .HasDefaultValueSql("'0'")
                .HasColumnName("sort");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Hospital>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("hospitals", tb => tb.HasComment("Danh mục cơ sở khám chữa bệnh"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.Code, "code").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("code");
            entity.Property(e => e.CountryCode)
                .HasMaxLength(50)
                .HasDefaultValueSql("'VN'")
                .HasColumnName("country_code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Director)
                .HasMaxLength(255)
                .HasColumnName("director");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .HasColumnName("image");
            entity.Property(e => e.Name)
                .HasColumnType("text")
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .HasColumnName("phone");
            entity.Property(e => e.Rank)
                .HasMaxLength(50)
                .HasComment("Hạng")
                .HasColumnName("rank");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasComment("tuyến")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Information>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("informations")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.Code, "code");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<InformationInsurance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("information_insurance", tb => tb.HasComment("Cấu hình thông tin BHYT"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AccountSocialInsurance)
                .HasMaxLength(255)
                .HasComment("Tài khoản BHXH")
                .HasColumnName("account_social_insurance");
            entity.Property(e => e.ApiSocialInsurance)
                .HasMaxLength(255)
                .HasComment("API BHXH")
                .HasColumnName("api_social_insurance");
            entity.Property(e => e.MinimumSalaryMonth)
                .HasComment("Tháng lương tối thiểu")
                .HasColumnName("minimum_salary_month");
            entity.Property(e => e.OfflinePayment)
                .HasComment("Mức chi trả trái tuyến")
                .HasColumnName("offline_payment");
            entity.Property(e => e.PasswordSocialInsurance)
                .HasMaxLength(255)
                .HasComment("Mật khẩu BHXH")
                .HasColumnName("password_social_insurance");
        });

        modelBuilder.Entity<InsuranceCard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("insurance_cards", tb => tb.HasComment("Nhóm BHYT"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BenefitCode)
                .HasMaxLength(45)
                .HasColumnName("benefit_code");
            entity.Property(e => e.BenefitRate).HasColumnName("benefit_rate");
            entity.Property(e => e.InsuranceCode)
                .HasMaxLength(45)
                .HasColumnName("insurance_code");
            entity.Property(e => e.InsuranceName)
                .HasMaxLength(255)
                .HasColumnName("insurance_name");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("inventories", tb => tb.HasComment("Quản lý kho hàng hóa"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.ProductId, "product_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.Area)
                .HasMaxLength(50)
                .HasColumnName("area");
            entity.Property(e => e.Barcode)
                .HasMaxLength(255)
                .HasColumnName("barcode");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.ExpirationDate).HasColumnName("expiration_date");
            entity.Property(e => e.Locked)
                .HasComment("số hàng đang tạm giữ")
                .HasColumnName("locked");
            entity.Property(e => e.PackageCode)
                .HasMaxLength(100)
                .HasComment("Mã lô hoặc serial")
                .HasColumnName("package_code");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .HasColumnName("product_name");
            entity.Property(e => e.ProductionDate).HasColumnName("production_date");
            entity.Property(e => e.Quantity)
                .HasComment("Số hàng tồn")
                .HasColumnName("quantity");
            entity.Property(e => e.Sku)
                .HasMaxLength(255)
                .HasColumnName("sku");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");
            entity.Property(e => e.StockId).HasColumnName("stock_id");
            entity.Property(e => e.TakePrice)
                .HasDefaultValueSql("'1'")
                .HasColumnName("take_price");
            entity.Property(e => e.Unit)
                .HasMaxLength(50)
                .HasComment("Đơn vị tính")
                .HasColumnName("unit");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<InventoryLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("inventory_logs", tb => tb.HasComment("Lịch sử xuất nhập kho"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AfterAmount).HasColumnName("after_amount");
            entity.Property(e => e.Amount)
                .HasComment("Số lượng mua")
                .HasColumnType("float(12,0)")
                .HasColumnName("amount");
            entity.Property(e => e.BeforeAmount).HasColumnName("before_amount");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatorId)
                .HasComment("người tạo")
                .HasColumnName("creator_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.InventoryId).HasColumnName("inventory_id");
            entity.Property(e => e.Logs)
                .HasColumnType("mediumtext")
                .HasColumnName("logs");
            entity.Property(e => e.OrderCode)
                .HasMaxLength(255)
                .HasComment("Mã đơn hàng")
                .HasColumnName("order_code");
            entity.Property(e => e.PackageCode)
                .HasMaxLength(255)
                .HasColumnName("package_code");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.ProductName)
                .HasMaxLength(255)
                .HasColumnName("product_name");
            entity.Property(e => e.Reason)
                .HasMaxLength(50)
                .HasColumnName("reason");
            entity.Property(e => e.StockId)
                .HasComment("kho chịu tác động")
                .HasColumnName("stock_id");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasComment("- hoặc +")
                .HasColumnName("type");
            entity.Property(e => e.Unit)
                .HasMaxLength(255)
                .HasColumnName("unit");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId)
                .HasComment("khách hàng")
                .HasColumnName("user_id");
        });

        modelBuilder.Entity<InventoryPo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("inventory_pos")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.Code, "code").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.DeviceId)
                .HasMaxLength(255)
                .HasColumnName("device_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Seller)
                .HasColumnType("text")
                .HasColumnName("seller");
            entity.Property(e => e.Stadium).HasColumnName("stadium");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");
            entity.Property(e => e.Stock)
                .HasColumnType("text")
                .HasColumnName("stock");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<InventoryStock>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("inventory_stock", tb => tb.HasComment("Kho"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.Key, "key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .HasColumnName("city");
            entity.Property(e => e.ContactName)
                .HasMaxLength(255)
                .HasColumnName("contact_name");
            entity.Property(e => e.ContactPhone).HasColumnName("contact_phone");
            entity.Property(e => e.Country)
                .HasMaxLength(255)
                .HasDefaultValueSql("'VN'")
                .HasColumnName("country");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Key)
                .HasMaxLength(50)
                .HasColumnName("key");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<InventoryUnitConvert>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("inventory_unit_convert")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.FromUnit)
                .HasMaxLength(50)
                .HasComment("key")
                .HasColumnName("from_unit");
            entity.Property(e => e.FromUnitName)
                .HasMaxLength(50)
                .HasColumnName("from_unit_name");
            entity.Property(e => e.ToUnit)
                .HasMaxLength(50)
                .HasColumnName("to_unit");
            entity.Property(e => e.ToUnitName)
                .HasMaxLength(50)
                .HasColumnName("to_unit_name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.Value)
                .HasDefaultValueSql("'1'")
                .HasComment("gia tri quy doi")
                .HasColumnName("value");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("invoices")
                .UseCollation("utf8_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountantId)
                .HasComment("Kế toán viên")
                .HasColumnName("accountant_id");
            entity.Property(e => e.AccountantIdCancell)
                .HasComment("Kế toán nào hủy phiếu")
                .HasColumnName("accountant_id_cancell");
            entity.Property(e => e.AdminNote)
                .HasColumnType("text")
                .HasColumnName("admin_note");
            entity.Property(e => e.AffilateId)
                .HasComment("Hoa hồng")
                .HasColumnName("affilate_id");
            entity.Property(e => e.Approved)
                .HasDefaultValueSql("'1'")
                .HasColumnName("approved");
            entity.Property(e => e.BankInfo)
                .HasColumnType("text")
                .HasColumnName("bank_info");
            entity.Property(e => e.CancellOrders)
                .HasComment("chuỗi json chi tiết thanh toán bị hủy")
                .HasColumnType("text")
                .HasColumnName("cancell_orders");
            entity.Property(e => e.CancelledReason)
                .HasMaxLength(255)
                .HasColumnName("cancelled_reason");
            entity.Property(e => e.CheckinId).HasColumnName("checkin_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(10)
                .HasColumnName("currency_code");
            entity.Property(e => e.CurrencyRate).HasColumnName("currency_rate");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasComment("Mô tả cho thanh toán")
                .HasColumnName("description");
            entity.Property(e => e.Discount)
                .HasDefaultValueSql("'0'")
                .HasComment("Số tiền được giảm")
                .HasColumnName("discount");
            entity.Property(e => e.FundId)
                .HasComment("Tài khoản nhận")
                .HasColumnName("fund_id");
            entity.Property(e => e.InvoiceCode)
                .HasMaxLength(50)
                .HasColumnName("invoice_code");
            entity.Property(e => e.InvoiceType)
                .HasMaxLength(50)
                .HasDefaultValueSql("'TT'")
                .HasComment("thanh toán , tạm ứng ....")
                .HasColumnName("invoice_type");
            entity.Property(e => e.Locked)
                .HasDefaultValueSql("'0'")
                .HasColumnName("locked");
            entity.Property(e => e.Module)
                .HasMaxLength(50)
                .HasColumnName("module");
            entity.Property(e => e.NetAmount)
                .HasComment("Tổng tiền đã gồm tiền hàng, thuế, phí")
                .HasColumnName("net_amount");
            entity.Property(e => e.PayAmount).HasColumnName("pay_amount");
            entity.Property(e => e.PayerName)
                .HasMaxLength(255)
                .HasColumnName("payer_name");
            entity.Property(e => e.PayerPhone)
                .HasMaxLength(255)
                .HasColumnName("payer_phone");
            entity.Property(e => e.Paygate)
                .HasMaxLength(50)
                .HasDefaultValueSql("'TM'")
                .HasComment("ex: tiền mặt ..")
                .HasColumnName("paygate");
            entity.Property(e => e.PaygateCode)
                .HasMaxLength(50)
                .HasColumnName("paygate_code");
            entity.Property(e => e.PaymentFees)
                .HasComment("Phí của cổng thanh toán")
                .HasColumnName("payment_fees");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(50)
                .HasComment("cash")
                .HasColumnName("payment_method");
            entity.Property(e => e.Reference)
                .HasMaxLength(255)
                .HasComment("Mã đối chiếu, chính là charging ID")
                .HasColumnName("reference");
            entity.Property(e => e.ReferenceInvoiceId)
                .HasComment("hủy từ invoice nào / hủy bởi invoice nào")
                .HasColumnName("reference_invoice_id");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValueSql("'UNPAID'")
                .HasComment("trạng thái  thanh toan")
                .HasColumnName("status");
            entity.Property(e => e.Tax)
                .HasDefaultValueSql("'0'")
                .HasColumnName("tax");
            entity.Property(e => e.TransferId)
                .HasMaxLength(255)
                .HasColumnName("transfer_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("languages", tb => tb.HasComment("Ngôn ngữ"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.Code, "code7").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Charset)
                .HasMaxLength(50)
                .HasColumnName("charset")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .HasColumnName("code")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Default).HasColumnName("default");
            entity.Property(e => e.Flag)
                .HasMaxLength(255)
                .HasColumnName("flag")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Hreflang)
                .HasMaxLength(50)
                .HasColumnName("hreflang")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Installed).HasColumnName("installed");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Sort).HasColumnName("sort");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<LocalAdminUnit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("local_admin_units")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CodeName)
                .HasMaxLength(255)
                .HasColumnName("code_name");
            entity.Property(e => e.CodeNameEn)
                .HasMaxLength(255)
                .HasColumnName("code_name_en");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .HasColumnName("full_name");
            entity.Property(e => e.FullNameEn)
                .HasMaxLength(255)
                .HasColumnName("full_name_en");
            entity.Property(e => e.ShortName)
                .HasMaxLength(255)
                .HasColumnName("short_name");
            entity.Property(e => e.ShortNameEn)
                .HasMaxLength(255)
                .HasColumnName("short_name_en");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<LocalCity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("local_cities", tb => tb.HasComment("Thành phố"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.Code, "code").IsUnique();

            entity.HasIndex(e => e.CountryCode, "country_code");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.CountryCode).HasColumnName("country_code");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Featured).HasColumnName("featured");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.NameEn)
                .HasMaxLength(255)
                .HasColumnName("name_en");
            entity.Property(e => e.Region)
                .HasMaxLength(255)
                .HasColumnName("region");
            entity.Property(e => e.Sort).HasColumnName("sort");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.CountryCodeNavigation).WithMany(p => p.LocalCities)
                .HasPrincipalKey(p => p.Code)
                .HasForeignKey(d => d.CountryCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cities_countries");
        });

        modelBuilder.Entity<LocalCountry>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("local_countries", tb => tb.HasComment("Quốc tịch"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.Code, "code").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Area)
                .HasMaxLength(50)
                .HasColumnName("area");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DialCode)
                .HasMaxLength(255)
                .HasColumnName("dial_code");
            entity.Property(e => e.Featured).HasColumnName("featured");
            entity.Property(e => e.Lang)
                .HasMaxLength(255)
                .HasColumnName("lang");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.NameEn)
                .HasMaxLength(255)
                .HasColumnName("name_en");
            entity.Property(e => e.Sort).HasColumnName("sort");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<LocalDistrict>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("local_districts", tb => tb.HasComment("Quận/Huyện"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AdministrativeUnitId).HasColumnName("administrative_unit_id");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("code");
            entity.Property(e => e.CodeName)
                .HasMaxLength(255)
                .HasColumnName("code_name");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .HasColumnName("full_name");
            entity.Property(e => e.FullNameEn)
                .HasMaxLength(255)
                .HasColumnName("full_name_en");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.NameEn)
                .HasMaxLength(255)
                .HasColumnName("name_en");
            entity.Property(e => e.ProvinceCode)
                .HasMaxLength(255)
                .HasColumnName("province_code");
            entity.Property(e => e.Sort).HasColumnName("sort");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<LocalRegion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("local_regions", tb => tb.HasComment("Vùng/Miền"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CodeName)
                .HasMaxLength(255)
                .HasColumnName("code_name");
            entity.Property(e => e.CodeNameEn)
                .HasMaxLength(255)
                .HasColumnName("code_name_en");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.NameEn)
                .HasMaxLength(255)
                .HasColumnName("name_en");
            entity.Property(e => e.Sort).HasColumnName("sort");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<LocalWard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("local_wards", tb => tb.HasComment("Phường/Xã"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.Code, "code");

            entity.HasIndex(e => e.ShortCode, "short_code");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AdministrativeUnitId).HasColumnName("administrative_unit_id");
            entity.Property(e => e.CityCode)
                .HasMaxLength(255)
                .HasColumnName("city_code");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("code");
            entity.Property(e => e.CodeName)
                .HasMaxLength(255)
                .HasColumnName("code_name");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DistrictCode)
                .HasMaxLength(255)
                .HasColumnName("district_code");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .HasColumnName("full_name");
            entity.Property(e => e.FullNameEn)
                .HasMaxLength(255)
                .HasColumnName("full_name_en");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.NameEn)
                .HasMaxLength(255)
                .HasColumnName("name_en");
            entity.Property(e => e.ShortCode)
                .HasComment("go tat")
                .HasColumnName("short_code");
            entity.Property(e => e.Sort).HasColumnName("sort");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Machine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("machine")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.MachineCode, "machine_code").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ConnectionType)
                .HasMaxLength(50)
                .HasDefaultValueSql("'RS-232'")
                .HasColumnName("connection_type");
            entity.Property(e => e.MachineCode)
                .HasMaxLength(50)
                .HasColumnName("machine_code");
            entity.Property(e => e.MachineName)
                .HasMaxLength(50)
                .HasColumnName("machine_name");
            entity.Property(e => e.ServiceTypeIns)
                .HasMaxLength(50)
                .HasComment("ex: SH / HH / CL / MRI")
                .HasColumnName("service_type_ins");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");
            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasDefaultValueSql("'RIS'")
                .HasColumnName("type");
        });

        modelBuilder.Entity<MachineDevice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("machine_device", tb => tb.HasComment("thiết bị máy móc"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => new { e.MachineCode, e.DeviceNumber }, "machine_code_device_number").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DeviceNumber)
                .HasMaxLength(50)
                .HasDefaultValueSql("'0'")
                .HasComment("serial máy ; gồm 6 số cuối hoặc thêm 0 vào đầu cho đủ 6 số")
                .HasColumnName("device_number");
            entity.Property(e => e.FundingSource)
                .HasDefaultValueSql("'3'")
                .HasComment("1: ngân sách nhà nước ; 2: xã hội hóa ; 3: khác")
                .HasColumnName("funding_source");
            entity.Property(e => e.MachineCode)
                .HasMaxLength(50)
                .HasDefaultValueSql("'0'")
                .HasComment("mã model")
                .HasColumnName("machine_code");
            entity.Property(e => e.RoomId).HasColumnName("room_id");
        });

        modelBuilder.Entity<MachineTestcode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("machine_testcode")
                .UseCollation("utf8_unicode_ci");

            entity.HasIndex(e => new { e.MachineCode, e.TestCode }, "machine_code_test_code").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MachineCode)
                .HasMaxLength(50)
                .HasColumnName("machine_code");
            entity.Property(e => e.ServiceCode)
                .HasMaxLength(50)
                .HasColumnName("service_code");
            entity.Property(e => e.TestCode)
                .HasMaxLength(50)
                .HasColumnName("test_code");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("news")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.Slug, "news_slug");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Author)
                .HasMaxLength(50)
                .HasColumnName("author")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.CatId).HasColumnName("cat_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("time")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .HasColumnName("image")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Slug)
                .HasColumnName("slug")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("time")
                .HasColumnName("updated_at");
            entity.Property(e => e.Views)
                .HasDefaultValueSql("'0'")
                .HasColumnName("views");
        });

        modelBuilder.Entity<NewsCat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("news_cats")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.Slug, "url_key");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Image)
                .HasMaxLength(250)
                .HasColumnName("image")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.ParentId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("parent_id");
            entity.Property(e => e.Slug)
                .HasColumnName("slug")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Sort).HasColumnName("sort");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("patients", tb => tb.HasComment("Thông tin bệnh nhân"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.PatientNumber, "patient_number");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.Birthday)
                .HasColumnType("datetime")
                .HasColumnName("birthday");
            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.CountryCode)
                .HasMaxLength(50)
                .HasDefaultValueSql("'VN'")
                .HasColumnName("country_code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Credit)
                .HasPrecision(20, 6)
                .HasDefaultValueSql("'0.000000'")
                .HasComment("Số tiền cọc")
                .HasColumnName("credit");
            entity.Property(e => e.DayBorn)
                .HasMaxLength(5)
                .HasColumnName("day_born");
            entity.Property(e => e.DetailObject)
                .HasMaxLength(255)
                .HasComment("Đối tượng chi tiết")
                .HasColumnName("detail_object");
            entity.Property(e => e.DistrictId).HasColumnName("district_id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Ethnic)
                .HasMaxLength(255)
                .HasComment("Dân tộc")
                .HasColumnName("ethnic");
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .HasColumnName("gender");
            entity.Property(e => e.IdCard)
                .HasMaxLength(50)
                .HasColumnName("id_card");
            entity.Property(e => e.IdCardType)
                .HasMaxLength(50)
                .HasDefaultValueSql("'cccd'")
                .HasComment("cccd, cmnd, passport")
                .HasColumnName("id_card_type");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .HasColumnName("image");
            entity.Property(e => e.IssueDate)
                .HasColumnType("datetime")
                .HasColumnName("issue_date");
            entity.Property(e => e.JobTitle)
                .HasMaxLength(255)
                .HasColumnName("job_title");
            entity.Property(e => e.Lang)
                .HasMaxLength(50)
                .HasColumnName("lang");
            entity.Property(e => e.MonthBorn)
                .HasMaxLength(5)
                .HasColumnName("month_born");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Nationality)
                .HasMaxLength(50)
                .HasDefaultValueSql("'Vietnamese'")
                .HasColumnName("nationality");
            entity.Property(e => e.PatientNumber)
                .HasMaxLength(50)
                .HasColumnName("patient_number");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.PostCode)
                .HasMaxLength(50)
                .HasColumnName("post_code");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasDefaultValueSql("'adult'")
                .HasComment("adult, child, infant")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.WardId)
                .HasComment("Thôn xóm")
                .HasColumnName("ward_id");
            entity.Property(e => e.YearBorn)
                .HasMaxLength(5)
                .HasColumnName("year_born");
        });

        modelBuilder.Entity<PatientDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("patient_details", tb => tb.HasComment("Chi tiết bệnh nhân"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.PatientId, "FK_patient_details_patients");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.AddressWorkplace)
                .HasMaxLength(255)
                .HasComment("địa chỉ nơi làm việc")
                .HasColumnName("address_workplace");
            entity.Property(e => e.Children).HasColumnName("children");
            entity.Property(e => e.Company)
                .HasMaxLength(255)
                .HasColumnName("company");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Education)
                .HasMaxLength(255)
                .HasComment("Học vấn")
                .HasColumnName("education");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .HasColumnName("image");
            entity.Property(e => e.JobTitle)
                .HasMaxLength(255)
                .HasComment("Nghề nghiệp")
                .HasColumnName("job_title");
            entity.Property(e => e.Married).HasColumnName("married");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.Prehistoric)
                .HasComment("Tiền sử bệnh, Array")
                .HasColumnType("text")
                .HasColumnName("prehistoric");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Patient).WithMany(p => p.PatientDetails)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_patient_details_patients");
        });

        modelBuilder.Entity<PatientInsuranceCard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("patient_insurance_cards", tb => tb.HasComment("BHYT ứng với bệnh nhân"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.PatientId, "FK_patient_insurance_cards_patients");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BenefitRate)
                .HasComment("Quyền lợi hưởng mặc định")
                .HasColumnName("benefit_rate");
            entity.Property(e => e.BenifitCode)
                .HasMaxLength(255)
                .HasColumnName("benifit_code");
            entity.Property(e => e.CityCode)
                .HasMaxLength(255)
                .HasColumnName("city_code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.ExpirationDate).HasColumnName("expiration_date");
            entity.Property(e => e.FromDate).HasColumnName("from_date");
            entity.Property(e => e.FullNumber)
                .HasMaxLength(255)
                .HasComment("Số FULL")
                .HasColumnName("full_number");
            entity.Property(e => e.InsuranceAddress)
                .HasMaxLength(255)
                .HasComment("Địa chỉ thẻ")
                .HasColumnName("insurance_address");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .HasColumnName("note");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.Region)
                .HasMaxLength(255)
                .HasComment("Nơi sống: K1,K2,K3")
                .HasColumnName("region");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasDefaultValueSql("'valid'")
                .HasColumnName("status");
            entity.Property(e => e.SubjectCode)
                .HasMaxLength(255)
                .HasComment("Mã đối tượng")
                .HasColumnName("subject_code");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Patient).WithMany(p => p.PatientInsuranceCards)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_patient_insurance_cards_patients");
        });

        modelBuilder.Entity<PatientPrehistoric>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("patient_prehistoric", tb => tb.HasComment("Tiền sử bệnh"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.PatientId, "FK_patient_prehistoric_patients");

            entity.HasIndex(e => new { e.DiseaseId, e.PatientId }, "disease_id_patient_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
            entity.Property(e => e.DiseaseId).HasColumnName("disease_id");
            entity.Property(e => e.FromDate)
                .HasColumnType("timestamp")
                .HasColumnName("from_date");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Patient).WithMany(p => p.PatientPrehistorics)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_patient_prehistoric_patients");
        });

        modelBuilder.Entity<PatientRelation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("patient_relations", tb => tb.HasComment("Gia đình bệnh nhân"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.FaAddress)
                .HasMaxLength(255)
                .HasColumnName("fa_address");
            entity.Property(e => e.FaIdCard)
                .HasMaxLength(50)
                .HasColumnName("fa_id_card");
            entity.Property(e => e.FaName)
                .HasMaxLength(255)
                .HasColumnName("fa_name");
            entity.Property(e => e.FaPhone)
                .HasMaxLength(255)
                .HasColumnName("fa_phone");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.RelationType)
                .HasMaxLength(255)
                .HasComment("là bố, mẹ, giám hộ, ...")
                .HasColumnName("relation_type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<PatientType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("patient_types", tb => tb.HasComment("Loại bệnh nhân (Nhân dân, Bộ đội, .....)"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.Code, "code").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.NameEn)
                .HasMaxLength(255)
                .HasColumnName("name_en");
            entity.Property(e => e.Sort).HasColumnName("sort");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Paygate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("paygates")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.Code, "code14").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AllowGroups)
                .HasMaxLength(255)
                .HasColumnName("allow_groups")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Avatar)
                .HasMaxLength(255)
                .HasColumnName("avatar")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Balance).HasColumnName("balance");
            entity.Property(e => e.CancelTime).HasColumnName("cancel_time");
            entity.Property(e => e.Code)
                .HasColumnName("code")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Configs).HasColumnName("configs");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(10)
                .HasColumnName("currency_code")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.Deposit).HasColumnName("deposit");
            entity.Property(e => e.DepositPaygate).HasColumnName("deposit_paygate");
            entity.Property(e => e.InputFixed)
                .HasMaxLength(255)
                .HasColumnName("input_fixed")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.InputPercent)
                .HasMaxLength(255)
                .HasColumnName("input_percent")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.MidBank)
                .HasMaxLength(50)
                .HasColumnName("mid_bank")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.OutputFixed)
                .HasMaxLength(255)
                .HasColumnName("output_fixed")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.OutputPercent)
                .HasMaxLength(255)
                .HasColumnName("output_percent")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Paygate1)
                .HasMaxLength(255)
                .HasColumnName("paygate")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Payment).HasColumnName("payment");
            entity.Property(e => e.QrBank)
                .HasMaxLength(50)
                .HasColumnName("qr_bank")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Round)
                .HasDefaultValueSql("'0'")
                .HasColumnName("round");
            entity.Property(e => e.Sort)
                .HasDefaultValueSql("'0'")
                .HasColumnName("sort");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId)
                .HasComment("người quản lý")
                .HasColumnName("user_id");
            entity.Property(e => e.Withdraw).HasColumnName("withdraw");
            entity.Property(e => e.WithdrawField).HasColumnName("withdraw_field");
            entity.Property(e => e.WithdrawPaygate).HasColumnName("withdraw_paygate");
        });

        modelBuilder.Entity<PaygatesLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("paygates_logs")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountName)
                .HasMaxLength(255)
                .HasColumnName("account_name")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.AccountReceiver)
                .HasMaxLength(50)
                .HasColumnName("account_receiver")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.BankCode)
                .HasMaxLength(50)
                .HasColumnName("bank_code")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.CallbackLogs).HasColumnName("callback_logs");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Fees).HasColumnName("fees");
            entity.Property(e => e.NetAmount).HasColumnName("net_amount");
            entity.Property(e => e.OrderCode)
                .HasMaxLength(50)
                .HasColumnName("order_code")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Time)
                .HasMaxLength(50)
                .HasComment("time in interger")
                .HasColumnName("time")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.TransDate)
                .HasColumnType("timestamp")
                .HasColumnName("trans_date");
            entity.Property(e => e.TrialAccountNum14)
                .HasMaxLength(255)
                .HasColumnName("trial_account_num_14")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.TrialCreatedAt22)
                .HasColumnType("timestamp")
                .HasColumnName("trial_created_at_22");
            entity.Property(e => e.TrialCurrencyCode9)
                .HasMaxLength(50)
                .HasColumnName("trial_currency_code_9")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.TrialCurrencyId8).HasColumnName("trial_currency_id_8");
            entity.Property(e => e.TrialIp13)
                .HasMaxLength(50)
                .HasColumnName("trial_ip_13")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.TrialPatientId3).HasColumnName("trial_patient_id_3");
            entity.Property(e => e.TrialPayAmount7).HasColumnName("trial_pay_amount_7");
            entity.Property(e => e.TrialProvider10)
                .HasMaxLength(50)
                .HasColumnName("trial_provider_10")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.TrialStatus17)
                .HasMaxLength(50)
                .HasColumnName("trial_status_17")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.TrialTransId20)
                .HasMaxLength(255)
                .HasColumnName("trial_trans_id_20")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("permissions")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.Name, "name");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(255)
                .HasColumnName("code")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .HasColumnName("description")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Menu).HasColumnName("menu");
            entity.Property(e => e.Name)
                .HasColumnName("name")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<PrescriptionCeiling>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("prescription_ceiling", tb => tb.HasComment("Quản lý trần đơn thuốc"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CeilingTotalExpenditure)
                .HasMaxLength(45)
                .HasComment("Trần tổng chi(Nếu nhập trần BHYT và trần tổng chi <= 100 hiểu là %, > 100 hiểu là số tiền)")
                .HasColumnName("ceiling_total_expenditure");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DiagnosticCode)
                .HasMaxLength(255)
                .HasComment("ICD10")
                .HasColumnName("diagnostic_code");
            entity.Property(e => e.HealthInsuranceCeiling)
                .HasMaxLength(255)
                .HasComment("Trần BHYT(Nếu nhập trần BHYT và trần tổng chi <= 100 hiểu là %, > 100 hiểu là số tiền)")
                .HasColumnName("health_insurance_ceiling");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<PrescriptionOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("prescription_order", tb => tb.HasComment("Chỉ định thuốc, vật tư"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.PriDiagnosticId, "FK_prescription_order_catalog_diagnostic");

            entity.HasIndex(e => e.AccomDiagnosticId, "FK_prescription_order_catalog_diagnostic_2");

            entity.HasIndex(e => e.ExaminationId, "FK_prescription_order_examination");

            entity.HasIndex(e => e.StockId, "FK_prescription_order_product_stocks");

            entity.HasIndex(e => e.Barcode, "barcode").IsUnique();

            entity.Property(e => e.AccomDiagnosticId)
                .HasComment("Chuẩn đoán kèm theo")
                .HasColumnName("accom_diagnostic_id");
            entity.Property(e => e.AppointmentUserId)
                .HasComment("Người chỉ định")
                .HasColumnName("appointment_user_id");
            entity.Property(e => e.Barcode)
                .HasMaxLength(50)
                .HasColumnName("barcode");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.ExaminationId).HasColumnName("examination_id");
            entity.Property(e => e.OrderDate)
                .HasComment("Ngày y lệnh")
                .HasColumnType("datetime")
                .HasColumnName("order_date");
            entity.Property(e => e.PriDiagnosticId)
                .HasComment("Chuẩn đoán")
                .HasColumnName("pri_diagnostic_id");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.StockId).HasColumnName("stock_id");
            entity.Property(e => e.TicketId).HasColumnName("ticket_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.AccomDiagnostic).WithMany(p => p.PrescriptionOrderAccomDiagnostics)
                .HasForeignKey(d => d.AccomDiagnosticId)
                .HasConstraintName("FK_prescription_order_catalog_diagnostic_2");

            entity.HasOne(d => d.Examination).WithMany(p => p.PrescriptionOrders)
                .HasForeignKey(d => d.ExaminationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_prescription_order_examination");

            entity.HasOne(d => d.PriDiagnostic).WithMany(p => p.PrescriptionOrderPriDiagnostics)
                .HasForeignKey(d => d.PriDiagnosticId)
                .HasConstraintName("FK_prescription_order_catalog_diagnostic");

            entity.HasOne(d => d.Stock).WithMany(p => p.PrescriptionOrders)
                .HasForeignKey(d => d.StockId)
                .HasConstraintName("FK_prescription_order_product_stocks");
        });

        modelBuilder.Entity<PrescriptionOrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("prescription_order_item", tb => tb.HasComment("Chi tiết thuốc, vật tư chỉ định."))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.PrescriptionOrderId, "FK__prescription_order");

            entity.HasIndex(e => e.ProductId, "FK__products");

            entity.Property(e => e.Advice)
                .HasMaxLength(500)
                .HasComment("Lời khuyên")
                .HasColumnName("advice");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.PrescriptionOrderId).HasColumnName("prescription_order_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity)
                .HasComment("Số lượng")
                .HasColumnName("quantity");
            entity.Property(e => e.Unit)
                .HasMaxLength(50)
                .HasComment("Đơn vị")
                .HasColumnName("unit");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserManual)
                .HasMaxLength(500)
                .HasComment("Hướng dẫn sử dụng")
                .HasColumnName("user_manual");

            entity.HasOne(d => d.PrescriptionOrder).WithMany(p => p.PrescriptionOrderItems)
                .HasForeignKey(d => d.PrescriptionOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__prescription_order");

            entity.HasOne(d => d.Product).WithMany(p => p.PrescriptionOrderItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__products");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("products")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.CatId, "FK_product_product_cats");

            entity.HasIndex(e => e.Barcode, "barcode").IsUnique();

            entity.HasIndex(e => e.Sku, "sku").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Antibiotic)
                .HasDefaultValueSql("'0'")
                .HasComment("Kháng sinh")
                .HasColumnName("antibiotic");
            entity.Property(e => e.Area)
                .HasMaxLength(50)
                .HasDefaultValueSql("'drug'")
                .HasComment("Loại sp (Thuốc/Vật tư y tế)")
                .HasColumnName("area");
            entity.Property(e => e.Barcode).HasColumnName("barcode");
            entity.Property(e => e.CatId)
                .HasComment("Danh mục")
                .HasColumnName("cat_id");
            entity.Property(e => e.Concentration)
                .HasMaxLength(255)
                .HasComment("nồng độ")
                .HasColumnName("concentration");
            entity.Property(e => e.CountryCode)
                .HasMaxLength(50)
                .HasColumnName("country_code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(50)
                .HasDefaultValueSql("'VND'")
                .HasColumnName("currency_code");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.EasternMed)
                .HasDefaultValueSql("'0'")
                .HasComment("Đông y")
                .HasColumnName("eastern_ med");
            entity.Property(e => e.Featured).HasColumnName("featured");
            entity.Property(e => e.FunctionalFood)
                .HasDefaultValueSql("'0'")
                .HasComment("Thực phẩm chức năng")
                .HasColumnName("functional_food");
            entity.Property(e => e.GroupId)
                .HasMaxLength(255)
                .HasComment("Array")
                .HasColumnName("group_id");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .HasColumnName("image");
            entity.Property(e => e.IsPrivate)
                .HasDefaultValueSql("'0'")
                .HasComment("Chỉ dành cho cơ sở bán trực tiếp")
                .HasColumnName("is_private");
            entity.Property(e => e.Manufacturer).HasColumnName("manufacturer");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.NameIns)
                .HasMaxLength(255)
                .HasColumnName("name_ins");
            entity.Property(e => e.Packing)
                .HasMaxLength(255)
                .HasComment("quy cach")
                .HasColumnName("packing");
            entity.Property(e => e.Price)
                .HasPrecision(20, 6)
                .HasComment("Giá bán thường")
                .HasColumnName("price");
            entity.Property(e => e.PriceInput)
                .HasPrecision(20, 6)
                .HasComment("Giá nhập")
                .HasColumnName("price_input");
            entity.Property(e => e.PriceIns)
                .HasPrecision(20, 6)
                .HasComment("Giá discout, giá bhyt")
                .HasColumnName("price_ins");
            entity.Property(e => e.PriceRequest)
                .HasPrecision(20, 6)
                .HasComment("Giá yêu cầu")
                .HasColumnName("price_request");
            entity.Property(e => e.Sku).HasColumnName("sku");
            entity.Property(e => e.Sort).HasColumnName("sort");
            entity.Property(e => e.Specifications)
                .HasComment("Các thông số kỹ thuật")
                .HasColumnType("text")
                .HasColumnName("specifications");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasDefaultValueSql("'onetime'")
                .HasComment("Loại tiêu hao và ko tiêu hao")
                .HasColumnName("type");
            entity.Property(e => e.Unit)
                .HasMaxLength(50)
                .HasColumnName("unit");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.Usage)
                .HasMaxLength(255)
                .HasComment("cách sử dụng")
                .HasColumnName("usage");
            entity.Property(e => e.UsageIns)
                .HasComment("mã đường dùng BHYT")
                .HasColumnName("usage_ins");
            entity.Property(e => e.Volume)
                .HasMaxLength(255)
                .HasComment("thể tích")
                .HasColumnName("volume");

            entity.HasOne(d => d.Cat).WithMany(p => p.Products)
                .HasForeignKey(d => d.CatId)
                .HasConstraintName("FK_product_product_cats");
        });

        modelBuilder.Entity<ProductBid>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("product_bids", tb => tb.HasComment("Gói thầu"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.ProductId, "FK_product_bids_product");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BidDate).HasColumnName("bid_date");
            entity.Property(e => e.BidGroup)
                .HasMaxLength(255)
                .HasColumnName("bid_group");
            entity.Property(e => e.BidNumber)
                .HasMaxLength(255)
                .HasColumnName("bid_number");
            entity.Property(e => e.BidPackage)
                .HasMaxLength(255)
                .HasColumnName("bid_package");
            entity.Property(e => e.BidYear)
                .HasMaxLength(255)
                .HasColumnName("bid_year");
            entity.Property(e => e.Code)
                .HasMaxLength(255)
                .HasColumnName("code");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.CreatorId)
                .HasMaxLength(255)
                .HasColumnName("creator_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.UpdaterId)
                .HasMaxLength(255)
                .HasColumnName("updater_id");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductBids)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_product_bids_product");
        });

        modelBuilder.Entity<ProductBidItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("product_bid_items")
                .UseCollation("utf8_unicode_ci");

            entity.HasIndex(e => e.BidId, "FK_product_bid_items_product_bids");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BidId).HasColumnName("bid_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Price)
                .HasPrecision(11)
                .HasColumnName("price");
            entity.Property(e => e.PriceIns)
                .HasPrecision(10)
                .HasColumnName("price_ins");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Unit)
                .HasMaxLength(255)
                .HasColumnName("unit");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.Vat)
                .HasPrecision(10)
                .HasColumnName("vat");

            entity.HasOne(d => d.Bid).WithMany(p => p.ProductBidItems)
                .HasForeignKey(d => d.BidId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_product_bid_items_product_bids");
        });

        modelBuilder.Entity<ProductCat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("product_cats")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.Slug, "slug").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Area)
                .HasMaxLength(50)
                .HasColumnName("area");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .HasColumnName("image");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Slug).HasColumnName("slug");
            entity.Property(e => e.Sort)
                .HasDefaultValueSql("'0'")
                .HasColumnName("sort");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<ProductInventory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("product_inventories")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.ProductId, "FK_product_inventories_product");

            entity.HasIndex(e => e.StockId, "FK_product_inventories_product_stocks");

            entity.HasIndex(e => e.Barcode, "barcode");

            entity.HasIndex(e => new { e.Barcode, e.PackageCode }, "barcode_package_code").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Barcode).HasColumnName("barcode");
            entity.Property(e => e.BidId).HasColumnName("bid_id");
            entity.Property(e => e.CertificateCode)
                .HasMaxLength(255)
                .HasComment("Mã chứng nhận")
                .HasColumnName("certificate_code");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.CreatorId)
                .HasMaxLength(255)
                .HasColumnName("creator_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.ExpirationDate)
                .HasColumnType("datetime")
                .HasColumnName("expiration_date");
            entity.Property(e => e.LockedQty)
                .HasDefaultValueSql("'0'")
                .HasColumnName("locked_qty");
            entity.Property(e => e.PackageCode)
                .HasComment("Mã lô")
                .HasColumnName("package_code");
            entity.Property(e => e.Position)
                .HasMaxLength(255)
                .HasComment("Vùng/ chỗ để")
                .HasColumnName("position");
            entity.Property(e => e.ProductId)
                .HasComment("san pham")
                .HasColumnName("product_id");
            entity.Property(e => e.ProductionDate)
                .HasColumnType("datetime")
                .HasColumnName("production_date");
            entity.Property(e => e.Qty).HasColumnName("qty");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.StockId)
                .HasComment("Kho")
                .HasColumnName("stock_id");
            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.UpdaterId)
                .HasMaxLength(255)
                .HasColumnName("updater_id");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductInventories)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_product_inventories_product");

            entity.HasOne(d => d.Stock).WithMany(p => p.ProductInventories)
                .HasForeignKey(d => d.StockId)
                .HasConstraintName("FK_product_inventories_product_stocks");
        });

        modelBuilder.Entity<ProductStock>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("product_stocks")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.Code, "code").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.OwnerId)
                .HasMaxLength(255)
                .HasComment("các thủ quỹ")
                .HasColumnName("owner_id");
            entity.Property(e => e.PaymentRequire)
                .HasDefaultValueSql("'1'")
                .HasComment("co thanh toan ko")
                .HasColumnName("payment_require");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .HasColumnName("phone");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Type)
                .HasComment("Loại kho (Nội trú, ngoại trú)")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
        });

        modelBuilder.Entity<ProductStockOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("product_stock_orders", tb => tb.HasComment("Phiếu xuất nhập kho"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.Code, "code").IsUnique();

            entity.HasIndex(e => e.TargetStockId, "storehouse_from_id");

            entity.HasIndex(e => e.StockId, "storehouse_id");

            entity.HasIndex(e => e.SupplierId, "supplier_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApproveDate)
                .HasComment("thời gian duyệt")
                .HasColumnName("approve_date");
            entity.Property(e => e.ApproveId).HasColumnName("approve_id");
            entity.Property(e => e.Barcode)
                .HasMaxLength(255)
                .HasColumnName("barcode");
            entity.Property(e => e.BatchCode)
                .HasMaxLength(255)
                .HasColumnName("batch_code");
            entity.Property(e => e.BidDate)
                .HasComment("ngay trung thau")
                .HasColumnName("bid_date");
            entity.Property(e => e.BidGroup)
                .HasMaxLength(255)
                .HasComment("nhom thau")
                .HasColumnName("bid_group");
            entity.Property(e => e.BidId).HasColumnName("bid_id");
            entity.Property(e => e.BidNumber)
                .HasMaxLength(255)
                .HasComment("so qd trung thau")
                .HasColumnName("bid_number");
            entity.Property(e => e.BidPackage)
                .HasMaxLength(255)
                .HasComment("goi thau")
                .HasColumnName("bid_package");
            entity.Property(e => e.BidYear)
                .HasMaxLength(255)
                .HasComment("nam thau")
                .HasColumnName("bid_year");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasComment("Mã phiếu")
                .HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasComment("thoi gian tao ban ghi")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatorId)
                .HasComment("nguoi tao")
                .HasColumnName("creator_id");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(50)
                .HasColumnName("currency_code");
            entity.Property(e => e.CustomerId)
                .HasComment("id benh nhan")
                .HasColumnName("customer_id");
            entity.Property(e => e.CustomerType)
                .HasMaxLength(50)
                .HasComment("Đối tượng thanh toán")
                .HasColumnName("customer_type");
            entity.Property(e => e.Deliver)
                .HasMaxLength(255)
                .HasComment("Người giao")
                .HasColumnName("deliver");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.ExportDate)
                .HasComment("thơi gian xuat kho")
                .HasColumnName("export_date");
            entity.Property(e => e.Group)
                .HasMaxLength(50)
                .HasComment("Tách nhóm")
                .HasColumnName("group");
            entity.Property(e => e.ImportDate)
                .HasComment("thoi gian nhap kho")
                .HasColumnName("import_date");
            entity.Property(e => e.Note)
                .HasComment("ghi chu")
                .HasColumnType("text")
                .HasColumnName("note");
            entity.Property(e => e.OrderDate)
                .HasComment("Ngày hóa đơn")
                .HasColumnName("order_date");
            entity.Property(e => e.PackageCode)
                .HasMaxLength(255)
                .HasColumnName("package_code");
            entity.Property(e => e.PayAmount)
                .HasPrecision(20, 6)
                .HasComment("Số còn lại phải thanh toán")
                .HasColumnName("pay_amount");
            entity.Property(e => e.PaygateId)
                .HasComment("Tk nhận tiền")
                .HasColumnName("paygate_id");
            entity.Property(e => e.Price)
                .HasPrecision(20, 6)
                .HasComment("Giá dịch vụ")
                .HasColumnName("price");
            entity.Property(e => e.Reason)
                .HasComment("ly do")
                .HasColumnType("text")
                .HasColumnName("reason");
            entity.Property(e => e.Receiver)
                .HasMaxLength(255)
                .HasComment("Người nhận")
                .HasColumnName("receiver");
            entity.Property(e => e.RequirePayment)
                .HasDefaultValueSql("'1'")
                .HasComment("Yêu cầu phải thanh toán")
                .HasColumnName("require_payment");
            entity.Property(e => e.RoomId)
                .HasComment("id khoa/ phong")
                .HasColumnName("room_id");
            entity.Property(e => e.Status)
                .HasComment("trang thai ban ghi")
                .HasColumnName("status");
            entity.Property(e => e.StockId)
                .HasComment("id kho lấy hàng")
                .HasColumnName("stock_id");
            entity.Property(e => e.SupplierId)
                .HasComment("id nha cc")
                .HasColumnName("supplier_id");
            entity.Property(e => e.TargetStockId)
                .HasComment("id kho nhận hàng")
                .HasColumnName("target_stock_id");
            entity.Property(e => e.TaxAmount)
                .HasPrecision(20, 6)
                .HasColumnName("tax_amount");
            entity.Property(e => e.TaxRate)
                .HasPrecision(20, 6)
                .HasComment("%")
                .HasColumnName("tax_rate");
            entity.Property(e => e.Type)
                .HasComment("Loại phiếu (import/export/transfer/return)")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasComment("thoi tian cap nhat ban ghi")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdaterId)
                .HasMaxLength(255)
                .HasComment("nguoi cap nhat")
                .HasColumnName("updater_id");
        });

        modelBuilder.Entity<ProductStockOrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("product_stock_order_items", tb => tb.HasComment("Phiếu xuất nhập kho"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.StockOrderId, "FK_product_stock_order_items_product_stock_orders");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApproveDate)
                .HasComment("thời gian duyệt")
                .HasColumnName("approve_date");
            entity.Property(e => e.ApproveId).HasColumnName("approve_id");
            entity.Property(e => e.ApproveQty)
                .HasDefaultValueSql("'1'")
                .HasComment("Số lượng duyệt")
                .HasColumnName("approve_qty");
            entity.Property(e => e.Barcode)
                .HasMaxLength(255)
                .HasColumnName("barcode");
            entity.Property(e => e.BatchCode)
                .HasMaxLength(255)
                .HasColumnName("batch_code");
            entity.Property(e => e.CreatedAt)
                .HasComment("thoi gian tao ban ghi")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatorId)
                .HasComment("nguoi tao")
                .HasColumnName("creator_id");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(50)
                .HasColumnName("currency_code");
            entity.Property(e => e.ExpirationDate)
                .HasColumnType("datetime")
                .HasColumnName("expiration_date");
            entity.Property(e => e.Price)
                .HasPrecision(20, 6)
                .HasComment("Giá dịch vụ")
                .HasColumnName("price");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.ProductionDate)
                .HasColumnType("datetime")
                .HasColumnName("production_date");
            entity.Property(e => e.Qty)
                .HasDefaultValueSql("'1'")
                .HasColumnName("qty");
            entity.Property(e => e.StockOrderId)
                .HasComment("Order cha")
                .HasColumnName("stock_order_id");
            entity.Property(e => e.TaxAmount)
                .HasPrecision(20, 6)
                .HasColumnName("tax_amount");
            entity.Property(e => e.TaxRate)
                .HasPrecision(20, 6)
                .HasComment("%")
                .HasColumnName("tax_rate");
            entity.Property(e => e.Unit)
                .HasMaxLength(255)
                .HasColumnName("unit");
            entity.Property(e => e.UpdatedAt)
                .HasComment("thoi tian cap nhat ban ghi")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.StockOrder).WithMany(p => p.ProductStockOrderItems)
                .HasForeignKey(d => d.StockOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_product_stock_order_items_product_stock_orders");
        });

        modelBuilder.Entity<ProductSupplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("product_supplier")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.Code, "code").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.ContactEmail)
                .HasMaxLength(255)
                .HasColumnName("contact_email");
            entity.Property(e => e.ContactPhone)
                .HasMaxLength(255)
                .HasColumnName("contact_phone");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
        });

        modelBuilder.Entity<ProductUnit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("product_units", tb => tb.HasComment("Đơn vị "))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.Key, "key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Default)
                .HasDefaultValueSql("'0'")
                .HasColumnName("default");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Key)
                .HasMaxLength(50)
                .HasColumnName("key");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("reports", tb => tb.HasComment("Báo cáo"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.Code, "code").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.FieldXml)
                .HasMaxLength(255)
                .HasColumnName("field_xml");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.ParentId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("parent_id");
            entity.Property(e => e.QuerySql)
                .HasMaxLength(4000)
                .HasColumnName("query_sql");
            entity.Property(e => e.RoomTypeId)
                .HasComment("Phòng khám")
                .HasColumnName("room_type_id");
            entity.Property(e => e.Sort)
                .HasDefaultValueSql("'0'")
                .HasColumnName("sort");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");
            entity.Property(e => e.StoreName)
                .HasMaxLength(255)
                .HasColumnName("store_name");
            entity.Property(e => e.TemplateName)
                .HasMaxLength(50)
                .HasColumnName("template_name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<RocheDatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("roche_data", tb => tb.HasComment("Luu thong tin file lis tu may"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Direction)
                .HasMaxLength(50)
                .HasColumnName("direction");
            entity.Property(e => e.FileData).HasColumnName("file_data");
            entity.Property(e => e.FileName)
                .HasMaxLength(255)
                .HasColumnName("file_name");
            entity.Property(e => e.FilePath)
                .HasMaxLength(255)
                .HasColumnName("file_path");
            entity.Property(e => e.TicketId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("ticket_id");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("roles", tb => tb.HasComment("Role người dùng"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.Name, "name1");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("time")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.GuardName)
                .HasMaxLength(191)
                .HasColumnName("guard_name")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Name)
                .HasMaxLength(191)
                .HasColumnName("name")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("time")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<RolePermission>(entity =>
        {
            entity.HasKey(e => new { e.PermissionId, e.TroleId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity
                .ToTable("role_permissions")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.PermissionId).HasColumnName("permission_id");
            entity.Property(e => e.TroleId).HasColumnName("trole_id");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("rooms", tb => tb.HasComment("Phòng"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.Code, "code").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AcceptInsurance)
                .HasDefaultValueSql("'1'")
                .HasColumnName("accept_insurance");
            entity.Property(e => e.AllowUsers)
                .HasComment("Cho phép user nhìn thấy")
                .HasColumnType("text")
                .HasColumnName("allow_users");
            entity.Property(e => e.BigClinic)
                .HasDefaultValueSql("'0'")
                .HasColumnName("big_clinic");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.HospitalId).HasColumnName("hospital_id");
            entity.Property(e => e.LocationId).HasColumnName("location_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.NameArray)
                .HasMaxLength(255)
                .HasColumnName("name_array");
            entity.Property(e => e.Polyclinic)
                .HasDefaultValueSql("'0'")
                .HasColumnName("polyclinic");
            entity.Property(e => e.RisDevice)
                .HasMaxLength(255)
                .HasComment("Máy thực hiện CDHA")
                .HasColumnName("ris_device");
            entity.Property(e => e.RoomNumber)
                .HasMaxLength(45)
                .HasComment("Số phòng")
                .HasColumnName("room_number");
            entity.Property(e => e.RoomType).HasColumnName("room_type");
            entity.Property(e => e.Sort)
                .HasDefaultValueSql("'1'")
                .HasColumnName("sort");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");
            entity.Property(e => e.TitlePrintName)
                .HasMaxLength(255)
                .HasComment("Tên phiếu in")
                .HasColumnName("title_print_name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<RoomNumber>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("room_numbers")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.Number, "number");

            entity.HasIndex(e => e.RoomId, "room_id");

            entity.HasIndex(e => e.RoomTypeId, "room_type_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AllowUsers)
                .HasColumnType("mediumtext")
                .HasColumnName("allow_users");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .HasColumnName("note");
            entity.Property(e => e.Number)
                .HasMaxLength(50)
                .HasColumnName("number");
            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.RoomTypeCode)
                .HasMaxLength(255)
                .HasColumnName("room_type_code");
            entity.Property(e => e.RoomTypeId).HasColumnName("room_type_id");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<RoomStaff>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("room_staffs", tb => tb.HasComment("Danh sách bác sỹ và nhân viên phục vụ"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CheckinAt)
                .HasColumnType("timestamp")
                .HasColumnName("checkin_at");
            entity.Property(e => e.CheckoutAt)
                .HasColumnType("timestamp")
                .HasColumnName("checkout_at");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.JobType)
                .HasMaxLength(50)
                .HasColumnName("job_type");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValueSql("'working'")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId)
                .HasComment("bác sỹ hoặc nhân viên")
                .HasColumnName("user_id");
        });

        modelBuilder.Entity<RoomType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("room_types", tb => tb.HasComment("Loại phòng"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.Code, "code").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasComment("slug")
                .HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.NameArray)
                .HasMaxLength(255)
                .HasColumnName("name_array");
            entity.Property(e => e.Sort).HasColumnName("sort");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Route>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("routes")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.Code, "code");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasColumnType("text")
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<SampleDevice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("sample_device")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.Status)
                .HasColumnType("bit(1)")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<SendmailDriver>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("sendmail_driver")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.Driver, "driver").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Configs).HasColumnName("configs");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Driver)
                .HasMaxLength(50)
                .HasColumnName("driver")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Nstalled).HasColumnName("nstalled");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<SendmailSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("sendmail_setting")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Driver)
                .HasMaxLength(50)
                .HasColumnName("driver")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.FromEmail)
                .HasMaxLength(50)
                .HasColumnName("from_email")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.FromName)
                .HasMaxLength(50)
                .HasColumnName("from_name")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("services", tb => tb.HasComment("Dịch vụ"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.Code, "code").IsUnique();

            entity.HasIndex(e => e.ServiceGroupId, "service_group_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.CodeIns)
                .HasMaxLength(255)
                .HasComment("Code theo  bảo hiểm y tế")
                .HasColumnName("code_ins");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.EquivalentCode)
                .HasMaxLength(255)
                .HasComment("Mã tương đương(Mã do BHYT quy định)")
                .HasColumnName("equivalent_code");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.NameIns)
                .HasMaxLength(255)
                .HasComment("Tên theo bảo hiểm y tế")
                .HasColumnName("name_ins");
            entity.Property(e => e.OfflineRate)
                .HasComment("Tỉ lệ trái tuyến")
                .HasColumnName("offline_rate");
            entity.Property(e => e.OriginalResult)
                .HasMaxLength(255)
                .HasComment("Gia tri binh thuong")
                .HasColumnName("original_result");
            entity.Property(e => e.ParentId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("parent_id");
            entity.Property(e => e.PriceIns)
                .HasComment("Gia BHYT")
                .HasColumnName("price_ins");
            entity.Property(e => e.PriceNormal)
                .HasComment("Gia BV")
                .HasColumnName("price_normal");
            entity.Property(e => e.PriceService)
                .HasComment("Gia DV")
                .HasColumnName("price_service");
            entity.Property(e => e.ReassignmentTime)
                .HasComment("Thời gian tái chỉ định: Theo TT35 thì 1 số DV chỉ được phép chỉ định sau x ngày (VD: HbA1C sau 90 ngày)")
                .HasColumnName("reassignment_time");
            entity.Property(e => e.RightRate)
                .HasComment("Tỉ lệ đúng tuyến")
                .HasColumnName("right_rate");
            entity.Property(e => e.RoomHandleId)
                .HasMaxLength(50)
                .HasComment("Phong xu ly/ thuc hien")
                .HasColumnName("room_handle_id");
            entity.Property(e => e.RoomId)
                .HasMaxLength(255)
                .HasComment("Phòng khám")
                .HasColumnName("room_id")
                .UseCollation("utf8mb4_unicode_ci");
            entity.Property(e => e.RoomSampleId)
                .HasMaxLength(50)
                .HasComment("Phòng lấy mẫu")
                .HasColumnName("room_sample_id");
            entity.Property(e => e.ServiceGroupId).HasColumnName("service_group_id");
            entity.Property(e => e.ServiceTypeId)
                .HasComment("Loai dich vu")
                .HasColumnName("service_type_id");
            entity.Property(e => e.Sort)
                .HasDefaultValueSql("'0'")
                .HasColumnName("sort");
            entity.Property(e => e.SpecialtyCode)
                .HasMaxLength(255)
                .HasComment("Mã chuyên khoa(theo QĐ BYT BN khám nhiều chuyên khoa mà các chuyên khoa giống nhau thì không thu thêm tiền công khám, khác chuyên khoa thì thu thêm 30% nhưng không vượt quá tổng 2 lần khám)")
                .HasColumnName("specialty_code");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");
            entity.Property(e => e.Unit)
                .HasMaxLength(50)
                .HasColumnName("unit");
            entity.Property(e => e.UnitId).HasColumnName("unit_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<ServiceCodeMapping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("service_code_mapping", tb => tb.HasComment("Mapping giữa service code và machine code"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.MachineTestCode, "machine_test_code");

            entity.HasIndex(e => e.ServiceCode, "service_code");

            entity.HasIndex(e => new { e.ServiceCode, e.MachineTestCode, e.MachineCode }, "service_code_machine_test_code_machine_code").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MachineCode).HasColumnName("machine_code");
            entity.Property(e => e.MachineTestCode).HasColumnName("machine_test_code");
            entity.Property(e => e.ServiceCode).HasColumnName("service_code");
        });

        modelBuilder.Entity<ServiceGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("service_groups", tb => tb.HasComment("Nhóm dịch vụ- fix khong dc thay doi"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.Code, "code");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasComment("tach phieu")
                .HasColumnName("code");
            entity.Property(e => e.CodeName)
                .HasMaxLength(255)
                .HasComment("tach phieu")
                .HasColumnName("code_name");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Sort)
                .HasDefaultValueSql("'0'")
                .HasColumnName("sort");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<ServiceType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("service_types", tb => tb.HasComment("Loại dịch vụ"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(255)
                .HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.NameArray)
                .HasMaxLength(255)
                .HasColumnName("name_array");
            entity.Property(e => e.ServiceGroupId).HasColumnName("service_group_id");
            entity.Property(e => e.Sort)
                .HasDefaultValueSql("'0'")
                .HasColumnName("sort");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<ServicesItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("services_items", tb => tb.HasComment("Dịch vụ"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.ServiceId, "FK_services_items_services");

            entity.HasIndex(e => e.Code, "code").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.CodeIns)
                .HasMaxLength(255)
                .HasComment("Code theo  bảo hiểm y tế")
                .HasColumnName("code_ins");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.NameIns)
                .HasMaxLength(255)
                .HasComment("Tên theo bảo hiểm y tế")
                .HasColumnName("name_ins");
            entity.Property(e => e.OriginalResult)
                .HasMaxLength(255)
                .HasComment("Gia tri binh thuong")
                .HasColumnName("original_result");
            entity.Property(e => e.RoomHandleId)
                .HasMaxLength(50)
                .HasComment("Phong xu ly/ thuc hien")
                .HasColumnName("room_handle_id");
            entity.Property(e => e.RoomId)
                .HasMaxLength(255)
                .HasColumnName("room_id");
            entity.Property(e => e.RoomSampleId)
                .HasMaxLength(50)
                .HasComment("Phòng lấy mẫu")
                .HasColumnName("room_sample_id");
            entity.Property(e => e.ServiceId)
                .HasComment("Chi vuj cha")
                .HasColumnName("service_id");
            entity.Property(e => e.Sort)
                .HasDefaultValueSql("'0'")
                .HasColumnName("sort");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");
            entity.Property(e => e.Unit)
                .HasMaxLength(50)
                .HasColumnName("unit");
            entity.Property(e => e.UnitId).HasColumnName("unit_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Service).WithMany(p => p.ServicesItems)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_services_items_services");
        });

        modelBuilder.Entity<Setting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("settings")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.Key, "key3").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Key)
                .HasMaxLength(250)
                .HasColumnName("key")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.Value).HasColumnName("value");
            entity.Property(e => e.ValueArr).HasColumnName("value_arr");
        });

        modelBuilder.Entity<SmsLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("sms_logs")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.Phone, "phone");

            entity.HasIndex(e => e.Provider, "provider1");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cost).HasColumnName("cost");
            entity.Property(e => e.CountryCode)
                .HasMaxLength(255)
                .HasColumnName("country_code")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Message)
                .HasMaxLength(255)
                .HasColumnName("message")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.OrderCode)
                .HasMaxLength(50)
                .HasColumnName("order_code")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Provider)
                .HasMaxLength(50)
                .HasColumnName("provider")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.ProviderResponse).HasColumnName("provider_response");
            entity.Property(e => e.ProviderSendId)
                .HasMaxLength(100)
                .HasColumnName("provider_send_id")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<SmsProvider>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("sms_provider")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.Provider, "provider").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Balance)
                .HasMaxLength(50)
                .HasColumnName("balance")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Brandname)
                .HasMaxLength(50)
                .HasColumnName("brandname")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Configs).HasColumnName("configs");
            entity.Property(e => e.Installed).HasColumnName("installed");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasDefaultValueSql("'0'")
                .HasColumnName("name")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Provider)
                .HasMaxLength(50)
                .HasDefaultValueSql("'0'")
                .HasColumnName("provider")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<StorehouseInven>(entity =>
        {
            entity.HasKey(e => e.InvenId).HasName("PRIMARY");

            entity
                .ToTable("storehouse_inven")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => new { e.StorehouseId, e.ProductId, e.PriceInput, e.Price, e.PriceIns, e.PriceFee, e.PriceHospital, e.PriceRequest, e.BatchNumber, e.Vat, e.BidNumber, e.BidGroup, e.BidPackage, e.BidYear, e.ExpirationDateFe, e.ProductionDate }, "groupUniqueInven").IsUnique();

            entity.Property(e => e.InvenId).HasColumnName("inven_id");
            entity.Property(e => e.BatchNumber)
                .HasMaxLength(100)
                .HasColumnName("batch_number");
            entity.Property(e => e.BidGroup)
                .HasMaxLength(100)
                .HasColumnName("bid_group");
            entity.Property(e => e.BidNumber)
                .HasMaxLength(100)
                .HasColumnName("bid_number");
            entity.Property(e => e.BidPackage)
                .HasMaxLength(100)
                .HasColumnName("bid_package");
            entity.Property(e => e.BidYear)
                .HasMaxLength(100)
                .HasColumnName("bid_year");
            entity.Property(e => e.CreatedDate).HasColumnName("created_date");
            entity.Property(e => e.ExpirationDate).HasColumnName("expiration_date");
            entity.Property(e => e.ExpirationDateFe)
                .HasMaxLength(100)
                .HasColumnName("expiration_date_fe");
            entity.Property(e => e.OrderDetailId).HasColumnName("order_detail_id");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.PriceFee).HasColumnName("price_fee");
            entity.Property(e => e.PriceHospital).HasColumnName("price_hospital");
            entity.Property(e => e.PriceInput).HasColumnName("price_input");
            entity.Property(e => e.PriceIns).HasColumnName("price_ins");
            entity.Property(e => e.PriceRequest).HasColumnName("price_request");
            entity.Property(e => e.PriceSelling).HasColumnName("price_selling");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.ProductionDate).HasColumnName("production_date");
            entity.Property(e => e.Qty).HasColumnName("qty");
            entity.Property(e => e.QtyLock).HasColumnName("qty_lock");
            entity.Property(e => e.StorehouseId).HasColumnName("storehouse_id");
            entity.Property(e => e.UpdatedDate).HasColumnName("updated_date");
            entity.Property(e => e.Vat).HasColumnName("vat");
        });

        modelBuilder.Entity<TemplateService>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("template_service")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(255)
                .HasColumnName("code");
            entity.Property(e => e.Content)
                .HasColumnType("text")
                .HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatorId)
                .HasMaxLength(255)
                .HasColumnName("creator_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.ServiceId)
                .HasMaxLength(255)
                .HasColumnName("service_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<TestCode>(entity =>
        {
            entity.HasKey(e => e.TestCode1).HasName("PRIMARY");

            entity
                .ToTable("test_code")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.TestCode1).HasColumnName("test_code");
            entity.Property(e => e.TestName)
                .HasMaxLength(255)
                .HasColumnName("test_name");
        });

        modelBuilder.Entity<Treatment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("treatments", tb => tb.HasComment("Dieu tri"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
        });

        modelBuilder.Entity<TreatmentRegiman>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("treatment_regimen", tb => tb.HasComment("Phác đồ điều trị"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DiagnosticCode)
                .HasMaxLength(255)
                .HasComment("Chọn ICD10\n")
                .HasColumnName("diagnostic_code");
            entity.Property(e => e.DrugIngredient)
                .HasMaxLength(255)
                .HasComment("Hoạt chất")
                .HasColumnName("drug_ingredient");
            entity.Property(e => e.RegimenName)
                .HasMaxLength(255)
                .HasComment("Tên phác đồ")
                .HasColumnName("regimen_name");
            entity.Property(e => e.ServiceId)
                .HasMaxLength(255)
                .HasComment("Dịch vụ kỹ thuật")
                .HasColumnName("service_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("users", tb => tb.HasComment("Người dùng"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.Phone, "phone1").IsUnique();

            entity.HasIndex(e => e.Username, "username").IsUnique();

            entity.HasIndex(e => e.Email, "users_email_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Avatar)
                .HasMaxLength(255)
                .HasColumnName("avatar")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Birthday).HasColumnName("birthday");
            entity.Property(e => e.Certificate)
                .HasMaxLength(255)
                .HasColumnName("certificate")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.CountryCode)
                .HasMaxLength(15)
                .HasColumnName("country_code")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(50)
                .HasColumnName("currency_code")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Email)
                .HasMaxLength(191)
                .HasColumnName("email")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Failed)
                .HasDefaultValueSql("'0'")
                .HasComment("Số lần đăng nhập sai")
                .HasColumnName("failed");
            entity.Property(e => e.FailedReason)
                .HasMaxLength(255)
                .HasColumnName("failed_reason")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Finger)
                .HasMaxLength(255)
                .HasComment("Xác thực ngón tay")
                .HasColumnName("finger")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Gender)
                .HasMaxLength(8)
                .HasColumnName("gender")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.JobTitle).HasColumnName("job_title");
            entity.Property(e => e.Language)
                .HasMaxLength(100)
                .HasColumnName("language")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.LastLoginIp)
                .HasMaxLength(255)
                .HasColumnName("last_login_ip")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Name)
                .HasMaxLength(191)
                .HasColumnName("name")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Password)
                .HasMaxLength(191)
                .HasColumnName("password")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .HasColumnName("phone")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.PractisingCertificate)
                .HasMaxLength(255)
                .HasComment("Chứng chỉ hành nghề")
                .HasColumnName("practising_certificate")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.RememberToken)
                .HasMaxLength(1000)
                .HasColumnName("remember_token")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'0'")
                .HasColumnName("status");
            entity.Property(e => e.Twofactor)
                .HasMaxLength(100)
                .HasColumnName("twofactor")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.TwofactorSecret)
                .HasMaxLength(255)
                .HasColumnName("twofactor_secret")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.VerifyFailReason)
                .HasMaxLength(255)
                .HasColumnName("verify_fail_reason")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
        });

        modelBuilder.Entity<UserCertificate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("user_certificates", tb => tb.HasComment("Chứng chỉ"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("time")
                .HasColumnName("created_at");
            entity.Property(e => e.ExpireDate)
                .HasColumnType("timestamp")
                .HasColumnName("expire_date");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .HasColumnName("image")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.IssueBy)
                .HasMaxLength(255)
                .HasColumnName("issue_by")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.IssueDate)
                .HasColumnType("timestamp")
                .HasColumnName("issue_date");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .HasColumnName("name")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("time")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<UserDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("user_details", tb => tb.HasComment("Chi tiết user"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Children).HasColumnName("children");
            entity.Property(e => e.ChildrenInfo).HasColumnName("children_info");
            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.CountryCode)
                .HasMaxLength(50)
                .HasColumnName("country_code")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.ExpireAt)
                .HasColumnType("timestamp")
                .HasColumnName("expire_at");
            entity.Property(e => e.FatherInfo).HasColumnName("father_info");
            entity.Property(e => e.HusbandWifeInfo).HasColumnName("husband_wife_info");
            entity.Property(e => e.IdNumber)
                .HasMaxLength(255)
                .HasColumnName("id_number")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.JobId).HasColumnName("job_id");
            entity.Property(e => e.Married).HasColumnName("married");
            entity.Property(e => e.MotherInfo).HasColumnName("mother_info");
            entity.Property(e => e.Nationality)
                .HasMaxLength(50)
                .HasColumnName("nationality")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.PartyMember).HasColumnName("party_member");
            entity.Property(e => e.Religion)
                .HasMaxLength(50)
                .HasColumnName("religion")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<UserDevice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("user_devices", tb => tb.HasComment("Thiết bị của user"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.DeviceId, "device_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("time")
                .HasColumnName("created_at");
            entity.Property(e => e.DeviceId)
                .HasColumnName("device_id")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.DeviceName)
                .HasMaxLength(255)
                .HasColumnName("device_name")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Platform)
                .HasMaxLength(255)
                .HasColumnName("platform")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.SessionId)
                .HasMaxLength(50)
                .HasColumnName("session_id")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Token)
                .HasMaxLength(50)
                .HasColumnName("token")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("time")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserAgent)
                .HasMaxLength(255)
                .HasColumnName("user_agent")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Verified)
                .HasDefaultValueSql("'0'")
                .HasColumnName("verified");
            entity.Property(e => e.VerifiedAt)
                .HasColumnType("timestamp")
                .HasColumnName("verified_at");
            entity.Property(e => e.Version)
                .HasMaxLength(255)
                .HasColumnName("version")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("user_roles")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.RoleId, "role_id");

            entity.HasIndex(e => e.UserId, "user_id");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
