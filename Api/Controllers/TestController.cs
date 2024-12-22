using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    [HttpGet("test")]
    public string GetHelloWorldText() => 
        "Hello world";

    [HttpGet("hello/{name}")]
    public string GetGreetingByName(string name) =>
        $"Привет {name}";
}