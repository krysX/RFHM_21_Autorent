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
    private readonly IUserRepository _user;
    private readonly IRentalRepository _rental;
    private readonly ISaleRepository _sale;
    private readonly ICarRepository _car;
    private readonly ICategoryRepository _category;

    public UserController(ILogger<UserController> logger, IUserRepository user, IRentalRepository rental, 
            ISaleRepository sale, ICarRepository car, ICategoryRepository category)
    {
        _logger = logger;
        _user = user;
        _rental = rental;
        _sale = sale;
        _car = car;
        _category = category;
    }
    
    [HttpGet]
    public IActionResult GetAllUsers()
    {
        var result = _user.FindAll();
        return null == result ? NotFound() : Ok(result);
    }
    
    // nagyon kókány authentikáció
    [HttpGet("login")]
    public IActionResult Login(string username, string password)
    {
        var result = _user.FindByCondition(usr => usr.Username == username && usr.Password == password);
        
        return null == result ? Unauthorized() : Ok(result);
    }

    [HttpGet("{id}")]
    public ActionResult<User> GetUserDataById(int id)
    {
        var result = _user.FindByCondition(usr => usr.Id == id);
        return null == result ? NotFound() : Ok(result);
    }
}