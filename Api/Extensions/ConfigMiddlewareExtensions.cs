using Api.Middleware;

namespace Api.Extensions;

/// <summary>
/// Расширения для <see cref="IApplicationBuilder"/> для добавления конфигурационного промежуточного ПО.
/// </summary>
public static class ConfigMiddlewareExtensions
{
    /// <summary>
    /// Добавляет конфигурационное промежуточное ПО в конвейер обработки запросов.
    /// </summary>
    /// <param name="app">Объект <see cref="IApplicationBuilder"/>, используемый для настройки конвейера обработки запросов.</param>
    /// <returns>
    /// Возвращает тот же объект <see cref="IApplicationBuilder"/>, что позволяет использовать цепочку вызовов методов.
    /// </returns>
    public static IApplicationBuilder UseConfigMiddleware(this IApplicationBuilder app) =>
        app.UseMiddleware<ConfigMiddleware>();
}