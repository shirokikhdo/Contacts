using Api.ModelDto;
using Api.Models;
using Api.Storage;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class ContactManagementController : ContactsController
{
    private readonly ContactStorage _contactStorage;

    public ContactManagementController(ContactStorage contactStorage)
    {
        _contactStorage = contactStorage;
    }

    [HttpPost("contacts")]
    public IActionResult Create([FromBody] Contact contact)
    {
        if (contact.Id <= 0)
            return BadRequest("Ошибка указания ID");

        var success = _contactStorage.Add(contact);

        if (success)
            return Created();

        return BadRequest("Контакт с таким ID уже существует");
    }

    [HttpGet("contacts")]
    public ActionResult<List<Contact>> GetAll() =>
        Ok(_contactStorage.GetAll());

    [HttpGet("contacts/{id}")]
    public ActionResult<Contact> Get(int id)
    {
        if (id <= 0)
            return BadRequest("Ошибка указания ID");

        var user = _contactStorage.Get(id);

        if (user is null)
            return NotFound("Контакт с таким ID не найден");

        return Ok(user);
    }

    [HttpDelete("contacts/{id}")]
    public ActionResult<Contact> Delete(int id)
    {
        if (id <= 0)
            return BadRequest("Ошибка указания ID");

        var user = _contactStorage.Get(id);
        var success = _contactStorage.Delete(id);

        if (success)
            return Ok(user);

        return NotFound("Контакт с таким ID не найден");
    }

    [HttpPut("contacts/{id}")]
    public ActionResult<Contact> Update(int id, [FromBody] ContactDto contactDto)
    {
        if (id <= 0)
            return BadRequest("Ошибка указания ID");

        var success = _contactStorage.Update(id, contactDto);

        if (success)
        {
            var user = _contactStorage.Get(id);
            return Ok(user);
        }

        return NotFound("Контакт с таким ID не найден");
    }
}