using Api.Seed;
using Api.Storage;

namespace Api.Extensions;

public static class ApplicationServiceProviderExtension
{
    public static IServiceProvider AddServiceProvider(
        this IServiceProvider provider,
        IConfiguration configuration)
    {
        using var scope = provider.CreateScope();
        var storage = scope.ServiceProvider.GetService<IStorage>();
        
        if (storage is null) 
            return provider;

        var connectionString = configuration
            .GetConnectionString("SqliteConnectionString");

        var initializer = new FakerInitializer(connectionString);
        initializer.Initialize();

        return provider;
    }
}