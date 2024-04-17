using AutorentServer.Domain;
using AutorentServer.Domain.Models;
using AutorentServer.Domain.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AutorentServer.Controllers;
[ApiController]
[Route("users/")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IRepositoryWrapper _repository;

    public UserController(ILogger<UserController> logger, IRepositoryWrapper repository)
    {
        _logger = logger;
        _repository = repository;
    }
    
    [HttpGet]
    public IActionResult GetAllUsers()
    {
        var result = _repository.User.FindAll();
        return null == result ? NotFound() : Ok(result);
    }
    
    // nagyon kókány authentikáció
    [HttpGet("login")]
    public IActionResult Login(string username, string password)
    {
        var result = _repository.User.FindByCondition(usr => usr.Username == username && usr.Password == password);
        
        return null == result ? Unauthorized() : Ok(result);
    }

    [HttpGet("{id}")]
    public ActionResult<User> GetUserDataById(int id)
    {
        var result = _repository.User.FindByCondition(usr => usr.Id == id);
        return null == result ? NotFound() : Ok(result);
    }
}