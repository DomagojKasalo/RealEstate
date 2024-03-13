using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using persistance.Datacontext;
using Microsoft.OpenApi.Models;
using application;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using xtend_platform_persistance;
using domain.Entities.users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using persistance.Mapper.CRM;
using persistance.Mapper.CPM;
using xtend_platform_persistance.Mapper.CPM;
using domain.Entities.email;
using System.Text.Json.Serialization;
using persistance.Mapper;
using Azure.Storage.Blobs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

string azureBlobStorageConnectionString = builder.Configuration.GetConnectionString("AzureBlobStorage");


builder.Services.AddSingleton(new BlobServiceClient(azureBlobStorageConnectionString));


builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthorization();

// Add services to the container.
builder.Services.AddRazorPages();

//builder.Services.AddControllers().AddJsonOptions(x =>
//    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<RoleManager<IdentityRole>, RoleManager<IdentityRole>>();

builder.Logging.AddConsole();

//SeedRoles(builder.Services.BuildServiceProvider());

builder.Services.AddAutoMapper(typeof(User));
builder.Services.AddAutoMapper(typeof(AutoMappingAut));
builder.Services.AddAutoMapper(typeof(AutoMapperCompany));
builder.Services.AddAutoMapper(typeof(AutoMapperCompanyType));
builder.Services.AddAutoMapper(typeof(AutoMapperRealEstateCatalog));
builder.Services.AddAutoMapper(typeof(AutoMapperRealEstateCatalogItem));
builder.Services.AddAutoMapper(typeof(AutoMapperRealEstateCatalogItemStatus));
builder.Services.AddAutoMapper(typeof(AutoMapperRealEstateCatalogItemType));
builder.Services.AddAutoMapper(typeof(AutoMapperRealEstateCatalogType));
builder.Services.AddAutoMapper(typeof(AutoMapperDeploymentStatus));

builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));


builder.Services.AddScoped<UserManager<User>>();
builder.Services.AddScoped<SignInManager<User>>();

// Use Autofac as the service provider factory.
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


builder.Host.ConfigureContainer<ContainerBuilder>(b =>
{
    // Add things to the Autofac ContainerBuilder as needed
    b.RegisterModule<PersistanceModule>();
    b.RegisterModule<AppModule>();
});

// Register the Swagger generator, defining 1 or more Swagger documents
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Seminar",
        Version = "v1",
        Description = "This is a page for testing of API Services!"
    });

    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "JWT Authentication",
        Description = "Enter JWT Bearer token **_only_**",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer", 
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {securityScheme, Array.Empty<string>()}
    });
});

// Configure the services using the AppModule

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Seminar v1");
    });
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", context =>
{
    context.Response.Redirect("/swagger");
    return Task.CompletedTask;
});

app.MapControllers();

app.MapRazorPages();

app.Run();

//static void SeedRoles(IServiceProvider serviceProvider)
//{
//    using var scope = serviceProvider.CreateScope();
//    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

//    string[] roles = { "Admin", "Client", "Basic User" };

//    foreach (var roleName in roles)
//    {
//        if (!roleManager.RoleExistsAsync(roleName).Result)
//        {
//            var role = new IdentityRole(roleName);
//            roleManager.CreateAsync(role).Wait();
//        }
//    }
//}
