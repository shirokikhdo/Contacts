using Api.Middleware;

namespace Api.Extensions;

public static class ConfigMiddlewareExtensions
{
    public static IApplicationBuilder UseConfigMiddleware(this IApplicationBuilder app) =>
        app.UseMiddleware<ConfigMiddleware>();
}