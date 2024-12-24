using Api.ModelDto;
using Api.Models;

namespace Api.Storage;

public interface IStorage
{
    List<Contact> GetAll();

    Contact Get(int id);

    bool Add(Contact contact);

    bool Delete(int id);

    bool Update(int id, ContactDto dto);
}