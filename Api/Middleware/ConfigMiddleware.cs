namespace Api.Middleware;

public class ConfigMiddleware
{
    private readonly RequestDelegate _next;

    public ConfigMiddleware(RequestDelegate next)
    {
        _next = next;
    }

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