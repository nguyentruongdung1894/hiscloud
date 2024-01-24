using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Nencer;
using Nencer.Extensions;
using Nencer.Modules;
using Nencer.Modules.Backend;
using Nencer.Modules.Examination;
using Nencer.Modules.Local;
using Nencer.Modules.ManageService;
using Nencer.Modules.Product;
using Nencer.Modules.Room;
using Nencer.Modules.Service;
using Nencer.Modules.Users;
using Nencer.Modules.Users.Repository;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Configuration;
using System.Globalization;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddLocalization();
builder.Services.Configure<RequestLocalizationOptions>(
    options =>
    {
        var supportedCultures = new List<CultureInfo>
        {
            new CultureInfo("en"),
            new CultureInfo("vi")
        };

        options.DefaultRequestCulture = new RequestCulture(culture: "en", uiCulture: "en");
        options.SupportedCultures = supportedCultures;
        options.SupportedUICultures = supportedCultures;
    });

builder.Services.AddControllers(opt =>
{
    opt.Filters.Add(typeof(CustomExceptionFilter));
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Nencer_HIS", Version = "v1" });
    opt.OperationFilter<AddAcceptLanguageHeaderParameter>();
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    opt.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{ }
        }
    });
});

builder.Services.AddDbContext<NencerDbContext>(opt =>
{
    var connectionString = builder.Configuration.GetConnectionString("Default");
    opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
}); 

// dang ky dich vu
CategoryServiceRegistration.RegisterServices(builder.Services);
UserServiceRegistration.RegisterServices(builder.Services);
LocalServiceRegistration.RegisterServices(builder.Services);
PatientServiceRegistration.RegisterServices(builder.Services);
ManageServiceServiceRegistration.RegisterServices(builder.Services);
RoomServiceRegistration.RegisterServices(builder.Services);
ExaminationServiceRegistration.RegisterServices(builder.Services);
CheckinServiceRegistration.RegisterServices(builder.Services);
ProductServiceRegistration.RegisterServices(builder.Services);
BackendServiceRegistration.RegisterServices(builder.Services);
builder.Services.AddScoped<ICommon, Common>();
// dapper
builder.Services.AddSingleton<DapperContext>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        var secretKey = builder.Configuration["Settings:SecretKey"];
        opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,

            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
            ClockSkew = TimeSpan.Zero
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(opt =>
    {
        opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Nencer_HIS");
    });
}

var localizeOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(localizeOptions.Value);

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
