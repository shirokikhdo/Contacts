using Api.Models;
using Api.Storage;
using Bogus;
using Microsoft.EntityFrameworkCore;

namespace Api.Seed;

public class SqliteEfFakerInitializer : IInitializer
{
    private readonly SqliteDbContext _dbContext;

    public SqliteEfFakerInitializer(SqliteDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Initialize()
    {
        _dbContext.Database.Migrate();

        if (_dbContext.Contacts.Any())
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

        _dbContext.AddRange(contacts);
        _dbContext.SaveChanges();
    }
}