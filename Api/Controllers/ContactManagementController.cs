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
    public void Create([FromBody] Contact contact) =>
        _contactStorage.Add(contact);

    [HttpGet("contacts")]
    public List<Contact> GetAll() =>
        _contactStorage.GetAll();

    [HttpDelete("contacts/{id}")]
    public void Delete(int id) =>
        _contactStorage.Delete(id);

    [HttpPut("contacts/{id}")]
    public void Update(int id, [FromBody] ContactDto contactDto) =>
        _contactStorage.Update(id, contactDto);
}