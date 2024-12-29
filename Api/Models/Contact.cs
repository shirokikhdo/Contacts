namespace Api.Models;

/// <summary>
/// Представляет контакт с его основными данными.
/// </summary>
public class Contact
{
    /// <summary>
    /// Получает или задает уникальный идентификатор контакта.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Получает или задает имя контакта.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Получает или задает адрес электронной почты контакта.
    /// </summary>
    public string Email { get; set; }
}