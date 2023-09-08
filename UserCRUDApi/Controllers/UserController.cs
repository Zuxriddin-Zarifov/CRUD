using UserCRUDApi.Infractructure;
using UserCRUDApi.Infractructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using UserCRUDApi.Domain;

namespace UserCRUDApi.Controllers;

[Controller,Route("[controller]")]
public class UserController : ControllerBase
{

    public UserController()
    {
    }
    [HttpGet("/")]
    public async Task<IEnumerable<User>> GetAll()
    {
        return null;
    }
}