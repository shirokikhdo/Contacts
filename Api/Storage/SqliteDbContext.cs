using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Storage;

/// <summary>
/// Контекст базы данных для работы с SQLite.
/// </summary>
public class SqliteDbContext : DbContext
{
    /// <summary>
    /// Получает или устанавливает набор контактов.
    /// </summary>
    public DbSet<Contact> Contacts { get; set; }

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="SqliteDbContext"/> с заданными параметрами.
    /// </summary>
    /// <param name="options">Параметры контекста базы данных <see cref="DbContextOptions{SqliteDbContext}"/>.</param>
    public SqliteDbContext(DbContextOptions<SqliteDbContext> options) 
        : base(options)
    {
        
    }
}