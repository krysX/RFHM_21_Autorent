using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutorentServer.Domain;
using AutorentServer.Domain.Models;
using AutorentServer.Domain.Repository;
using AutorentServer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AutorentServer.Controllers;

[Authorize]
[ApiController]
[Route("users/")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IRepositoryWrapper _repository;
    private readonly IAuthService _auth;

    public UserController(ILogger<UserController> logger, IRepositoryWrapper repository, IAuthService auth)
    {
        _logger = logger;
        _repository = repository;
        _auth = auth;
    }
    
    [Authorize(Roles = "Admin")]
    [HttpGet]
    public IActionResult GetAllUsers()
    {
        var result = _repository.User.FindAll();
        return null == result ? NotFound() : Ok(result);
    }
    
    [AllowAnonymous]
    [HttpGet("login")]
    public IActionResult Login(string username, string password)
    {
        User? usr = _repository.User.FindByUsername(username);
        if (null == usr)
            return Unauthorized();

        bool passwordMatch = _auth.CheckForLogin(usr, username, password);

        if (!passwordMatch)
            return Unauthorized();

        string tokenStr = _auth.GenerateJwtToken(usr.Username);
        return Ok(tokenStr);
    }

    [HttpGet("{id}")]
    public ActionResult<User> GetUserDataById(int id)
    {
        var result = _repository.User.FindByCondition(usr => usr.Id == id);
        return null == result ? NotFound() : Ok(result);
    }

    [HttpGet("{userId}/rentals/")]
    public IActionResult GetRentalHistory(int userId)
    {
        var result = _repository.Rental.FindByCondition(rent => rent.UserId == userId);
        return null == result ? NotFound() : Ok(result); 
    }
    
    [HttpGet("{userId}/rentals/{rentalId}")]
    public IActionResult GetRental(int userId, int rentalId)
    {
        var result = _repository.Rental.FindByCondition
            (rent => rent.UserId == userId && rent.Id == rentalId);
        return null == result ? NotFound() : Ok(result); 
    }

    [HttpPost("{userId}/rentals/")]
    public IActionResult RentCar(int userId, int carId, string from, string to)
    {
        string uname = User.Identity.Name.ToString();
        bool auth = User.Identity.IsAuthenticated && _repository.User.FindById(userId).Name == uname;

        if (!auth)
            return Unauthorized();
        
        Rental r = new Rental
        {
            Id = _repository.Rental.FindAll().OrderBy(r => r.Id).LastOrDefault().Id + 1,
            UserId = userId,
            CarId = carId,
            FromDate = DateOnly.Parse(from),
            ToDate = DateOnly.Parse(to),
            Created = DateTime.Now
        };

        _repository.Rental.Create(r);
        _repository.Save();
        return Ok();
    }
}