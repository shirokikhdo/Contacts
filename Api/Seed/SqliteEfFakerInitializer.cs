using Api.Models;
using Api.Storage;
using Bogus;
using Microsoft.EntityFrameworkCore;

namespace Api.Seed;

/// <summary>
/// Класс для инициализации базы данных с использованием фейковых данных.
/// Реализует интерфейс <see cref="IInitializer"/>.
/// </summary>
public class SqliteEfFakerInitializer : IInitializer
{
    private readonly SqliteDbContext _dbContext;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="SqliteEfFakerInitializer"/>.
    /// </summary>
    /// <param name="dbContext">Контекст базы данных <see cref="SqliteDbContext"/>.</param>
    public SqliteEfFakerInitializer(SqliteDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Инициализирует базу данных, выполняя миграции и заполняя ее фейковыми данными,
    /// если база данных еще не содержит записей.
    /// </summary>
    public void Initialize()
    {
        _dbContext.Database.Migrate();

        if (_dbContext.Contacts.Any())
            return;

        var faker = new Faker("ru");
        var contacts = Enumerable.Range(1, 100).Select(i =>
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

        _dbContext.AddRange(contacts);
        _dbContext.SaveChanges();
    }
}