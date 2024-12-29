namespace Api.ModelDto;

/// <summary>
/// Представляет объект передачи данных (DTO) для контакта.
/// </summary>
public class ContactDto
{
    /// <summary>
    /// Получает или задает имя контакта.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Получает или задает адрес электронной почты контакта.
    /// </summary>
    public string Email { get; set; }
}