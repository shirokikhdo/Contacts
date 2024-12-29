namespace Api.Seed;

/// <summary>
/// Интерфейс для инициализации базы данных.
/// </summary>
public interface IInitializer
{
    /// <summary>
    /// Метод для инициализации базы данных.
    /// </summary>
    void Initialize();
}