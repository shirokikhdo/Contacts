using Api.ModelDto;
using Api.Models;
using Api.Storage;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class ContactManagementController : ContactsController
{
    private readonly IStorage _storage;

    public ContactManagementController(IStorage storage)
    {
        _storage = storage;
    }

    [HttpPost("contacts")]
    public IActionResult Create([FromBody] Contact contact)
    {
        var result = _storage.Add(contact);

        if (result is null)
            return BadRequest("Контакт с таким ID уже существует");

        return Ok(result);
    }

    [HttpGet("contacts")]
    public ActionResult<List<Contact>> GetAll() =>
        Ok(_storage.GetAll());

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

    [HttpPut("contacts/{id}")]
    public ActionResult<Contact> Update(int id, [FromBody] ContactDto contactDto)
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
}