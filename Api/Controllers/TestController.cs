using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;


public class TestController : ContactsController
{
    [HttpGet("test")]
    public string GetHelloWorldText() => 
        "Hello world";

    [HttpGet("hello/{name}")]
    public string GetGreetingByName(string name) =>
        $"Привет {name}";
}