using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("[controller]")]
public class FallbackController : Controller
{
    [HttpGet("/")]
    public IActionResult Index() =>
        PhysicalFile(Path.Combine(
            Directory.GetCurrentDirectory(),
            "wwwroot",
            "index.html"), 
            "text/HTML");
}