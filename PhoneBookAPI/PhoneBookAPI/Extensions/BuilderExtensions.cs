using System.Reflection;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Persistence;
using Persistence.Repositories;
using Services;
using Services.Abstracts;

namespace PhoneBookAPI.Extensions;

public static class BuilderExtensions
{
    public static WebApplication ConfigureBuilder(this WebApplicationBuilder builder)
    {
        builder.RegisterSwaggerConfiguration();
        builder.RegisterControllers();
        builder.RegisterCors();
        builder.RegisterDbContext();
        builder.RegisterServicesRepositories();

        return builder.Build();
    }

    private static void RegisterSwaggerConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(o =>
        {
            o.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "API для телефонного справочника",
                    Version = "v1",
                    Description = "API для работы с пользователями и телефонными номерами"
                });

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            o.IncludeXmlComments(xmlPath);
        });
    }

    private static void RegisterControllers(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
    }

    private static void RegisterCors(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options => options.AddPolicy("Cors Policy",
            configurePolicy: policyBuilder =>
            {
                policyBuilder.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:5000");
            }));
    }

    private static void RegisterDbContext(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("Default"))
        );
    }

    private static void RegisterServicesRepositories(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
        builder.Services.AddScoped<IServiceManager, ServiceManager>();
    }
}