using AutorentServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AutorentServer.Controllers;
[ApiController]
[Route("users/")]
public class UserController
{
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet("")]
    public IEnumerable<User> GetAllUsers()
    {
        return DbSimulation.Users;
    }
    
    [HttpGet("login")]
    public IActionResult Login(string username, string password)
    {
        var user = DbSimulation.Users.Find(usr => usr.Username == username && usr.Password == password);
        return null == user ? new BadRequestResult() : new OkResult();
    }
}