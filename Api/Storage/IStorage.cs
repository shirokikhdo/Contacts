using Api.ModelDto;
using Api.Models;

namespace Api.Storage;

/// <summary>
/// Интерфейс для хранения контактов.
/// </summary>
public interface IStorage
{
    /// <summary>
    /// Получает список всех контактов.
    /// </summary>
    /// <returns>
    /// Список всех контактов <see cref="List{Contact}"/>.
    /// </returns>
    List<Contact> GetAll();

    /// <summary>
    /// Получает контакт по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор контакта.</param>
    /// <returns>
    /// Контакт <see cref="Contact"/>, если найден; в противном случае - <c>null</c>.
    /// </returns>
    Contact Get(int id);

    /// <summary>
    /// Добавляет новый контакт.
    /// </summary>
    /// <param name="contact">Контакт для добавления <see cref="Contact"/>.</param>
    /// <returns>
    /// Добавленный контакт <see cref="Contact"/>.
    /// </returns>
    Contact Add(Contact contact);

    /// <summary>
    /// Удаляет контакт по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор контакта для удаления.</param>
    /// <returns>
    /// <c>true</c>, если контакт был успешно удален; в противном случае - <c>false</c>.
    /// </returns>
    bool Delete(int id);

    /// <summary>
    /// Обновляет существующий контакт.
    /// </summary>
    /// <param name="id">Идентификатор контакта для обновления.</param>
    /// <param name="dto">Объект с новыми данными контакта <see cref="ContactDto"/>.</param>
    /// <returns>
    /// <c>true</c>, если контакт был успешно обновлен; в противном случае - <c>false</c>.
    /// </returns>
    bool Update(int id, ContactDto dto);
}