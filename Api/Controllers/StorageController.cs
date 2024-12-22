using Api.Storage;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class StorageController : ContactsController
{
    private readonly DataContext _dataContext;

    public StorageController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [HttpGet("SetString/{value}")]
    public void SetString(string value) =>
        _dataContext.Str = value;

    [HttpGet("GetString")]
    public string GetString() =>
        _dataContext.Str;
}