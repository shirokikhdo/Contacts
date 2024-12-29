using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

/// <summary>
/// Контроллер для обработки запросов на корневой маршрут.
/// Возвращает файл index.html из папки wwwroot при обращении к корневому URL.
/// </summary>
[Route("[controller]")]
public class FallbackController : Controller
{
    /// <summary>
    /// Обрабатывает HTTP GET запросы на корневой маршрут.
    /// Возвращает файл index.html как ответ с типом контента "text/html".
    /// </summary>
    /// <returns>Возвращает IActionResult, содержащий файл index.html.</returns>
    [HttpGet("/")]
    public IActionResult Index() =>
        PhysicalFile(Path.Combine(
            Directory.GetCurrentDirectory(),
            "wwwroot",
            "index.html"), 
            "text/HTML");
}