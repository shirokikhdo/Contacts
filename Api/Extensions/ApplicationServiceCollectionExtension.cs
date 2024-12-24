using Api.Storage;

namespace Api.Extensions;

public static class ApplicationServiceCollectionExtension
{
    public static IServiceCollection AddServiceCollection(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddSingleton<IStorage>(
            new SqliteStorage(
                configuration.GetConnectionString("SqliteConnectionString")));
        services.AddCors(options =>
            options.AddPolicy("CorsPolicy", policy =>
                policy.AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithOrigins(configuration["ClientHost"])));

        return services;
    }
}