using Api.Models;

namespace Api.Storage;

/// <summary>
/// Интерфейс для хранилища, поддерживающего пагинацию.
/// Наследуется от <see cref="IStorage"/>.
/// </summary>
public interface IPaginationStorage : IStorage
{
    /// <summary>
    /// Получает список контактов с поддержкой пагинации.
    /// </summary>
    /// <param name="pageNumber">Номер страницы для получения.</param>
    /// <param name="pageSize">Количество элементов на странице.</param>
    /// <returns>
    /// Кортеж, содержащий:
    /// <list type="bullet">
    /// <item>
    /// <description>Список контактов <see cref="List{Contact}"/>.</description>
    /// </item>
    /// <item>
    /// <description>Общее количество контактов <see cref="int"/>.</description>
    /// </item>
    /// </list>
    /// </returns>
    (List<Contact>, int Total) GetPagination(int pageNumber, int pageSize);
}