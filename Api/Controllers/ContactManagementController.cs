using Api.ModelDto;
using Api.Models;
using Api.Storage;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

/// <summary>
/// Контроллер для управления контактами.
/// Предоставляет методы для создания, получения, обновления и удаления контактов.
/// </summary>
public class ContactManagementController : ContactsController
{
    private readonly IPaginationStorage _storage;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="ContactManagementController"/>.
    /// </summary>
    /// <param name="storage">Хранилище для контактов.</param>
    public ContactManagementController(IPaginationStorage storage)
    {
        _storage = storage;
    }

    /// <summary>
    /// Создает новый контакт.
    /// </summary>
    /// <param name="contact">Контакт для создания.</param>
    /// <returns>Результат операции создания контакта.</returns>
    [HttpPost("contacts")]
    public IActionResult Create([FromBody] Contact contact)
    {
        var result = _storage.Add(contact);

        if (result is null)
            return BadRequest("Контакт с таким ID уже существует");

        return Ok(result);
    }

    /// <summary>
    /// Получает список всех контактов.
    /// </summary>
    /// <returns>Список всех контактов.</returns>
    [HttpGet("contacts")]
    public ActionResult<List<Contact>> GetAll() =>
        Ok(_storage.GetAll());

    /// <summary>
    /// Получает контакт по указанному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор контакта.</param>
    /// <returns>Контакт с указанным идентификатором, если он существует.</returns>
    [HttpGet("contacts/{id}")]
    public ActionResult<Contact> Get(int id)
    {
        if (id <= 0)
            return BadRequest("Ошибка указания ID");

        var user = _storage.Get(id);

        if (user is null)
            return NotFound("Контакт с таким ID не найден");

        return Ok(user);
    }

    /// <summary>
    /// Удаляет контакт по указанному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор контакта для удаления.</param>
    /// <returns>Удаленный контакт, если он существовал; иначе - ошибка 404.</returns>
    [HttpDelete("contacts/{id}")]
    public ActionResult<Contact> Delete(int id)
    {
        if (id <= 0)
            return BadRequest("Ошибка указания ID");

        var user = _storage.Get(id);
        var success = _storage.Delete(id);

        if (success)
            return Ok(user);

        return NotFound("Контакт с таким ID не найден");
    }

    // <summary>
    /// Обновляет контакт по указанному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор контакта для обновления.</param>
    /// <param name="contactDto">Данные для обновления контакта.</param>
    /// <returns>Обновленный контакт, если операция успешна; иначе - ошибка 404.</returns>
    [HttpPut("contacts/{id}")]
    public ActionResult<Contact> Update(
        int id, [FromBody] ContactDto contactDto)
    {
        if (id <= 0)
            return BadRequest("Ошибка указания ID");

        var success = _storage.Update(id, contactDto);

        if (success)
        {
            var user = _storage.Get(id);
            return Ok(user);
        }

        return NotFound("Контакт с таким ID не найден");
    }

    /// <summary>
    /// Получает список контактов с пагинацией.
    /// </summary>
    /// <param name="pageNumber">Номер страницы (по умолчанию 1).</param>
    /// <param name="pageSize">Количество контактов на странице (по умолчанию 5).</param>
    /// <returns>Пагинированный список контактов и общая информация о количестве.</returns>
    [HttpGet("contacts/page")]
    public ActionResult<List<Contact>> GetPagination(
        int pageNumber = 1, int pageSize = 5)
    {
        var (contacts, total) = _storage
            .GetPagination(pageNumber, pageSize);
        var response = new
        {
            Contacts = contacts,
            TotalCount = total,
            CurrentPage = pageNumber,
            PageSize = pageSize
        };
        return Ok(response);
    }
}