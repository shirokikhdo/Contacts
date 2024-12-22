using Api.Models;

namespace Api.Storage;

public class ContactStorage
{
    public List<Contact> Contacts { get; set; }

    public ContactStorage()
    {
        Contacts = new List<Contact>();
        
        for (var i = 1; i <= 10; i++)
        {
            Contacts.Add(new Contact
            {
                Id = i,
                Name = $"Полное имя {i}",
                Email = $"{Guid.NewGuid().ToString().Substring(0, 5)}@mail.ru"
            });
        }
    }
}