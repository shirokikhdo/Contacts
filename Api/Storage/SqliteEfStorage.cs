using Api.ModelDto;
using Api.Models;

namespace Api.Storage;

public class SqliteEfStorage : IStorage
{
    private readonly SqliteDbContext _dbContext;

    public SqliteEfStorage(SqliteDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Contact> GetAll() =>
        _dbContext.Contacts.ToList();

    public Contact Get(int id) =>
        _dbContext.Contacts
            .FirstOrDefault(x => x.Id == id);

    public Contact Add(Contact contact)
    {
        if (_dbContext.Contacts
            .Any(x => x.Id == contact.Id))
            return null;

        _dbContext.Contacts.Add(contact);
        _dbContext.SaveChanges();

        return contact;
    }

    public bool Delete(int id)
    {
        var deletedUser = _dbContext.Contacts
            .FirstOrDefault(x => x.Id == id);

        if(deletedUser is null)
            return false;

        _dbContext.Contacts.Remove(deletedUser);
        _dbContext.SaveChanges();
        return true;
    }

    public bool Update(int id, ContactDto contactDto)
    {
        var updatedUser = _dbContext.Contacts
            .FirstOrDefault(x => x.Id == id);

        if (updatedUser is null)
            return false;

        if (!string.IsNullOrEmpty(contactDto.Name))
            updatedUser.Name = contactDto.Name;

        if (!string.IsNullOrEmpty(contactDto.Email))
            updatedUser.Email = contactDto.Email;

        _dbContext.SaveChanges();
        return true;
    }
}