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
        var success = _contactStorage.Add(contact);

        if (success)
            return Created();

        return BadRequest("Контакт с таким ID уже существует");
    }

    [HttpGet("contacts")]
    public ActionResult<List<Contact>> GetAll() =>
        Ok(_contactStorage.GetAll());

    [HttpDelete("contacts/{id}")]
    public IActionResult Delete(int id)
    {
        var success = _contactStorage.Delete(id);

        if (success)
            return Ok();

        return BadRequest("Контакт с таким ID не найден");
    }

    [HttpPut("contacts/{id}")]
    public IActionResult Update(int id, [FromBody] ContactDto contactDto)
    {
        var success = _contactStorage.Update(id, contactDto);

        if (success)
            return Ok();

        return BadRequest("Контакт с таким ID не найден");
    }
}