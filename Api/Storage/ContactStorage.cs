using Api.ModelDto;
using Api.Models;

namespace Api.Storage;

public class ContactStorage
{
    private readonly List<Contact> _contacts;

    public ContactStorage()
    {
        _contacts = Enumerable.Range(1, 10)
            .Select(x => new Contact 
            {
                Id = x,
                Name = $"Полное имя {x}",
                Email = $"{Guid.NewGuid().ToString().Substring(0, 5)}@mail.ru"
            })
            .ToList();
    }

    public List<Contact> GetAll() => 
        _contacts;

    public void Add(Contact contact) =>
        _contacts.Add(contact);

    public void Delete(int id)
    {
        var deletedUser = _contacts
            .FirstOrDefault(x => x.Id == id);

        if (deletedUser is null)
            return;

        _contacts.Remove(deletedUser);
    }

    public void Update(int id, ContactDto contactDto)
    {
        var updatedUser = _contacts
            .FirstOrDefault(x => x.Id == id);

        if (updatedUser is null)
            return;

        if(!string.IsNullOrEmpty(contactDto.Name))
            updatedUser.Name = contactDto.Name;
        
        if(!string.IsNullOrEmpty(contactDto.Email))
            updatedUser.Email = contactDto.Email;
    }
}