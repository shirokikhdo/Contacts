using Api.Seed;

namespace Api.Extensions;

public static class ApplicationServiceProviderExtension
{
    public static IServiceProvider AddServiceProvider(
        this IServiceProvider provider)
    {
        using var scope = provider.CreateScope();
        var initializer = scope.ServiceProvider.GetRequiredService<IInitializer>();
        initializer.Initialize();

        return provider;
    }
}