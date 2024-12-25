using Api.Storage;
using Microsoft.EntityFrameworkCore;

namespace Api.Extensions;

public static class ApplicationServiceCollectionExtension
{
    public static IServiceCollection AddServiceCollection(
        this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("SqliteConnectionString");

        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddDbContext<SqliteDbContext>(options =>
            options.UseSqlite(connectionString));
        services.AddScoped<IStorage, SqliteEfStorage>();
        services.AddCors(options =>
            options.AddPolicy("CorsPolicy", policy =>
                policy.AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithOrigins(configuration["ClientHost"])));

        return services;
    }
}