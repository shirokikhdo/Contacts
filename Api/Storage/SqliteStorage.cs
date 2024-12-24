using Api.ModelDto;
using Api.Models;
using Microsoft.Data.Sqlite;

namespace Api.Storage;

public class SqliteStorage : IStorage
{
    public List<Contact> GetAll()
    {
        var contacts = new List<Contact>();

        var connectionString = "Data Source=contacts.db";
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM contacts";

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            contacts.Add(new Contact
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Email = reader.GetString(2)
            });
        }

        return contacts;
    }

    public Contact Get(int id)
    {
        throw new NotImplementedException();
    }

    public bool Add(Contact contact)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int id)
    {
        var connectionString = "Data Source=contacts.db";
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "DELETE FROM contacts WHERE id = @id";
        command.Parameters.AddWithValue("@id", id);

        var result = command.ExecuteNonQuery() > 0;
        return result;
    }

    public bool Update(int id, ContactDto dto)
    {
        throw new NotImplementedException();
    }
}