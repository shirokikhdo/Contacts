using Api.ModelDto;
using Api.Models;
using Microsoft.Data.Sqlite;

namespace Api.Storage;

public class SqliteStorage : IStorage
{
    private readonly string _connectionString;

    public SqliteStorage(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<Contact> GetAll()
    {
        var contacts = new List<Contact>();

        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM contacts;";

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
        Contact result = null;

        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM contacts WHERE id=@id;";
        command.Parameters.AddWithValue("@id", id);

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            result = new Contact
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Email = reader.GetString(2)
            };
        }

        return result;
    }

    public bool Add(Contact contact)
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO contacts(name, email) VALUES (@name, @email);";
        command.Parameters.AddWithValue("@name", contact.Name);
        command.Parameters.AddWithValue("@email", contact.Email);

        return command.ExecuteNonQuery() > 0;
    }

    public bool Delete(int id)
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "DELETE FROM contacts WHERE id = @id;";
        command.Parameters.AddWithValue("@id", id);

        return command.ExecuteNonQuery() > 0;
    }

    public bool Update(int id, ContactDto dto)
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @"UPDATE contacts
                                SET name = @name, email = @email
                                WHERE id = @id;";
        command.Parameters.AddWithValue("@id", id);
        command.Parameters.AddWithValue("@name", dto.Name);
        command.Parameters.AddWithValue("@email", dto.Email);

        return command.ExecuteNonQuery() > 0;
    }
}