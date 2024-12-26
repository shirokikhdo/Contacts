using Api.Models;

namespace Api.Storage;

public interface IPaginationStorage : IStorage
{
    (List<Contact>, int Total) GetPagination(int pageNumber, int pageSize);
}