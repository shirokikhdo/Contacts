using Api.Seed;

namespace Api.Extensions;

/// <summary>
/// Расширение для <see cref="IServiceProvider"/> для добавления инициализации сервисов.
/// </summary>
public static class ApplicationServiceProviderExtension
{
    /// <summary>
    /// Инициализирует необходимые сервисы в рамках созданного скоупа.
    /// </summary>
    /// <param name="provider">Объект <see cref="IServiceProvider"/>, используемый для разрешения зависимостей.</param>
    /// <returns>
    /// Возвращает тот же объект <see cref="IServiceProvider"/> после инициализации сервисов.
    /// </returns>
    public static IServiceProvider AddServiceProvider(
        this IServiceProvider provider)
    {
        using var scope = provider.CreateScope();
        var initializer = scope.ServiceProvider.GetRequiredService<IInitializer>();
        initializer.Initialize();

        return provider;
    }
}