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
        _contactStorage.Contacts.Add(contact);

    [HttpGet("contacts")]
    public List<Contact> GetAll() =>
        _contactStorage.Contacts;

    [HttpDelete("contacts/{id}")]
    public void Delete(int id)
    {
        var deletedUser = _contactStorage.Contacts
            .FirstOrDefault(x => x.Id == id);

        if(deletedUser is null)
            return;

        _contactStorage.Contacts.Remove(deletedUser);
    }

    [HttpPut("contacts/{id}")]
    public void Update(
        int id,
        [FromBody] ContactDto contactDto)
    {
        var updatedUser = _contactStorage.Contacts
            .FirstOrDefault(x => x.Id == id);

        if (updatedUser is null)
            return;

        if(!string.IsNullOrEmpty(contactDto.Name))
            updatedUser.Name = contactDto.Name;

        if(!string.IsNullOrWhiteSpace(contactDto.Email))
            updatedUser.Email = contactDto.Email;
    }
}