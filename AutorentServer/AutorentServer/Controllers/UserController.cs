using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutorentServer.Domain;
using AutorentServer.Domain.Models;
using AutorentServer.Domain.Repository;
using AutorentServer.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AutorentServer.Controllers;
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
        User? usr = _repository.User.FindByUsername(username);
        if (null == usr)
            return Unauthorized();

        bool passwordMatch = _auth.CheckForLogin(usr, username, password);
        
        // I am not sure about this part
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes("yourSecretKey");
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, "username"),
                // Add more claims as needed
            }),
            Expires = DateTime.UtcNow.AddHours(1), // Token expiration time
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenString = tokenHandler.WriteToken(token);
        // end of unsure part
        
        return !passwordMatch ? Unauthorized() : Ok("Login successful");
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