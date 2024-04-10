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
    public ActionResult<List<User>> GetAllUsers()
    {
        if (null != DbSimulation.loggedIn && DbSimulation.loggedIn.Username == "admin") // kókány authorizáció
            return new ActionResult<List<User>>(DbSimulation.Users);
        return new UnauthorizedResult();
    }
    
    // nagyon kókány authentikáció
    [HttpGet("login")]
    public ActionResult<User> Login(string username, string password)
    {
        var user = DbSimulation.Users.Find(usr => usr.Username == username && usr.Password == password);
        
        DbSimulation.loggedIn = user;
        return null == user ? new UnauthorizedResult() : new ActionResult<User>(user);
    }

    [HttpGet("{id}")]
    public ActionResult<User> GetUserDataById(int id)
    {
        if (null != DbSimulation.loggedIn && DbSimulation.loggedIn.Id == id)
            return new ActionResult<User>(DbSimulation.loggedIn);
        return new UnauthorizedResult();
    }
}