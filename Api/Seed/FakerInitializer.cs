﻿using Api.Models;
using Bogus;
using Microsoft.Data.Sqlite;

namespace Api.Seed;

/// <summary>
/// Инициализатор для создания и заполнения таблицы контактов в базе данных.
/// </summary>
public class FakerInitializer : IInitializer
{
    private readonly string _connectionString;

    /// <summary>
    /// Создает новый экземпляр <see cref="FakerInitializer"/> с указанной строкой подключения.
    /// </summary>
    /// <param name="connectionString">Строка подключения к базе данных.</param>
    public FakerInitializer(string connectionString)
    {
        _connectionString = connectionString;
    }

    /// <summary>
    /// Инициализирует базу данных, создавая таблицу контактов и заполняя ее тестовыми данными,
    /// если таблица пуста.
    /// </summary>
    public void Initialize()
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();
        var command = connection.CreateCommand();

        command.CommandText = @"
            CREATE TABLE IF NOT EXISTS contacts (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                name TEXT NOT NULL,
                email TEXT NOT NULL);";
        command.ExecuteNonQuery();

        command.CommandText = @"SELECT count(*) FROM contacts;";
        var count = (long) command.ExecuteScalar();

        if (count != 0) 
            return;

        var faker = new Faker("ru");
        var contacts = Enumerable.Range(1, 20).Select(i =>
        {
            var firsName = faker.Name.FirstName();
            var lastName = faker.Name.LastName();
            var name = $"{firsName} {lastName}";
            var email = faker.Internet.Email(firsName, lastName);
            return new Contact
            {
                Name = name,
                Email = email,
            };
        });

        foreach (var contact in contacts)
        {
            command.CommandText = @"INSERT INTO contacts(name, email) VALUES(@name, @email);";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@name", contact.Name);
            command.Parameters.AddWithValue("@email", contact.Email);
            command.ExecuteNonQuery();
        }
    }
}