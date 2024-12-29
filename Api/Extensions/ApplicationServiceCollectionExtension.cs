using Api.Seed;
using Api.Storage;
using Microsoft.EntityFrameworkCore;

namespace Api.Extensions;

/// <summary>
/// Расширение для <see cref="IServiceCollection"/> для добавления необходимых сервисов в приложении.
/// </summary>
public static class ApplicationServiceCollectionExtension
{
    /// <summary>
    /// Добавляет сервисы в контейнер зависимостей на основе конфигурации приложения.
    /// </summary>
    /// <param name="services">Коллекция сервисов, в которую будут добавлены новые сервисы.</param>
    /// <param name="configuration">Объект конфигурации, используемый для получения строк подключения и других параметров.</param>
    /// <returns>
    /// Возвращает обновленную коллекцию сервисов <see cref="IServiceCollection"/>.
    /// </returns>
    public static IServiceCollection AddServiceCollection(
        this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("SqliteConnectionString");

        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddDbContext<SqliteDbContext>(options =>
            options.UseSqlite(connectionString));
        services.AddScoped<IPaginationStorage, SqliteEfStorage>();
        services.AddScoped<IInitializer, SqliteEfFakerInitializer>();
        services.AddCors(options =>
            options.AddPolicy("CorsPolicy", policy =>
                policy.AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithOrigins(configuration["ClientHost"])));

        return services;
    }
}