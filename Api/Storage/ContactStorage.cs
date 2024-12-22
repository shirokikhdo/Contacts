using Api.Models;

namespace Api.Storage;

public class ContactStorage
{
    public List<Contact> Contacts { get; set; }

    public ContactStorage()
    {
        Contacts = new List<Contact>();
    }
}