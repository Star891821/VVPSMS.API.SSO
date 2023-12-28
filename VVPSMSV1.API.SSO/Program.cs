using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;
using VVPSMSV1.API.SSO.AutoMapper;
using VVPSMSV1.API.SSO.Domain.Models;
using VVPSMSV1.API.SSO.Models.ModelsDto;
using VVPSMSV1.API.SSO.Service.DataManagers;
using VVPSMSV1.API.SSO.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<FormOptions>(o =>
{
    o.ValueLengthLimit = int.MaxValue;
    o.MultipartBodyLengthLimit = int.MaxValue;
    o.MemoryBufferThreshold = int.MaxValue;
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//JWT Tocken region

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});
builder.Services.AddAuthorization();
// Add configuration from appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

// End region

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "JWTToken_Auth_API",
        Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

    options.JsonSerializerOptions.DefaultIgnoreCondition =
        JsonIgnoreCondition.WhenWritingNull;
});
builder.Services.AddDbContext<VvpsmsSsoContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("VVPSMSDBV1"));
    options.EnableSensitiveDataLogging();

});
builder.Services.AddTransient<IStorageService, StorageService>();
builder.Services.AddTransient<IGoogleSSOService<GoogleConfigurationDto>, GoogleSSOService>();
builder.Services.AddTransient<IMicroSoftSSOService<MicroSoftConfigurationDto>, MicroSoftSSOService>();
builder.Services.AddTransient<IAzureSSOService<AzureBlobConfigurationDto>, AzureSSOService>();
//builder.Services.AddScoped<ITeacherUnitOfWork, TeacherUnitOfWork>();
//builder.Services.AddScoped<IParentUnitOfWork, ParentUnitOfWork>();
builder.Services.AddTransient<IGenericService<MstUserRoleDto>, MstUserRoleService>();
builder.Services.AddTransient<IUserPermissionService<MstPermissionDto>,MstPermissionService>();
builder.Services.AddTransient<IUserService<MstUserDto>, UserService>();
builder.Services.AddTransient<IApplicantService<ApplicantDto>, ApplicantService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.Configure<ApiBehaviorOptions>(options
      => options.SuppressModelStateInvalidFilter = true);
var mappingConfiguration = new MapperConfiguration(config => config.AddProfile(new AutoMapperProfile()));
IMapper mapper = mappingConfiguration.CreateMapper();
builder.Services.AddSingleton(mapper);
var devCorsPolicy = "devCorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(devCorsPolicy, builder =>
    {
        //builder.WithOrigins("http://localhost:4200",
        //    "https://localhost:4200", 
        //    "http://projects.sustainedgeconsulting.com/VVPSMS/V0/VVPSMSUI/", 
        //    "https://projects.sustainedgeconsulting.com/VVPSMS/V0/VVPSMSUI/").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        builder.WithOrigins("*").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost");
        //builder.SetIsOriginAllowed(origin => true);
    });
});
var prodCorsPolicy = "prodCorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(devCorsPolicy, builder =>
    {
        //builder.WithOrigins("http://localhost:4200",
        //    "https://localhost:4200", 
        //    "http://projects.sustainedgeconsulting.com/VVPSMS/V0/VVPSMSUI/", 
        //    "https://projects.sustainedgeconsulting.com/VVPSMS/V0/VVPSMSUI/").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        builder.WithOrigins("*").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost");
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

    app.UseSwagger();
    app.UseSwaggerUI();
}
else if (app.Environment.IsProduction())
{
    app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
    // app.UseCors(prodCorsPolicy);
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
IConfiguration configuration = app.Configuration;
IWebHostEnvironment environment = app.Environment;

app.MapControllers();

app.Run();
