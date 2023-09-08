using UserCRUDApi.Infractructure;
using UserCRUDApi.Infractructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserCRUDApi.Domain;
using UserCRUDApi.Domain.Dtos;
using UserCRUDApi.Infractructure.Interfaces;

namespace UserCRUDApi.Controllers;

[Controller, Route("users")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    public async ValueTask<IEnumerable<User>> GetAll() =>
        await _userRepository.GetSet().ToListAsync();

    [HttpGet("{id:long}")]
    public async ValueTask<User> GetById(long id)
    {
        User user = await _userRepository.GetByIdAsync(id);
        if (user is null)
            throw new Exception("User not found");

        return user;
    }

    [HttpGet("search/name")]
    public async ValueTask<User> GetByName([FromQuery(Name = "q")] string name)
    {
        User user = _userRepository.GetSet().FirstOrDefault(x => x.Name == name);
        if (user is null)
            throw new Exception("User not found");

        return user;
    }

    [HttpGet("search/phone_number")]
    public async ValueTask<User> GetByPhoneNumber([FromQuery(Name = "q")] string phoneNumber)
    {
        User user = _userRepository.GetSet().FirstOrDefault(x => x.PhoneNumber == phoneNumber);
        if (user is null)
            throw new Exception("User not found");

        return user;
    }

    [HttpGet("search/email")]
    public async ValueTask<User> GetByEmail([FromQuery(Name = "q")] string email)
    {
        User user = _userRepository.GetSet().FirstOrDefault(x => x.Email == email);
        if (user is null)
            throw new Exception("User not found");

        return user;
    }

    [HttpPost("add")]
    public async ValueTask<User> Create([FromBody]UserCreateDto userCreateDto)
    {
        User user = new User()
        {
            Name = userCreateDto.Name,
            Surname = userCreateDto.Surname,
            PhoneNumber = userCreateDto.PhoneNumber,
            Email = userCreateDto.Email,
            Password = userCreateDto.Password
        };
        return await _userRepository.CreateAsync(user);
    }

    [HttpPut("update")]
    public async ValueTask<User> Update([FromRoute] UserUpdateDto userUpdateDto)
    {
        User user = new User()
        {
            Name = userUpdateDto.Name,
            Surname = userUpdateDto.Surname,
            PhoneNumber = userUpdateDto.PhoneNumber,
            Email = userUpdateDto.Email,
            Password = userUpdateDto.Password
        };
        return await _userRepository.UpdateAsync(user);
    }
    [HttpDelete("{id:int}")]
    public async ValueTask<User> Delete([FromRoute] long id)
    {
        User user = await _userRepository.GetByIdAsync(id);
        if (user is null)
            throw new Exception("User not fount");
        return await _userRepository.DeleteAsync(user);
    }

    [HttpGet("pagination")]
    public async ValueTask<IEnumerable<User>> GetPaginations(UserGetPagination pagination)
    {
        IEnumerable<User> users = _userRepository.GetSet().Skip(pagination.Skip).Take(pagination.Take);
        if (users is null)
            throw new Exception("users not fount");
        return users;
    }
}