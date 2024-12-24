using Api.ModelDto;
using Api.Models;

namespace Api.Storage;

public class InMemoryStorage : IStorage
{
    private readonly List<Contact> _contacts;

    public InMemoryStorage()
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

    public Contact Get(int id) =>
        _contacts.FirstOrDefault(x => x.Id == id);

    public bool Add(Contact contact)
    {
        if (_contacts.Any(x => x.Id == contact.Id))
            return false;
        
        _contacts.Add(contact);
        return true;
    }

    public bool Delete(int id)
    {
        var deletedUser = _contacts
            .FirstOrDefault(x => x.Id == id);

        return deletedUser is not null 
               && _contacts.Remove(deletedUser);
    }

    public bool Update(int id, ContactDto contactDto)
    {
        var updatedUser = _contacts
            .FirstOrDefault(x => x.Id == id);

        if (updatedUser is null)
            return false;

        if(!string.IsNullOrEmpty(contactDto.Name))
            updatedUser.Name = contactDto.Name;
        
        if(!string.IsNullOrEmpty(contactDto.Email))
            updatedUser.Email = contactDto.Email;

        return true;
    }
}