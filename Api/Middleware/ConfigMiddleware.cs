namespace Api.Middleware;

/// <summary>
/// Промежуточное ПО для обработки запросов к файлу конфигурации <c>config.js</c>.
/// </summary>
public class ConfigMiddleware
{
    private readonly RequestDelegate _next;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="ConfigMiddleware"/>.
    /// </summary>
    /// <param name="next">Делегат, представляющий следующий компонент в конвейере обработки запросов.</param>
    public ConfigMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    /// <summary>
    /// Асинхронно обрабатывает входящие HTTP-запросы.
    /// </summary>
    /// <param name="context">Контекст текущего HTTP-запроса.</param>
    /// <returns>Задача, представляющая асинхронную операцию.</returns>
    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path == "/config.js")
        {
            var scheme = context.Request.Scheme;
            var host = context.Request.Host.Value;
            var pathBase = context.Request.PathBase.Value;

            var apiUrl = $"{scheme}://{host}{pathBase}/api/ContactManagement";

            var config = $@"window.config = {{
                apiUrl: '{apiUrl}'
            }};";

            context.Response.ContentType = "application/javascript";
            await context.Response.WriteAsync(config);
        }
        else
        {
            await _next(context);
        }
    }
}